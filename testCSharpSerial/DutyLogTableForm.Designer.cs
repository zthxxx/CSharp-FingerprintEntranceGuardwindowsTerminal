namespace testCSharpSerial
{
    partial class DutyLogTableForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView_UserAndTimeList = new System.Windows.Forms.DataGridView();
            this.label_DutyLogTable = new System.Windows.Forms.Label();
            this.label_NowTime = new System.Windows.Forms.Label();
            this.pictureBox_UserPhoto = new System.Windows.Forms.PictureBox();
            this.label_StaticUserName = new System.Windows.Forms.Label();
            this.label_StaticUserSector = new System.Windows.Forms.Label();
            this.label_StaticUserOffice = new System.Windows.Forms.Label();
            this.label_StaticUserDutyTime = new System.Windows.Forms.Label();
            this.label_VariableUserName = new System.Windows.Forms.Label();
            this.label_VariableUserSector = new System.Windows.Forms.Label();
            this.label_VariableUserOffice = new System.Windows.Forms.Label();
            this.label_VariableUserDutyTime = new System.Windows.Forms.Label();
            this.label_StaticUserInformation = new System.Windows.Forms.Label();
            this.groupBox_StaticUserInfomation = new System.Windows.Forms.GroupBox();
            this.cSharpSerialFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Column_UserArriveTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_UserAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_UserAndTimeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_UserPhoto)).BeginInit();
            this.groupBox_StaticUserInfomation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cSharpSerialFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_UserAndTimeList
            // 
            this.dataGridView_UserAndTimeList.AllowUserToDeleteRows = false;
            this.dataGridView_UserAndTimeList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView_UserAndTimeList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_UserAndTimeList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView_UserAndTimeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_UserAndTimeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_UserArriveTime,
            this.Column_UserID,
            this.Column_UserName,
            this.Column_UserAddress});
            this.dataGridView_UserAndTimeList.Location = new System.Drawing.Point(466, 46);
            this.dataGridView_UserAndTimeList.Name = "dataGridView_UserAndTimeList";
            this.dataGridView_UserAndTimeList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView_UserAndTimeList.RowTemplate.Height = 23;
            this.dataGridView_UserAndTimeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_UserAndTimeList.Size = new System.Drawing.Size(449, 494);
            this.dataGridView_UserAndTimeList.TabIndex = 20;
            this.dataGridView_UserAndTimeList.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView_UserAndTimeList_RowStateChanged);
            this.dataGridView_UserAndTimeList.SelectionChanged += new System.EventHandler(this.dataGridView_UserAndTimeList_SelectionChanged);
            // 
            // label_DutyLogTable
            // 
            this.label_DutyLogTable.AutoSize = true;
            this.label_DutyLogTable.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_DutyLogTable.ForeColor = System.Drawing.Color.Firebrick;
            this.label_DutyLogTable.Location = new System.Drawing.Point(563, 9);
            this.label_DutyLogTable.Name = "label_DutyLogTable";
            this.label_DutyLogTable.Size = new System.Drawing.Size(223, 29);
            this.label_DutyLogTable.TabIndex = 21;
            this.label_DutyLogTable.Text = "当前执勤记录表";
            // 
            // label_NowTime
            // 
            this.label_NowTime.AutoSize = true;
            this.label_NowTime.Location = new System.Drawing.Point(802, 32);
            this.label_NowTime.Name = "label_NowTime";
            this.label_NowTime.Size = new System.Drawing.Size(65, 12);
            this.label_NowTime.TabIndex = 22;
            this.label_NowTime.Text = "当前时间：";
            // 
            // pictureBox_UserPhoto
            // 
            this.pictureBox_UserPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_UserPhoto.ErrorImage = global::testCSharpSerial.Properties.Resources.图片1;
            this.pictureBox_UserPhoto.Image = global::testCSharpSerial.Properties.Resources.图片1;
            this.pictureBox_UserPhoto.InitialImage = global::testCSharpSerial.Properties.Resources.图片1;
            this.pictureBox_UserPhoto.Location = new System.Drawing.Point(102, 82);
            this.pictureBox_UserPhoto.Name = "pictureBox_UserPhoto";
            this.pictureBox_UserPhoto.Size = new System.Drawing.Size(165, 206);
            this.pictureBox_UserPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_UserPhoto.TabIndex = 23;
            this.pictureBox_UserPhoto.TabStop = false;
            // 
            // label_StaticUserName
            // 
            this.label_StaticUserName.AutoSize = true;
            this.label_StaticUserName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_StaticUserName.Location = new System.Drawing.Point(79, 319);
            this.label_StaticUserName.Name = "label_StaticUserName";
            this.label_StaticUserName.Size = new System.Drawing.Size(69, 19);
            this.label_StaticUserName.TabIndex = 24;
            this.label_StaticUserName.Text = "姓名：";
            // 
            // label_StaticUserSector
            // 
            this.label_StaticUserSector.AutoSize = true;
            this.label_StaticUserSector.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_StaticUserSector.Location = new System.Drawing.Point(79, 366);
            this.label_StaticUserSector.Name = "label_StaticUserSector";
            this.label_StaticUserSector.Size = new System.Drawing.Size(69, 19);
            this.label_StaticUserSector.TabIndex = 25;
            this.label_StaticUserSector.Text = "部门：";
            // 
            // label_StaticUserOffice
            // 
            this.label_StaticUserOffice.AutoSize = true;
            this.label_StaticUserOffice.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_StaticUserOffice.Location = new System.Drawing.Point(79, 413);
            this.label_StaticUserOffice.Name = "label_StaticUserOffice";
            this.label_StaticUserOffice.Size = new System.Drawing.Size(69, 19);
            this.label_StaticUserOffice.TabIndex = 26;
            this.label_StaticUserOffice.Text = "科室：";
            // 
            // label_StaticUserDutyTime
            // 
            this.label_StaticUserDutyTime.AutoSize = true;
            this.label_StaticUserDutyTime.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_StaticUserDutyTime.Location = new System.Drawing.Point(39, 458);
            this.label_StaticUserDutyTime.Name = "label_StaticUserDutyTime";
            this.label_StaticUserDutyTime.Size = new System.Drawing.Size(109, 19);
            this.label_StaticUserDutyTime.TabIndex = 27;
            this.label_StaticUserDutyTime.Text = "打卡时间：";
            // 
            // label_VariableUserName
            // 
            this.label_VariableUserName.AutoSize = true;
            this.label_VariableUserName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_VariableUserName.Location = new System.Drawing.Point(165, 318);
            this.label_VariableUserName.Name = "label_VariableUserName";
            this.label_VariableUserName.Size = new System.Drawing.Size(40, 16);
            this.label_VariableUserName.TabIndex = 28;
            this.label_VariableUserName.Text = "    ";
            // 
            // label_VariableUserSector
            // 
            this.label_VariableUserSector.AutoSize = true;
            this.label_VariableUserSector.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_VariableUserSector.Location = new System.Drawing.Point(165, 365);
            this.label_VariableUserSector.Name = "label_VariableUserSector";
            this.label_VariableUserSector.Size = new System.Drawing.Size(40, 16);
            this.label_VariableUserSector.TabIndex = 29;
            this.label_VariableUserSector.Text = "    ";
            // 
            // label_VariableUserOffice
            // 
            this.label_VariableUserOffice.AutoSize = true;
            this.label_VariableUserOffice.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_VariableUserOffice.Location = new System.Drawing.Point(165, 412);
            this.label_VariableUserOffice.Name = "label_VariableUserOffice";
            this.label_VariableUserOffice.Size = new System.Drawing.Size(40, 16);
            this.label_VariableUserOffice.TabIndex = 30;
            this.label_VariableUserOffice.Text = "    ";
            // 
            // label_VariableUserDutyTime
            // 
            this.label_VariableUserDutyTime.AutoSize = true;
            this.label_VariableUserDutyTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_VariableUserDutyTime.Location = new System.Drawing.Point(165, 458);
            this.label_VariableUserDutyTime.Name = "label_VariableUserDutyTime";
            this.label_VariableUserDutyTime.Size = new System.Drawing.Size(56, 16);
            this.label_VariableUserDutyTime.TabIndex = 31;
            this.label_VariableUserDutyTime.Text = "      ";
            // 
            // label_StaticUserInformation
            // 
            this.label_StaticUserInformation.AutoSize = true;
            this.label_StaticUserInformation.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_StaticUserInformation.ForeColor = System.Drawing.Color.Green;
            this.label_StaticUserInformation.Location = new System.Drawing.Point(90, 31);
            this.label_StaticUserInformation.Name = "label_StaticUserInformation";
            this.label_StaticUserInformation.Size = new System.Drawing.Size(193, 29);
            this.label_StaticUserInformation.TabIndex = 32;
            this.label_StaticUserInformation.Text = "当前用户信息";
            // 
            // groupBox_StaticUserInfomation
            // 
            this.groupBox_StaticUserInfomation.Controls.Add(this.pictureBox_UserPhoto);
            this.groupBox_StaticUserInfomation.Controls.Add(this.label_StaticUserInformation);
            this.groupBox_StaticUserInfomation.Controls.Add(this.label_StaticUserName);
            this.groupBox_StaticUserInfomation.Controls.Add(this.label_VariableUserDutyTime);
            this.groupBox_StaticUserInfomation.Controls.Add(this.label_StaticUserSector);
            this.groupBox_StaticUserInfomation.Controls.Add(this.label_VariableUserOffice);
            this.groupBox_StaticUserInfomation.Controls.Add(this.label_StaticUserOffice);
            this.groupBox_StaticUserInfomation.Controls.Add(this.label_VariableUserSector);
            this.groupBox_StaticUserInfomation.Controls.Add(this.label_StaticUserDutyTime);
            this.groupBox_StaticUserInfomation.Controls.Add(this.label_VariableUserName);
            this.groupBox_StaticUserInfomation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox_StaticUserInfomation.Location = new System.Drawing.Point(44, 39);
            this.groupBox_StaticUserInfomation.Name = "groupBox_StaticUserInfomation";
            this.groupBox_StaticUserInfomation.Size = new System.Drawing.Size(362, 502);
            this.groupBox_StaticUserInfomation.TabIndex = 33;
            this.groupBox_StaticUserInfomation.TabStop = false;
            this.groupBox_StaticUserInfomation.Text = "用户信息展示区";
            // 
            // cSharpSerialFormBindingSource
            // 
            this.cSharpSerialFormBindingSource.DataSource = typeof(testCSharpSerial.CSharpSerialForm);
            // 
            // Column_UserArriveTime
            // 
            this.Column_UserArriveTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_UserArriveTime.DataPropertyName = "cdt";
            this.Column_UserArriveTime.FillWeight = 120F;
            this.Column_UserArriveTime.HeaderText = "时间";
            this.Column_UserArriveTime.Name = "Column_UserArriveTime";
            this.Column_UserArriveTime.ReadOnly = true;
            // 
            // Column_UserID
            // 
            this.Column_UserID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_UserID.DataPropertyName = "f_id";
            this.Column_UserID.FillWeight = 80F;
            this.Column_UserID.HeaderText = "用户ID";
            this.Column_UserID.Name = "Column_UserID";
            this.Column_UserID.ReadOnly = true;
            // 
            // Column_UserName
            // 
            this.Column_UserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_UserName.FillWeight = 80F;
            this.Column_UserName.HeaderText = "用户姓名";
            this.Column_UserName.Name = "Column_UserName";
            this.Column_UserName.ReadOnly = true;
            // 
            // Column_UserAddress
            // 
            this.Column_UserAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_UserAddress.DataPropertyName = "addr";
            this.Column_UserAddress.FillWeight = 80F;
            this.Column_UserAddress.HeaderText = "地址";
            this.Column_UserAddress.Name = "Column_UserAddress";
            this.Column_UserAddress.ReadOnly = true;
            // 
            // DutyLogTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 568);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox_StaticUserInfomation);
            this.Controls.Add(this.label_NowTime);
            this.Controls.Add(this.label_DutyLogTable);
            this.Controls.Add(this.dataGridView_UserAndTimeList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DutyLogTableForm";
            this.Text = "执勤记录查看";
            this.Load += new System.EventHandler(this.DutyLogTableForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_UserAndTimeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_UserPhoto)).EndInit();
            this.groupBox_StaticUserInfomation.ResumeLayout(false);
            this.groupBox_StaticUserInfomation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cSharpSerialFormBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_UserAndTimeList;
        private System.Windows.Forms.Label label_DutyLogTable;
        private System.Windows.Forms.BindingSource cSharpSerialFormBindingSource;
        private System.Windows.Forms.Label label_NowTime;
        private System.Windows.Forms.PictureBox pictureBox_UserPhoto;
        private System.Windows.Forms.Label label_StaticUserName;
        private System.Windows.Forms.Label label_StaticUserSector;
        private System.Windows.Forms.Label label_StaticUserOffice;
        private System.Windows.Forms.Label label_StaticUserDutyTime;
        private System.Windows.Forms.Label label_VariableUserName;
        private System.Windows.Forms.Label label_VariableUserSector;
        private System.Windows.Forms.Label label_VariableUserOffice;
        private System.Windows.Forms.Label label_VariableUserDutyTime;
        private System.Windows.Forms.Label label_StaticUserInformation;
        private System.Windows.Forms.GroupBox groupBox_StaticUserInfomation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_UserArriveTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_UserAddress;
    }
}