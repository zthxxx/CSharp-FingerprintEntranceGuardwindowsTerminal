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
    public partial class DataBaseServerConfigForm : Form
    {
        public MysqlClientLinkClass mysqlClientLinkClass;
        public bool isDataBaseServerConfigFinished;
        public GlobalVariableClass.configFinishedJump configFinishedJump;

        public DataBaseServerConfigForm(GlobalVariableClass.configFinishedJump thisInvoke)
        {
            InitializeComponent();
            configFinishedJump = thisInvoke;
            mysqlClientLinkClass = new MysqlClientLinkClass();
            isDataBaseServerConfigFinished = false;
        }
        private void DataBaseServerConfigForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mysqlClientLinkClass.closeMysqlDataBaseConnection();
        }

        private void DataBaseServerConfigForm_Load(object sender, EventArgs e)
        {
            connectAndMulticastMysqlDataBaseObject();
        }
        private void getDataBaseConfigParameter(out string DataBaseServerIP,out string DataBaseName, out string DataBaseUserName, out string DataBaseUserPassword)
        {
            DataBaseServerIP = textBox_DataBaseServerIP.Text;
            DataBaseName = textBox_DataBaseName.Text;
            DataBaseUserName = textBox_DataBaseUserName.Text;
            DataBaseUserPassword = textBox_DataBaseUserPassword.Text;
        }

        private bool establishOneDataBaseConnection()
        {
            string DataBaseServerIP;
            string DataBaseName;
            string DataBaseUserName;
            string DataBaseUserPassword;

            getDataBaseConfigParameter(out DataBaseServerIP, out DataBaseName, out DataBaseUserName, out DataBaseUserPassword);

            isDataBaseServerConfigFinished = mysqlClientLinkClass.LinkMysqlDataBase(DataBaseServerIP, DataBaseName, DataBaseUserName, DataBaseUserPassword);
            
            return isDataBaseServerConfigFinished;
        }


        public bool linkDataBaseTest()
        {

            if (establishOneDataBaseConnection())
            {
                mysqlClientLinkClass.closeMysqlDataBaseConnection();
                label_isLinkDataBaseSuccessful.Text = "*连接测试成功！";
                label_isLinkDataBaseSuccessful.ForeColor = System.Drawing.Color.FromKnownColor(KnownColor.Green);
                return true;
            }
            else
            {
                label_isLinkDataBaseSuccessful.Text = "*连接测试失败！";
                label_isLinkDataBaseSuccessful.ForeColor = System.Drawing.Color.FromKnownColor(KnownColor.Red);
                return false;
            }

        }
        private void button_TestLinkDataBase_Click(object sender, EventArgs e)
        {
            linkDataBaseTest();
        }
        public void connectAndMulticastMysqlDataBaseObject()
        {
            if (establishOneDataBaseConnection())
            {
                GlobalVariableClass.multicastMysqlDataBaseObject(mysqlClientLinkClass);
            }
        }
        private void button_SaveDataBaseConnection_Click(object sender, EventArgs e)
        {
            connectAndMulticastMysqlDataBaseObject();
            configFinishedJump();
        }
    }
}
