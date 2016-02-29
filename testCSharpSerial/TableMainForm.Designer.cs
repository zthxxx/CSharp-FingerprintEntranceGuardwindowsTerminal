namespace testCSharpSerial
{
    partial class TableMainForm
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
            this.menuStrip_MainTablePageMenu = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.basisConfig_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataBaseConfig_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverLinkConfig_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fingerConfig_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManage_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userView_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userModify_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dutyLog_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todayRecord_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allTheRecord_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helper_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userInstruction_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_MainTablePageMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip_MainTablePageMenu
            // 
            this.menuStrip_MainTablePageMenu.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip_MainTablePageMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.basisConfig_ToolStripMenuItem,
            this.userManage_ToolStripMenuItem,
            this.dutyLog_ToolStripMenuItem,
            this.helper_ToolStripMenuItem});
            this.menuStrip_MainTablePageMenu.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_MainTablePageMenu.Name = "menuStrip_MainTablePageMenu";
            this.menuStrip_MainTablePageMenu.Size = new System.Drawing.Size(960, 29);
            this.menuStrip_MainTablePageMenu.TabIndex = 0;
            this.menuStrip_MainTablePageMenu.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 25);
            // 
            // basisConfig_ToolStripMenuItem
            // 
            this.basisConfig_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataBaseConfig_ToolStripMenuItem,
            this.serverLinkConfig_ToolStripMenuItem,
            this.fingerConfig_ToolStripMenuItem});
            this.basisConfig_ToolStripMenuItem.Name = "basisConfig_ToolStripMenuItem";
            this.basisConfig_ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.basisConfig_ToolStripMenuItem.Text = "基本配置";
            // 
            // dataBaseConfig_ToolStripMenuItem
            // 
            this.dataBaseConfig_ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataBaseConfig_ToolStripMenuItem.Name = "dataBaseConfig_ToolStripMenuItem";
            this.dataBaseConfig_ToolStripMenuItem.Size = new System.Drawing.Size(149, 24);
            this.dataBaseConfig_ToolStripMenuItem.Text = "数据库配置";
            this.dataBaseConfig_ToolStripMenuItem.Click += new System.EventHandler(this.dataBaseConfig_ToolStripMenuItem_Click);
            // 
            // serverLinkConfig_ToolStripMenuItem
            // 
            this.serverLinkConfig_ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.serverLinkConfig_ToolStripMenuItem.Name = "serverLinkConfig_ToolStripMenuItem";
            this.serverLinkConfig_ToolStripMenuItem.Size = new System.Drawing.Size(149, 24);
            this.serverLinkConfig_ToolStripMenuItem.Text = "服务器配置";
            // 
            // fingerConfig_ToolStripMenuItem
            // 
            this.fingerConfig_ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fingerConfig_ToolStripMenuItem.Name = "fingerConfig_ToolStripMenuItem";
            this.fingerConfig_ToolStripMenuItem.Size = new System.Drawing.Size(149, 24);
            this.fingerConfig_ToolStripMenuItem.Text = "指纹机配置";
            this.fingerConfig_ToolStripMenuItem.Click += new System.EventHandler(this.fingerConfig_ToolStripMenuItem_Click);
            // 
            // userManage_ToolStripMenuItem
            // 
            this.userManage_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userView_ToolStripMenuItem,
            this.userModify_ToolStripMenuItem});
            this.userManage_ToolStripMenuItem.Name = "userManage_ToolStripMenuItem";
            this.userManage_ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.userManage_ToolStripMenuItem.Text = "用户管理";
            // 
            // userView_ToolStripMenuItem
            // 
            this.userView_ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userView_ToolStripMenuItem.Name = "userView_ToolStripMenuItem";
            this.userView_ToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.userView_ToolStripMenuItem.Text = "查看用户";
            this.userView_ToolStripMenuItem.Click += new System.EventHandler(this.userView_ToolStripMenuItem_Click);
            // 
            // userModify_ToolStripMenuItem
            // 
            this.userModify_ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userModify_ToolStripMenuItem.Name = "userModify_ToolStripMenuItem";
            this.userModify_ToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.userModify_ToolStripMenuItem.Text = "修改用户";
            // 
            // dutyLog_ToolStripMenuItem
            // 
            this.dutyLog_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.todayRecord_ToolStripMenuItem,
            this.allTheRecord_ToolStripMenuItem});
            this.dutyLog_ToolStripMenuItem.Name = "dutyLog_ToolStripMenuItem";
            this.dutyLog_ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.dutyLog_ToolStripMenuItem.Text = "执勤记录";
            // 
            // todayRecord_ToolStripMenuItem
            // 
            this.todayRecord_ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.todayRecord_ToolStripMenuItem.Name = "todayRecord_ToolStripMenuItem";
            this.todayRecord_ToolStripMenuItem.Size = new System.Drawing.Size(135, 24);
            this.todayRecord_ToolStripMenuItem.Text = "今日记录";
            this.todayRecord_ToolStripMenuItem.Click += new System.EventHandler(this.todayRecord_ToolStripMenuItem_Click);
            // 
            // allTheRecord_ToolStripMenuItem
            // 
            this.allTheRecord_ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.allTheRecord_ToolStripMenuItem.Name = "allTheRecord_ToolStripMenuItem";
            this.allTheRecord_ToolStripMenuItem.Size = new System.Drawing.Size(135, 24);
            this.allTheRecord_ToolStripMenuItem.Text = "历史纪录";
            this.allTheRecord_ToolStripMenuItem.Click += new System.EventHandler(this.allTheRecord_ToolStripMenuItem_Click);
            // 
            // helper_ToolStripMenuItem
            // 
            this.helper_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userInstruction_ToolStripMenuItem});
            this.helper_ToolStripMenuItem.Name = "helper_ToolStripMenuItem";
            this.helper_ToolStripMenuItem.Size = new System.Drawing.Size(54, 25);
            this.helper_ToolStripMenuItem.Text = "帮助";
            // 
            // userInstruction_ToolStripMenuItem
            // 
            this.userInstruction_ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userInstruction_ToolStripMenuItem.Name = "userInstruction_ToolStripMenuItem";
            this.userInstruction_ToolStripMenuItem.Size = new System.Drawing.Size(135, 24);
            this.userInstruction_ToolStripMenuItem.Text = "使用说明";
            // 
            // TableMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 618);
            this.Controls.Add(this.menuStrip_MainTablePageMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip_MainTablePageMenu;
            this.Name = "TableMainForm";
            this.Text = "指纹机终端";
            this.Load += new System.EventHandler(this.FormTableMain_Load);
            this.menuStrip_MainTablePageMenu.ResumeLayout(false);
            this.menuStrip_MainTablePageMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip_MainTablePageMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem basisConfig_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManage_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dutyLog_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helper_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataBaseConfig_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverLinkConfig_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fingerConfig_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userView_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userModify_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todayRecord_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allTheRecord_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userInstruction_ToolStripMenuItem;
    }
}