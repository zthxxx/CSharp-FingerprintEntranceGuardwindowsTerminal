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
        private AnalysisBytesData packetAnalysisData = new AnalysisBytesData();
        private SendSerialPacketBytesData packetSendBytesData = new SendSerialPacketBytesData();
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
                    while (packetAnalysisData.dataLoadFromQueue())
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
            sendSerialOnePacket(packetSendBytesData.getOnePacketSendData(packetSignByte, responseCommandByte, userSendData));
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
            GlobalVariableClass.addDutyRecord(timeFormatString, userIDString, userAddressString);//广播事件  添加纪录到DataGridView
        }

        private void RespondToPacket(byte[] packetAddressData, byte packetSignByte, byte packetResponseCommandByte, byte[] userSendData)
        {
            switch (packetSignByte)
            {
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
    public class SendSerialPacketBytesData
    {
        public int minPacketBytesCount;
        public byte[] SendPacketStratData;//包头
        public byte[] SendPacketAddressData;//地址
        public byte SendPacketSignByte;//包标识
        public byte[] SendPacketFollowLengthData;//后续字节长度
        public int SendPacketFollowLength;//后续字节长度
        public byte SendResponseCommandByte;//响应指令
        public byte[] SendUserSendData;//实际传输数据位
        public byte[] SendCheckSumData;//校验和
        public SendSerialPacketBytesData()
        {
            memberInitialise();
        }
        public void memberInitialise()//初始化成员
        {
            minPacketBytesCount = 12;
            SendPacketStratData = GlobalVariableClass.fingerprintPocketData.PACKET_STRAT_DATA;
            SendPacketAddressData = GlobalVariableClass.fingerprintPocketData.PACKET_ADDRESS_DATA;
            SendPacketSignByte = 0x00;
            SendPacketFollowLengthData = new byte[2];
            SendPacketFollowLength = 0;
            SendResponseCommandByte = 0x00;
            SendCheckSumData = new byte[2];
        }
    
        public byte[] getOnePacketSendData(byte packetSignByte,  byte responseCommandByte, byte[] userSendData)
        {
            int circleSumCount = 0;
            int packetAllDataSumLength = minPacketBytesCount;
            int checkSum = 0;
            int userSendDataLength = userSendData.Length;
            byte[] packetSendData;
            SendPacketSignByte = packetSignByte;
            SendResponseCommandByte = responseCommandByte;

            byte ad = 0;
            SendPacketFollowLength = userSendDataLength + 3 ;
            SendPacketFollowLengthData[0] = BitConverter.GetBytes(SendPacketFollowLength)[1];
            SendPacketFollowLengthData[1] = BitConverter.GetBytes(SendPacketFollowLength)[0];

            packetAllDataSumLength += userSendDataLength;
            packetSendData = new byte[packetAllDataSumLength];

            Array.Copy(SendPacketStratData, 0, packetSendData, 0, 2);
            Array.Copy(SendPacketAddressData, 0, packetSendData, 2, 4);
            packetSendData[6] = SendPacketSignByte;
            Array.Copy(SendPacketFollowLengthData, 0, packetSendData, 7, 2);
            packetSendData[9] = SendResponseCommandByte;
            Array.Copy(userSendData, 0, packetSendData, 10, userSendDataLength);

            for (circleSumCount = 6; circleSumCount < packetAllDataSumLength - 2; circleSumCount++)
            {
                checkSum += packetSendData[circleSumCount];
            }
            SendCheckSumData[0] = BitConverter.GetBytes(checkSum)[1];
            SendCheckSumData[1] = BitConverter.GetBytes(checkSum)[0];

            Array.Copy(SendCheckSumData, 0, packetSendData, 10 + userSendDataLength, 2);
            return packetSendData;
        }
    }
    public class AnalysisBytesData
    {
        public int minPacketBytesCount;
        public byte[] AnalysisPacketStratData;//包头
        public byte[] AnalysisAddressData;//地址
        public byte AnalysisPacketSignByte;//包标识
        public byte[] AnalysisPacketFollowLengthData;//后续字节长度
        public int AnalysisPacketFollowLength;//后续字节长度
        public int AnalysisPacketUserDataLength;//用户数据字节长度
        public byte AnalysisResponseCommandByte;//响应指令
        public byte[] AnalysisUserSendData;//实际传输数据
        public byte[] AnalysisCheckSumData;//校验和
        public bool isThePacketEnd = true;
        public Queue<byte> receiveBytesDataFIFO;
        private byte[] standardPocketStartData;
        private byte[] standardPocketAddresData;
        private byte standarUserIDHead;
        public AnalysisBytesData()
        {
            memberInitialise();
        }
        public void memberInitialise()//初始化成员
        {
            minPacketBytesCount = 12;
            AnalysisPacketStratData = new byte[2];
            AnalysisAddressData = new byte[4];
            AnalysisPacketSignByte = 0x00;
            AnalysisPacketFollowLengthData = new byte[2];
            AnalysisPacketFollowLength = 0;
            AnalysisResponseCommandByte = 0x00;
            AnalysisCheckSumData = new byte[2];
            receiveBytesDataFIFO = new Queue<byte>();
            standardPocketStartData = GlobalVariableClass.fingerprintPocketData.PACKET_STRAT_DATA;
            standardPocketAddresData = GlobalVariableClass.fingerprintPocketData.PACKET_ADDRESS_DATA;
            standarUserIDHead = GlobalVariableClass.fingerprintPocketData.USER_ID_PREFIX_BYTE;
        }
        private byte[] queueDataPop(ref byte[] queueTpBytesData,int outCount)
        {
            if (receiveBytesDataFIFO.Count < outCount)
                return null;
            if (queueTpBytesData.Length < outCount)
                return null;
            int elementCount = 0;
            for(elementCount=0; elementCount< outCount; elementCount++)
            {
                queueTpBytesData[elementCount] = receiveBytesDataFIFO.Dequeue();
            }

            return queueTpBytesData;
        }
        private byte queueDataPop(ref byte queueTpBytesData, int outCount)
        {
            if (receiveBytesDataFIFO.Count < outCount) return 0;
            if (outCount > 1) return 0;
            queueTpBytesData = receiveBytesDataFIFO.Dequeue();
            return queueTpBytesData;
        }
        public bool dataLoadFromQueue()//从队列导入数据
        {
            if (isThePacketEnd)
            {
                if (receiveBytesDataFIFO.Count < minPacketBytesCount) return false;//基础解析字节长12
                do
                {
                    if (receiveBytesDataFIFO.Count == 0) return false;//基础解析字节长12
                    AnalysisPacketStratData[0] = AnalysisPacketStratData[1];
                    AnalysisPacketStratData[1] = receiveBytesDataFIFO.Dequeue();
                   //pocketStartCheckData
                } while (!AnalysisPacketStratData.SequenceEqual(standardPocketStartData));
            
                queueDataPop(ref AnalysisAddressData, 4);
                queueDataPop(ref AnalysisPacketSignByte, 1);
                queueDataPop(ref AnalysisPacketFollowLengthData, 2);
                AnalysisPacketFollowLength = (((int)AnalysisPacketFollowLengthData[0]) << 8) + (int)AnalysisPacketFollowLengthData[1];
                AnalysisPacketUserDataLength = AnalysisPacketFollowLength - 3;
                if (receiveBytesDataFIFO.Count < AnalysisPacketFollowLength)//小于加上用户数据长度
                {
                    isThePacketEnd = false;
                    return false;
                }
                queueDataPop(ref AnalysisResponseCommandByte, 1);
                AnalysisUserSendData = new byte[AnalysisPacketUserDataLength];
                queueDataPop(ref AnalysisUserSendData, AnalysisPacketUserDataLength);
                queueDataPop(ref AnalysisCheckSumData, 2);
                isThePacketEnd = true;
                return true;
            }
            else
            {
                if (receiveBytesDataFIFO.Count < AnalysisPacketFollowLength)//小于加上用户数据长度
                {
                    isThePacketEnd = false;
                    return false;
                }
                else
                {
                    queueDataPop(ref AnalysisResponseCommandByte, 1);
                    AnalysisUserSendData = new byte[AnalysisPacketUserDataLength];
                    queueDataPop(ref AnalysisUserSendData, AnalysisPacketUserDataLength);
                    queueDataPop(ref AnalysisCheckSumData, 2);
                    isThePacketEnd = true;
                    return true;
                }
            }
        }

        public void dataInitialise(byte[] bytesData)//导入数据
        {
            if (!(bytesData.Length >= minPacketBytesCount)) return;//基础解析字节长12
            Array.Copy(bytesData, 0, AnalysisPacketStratData, 0, 2);
            Array.Copy(bytesData, 2, AnalysisAddressData, 0, 4);
            AnalysisPacketSignByte = bytesData[6];
            Array.Copy(bytesData, 7, AnalysisPacketFollowLengthData, 0, 2);
            AnalysisPacketFollowLength = (((int)AnalysisPacketFollowLengthData[0]) << 8) + (int)AnalysisPacketFollowLengthData[1] - 3;
            AnalysisResponseCommandByte = bytesData[9];
            AnalysisUserSendData = new byte[AnalysisPacketFollowLength];
            Array.Copy(bytesData, 10, AnalysisUserSendData, 0, AnalysisPacketFollowLength);
            Array.Copy(bytesData, 10 + AnalysisPacketFollowLength, AnalysisCheckSumData, 0, 2);
        }
        private String ByteToHexString(byte[] hexBytes, bool isUseSegmentationSign)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string hexFormatString = "";
            string segmentationSign = "";
            if (isUseSegmentationSign)
            {
                segmentationSign = " ";
            }
            foreach (byte oneByte in hexBytes)
            {
                hexFormatString = oneByte.ToString("X2").ToUpper() + segmentationSign;
                stringBuilder.Append(hexFormatString);
            }
            return stringBuilder.ToString();
        }
        private String ByteToHexString(byte[] hexBytes)
        {
            return ByteToHexString(hexBytes, true);
        }

        private String ByteToASCIIString(byte[] bcd)
        {
            StringBuilder sb = new StringBuilder();
            string szHexFormatStr;
            szHexFormatStr = Encoding.ASCII.GetString(bcd);
            sb.Append(szHexFormatStr);
            return sb.ToString();
        }

        public int GetUserIDInt(byte[] userIDHexBytes)
        {
            int userIDNum = 0;
            if(userIDHexBytes[0] == standarUserIDHead)//用户ID头标记
            {
                userIDNum = (userIDHexBytes[1] & 0x00FF) << 8;
                userIDNum += (userIDHexBytes[2] & 0x00FF);
                return userIDNum;
            }
            return 0;
        }

        private String DataToTimeFormat(byte[] timeData)//20160101123045的ASCII码时间戳格式化成2016/01/01 12:30:45 
        {
            string timeFormat = "";
            byte[] timeASCIIArray;
            timeASCIIArray = new byte[2];
            Array.Copy(timeData, 0, timeASCIIArray, 0, 2);
            timeFormat = ByteToASCIIString(timeASCIIArray);
            Array.Copy(timeData, 2, timeASCIIArray, 0, 2);
            timeFormat += ByteToASCIIString(timeASCIIArray) + "/";
            Array.Copy(timeData, 4, timeASCIIArray, 0, 2);
            timeFormat += ByteToASCIIString(timeASCIIArray) + "/";
            Array.Copy(timeData, 6, timeASCIIArray, 0, 2);
            timeFormat += ByteToASCIIString(timeASCIIArray) + " ";
            Array.Copy(timeData, 8, timeASCIIArray, 0, 2);
            timeFormat += ByteToASCIIString(timeASCIIArray) + ":";
            Array.Copy(timeData, 10, timeASCIIArray, 0, 2);
            timeFormat += ByteToASCIIString(timeASCIIArray) + ":";
            Array.Copy(timeData, 12, timeASCIIArray, 0, 2);
            timeFormat += ByteToASCIIString(timeASCIIArray);
            return timeFormat;
        }
        //, out string userAddressString
        public void DataToTimeFormatAndUserID(byte[] timeUserData, byte[] packetAddressData, out string timeFormatString, out string userIDString, out string userAddressString)//将时间戳与用户ID解析分开
        {
            byte timeDataBytesLength = 14; ;
            byte[] timeASCIIBytes = new byte[timeDataBytesLength];
            byte[] userIDHexBytes;
            int userIDNum = 0;
            Array.Copy(timeUserData, 0, timeASCIIBytes, 0, timeDataBytesLength);
            timeFormatString = DataToTimeFormat(timeASCIIBytes);

            userIDHexBytes = new byte[timeUserData.Length - timeDataBytesLength];
            Array.Copy(timeUserData, timeDataBytesLength, userIDHexBytes, 0, timeUserData.Length - timeDataBytesLength);
            userIDNum = GetUserIDInt(userIDHexBytes);
            userIDString = userIDNum.ToString("D4");

            userAddressString = ByteToHexString(packetAddressData, false);
        }
        public void DataToTimeFormatAndUserID(byte[] timeUserData, out string timeFormatString, out string userIDString)//将时间戳与用户ID解析分开
        {
            byte timeDataBytesLength = 14;         ;
            byte[] timeASCIIBytes = new byte[timeDataBytesLength];
            byte[] userIDHexBytes;
            int userIDNum = 0;
            Array.Copy(timeUserData, 0, timeASCIIBytes, 0, timeDataBytesLength);
            timeFormatString = DataToTimeFormat(timeASCIIBytes);

            userIDHexBytes = new byte[timeUserData.Length - timeDataBytesLength];
            Array.Copy(timeUserData, timeDataBytesLength, userIDHexBytes, 0, timeUserData.Length - timeDataBytesLength);
            userIDNum = GetUserIDInt(userIDHexBytes);
            userIDString = userIDNum.ToString("D4");
        }
        private String DataToTimeFormatAndUserID(byte[] timeUserData)//将时间戳与用户ID解析分开
        {         
            string timeFormatString = "";
            string userIDString = "";
            DataToTimeFormatAndUserID(timeUserData, out timeFormatString, out userIDString);
            return timeFormatString + "  " + userIDString;
        }


        public string getPacketStratDataHex()//返回包头数据
        {
            return ByteToHexString(AnalysisPacketStratData);
        }
        public string getPacketAddressDataHex()//返回地址数据
        {
            return ByteToHexString(AnalysisAddressData);
        }
        public string getPacketSignDataHex()//返回包标识数据
        {
            return AnalysisPacketSignByte.ToString("X2").ToUpper() + " ";
        }
        public string getPacketFollowLengthDataHex()//返回后续长度字节数据
        {
            return ByteToHexString(AnalysisPacketFollowLengthData);
        }
        public string getPacketResponseCommandDataHex()//返回响应指令数据
        {
            return AnalysisResponseCommandByte.ToString("X2").ToUpper() + " ";
        }
        public string getPacketUserSendDataHex()//返回用户发送数据
        {
            switch (AnalysisPacketSignByte)
            {
                case 0x01:
                case 0x02:
                case 0x06:
                    return DataToTimeFormatAndUserID(AnalysisUserSendData);
                    break;
                case 0x05:                    
                    return DataToTimeFormat(AnalysisUserSendData);
                    break;
            }

            return ByteToHexString(AnalysisUserSendData);
        }
        public string getPacketCheckSumDataHex()//返回校验和数据
        {
            return ByteToHexString(AnalysisCheckSumData);
        }
        public string getPacketAllDataHex()
        {
            return getPacketStratDataHex() + getPacketAddressDataHex() + getPacketSignDataHex() + getPacketFollowLengthDataHex() + getPacketResponseCommandDataHex() + ByteToHexString(AnalysisUserSendData) + getPacketCheckSumDataHex();
        }
        public string getPacketPacketSignDataMeaing()//返回包标识含义
        {
            string signBitMeaing = "";
            switch (AnalysisPacketSignByte)
            {
                case 0x00:
                    signBitMeaing = "无";
                    break;
                case 0x01:
                    signBitMeaing = "当前用户ID";
                    break;
                case 0x02:
                    signBitMeaing = "新增用户ID";
                    break;
                case 0x03:
                    signBitMeaing = "当前用户指纹";
                    break;
                case 0x04:
                    signBitMeaing = "新增用户指纹";
                    break;
                case 0x05:
                    signBitMeaing = "时间戳";
                    break;
                case 0x06:
                    signBitMeaing = "导入用户ID";
                    break;
                case 0x07:
                    signBitMeaing = "导入用户指纹";
                    break;
                case 0x08:
                    signBitMeaing = "校对时间";
                    break;
                case 0x09:
                    signBitMeaing = "删除用户ID";
                    break;
                case 0x10:
                    signBitMeaing = "清除所有用户";
                    break;
                case 0x11:
                    signBitMeaing = "上位机故障后重启";
                    break;
                case 0x12:
                    signBitMeaing = "导出所有用户指纹";
                    break;
                case 0x13:
                    signBitMeaing = "请求重发上一包";
                    break;
            }
            return signBitMeaing;
        }
        public string getPacketResponseCommandDataMeaing()//返回响应指令含义
        {
            string responseBitMeaing = "";
            switch (AnalysisResponseCommandByte)
            {
                case 0x00:
                    responseBitMeaing = "无";
                    break;
                case 0x01:
                    responseBitMeaing = "接受成功";
                    break;
                case 0x02:
                    responseBitMeaing = "接收失败";
                    break;
                case 0x03:
                    responseBitMeaing = "包头";
                    break;
                case 0x04:
                    responseBitMeaing = "包间";
                    break;
                case 0x05:
                    responseBitMeaing = "包尾";
                    break;
                case 0x06:
                    responseBitMeaing = "时间读取失败";
                    break;
                case 0x07:
                    responseBitMeaing = "指纹读取失败";
                    break;
                case 0x08:
                    responseBitMeaing = "用户为空";
                    break;
                case 0x09:
                    responseBitMeaing = "校验和错误";
                    break;
                case 0x10:
                    responseBitMeaing = "重发上一包请求";
                    break;
                case 0x11:
                    responseBitMeaing = "清除用户成功";
                    break;
                case 0x12:
                    responseBitMeaing = "清除用户失败";
                    break;
                case 0x13:
                    responseBitMeaing = "重置时间成功";
                    break;
                case 0x14:
                    responseBitMeaing = "重置时间失败";
                    break;
            }
            return responseBitMeaing;
        }
        
    }
}
