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
    public partial class DutyLogTableForm : Form
    {
        public MysqlClientLinkClass mysqlClientLinkClass;//debug
        private bool isTodayDutyLog;
        public DutyLogTableForm(bool isTodayDutyLog)
        {
            InitializeComponent();
            GlobalVariableClass.AddDutyRecordDataGridViewEvent += addOneRecordToDataGridView;
            GlobalVariableClass.multicastDataBaseObjectEvent += receiveDataBaseObject;
            this.isTodayDutyLog = isTodayDutyLog;
            if (this.isTodayDutyLog)
            {
                label_DutyLogTable.Text = "今日执勤记录表";
                GlobalVariableClass.AddDutyRecordDataGridViewEvent += insertOneDutyLogIntoDataBase;
            }
            else
            {
                label_DutyLogTable.Text = "历史执勤记录表";
            }
        }

        private void DutyLogTableForm_Load(object sender, EventArgs e)
        {

        }
        public void receiveDataBaseObject(MysqlClientLinkClass dataBaseObject)
        {
            DataTable dutyDataTable;
            mysqlClientLinkClass = dataBaseObject;
            if (mysqlClientLinkClass.isMysqlDataBaseConnected)
            {
                if (isTodayDutyLog)
                {
                    dutyDataTable = mysqlClientLinkClass.getMysqlSelectDataTable("select cdt,f_id,addr from f_user where cdt >='" + DateTime.Now.ToShortDateString() + "'");//今日记录
                }
                else
                {
                    dutyDataTable = mysqlClientLinkClass.getMysqlSelectDataTable("select cdt,f_id,addr from f_user ");//所有记录
                }
                dataGridView_UserAndTimeList.DataSource = dutyDataTable;
            }
        }

        public void addOneRecordToDataGridView(string timeString, string userIDNum, string userAddressString)
        {
            if (dataGridView_UserAndTimeList.DataSource != null)
            {
                DataTable dataSourceTable = (DataTable)dataGridView_UserAndTimeList.DataSource;
                DataRow oneUserAndTimeRecord = dataSourceTable.NewRow();
                oneUserAndTimeRecord[0] = timeString;
                oneUserAndTimeRecord[1] = userIDNum;
                oneUserAndTimeRecord[2] = userAddressString;
                dataSourceTable.Rows.Add(oneUserAndTimeRecord);
            }
        }

        public void insertOneDutyLogIntoDataBase(string timeString, string userIDNum, string userAddressString)
        {
            string sqlCommandString = "";
            if (mysqlClientLinkClass != null)
            {
                sqlCommandString = "insert into f_user(f_id,addr,state,cdt,usid) values('" + userIDNum + "','" + userAddressString + "','正常','" + timeString + "',0)";
                try
                {
                    mysqlClientLinkClass.ExecuteSqlCommand(sqlCommandString);
                }
                catch
                {
                    MessageBox.Show("数据库插入失败！");
                }
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

        private void dataGridView_UserAndTimeList_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_UserAndTimeList.SelectedRows.Count > 0 && dataGridView_UserAndTimeList.SelectedRows[0].Index < dataGridView_UserAndTimeList.RowCount - 1 )//&& dataGridView_UserAndTimeList.SelectedRows[0].Cells[0].Value != null
            {
                DataRow dataRow = (dataGridView_UserAndTimeList.SelectedRows[0].DataBoundItem as DataRowView).Row;
                if (dataRow[0] != null)
                {
                    label_VariableUserDutyTime.Text = dataRow[0].ToString();
                    label_VariableUserName.Text = dataRow[1].ToString();
                    label_VariableUserSector.Text = dataRow[2].ToString();
                }
            }
            else
            {
                label_VariableUserSector.Text = label_VariableUserName.Text = "";
            }
        }
    }
}
