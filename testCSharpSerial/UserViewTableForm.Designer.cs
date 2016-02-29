namespace testCSharpSerial
{
    partial class UserViewTableForm
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
            this.cSharpSerialFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Column_UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_UserAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_UserSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_UserArriveTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_BornTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_UserAndTimeList)).BeginInit();
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
            this.Column_UserID,
            this.Column_UserName,
            this.Column_UserAddress,
            this.Column_UserSex,
            this.Column_UserArriveTime,
            this.Column_BornTime});
            this.dataGridView_UserAndTimeList.Location = new System.Drawing.Point(12, 46);
            this.dataGridView_UserAndTimeList.Name = "dataGridView_UserAndTimeList";
            this.dataGridView_UserAndTimeList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView_UserAndTimeList.RowTemplate.Height = 23;
            this.dataGridView_UserAndTimeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_UserAndTimeList.Size = new System.Drawing.Size(935, 494);
            this.dataGridView_UserAndTimeList.TabIndex = 20;
            // 
            // label_DutyLogTable
            // 
            this.label_DutyLogTable.AutoSize = true;
            this.label_DutyLogTable.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_DutyLogTable.ForeColor = System.Drawing.Color.Firebrick;
            this.label_DutyLogTable.Location = new System.Drawing.Point(377, 9);
            this.label_DutyLogTable.Name = "label_DutyLogTable";
            this.label_DutyLogTable.Size = new System.Drawing.Size(163, 29);
            this.label_DutyLogTable.TabIndex = 21;
            this.label_DutyLogTable.Text = "用户信息表";
            // 
            // cSharpSerialFormBindingSource
            // 
            this.cSharpSerialFormBindingSource.DataSource = typeof(testCSharpSerial.CSharpSerialForm);
            // 
            // Column_UserID
            // 
            this.Column_UserID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_UserID.DataPropertyName = "sbid";
            this.Column_UserID.FillWeight = 80F;
            this.Column_UserID.HeaderText = "用户ID";
            this.Column_UserID.Name = "Column_UserID";
            this.Column_UserID.ReadOnly = true;
            // 
            // Column_UserName
            // 
            this.Column_UserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_UserName.DataPropertyName = "name";
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
            // Column_UserSex
            // 
            this.Column_UserSex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_UserSex.DataPropertyName = "sex";
            this.Column_UserSex.FillWeight = 80F;
            this.Column_UserSex.HeaderText = "性别";
            this.Column_UserSex.Name = "Column_UserSex";
            this.Column_UserSex.ReadOnly = true;
            // 
            // Column_UserArriveTime
            // 
            this.Column_UserArriveTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_UserArriveTime.DataPropertyName = "army";
            this.Column_UserArriveTime.FillWeight = 80F;
            this.Column_UserArriveTime.HeaderText = "入职时间";
            this.Column_UserArriveTime.Name = "Column_UserArriveTime";
            this.Column_UserArriveTime.ReadOnly = true;
            // 
            // Column_BornTime
            // 
            this.Column_BornTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_BornTime.DataPropertyName = "born";
            this.Column_BornTime.FillWeight = 80F;
            this.Column_BornTime.HeaderText = "出生日期";
            this.Column_BornTime.Name = "Column_BornTime";
            this.Column_BornTime.ReadOnly = true;
            // 
            // UserViewTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 568);
            this.ControlBox = false;
            this.Controls.Add(this.label_DutyLogTable);
            this.Controls.Add(this.dataGridView_UserAndTimeList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserViewTableForm";
            this.Text = "执勤记录查看";
            this.Load += new System.EventHandler(this.UserViewTableForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_UserAndTimeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSharpSerialFormBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_UserAndTimeList;
        private System.Windows.Forms.Label label_DutyLogTable;
        private System.Windows.Forms.BindingSource cSharpSerialFormBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_UserAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_UserSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_UserArriveTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_BornTime;
    }
}