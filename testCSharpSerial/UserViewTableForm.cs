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
    public partial class UserViewTableForm : Form
    {
        public MysqlClientLinkClass mysqlClientLinkClass;//debug
        public UserViewTableForm()
        {
            InitializeComponent();
            GlobalVariableClass.multicastDataBaseObjectEvent += receiveDataBaseObject;
        }

        private void UserViewTableForm_Load(object sender, EventArgs e)
        {

        }
        public void receiveDataBaseObject(MysqlClientLinkClass dataBaseObject)
        {
            DataTable dutyDataTable;
            mysqlClientLinkClass = dataBaseObject;
            if (mysqlClientLinkClass.isMysqlDataBaseConnected)
            {
                    dutyDataTable = mysqlClientLinkClass.getMysqlSelectDataTable("select sbid,name,sex,army,born from sb_info ");//今日记录
                    dataGridView_UserAndTimeList.DataSource = dutyDataTable;
            }
        }
    }
}
