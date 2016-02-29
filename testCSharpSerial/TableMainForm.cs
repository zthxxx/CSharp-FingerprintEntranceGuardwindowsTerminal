using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testCSharpSerial
{


    public partial class TableMainForm : Form
    {
        public CSharpSerialForm fingerConfigForm; 
        public DutyLogTableForm todayDutyLogTableForm;
        public DutyLogTableForm historyDutyLogTableForm;
        public DataBaseServerConfigForm dataBaseServerConfigForm;
        public UserViewTableForm userViewTableForm;

        public TableMainForm()
        {
            InitializeComponent();
            todayDutyLogTableForm = new DutyLogTableForm(GlobalVariableClass.todayDutylog);
            historyDutyLogTableForm = new DutyLogTableForm(GlobalVariableClass.historyDutylog);
            fingerConfigForm = new CSharpSerialForm(new GlobalVariableClass.configFinishedJump(configFinishedJumpOtherForm));
            dataBaseServerConfigForm = new DataBaseServerConfigForm(new GlobalVariableClass.configFinishedJump(configFinishedJumpOtherForm));
            userViewTableForm = new UserViewTableForm();
        }

        private void FormTableMain_Load(object sender, EventArgs e)
        {
            midChildFormConfig(fingerConfigForm);
            midChildFormConfig(historyDutyLogTableForm);
            midChildFormConfig(todayDutyLogTableForm);
            midChildFormConfig(dataBaseServerConfigForm);
            midChildFormConfig(userViewTableForm);
            fingerConfigForm.Activate();
        }

        private void midChildFormConfig(Object midChildFormObj)
        {
            Form midChildForm;
            midChildForm = (Form)midChildFormObj;
            midChildForm.MdiParent = this;
            midChildForm.WindowState = FormWindowState.Maximized;
            midChildForm.Dock = DockStyle.Fill;
            midChildForm.StartPosition = FormStartPosition.CenterParent;
            midChildForm.Show();
        }

        private void fingerConfig_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fingerConfigForm.Activate();
        }

        private void todayRecord_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            todayDutyLogTableForm.Activate();
        }

        private void dataBaseConfig_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataBaseServerConfigForm.Activate();
        }

        private void allTheRecord_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            historyDutyLogTableForm.Activate();
        }
        public void configFinishedJumpOtherForm()
        {
            if(fingerConfigForm.isSerialPortConfigFinished)
            {
                if(dataBaseServerConfigForm.isDataBaseServerConfigFinished)
                {
                    todayDutyLogTableForm.Activate();
                }
                else
                {
                    dataBaseServerConfigForm.Activate();
                }
            }
            else
            {
                fingerConfigForm.Activate();
            }
        }

        private void userView_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userViewTableForm.Activate();
        }
    }
}
