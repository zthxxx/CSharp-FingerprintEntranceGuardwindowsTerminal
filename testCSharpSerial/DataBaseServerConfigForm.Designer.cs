namespace testCSharpSerial
{
    partial class DataBaseServerConfigForm
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
            this.label_DataBaseServerCongfig = new System.Windows.Forms.Label();
            this.label_DataBaseServerIP = new System.Windows.Forms.Label();
            this.label_DataBaseName = new System.Windows.Forms.Label();
            this.label_DataBaseUserName = new System.Windows.Forms.Label();
            this.label_DataBaseUserPassword = new System.Windows.Forms.Label();
            this.textBox_DataBaseServerIP = new System.Windows.Forms.TextBox();
            this.textBox_DataBaseName = new System.Windows.Forms.TextBox();
            this.textBox_DataBaseUserName = new System.Windows.Forms.TextBox();
            this.textBox_DataBaseUserPassword = new System.Windows.Forms.TextBox();
            this.button_TestLinkDataBase = new System.Windows.Forms.Button();
            this.button_SaveDataBaseConnection = new System.Windows.Forms.Button();
            this.label_isLinkDataBaseSuccessful = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_DataBaseServerCongfig
            // 
            this.label_DataBaseServerCongfig.AutoSize = true;
            this.label_DataBaseServerCongfig.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_DataBaseServerCongfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_DataBaseServerCongfig.Location = new System.Drawing.Point(368, 83);
            this.label_DataBaseServerCongfig.Name = "label_DataBaseServerCongfig";
            this.label_DataBaseServerCongfig.Size = new System.Drawing.Size(223, 29);
            this.label_DataBaseServerCongfig.TabIndex = 0;
            this.label_DataBaseServerCongfig.Text = "数据库连接配置";
            // 
            // label_DataBaseServerIP
            // 
            this.label_DataBaseServerIP.AutoSize = true;
            this.label_DataBaseServerIP.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_DataBaseServerIP.Location = new System.Drawing.Point(333, 146);
            this.label_DataBaseServerIP.Name = "label_DataBaseServerIP";
            this.label_DataBaseServerIP.Size = new System.Drawing.Size(104, 19);
            this.label_DataBaseServerIP.TabIndex = 1;
            this.label_DataBaseServerIP.Text = "数据库地址";
            // 
            // label_DataBaseName
            // 
            this.label_DataBaseName.AutoSize = true;
            this.label_DataBaseName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_DataBaseName.Location = new System.Drawing.Point(333, 194);
            this.label_DataBaseName.Name = "label_DataBaseName";
            this.label_DataBaseName.Size = new System.Drawing.Size(104, 19);
            this.label_DataBaseName.TabIndex = 2;
            this.label_DataBaseName.Text = "数据库名称";
            // 
            // label_DataBaseUserName
            // 
            this.label_DataBaseUserName.AutoSize = true;
            this.label_DataBaseUserName.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_DataBaseUserName.Location = new System.Drawing.Point(333, 242);
            this.label_DataBaseUserName.Name = "label_DataBaseUserName";
            this.label_DataBaseUserName.Size = new System.Drawing.Size(104, 19);
            this.label_DataBaseUserName.TabIndex = 3;
            this.label_DataBaseUserName.Text = "登录用户名";
            // 
            // label_DataBaseUserPassword
            // 
            this.label_DataBaseUserPassword.AutoSize = true;
            this.label_DataBaseUserPassword.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_DataBaseUserPassword.Location = new System.Drawing.Point(332, 290);
            this.label_DataBaseUserPassword.Name = "label_DataBaseUserPassword";
            this.label_DataBaseUserPassword.Size = new System.Drawing.Size(104, 19);
            this.label_DataBaseUserPassword.TabIndex = 4;
            this.label_DataBaseUserPassword.Text = "使用者密码";
            // 
            // textBox_DataBaseServerIP
            // 
            this.textBox_DataBaseServerIP.Location = new System.Drawing.Point(445, 146);
            this.textBox_DataBaseServerIP.Name = "textBox_DataBaseServerIP";
            this.textBox_DataBaseServerIP.Size = new System.Drawing.Size(179, 21);
            this.textBox_DataBaseServerIP.TabIndex = 5;
            this.textBox_DataBaseServerIP.Text = "localhost";
            // 
            // textBox_DataBaseName
            // 
            this.textBox_DataBaseName.Location = new System.Drawing.Point(445, 193);
            this.textBox_DataBaseName.Name = "textBox_DataBaseName";
            this.textBox_DataBaseName.Size = new System.Drawing.Size(179, 21);
            this.textBox_DataBaseName.TabIndex = 6;
            this.textBox_DataBaseName.Text = "sb_terminal";
            // 
            // textBox_DataBaseUserName
            // 
            this.textBox_DataBaseUserName.Location = new System.Drawing.Point(445, 241);
            this.textBox_DataBaseUserName.Name = "textBox_DataBaseUserName";
            this.textBox_DataBaseUserName.Size = new System.Drawing.Size(179, 21);
            this.textBox_DataBaseUserName.TabIndex = 7;
            this.textBox_DataBaseUserName.Text = "root";
            // 
            // textBox_DataBaseUserPassword
            // 
            this.textBox_DataBaseUserPassword.Location = new System.Drawing.Point(445, 288);
            this.textBox_DataBaseUserPassword.Name = "textBox_DataBaseUserPassword";
            this.textBox_DataBaseUserPassword.PasswordChar = '*';
            this.textBox_DataBaseUserPassword.ShortcutsEnabled = false;
            this.textBox_DataBaseUserPassword.Size = new System.Drawing.Size(179, 21);
            this.textBox_DataBaseUserPassword.TabIndex = 8;
            this.textBox_DataBaseUserPassword.Text = "yqmh927";
            // 
            // button_TestLinkDataBase
            // 
            this.button_TestLinkDataBase.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_TestLinkDataBase.Location = new System.Drawing.Point(337, 397);
            this.button_TestLinkDataBase.Name = "button_TestLinkDataBase";
            this.button_TestLinkDataBase.Size = new System.Drawing.Size(80, 30);
            this.button_TestLinkDataBase.TabIndex = 9;
            this.button_TestLinkDataBase.Text = "连接测试";
            this.button_TestLinkDataBase.UseVisualStyleBackColor = true;
            this.button_TestLinkDataBase.Click += new System.EventHandler(this.button_TestLinkDataBase_Click);
            // 
            // button_SaveDataBaseConnection
            // 
            this.button_SaveDataBaseConnection.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_SaveDataBaseConnection.Location = new System.Drawing.Point(546, 397);
            this.button_SaveDataBaseConnection.Name = "button_SaveDataBaseConnection";
            this.button_SaveDataBaseConnection.Size = new System.Drawing.Size(78, 31);
            this.button_SaveDataBaseConnection.TabIndex = 10;
            this.button_SaveDataBaseConnection.Text = "确认保存";
            this.button_SaveDataBaseConnection.UseVisualStyleBackColor = true;
            this.button_SaveDataBaseConnection.Click += new System.EventHandler(this.button_SaveDataBaseConnection_Click);
            // 
            // label_isLinkDataBaseSuccessful
            // 
            this.label_isLinkDataBaseSuccessful.AutoSize = true;
            this.label_isLinkDataBaseSuccessful.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_isLinkDataBaseSuccessful.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label_isLinkDataBaseSuccessful.Location = new System.Drawing.Point(413, 343);
            this.label_isLinkDataBaseSuccessful.Name = "label_isLinkDataBaseSuccessful";
            this.label_isLinkDataBaseSuccessful.Size = new System.Drawing.Size(53, 20);
            this.label_isLinkDataBaseSuccessful.TabIndex = 11;
            this.label_isLinkDataBaseSuccessful.Text = "    ";
            // 
            // DataBaseServerConfigForm
            // 
            this.AcceptButton = this.button_SaveDataBaseConnection;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 498);
            this.ControlBox = false;
            this.Controls.Add(this.label_isLinkDataBaseSuccessful);
            this.Controls.Add(this.button_SaveDataBaseConnection);
            this.Controls.Add(this.button_TestLinkDataBase);
            this.Controls.Add(this.textBox_DataBaseUserPassword);
            this.Controls.Add(this.textBox_DataBaseUserName);
            this.Controls.Add(this.textBox_DataBaseName);
            this.Controls.Add(this.textBox_DataBaseServerIP);
            this.Controls.Add(this.label_DataBaseUserPassword);
            this.Controls.Add(this.label_DataBaseUserName);
            this.Controls.Add(this.label_DataBaseName);
            this.Controls.Add(this.label_DataBaseServerIP);
            this.Controls.Add(this.label_DataBaseServerCongfig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DataBaseServerConfigForm";
            this.Text = "6";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DataBaseServerConfigForm_FormClosed);
            this.Load += new System.EventHandler(this.DataBaseServerConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_DataBaseServerCongfig;
        private System.Windows.Forms.Label label_DataBaseServerIP;
        private System.Windows.Forms.Label label_DataBaseName;
        private System.Windows.Forms.Label label_DataBaseUserName;
        private System.Windows.Forms.Label label_DataBaseUserPassword;
        private System.Windows.Forms.TextBox textBox_DataBaseServerIP;
        private System.Windows.Forms.TextBox textBox_DataBaseName;
        private System.Windows.Forms.TextBox textBox_DataBaseUserName;
        private System.Windows.Forms.TextBox textBox_DataBaseUserPassword;
        private System.Windows.Forms.Button button_TestLinkDataBase;
        private System.Windows.Forms.Button button_SaveDataBaseConnection;
        private System.Windows.Forms.Label label_isLinkDataBaseSuccessful;
    }
}