namespace testCSharpSerial
{
    partial class CSharpSerialForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label_SerialPortNum = new System.Windows.Forms.Label();
            this.comboBox_SerialPortNum = new System.Windows.Forms.ComboBox();
            this.serialPortControl = new System.IO.Ports.SerialPort(this.components);
            this.textBox_SerialReceive = new System.Windows.Forms.TextBox();
            this.button_OpenOrCloseSerialPort = new System.Windows.Forms.Button();
            this.label_BaudRate = new System.Windows.Forms.Label();
            this.comboBox_BandRate = new System.Windows.Forms.ComboBox();
            this.label_SerialPortParity = new System.Windows.Forms.Label();
            this.comboBox_SerialPortParity = new System.Windows.Forms.ComboBox();
            this.label_SerialPortDataBit = new System.Windows.Forms.Label();
            this.comboBox_SerialPortDataBit = new System.Windows.Forms.ComboBox();
            this.label_SerialPortStopBits = new System.Windows.Forms.Label();
            this.comboBox_SerialPortStopBit = new System.Windows.Forms.ComboBox();
            this.button_TestCommunication = new System.Windows.Forms.Button();
            this.button_AddOneNewUser = new System.Windows.Forms.Button();
            this.button_CorrectTime = new System.Windows.Forms.Button();
            this.button_ClearText = new System.Windows.Forms.Button();
            this.button_ClearAllUser = new System.Windows.Forms.Button();
            this.button_CallResend = new System.Windows.Forms.Button();
            this.groupBox_ReceiveArea = new System.Windows.Forms.GroupBox();
            this.dataGridView_UserAndTimeList = new System.Windows.Forms.DataGridView();
            this.Column_UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_UserArriveTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_ClientAddress = new System.Windows.Forms.Label();
            this.button_SaveSerialPortConnection = new System.Windows.Forms.Button();
            this.button_AddAppointUserID = new System.Windows.Forms.Button();
            this.button_DelAppointUserID = new System.Windows.Forms.Button();
            this.groupBox_ReceiveArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_UserAndTimeList)).BeginInit();
            this.SuspendLayout();
            // 
            // label_SerialPortNum
            // 
            this.label_SerialPortNum.AutoSize = true;
            this.label_SerialPortNum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SerialPortNum.Location = new System.Drawing.Point(27, 333);
            this.label_SerialPortNum.Name = "label_SerialPortNum";
            this.label_SerialPortNum.Size = new System.Drawing.Size(49, 14);
            this.label_SerialPortNum.TabIndex = 0;
            this.label_SerialPortNum.Text = "串口号";
            // 
            // comboBox_SerialPortNum
            // 
            this.comboBox_SerialPortNum.FormattingEnabled = true;
            this.comboBox_SerialPortNum.Location = new System.Drawing.Point(79, 330);
            this.comboBox_SerialPortNum.Name = "comboBox_SerialPortNum";
            this.comboBox_SerialPortNum.Size = new System.Drawing.Size(85, 20);
            this.comboBox_SerialPortNum.TabIndex = 1;
            this.comboBox_SerialPortNum.Click += new System.EventHandler(this.comboBox_SerialPortNum_Click);
            // 
            // serialPortControl
            // 
            this.serialPortControl.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPortControl_DataReceived);
            // 
            // textBox_SerialReceive
            // 
            this.textBox_SerialReceive.AcceptsReturn = true;
            this.textBox_SerialReceive.AcceptsTab = true;
            this.textBox_SerialReceive.AllowDrop = true;
            this.textBox_SerialReceive.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_SerialReceive.Location = new System.Drawing.Point(12, 22);
            this.textBox_SerialReceive.Multiline = true;
            this.textBox_SerialReceive.Name = "textBox_SerialReceive";
            this.textBox_SerialReceive.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_SerialReceive.Size = new System.Drawing.Size(468, 266);
            this.textBox_SerialReceive.TabIndex = 2;
            this.textBox_SerialReceive.WordWrap = false;
            // 
            // button_OpenOrCloseSerialPort
            // 
            this.button_OpenOrCloseSerialPort.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_OpenOrCloseSerialPort.Location = new System.Drawing.Point(170, 329);
            this.button_OpenOrCloseSerialPort.Name = "button_OpenOrCloseSerialPort";
            this.button_OpenOrCloseSerialPort.Size = new System.Drawing.Size(75, 23);
            this.button_OpenOrCloseSerialPort.TabIndex = 3;
            this.button_OpenOrCloseSerialPort.Text = "打开串口";
            this.button_OpenOrCloseSerialPort.UseVisualStyleBackColor = true;
            this.button_OpenOrCloseSerialPort.Click += new System.EventHandler(this.button_OpenOrCloseSerialPort_Click);
            // 
            // label_BaudRate
            // 
            this.label_BaudRate.AutoSize = true;
            this.label_BaudRate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_BaudRate.Location = new System.Drawing.Point(27, 358);
            this.label_BaudRate.Name = "label_BaudRate";
            this.label_BaudRate.Size = new System.Drawing.Size(49, 14);
            this.label_BaudRate.TabIndex = 4;
            this.label_BaudRate.Text = "波特率";
            // 
            // comboBox_BandRate
            // 
            this.comboBox_BandRate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_BandRate.FormattingEnabled = true;
            this.comboBox_BandRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "57600",
            "115200"});
            this.comboBox_BandRate.Location = new System.Drawing.Point(79, 354);
            this.comboBox_BandRate.Name = "comboBox_BandRate";
            this.comboBox_BandRate.Size = new System.Drawing.Size(85, 20);
            this.comboBox_BandRate.TabIndex = 5;
            // 
            // label_SerialPortParity
            // 
            this.label_SerialPortParity.AutoSize = true;
            this.label_SerialPortParity.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SerialPortParity.Location = new System.Drawing.Point(27, 382);
            this.label_SerialPortParity.Name = "label_SerialPortParity";
            this.label_SerialPortParity.Size = new System.Drawing.Size(49, 14);
            this.label_SerialPortParity.TabIndex = 6;
            this.label_SerialPortParity.Text = "校验位";
            // 
            // comboBox_SerialPortParity
            // 
            this.comboBox_SerialPortParity.FormattingEnabled = true;
            this.comboBox_SerialPortParity.Items.AddRange(new object[] {
            "无校验",
            "奇校验",
            "偶校验",
            "1 校验",
            "0 校验"});
            this.comboBox_SerialPortParity.Location = new System.Drawing.Point(79, 378);
            this.comboBox_SerialPortParity.Name = "comboBox_SerialPortParity";
            this.comboBox_SerialPortParity.Size = new System.Drawing.Size(85, 20);
            this.comboBox_SerialPortParity.TabIndex = 7;
            // 
            // label_SerialPortDataBit
            // 
            this.label_SerialPortDataBit.AutoSize = true;
            this.label_SerialPortDataBit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SerialPortDataBit.Location = new System.Drawing.Point(27, 406);
            this.label_SerialPortDataBit.Name = "label_SerialPortDataBit";
            this.label_SerialPortDataBit.Size = new System.Drawing.Size(49, 14);
            this.label_SerialPortDataBit.TabIndex = 8;
            this.label_SerialPortDataBit.Text = "数据位";
            // 
            // comboBox_SerialPortDataBit
            // 
            this.comboBox_SerialPortDataBit.FormattingEnabled = true;
            this.comboBox_SerialPortDataBit.Items.AddRange(new object[] {
            "8",
            "9",
            "10"});
            this.comboBox_SerialPortDataBit.Location = new System.Drawing.Point(79, 402);
            this.comboBox_SerialPortDataBit.Name = "comboBox_SerialPortDataBit";
            this.comboBox_SerialPortDataBit.Size = new System.Drawing.Size(85, 20);
            this.comboBox_SerialPortDataBit.TabIndex = 9;
            // 
            // label_SerialPortStopBits
            // 
            this.label_SerialPortStopBits.AutoSize = true;
            this.label_SerialPortStopBits.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SerialPortStopBits.Location = new System.Drawing.Point(27, 428);
            this.label_SerialPortStopBits.Name = "label_SerialPortStopBits";
            this.label_SerialPortStopBits.Size = new System.Drawing.Size(49, 14);
            this.label_SerialPortStopBits.TabIndex = 10;
            this.label_SerialPortStopBits.Text = "停止位";
            // 
            // comboBox_SerialPortStopBit
            // 
            this.comboBox_SerialPortStopBit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_SerialPortStopBit.FormattingEnabled = true;
            this.comboBox_SerialPortStopBit.Items.AddRange(new object[] {
            "1位",
            "1.5位",
            "2位"});
            this.comboBox_SerialPortStopBit.Location = new System.Drawing.Point(79, 426);
            this.comboBox_SerialPortStopBit.Name = "comboBox_SerialPortStopBit";
            this.comboBox_SerialPortStopBit.Size = new System.Drawing.Size(85, 22);
            this.comboBox_SerialPortStopBit.TabIndex = 11;
            // 
            // button_TestCommunication
            // 
            this.button_TestCommunication.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_TestCommunication.Location = new System.Drawing.Point(277, 329);
            this.button_TestCommunication.Name = "button_TestCommunication";
            this.button_TestCommunication.Size = new System.Drawing.Size(75, 23);
            this.button_TestCommunication.TabIndex = 12;
            this.button_TestCommunication.Text = "握手测试";
            this.button_TestCommunication.UseVisualStyleBackColor = true;
            this.button_TestCommunication.Click += new System.EventHandler(this.button_TestCommunication_Click);
            // 
            // button_AddOneNewUser
            // 
            this.button_AddOneNewUser.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_AddOneNewUser.Location = new System.Drawing.Point(277, 359);
            this.button_AddOneNewUser.Name = "button_AddOneNewUser";
            this.button_AddOneNewUser.Size = new System.Drawing.Size(75, 23);
            this.button_AddOneNewUser.TabIndex = 13;
            this.button_AddOneNewUser.Text = "新增用户";
            this.button_AddOneNewUser.UseVisualStyleBackColor = true;
            this.button_AddOneNewUser.Click += new System.EventHandler(this.button_AddOneNewUser_Click);
            // 
            // button_CorrectTime
            // 
            this.button_CorrectTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_CorrectTime.Location = new System.Drawing.Point(277, 389);
            this.button_CorrectTime.Name = "button_CorrectTime";
            this.button_CorrectTime.Size = new System.Drawing.Size(75, 23);
            this.button_CorrectTime.TabIndex = 14;
            this.button_CorrectTime.Text = "校准时间";
            this.button_CorrectTime.UseVisualStyleBackColor = true;
            this.button_CorrectTime.Click += new System.EventHandler(this.button_CorrectTime_Click);
            // 
            // button_ClearText
            // 
            this.button_ClearText.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_ClearText.Location = new System.Drawing.Point(170, 360);
            this.button_ClearText.Name = "button_ClearText";
            this.button_ClearText.Size = new System.Drawing.Size(75, 23);
            this.button_ClearText.TabIndex = 15;
            this.button_ClearText.Text = "清空显示";
            this.button_ClearText.UseVisualStyleBackColor = true;
            this.button_ClearText.Click += new System.EventHandler(this.button_ClearText_Click);
            // 
            // button_ClearAllUser
            // 
            this.button_ClearAllUser.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_ClearAllUser.Location = new System.Drawing.Point(277, 419);
            this.button_ClearAllUser.Name = "button_ClearAllUser";
            this.button_ClearAllUser.Size = new System.Drawing.Size(75, 23);
            this.button_ClearAllUser.TabIndex = 16;
            this.button_ClearAllUser.Text = "清空用户";
            this.button_ClearAllUser.UseVisualStyleBackColor = true;
            this.button_ClearAllUser.Click += new System.EventHandler(this.button_ClearAllUser_Click);
            // 
            // button_CallResend
            // 
            this.button_CallResend.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_CallResend.Location = new System.Drawing.Point(380, 329);
            this.button_CallResend.Name = "button_CallResend";
            this.button_CallResend.Size = new System.Drawing.Size(75, 23);
            this.button_CallResend.TabIndex = 17;
            this.button_CallResend.Text = "请求重发";
            this.button_CallResend.UseVisualStyleBackColor = true;
            this.button_CallResend.Click += new System.EventHandler(this.button_CallResend_Click);
            // 
            // groupBox_ReceiveArea
            // 
            this.groupBox_ReceiveArea.Controls.Add(this.textBox_SerialReceive);
            this.groupBox_ReceiveArea.Location = new System.Drawing.Point(30, 16);
            this.groupBox_ReceiveArea.Name = "groupBox_ReceiveArea";
            this.groupBox_ReceiveArea.Size = new System.Drawing.Size(493, 302);
            this.groupBox_ReceiveArea.TabIndex = 18;
            this.groupBox_ReceiveArea.TabStop = false;
            this.groupBox_ReceiveArea.Text = "数据接收区";
            // 
            // dataGridView_UserAndTimeList
            // 
            this.dataGridView_UserAndTimeList.AllowUserToDeleteRows = false;
            this.dataGridView_UserAndTimeList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView_UserAndTimeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_UserAndTimeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_UserName,
            this.Column_UserArriveTime});
            this.dataGridView_UserAndTimeList.Location = new System.Drawing.Point(529, 38);
            this.dataGridView_UserAndTimeList.Name = "dataGridView_UserAndTimeList";
            this.dataGridView_UserAndTimeList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView_UserAndTimeList.RowTemplate.Height = 23;
            this.dataGridView_UserAndTimeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_UserAndTimeList.Size = new System.Drawing.Size(308, 395);
            this.dataGridView_UserAndTimeList.TabIndex = 19;
            this.dataGridView_UserAndTimeList.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView_UserAndTimeList_RowStateChanged);
            // 
            // Column_UserName
            // 
            this.Column_UserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_UserName.FillWeight = 130F;
            this.Column_UserName.HeaderText = "时间";
            this.Column_UserName.Name = "Column_UserName";
            this.Column_UserName.ReadOnly = true;
            // 
            // Column_UserArriveTime
            // 
            this.Column_UserArriveTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_UserArriveTime.FillWeight = 60F;
            this.Column_UserArriveTime.HeaderText = "用户ID";
            this.Column_UserArriveTime.Name = "Column_UserArriveTime";
            this.Column_UserArriveTime.ReadOnly = true;
            // 
            // label_ClientAddress
            // 
            this.label_ClientAddress.AutoSize = true;
            this.label_ClientAddress.Location = new System.Drawing.Point(530, 22);
            this.label_ClientAddress.Name = "label_ClientAddress";
            this.label_ClientAddress.Size = new System.Drawing.Size(89, 12);
            this.label_ClientAddress.TabIndex = 20;
            this.label_ClientAddress.Text = "当前终端地址: ";
            // 
            // button_SaveSerialPortConnection
            // 
            this.button_SaveSerialPortConnection.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_SaveSerialPortConnection.Location = new System.Drawing.Point(170, 390);
            this.button_SaveSerialPortConnection.Name = "button_SaveSerialPortConnection";
            this.button_SaveSerialPortConnection.Size = new System.Drawing.Size(75, 23);
            this.button_SaveSerialPortConnection.TabIndex = 21;
            this.button_SaveSerialPortConnection.Text = "确认保存";
            this.button_SaveSerialPortConnection.UseVisualStyleBackColor = true;
            this.button_SaveSerialPortConnection.Click += new System.EventHandler(this.button_SaveSerialPortConnection_Click);
            // 
            // button_AddAppointUserID
            // 
            this.button_AddAppointUserID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_AddAppointUserID.Location = new System.Drawing.Point(380, 359);
            this.button_AddAppointUserID.Name = "button_AddAppointUserID";
            this.button_AddAppointUserID.Size = new System.Drawing.Size(75, 23);
            this.button_AddAppointUserID.TabIndex = 22;
            this.button_AddAppointUserID.Text = "指定增加";
            this.button_AddAppointUserID.UseVisualStyleBackColor = true;
            this.button_AddAppointUserID.Click += new System.EventHandler(this.button_AddAppointUserID_Click);
            // 
            // button_DelAppointUserID
            // 
            this.button_DelAppointUserID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_DelAppointUserID.Location = new System.Drawing.Point(380, 388);
            this.button_DelAppointUserID.Name = "button_DelAppointUserID";
            this.button_DelAppointUserID.Size = new System.Drawing.Size(75, 23);
            this.button_DelAppointUserID.TabIndex = 23;
            this.button_DelAppointUserID.Text = "删除指定";
            this.button_DelAppointUserID.UseVisualStyleBackColor = true;
            this.button_DelAppointUserID.Click += new System.EventHandler(this.button_DelAppointUserID_Click);
            // 
            // CSharpSerialForm
            // 
            this.AcceptButton = this.button_OpenOrCloseSerialPort;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(868, 483);
            this.ControlBox = false;
            this.Controls.Add(this.button_DelAppointUserID);
            this.Controls.Add(this.button_AddAppointUserID);
            this.Controls.Add(this.button_SaveSerialPortConnection);
            this.Controls.Add(this.label_ClientAddress);
            this.Controls.Add(this.dataGridView_UserAndTimeList);
            this.Controls.Add(this.groupBox_ReceiveArea);
            this.Controls.Add(this.button_CallResend);
            this.Controls.Add(this.button_ClearAllUser);
            this.Controls.Add(this.button_ClearText);
            this.Controls.Add(this.button_CorrectTime);
            this.Controls.Add(this.button_AddOneNewUser);
            this.Controls.Add(this.button_TestCommunication);
            this.Controls.Add(this.comboBox_SerialPortStopBit);
            this.Controls.Add(this.label_SerialPortStopBits);
            this.Controls.Add(this.comboBox_SerialPortDataBit);
            this.Controls.Add(this.label_SerialPortDataBit);
            this.Controls.Add(this.comboBox_SerialPortParity);
            this.Controls.Add(this.label_SerialPortParity);
            this.Controls.Add(this.comboBox_BandRate);
            this.Controls.Add(this.label_BaudRate);
            this.Controls.Add(this.button_OpenOrCloseSerialPort);
            this.Controls.Add(this.comboBox_SerialPortNum);
            this.Controls.Add(this.label_SerialPortNum);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CSharpSerialForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "指纹机接收终端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CSharpSerialForm_FormClosing);
            this.groupBox_ReceiveArea.ResumeLayout(false);
            this.groupBox_ReceiveArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_UserAndTimeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_SerialPortNum;
        private System.Windows.Forms.ComboBox comboBox_SerialPortNum;
        private System.IO.Ports.SerialPort serialPortControl;
        private System.Windows.Forms.TextBox textBox_SerialReceive;
        private System.Windows.Forms.Button button_OpenOrCloseSerialPort;
        private System.Windows.Forms.Label label_BaudRate;
        private System.Windows.Forms.ComboBox comboBox_BandRate;
        private System.Windows.Forms.Label label_SerialPortParity;
        private System.Windows.Forms.ComboBox comboBox_SerialPortParity;
        private System.Windows.Forms.Label label_SerialPortDataBit;
        private System.Windows.Forms.ComboBox comboBox_SerialPortDataBit;
        private System.Windows.Forms.Label label_SerialPortStopBits;
        private System.Windows.Forms.ComboBox comboBox_SerialPortStopBit;
        private System.Windows.Forms.Button button_TestCommunication;
        private System.Windows.Forms.Button button_AddOneNewUser;
        private System.Windows.Forms.Button button_CorrectTime;
        private System.Windows.Forms.Button button_ClearText;
        private System.Windows.Forms.Button button_ClearAllUser;
        private System.Windows.Forms.Button button_CallResend;
        private System.Windows.Forms.GroupBox groupBox_ReceiveArea;
        private System.Windows.Forms.DataGridView dataGridView_UserAndTimeList;
        private System.Windows.Forms.Label label_ClientAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_UserArriveTime;
        private System.Windows.Forms.Button button_SaveSerialPortConnection;
        private System.Windows.Forms.Button button_AddAppointUserID;
        private System.Windows.Forms.Button button_DelAppointUserID;
    }
}

