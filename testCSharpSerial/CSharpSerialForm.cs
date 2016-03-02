using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


namespace testCSharpSerial
{
    
    public partial class CSharpSerialForm : Form
    {
        private bool isReceiving;
        private bool isTryToClose;
        public bool isSerialPortConfigFinished;
        private AnalysisPacketBytesData packetAnalysisData = new AnalysisPacketBytesData();
        private CombinePacketBytesData packetCombineBytesData = new CombinePacketBytesData();
        private delegate void TestBoxAppendDelegate(string str);//串口接收线程调用的UI委托
        private delegate void RespondToPacketDelegate(byte[] packetAddressData, byte packetSignByte, byte packetResponseCommandByte, byte[] userSendData);//串口接收线程调用的UI委托
        public GlobalVariableClass.configFinishedJump configFinishedJump;

        public CSharpSerialForm(GlobalVariableClass.configFinishedJump jumpInvoke)//构造函数
        {
            InitializeComponent();
            configFinishedJump = jumpInvoke;
            GlobalVariableClass.AddDutyRecordDataGridViewEvent += addOneRecordToDataGridView;

            ComboBox_SerialPortNumInitialise();
            ComboBox_BaudRateInitialise();
            ComboBox_SerialPortParityInitialise();
            ComboBox_SerialPortDataBitInitialise();
            ComboBox_SerialPortStopBitInitialise();
            isReceiving = false;
            isTryToClose = false;
            button_TestCommunication.Enabled = false;
            button_AddOneNewUser.Enabled = false;
            button_CorrectTime.Enabled = false;
            button_ClearAllUser.Enabled = false;
            button_CallResend.Enabled = false;
            button_AddAppointUserID.Enabled = false;
            button_DelAppointUserID.Enabled = false;
            button_SaveSerialPortConnection.Enabled = false;
            button_ReadMCULocalAddress.Enabled = false;
            isSerialPortConfigFinished = false;
            //Application.Idle += (object sender, EventArgs e) => { TestBoxAppend("dfa"); }; Lambda Test
        }

        private void TestBoxAppend(string str)
        {
            this.textBox_SerialReceive.AppendText(str + "\r\n");//输出到主窗口文本控件
        }
        private void ComboBox_SerialPortNumUpdataPortNum()//更新串口项
        {
            string serialPortComNum;
            serialPortComNum = comboBox_SerialPortNum.Text;            
            comboBox_SerialPortNum.Items.Clear();
            foreach (string vPortName in SerialPort.GetPortNames())//获取串口的值
            {
                comboBox_SerialPortNum.Items.Add(vPortName);
            }
            if (comboBox_SerialPortNum.Items.Count == 0)
            {
                comboBox_SerialPortNum.Items.Add("未找到串口!");
            }
            comboBox_SerialPortNum.Text = serialPortComNum;
        }
        private void ComboBox_SerialPortNumInitialise()//下拉框初始化，加入串口号
        {       
            comboBox_SerialPortNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;//设置控件为不可编辑状态
            ComboBox_SerialPortNumUpdataPortNum();
            comboBox_SerialPortNum.Text = comboBox_SerialPortNum.Items[0].ToString();
        }
        private void comboBox_SerialPortNum_Click(object sender, EventArgs e)
        {
            ComboBox_SerialPortNumUpdataPortNum();
        }//点击下拉框更新
        private void ComboBox_BaudRateInitialise()//下拉框初始化，波特率
        {
            comboBox_BandRate.Text = comboBox_BandRate.Items[comboBox_BandRate.Items.Count-1].ToString();
            comboBox_BandRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;//设置控件为不可编辑状态
         }
        private void ComboBox_SerialPortParityInitialise()//下拉框初始化，校验位
        {
            comboBox_SerialPortParity.Text = comboBox_SerialPortParity.Items[0].ToString();
            comboBox_SerialPortParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;//设置控件为不可编辑状态
        }
        private void ComboBox_SerialPortDataBitInitialise()//下拉框初始化，数据位
        {
            comboBox_SerialPortDataBit.Text = comboBox_SerialPortDataBit.Items[0].ToString();
            comboBox_SerialPortDataBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;//设置控件为不可编辑状态
        }
        private void ComboBox_SerialPortStopBitInitialise()//下拉框初始化，停止位
        {
            comboBox_SerialPortStopBit.Text = comboBox_SerialPortStopBit.Items[0].ToString();
            comboBox_SerialPortStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;//设置控件为不可编辑状态
        }
        private bool serialPortOpen()//设置串口属性并打开
        {
            serialPortControl.PortName = comboBox_SerialPortNum.Text;
            serialPortControl.BaudRate = int.Parse(comboBox_BandRate.Text);
            switch(comboBox_SerialPortParity.Text)
            {
                case "无校验":
                    serialPortControl.Parity = Parity.None;
                    break;
                case "奇校验":
                    serialPortControl.Parity = Parity.Odd;
                    break;
                case "偶校验":
                    serialPortControl.Parity = Parity.Even;
                    break;
                case "1 校验":
                    serialPortControl.Parity = Parity.Mark;
                    break;
                case "0 校验":
                    serialPortControl.Parity = Parity.Space;
                    break;
                default:
                    serialPortControl.Parity = Parity.None;
                    break;
            }
            serialPortControl.DataBits = int.Parse(comboBox_SerialPortDataBit.Text); 
            switch(comboBox_SerialPortStopBit.Text)
            {
                case "1位":
                    serialPortControl.StopBits = StopBits.One;
                    break;
                case "1.5位":
                    serialPortControl.StopBits = StopBits.OnePointFive;
                    break;
                case "2位":
                    serialPortControl.StopBits = StopBits.Two;
                    break;
                default:
                    serialPortControl.StopBits = StopBits.One;
                    break;
            }
            serialPortControl.Handshake = Handshake.None;
            serialPortControl.Open();
            serialPortControl.DiscardInBuffer();
            serialPortControl.DiscardOutBuffer();
            return serialPortControl.IsOpen;
        }
        private bool serialPortClose()//关闭串口
        {
            isTryToClose = true;
            while (isReceiving)
            {
                System.Windows.Forms.Application.DoEvents();
            }
            serialPortControl.DiscardOutBuffer();
            serialPortControl.DiscardInBuffer();            
            serialPortControl.Close();
            isTryToClose = false;
            return serialPortControl.IsOpen;
        } 

        private void CSharpSerialForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPortControl.IsOpen)
                serialPortClose();
        }
        private void reverseControlEnableState()
        {
            comboBox_SerialPortNum.Enabled = !comboBox_SerialPortNum.Enabled;
            comboBox_BandRate.Enabled = !comboBox_BandRate.Enabled;
            comboBox_SerialPortParity.Enabled = !comboBox_SerialPortParity.Enabled;
            comboBox_SerialPortDataBit.Enabled = !comboBox_SerialPortDataBit.Enabled;
            comboBox_SerialPortStopBit.Enabled = !comboBox_SerialPortStopBit.Enabled;
            button_TestCommunication.Enabled = !button_TestCommunication.Enabled;
            button_AddOneNewUser.Enabled = !button_AddOneNewUser.Enabled;
            button_CorrectTime.Enabled = !button_CorrectTime.Enabled;
            button_ClearAllUser.Enabled = !button_ClearAllUser.Enabled;
            button_CallResend.Enabled = !button_CallResend.Enabled;
            button_AddAppointUserID.Enabled = !button_AddAppointUserID.Enabled;
            button_DelAppointUserID.Enabled = !button_DelAppointUserID.Enabled;
            isSerialPortConfigFinished = !isSerialPortConfigFinished;
            button_SaveSerialPortConnection.Enabled = !button_SaveSerialPortConnection.Enabled;
            button_ReadMCULocalAddress.Enabled = !button_ReadMCULocalAddress.Enabled;

        }
        private void button_OpenOrCloseSerialPort_Click(object sender, EventArgs e)
        {
            if (!serialPortControl.IsOpen)
            {
                try
                {
                    serialPortOpen();
                    button_OpenOrCloseSerialPort.Text = "关闭串口";
                    reverseControlEnableState();
                    this.AcceptButton = button_SaveSerialPortConnection;
                    button_SaveSerialPortConnection.Focus();
                }
                catch(System.UnauthorizedAccessException ex)
                {
                    MessageBox.Show("串口被占用，请检查");
                    return;
                }
                catch(Exception ex)
                {
                    ComboBox_SerialPortNumUpdataPortNum();
                    MessageBox.Show("打开失败，请检查");
                    return;                
                }
            }
            else
            {
                serialPortClose();
                packetAnalysisData.receiveBytesDataFIFO.Clear();
                button_OpenOrCloseSerialPort.Text = "打开串口";
                reverseControlEnableState();
                this.AcceptButton = button_OpenOrCloseSerialPort;
            }            
        }
        private void button_ClearText_Click(object sender, EventArgs e)
        {
            textBox_SerialReceive.Clear();
        }
        public void addOneRecordToDataGridView(string timeString, string userIDNum, string userAddressString)
        {
            DataGridViewRow oneUserAndTimeRecord = new DataGridViewRow();
            oneUserAndTimeRecord.CreateCells(dataGridView_UserAndTimeList); 
            oneUserAndTimeRecord.Cells[0].Value = timeString;
            oneUserAndTimeRecord.Cells[1].Value = userIDNum;
            dataGridView_UserAndTimeList.Rows.Add(oneUserAndTimeRecord);
        }
        private void serialPortControl_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            isReceiving = true;
            if(isTryToClose)
            {
                serialPortControl.DiscardInBuffer();
                isReceiving = false;
                return;
            }
            string szRecvBuf = "";
            if (serialPortControl.IsOpen)
            {
                if (serialPortControl.BytesToRead > 0)
                {
                    byte[] aryBytes = new byte[serialPortControl.BytesToRead];
                    serialPortControl.Read(aryBytes, 0, aryBytes.Length);//数据保存到数组
                    foreach (byte objByte in aryBytes)
                    {
                        packetAnalysisData.receiveBytesDataFIFO.Enqueue(objByte);
                    }
                    while (packetAnalysisData.dataLoadFromQueue() && packetAnalysisData.checkPacketCheckSumData())
                    {
                        szRecvBuf = String.Format(
                            "接受数据包:\t{0}\r\n包头:\t\t{1}\r\n地址:\t\t{2}\r\n包标识:\t\t{3}\r\n包标识定义:\t{4}\r\n后续长度字节:\t{5}\r\n响应指令:\t{6}\r\n响应指令定义:\t{7}\r\n用户数据:\t{8}\r\n校验和:\t\t{9}\r\n",
                            packetAnalysisData.getPacketAllDataHex(),
                            packetAnalysisData.getPacketStratDataHex(),
                            packetAnalysisData.getPacketAddressDataHex(),
                            packetAnalysisData.getPacketSignDataHex(),
                            packetAnalysisData.getPacketPacketSignDataMeaing(),
                            packetAnalysisData.getPacketFollowLengthDataHex(),
                            packetAnalysisData.getPacketResponseCommandDataHex(),
                            packetAnalysisData.getPacketResponseCommandDataMeaing(),
                            packetAnalysisData.getPacketUserSendDataHex(),
                            packetAnalysisData.getPacketCheckSumDataHex()
                        );
                        this.Invoke(new TestBoxAppendDelegate(TestBoxAppend), szRecvBuf);//invoke调用委托 回传到另一个线程
                        this.Invoke(new RespondToPacketDelegate(RespondToPacket), packetAnalysisData.AnalysisAddressData, packetAnalysisData.AnalysisPacketSignByte, packetAnalysisData.AnalysisResponseCommandByte, packetAnalysisData.AnalysisUserSendData);//invoke调用委托 回传到另一个线程
                    }
                }
            }
            isReceiving = false;
        }
        private void sendSerialOnePacket(byte[] packetSendBytesData)
        {
            serialPortControl.Write(packetSendBytesData, 0, packetSendBytesData.Length);
        }
        private void sendSerialOnePacket(byte packetSignByte,  byte responseCommandByte, byte[] userSendData)
        {
            sendSerialOnePacket(packetCombineBytesData.getOnePacketSendData(packetSignByte, responseCommandByte, userSendData));
        }
        private void button_TestCommunication_Click(object sender, EventArgs e)
        {
            sendSerialOnePacket(0x00, 0x00, new byte[0]);
        }
        private void button_AddOneNewUser_Click(object sender, EventArgs e)
        {
            sendSerialOnePacket(0x02, 0x00, new byte[0]);
        }
        private void button_CorrectTime_Click(object sender, EventArgs e)
        {
            string timeStamp;
            timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            byte[] timeStampBytesData = System.Text.Encoding.ASCII.GetBytes(timeStamp);
            sendSerialOnePacket(0x08, 0x00, timeStampBytesData);
        }
        private void button_ClearAllUser_Click(object sender, EventArgs e)
        {          
            sendSerialOnePacket(0x10, 0x01, new byte[0]);
        }
        private void button_CallResend_Click(object sender, EventArgs e)
        {
            sendSerialOnePacket(0x13, 0x10, new byte[0]);
        }
        private void button_SaveSerialPortConnection_Click(object sender, EventArgs e)
        {
            configFinishedJump();
        }

        private void button_AddAppointUserID_Click(object sender, EventArgs e)
        {
            byte[] NewUserIDByteData = getInputNumBytes();
            if(NewUserIDByteData != null)
                sendSerialOnePacket(0x06, 0x05, NewUserIDByteData);
        }
        private void button_DelAppointUserID_Click(object sender, EventArgs e)
        {
            byte[] NewUserIDByteData = getInputNumBytes();
            if (NewUserIDByteData != null)
                sendSerialOnePacket(0x09, 0x05, NewUserIDByteData);
        }
        private void button_ReadMCULocalAddress_Click(object sender, EventArgs e)
        {
            byte[] lastPacketAddressData = new byte[4];
            Array.Copy(packetCombineBytesData.SendPacketAddressData, 0, lastPacketAddressData, 0, 4);
            packetCombineBytesData.SendPacketAddressData = GlobalVariableClass.fingerprintPocketData.PACKET_ADDRESS_READ_REQUEST_DATA; 
            sendSerialOnePacket(0x00, 0x00, new byte[0]);
            packetCombineBytesData.SendPacketAddressData = lastPacketAddressData;
        }

        private byte[] getInputNumBytes()
        {
            int AppointAddUserIDNum;
            byte[] NewUserIDByteData;
            string inputMessage = CSharpInputBox.InputBox.ShowInputBox("请输入您指定的用户ID", "提示：输完ID数字后请按回车确认。");
            try
            {
                AppointAddUserIDNum = int.Parse(inputMessage);
            }
            catch
            {
                MessageBox.Show("您输入的数字不正确！");
                return null;
            }
            NewUserIDByteData = new byte[3];
            NewUserIDByteData[0] = GlobalVariableClass.fingerprintPocketData.USER_ID_PREFIX_BYTE;
            NewUserIDByteData[1] = BitConverter.GetBytes(AppointAddUserIDNum)[1];
            NewUserIDByteData[2] = BitConverter.GetBytes(AppointAddUserIDNum)[0];
            return NewUserIDByteData;
        }
        private void recordNowUserIDandTime(byte[] packetAddressData, byte[] userSendData)
        {
            string timeFormatString;
            string userIDString;
            string userAddressString;
            packetAnalysisData.DataToTimeFormatAndUserID(userSendData, packetAddressData, out timeFormatString, out userIDString, out userAddressString);
            label_ClientAddress.Text = "当前终端地址: " + userAddressString;
            GlobalVariableClass.addDutyRecord(timeFormatString, userIDString, userAddressString);//广播事件  添加纪录到DataGridView
        }

        private void RespondToPacket(byte[] packetAddressData, byte packetSignByte, byte packetResponseCommandByte, byte[] userSendData)
        {
            switch (packetSignByte)
            {
                case 0x00:
                    packetCombineBytesData.SendPacketAddressData = packetAddressData;
                    break;
                case 0x01:
                    recordNowUserIDandTime(packetAddressData, userSendData);
                    break;
            }
        }

        private void dataGridView_UserAndTimeList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dataGridView_UserAndTimeList.RowCount > 1)
            {
                e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
                dataGridView_UserAndTimeList.Rows[dataGridView_UserAndTimeList.Rows.Count - 1].HeaderCell.Value = "";
            }
        }
    }
}
