using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace testCSharpSerial
{
    public class MysqlClientLinkClass
    {
        public MySqlConnection MysqlDataBaseConnection;
        public bool isMysqlDataBaseConnected;
        public MysqlClientLinkClass()
        {
            isMysqlDataBaseConnected = false;
        }

        public bool LinkMysqlDataBase(string Server, string Database, string UserID, string Password)
        {
            //连接字符串
            string connectionLinkString = "";
            connectionLinkString = String.Format("Server='{0}';Database='{1}';Uid='{2}';Pwd='{3}';CharSet='utf8';", Server, Database, UserID, Password);

            try
            {
                MysqlDataBaseConnection = new MySqlConnection();
                MysqlDataBaseConnection.ConnectionString = connectionLinkString;
                MysqlDataBaseConnection.Open();//打开连接
                isMysqlDataBaseConnected = true;
                return true;
            }
            catch
            {
                isMysqlDataBaseConnected = false;
                return false;
            }
        }

        public bool closeMysqlDataBaseConnection()
        {
            if (MysqlDataBaseConnection != null && MysqlDataBaseConnection.State != ConnectionState.Closed)
            {
                try
                {
                    MysqlDataBaseConnection.Close();
                    MysqlDataBaseConnection.Dispose();
                    isMysqlDataBaseConnected = false;
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// 修改功能
        /// </summary>
        /// <param name="sql">修改语句</param>
        /// <returns></returns>
        public int ExecuteSqlCommand(string sqlCommandString)
        {
            MySqlCommand mySqlCommand = null;
            MySqlTransaction mySqlTransaction = null;
            int executedCount = 0;
            try
            {
                mySqlCommand = MysqlDataBaseConnection.CreateCommand();
                mySqlCommand.CommandText = sqlCommandString;

                //创建事务
                mySqlTransaction = MysqlDataBaseConnection.BeginTransaction();
                mySqlCommand.Transaction = mySqlTransaction;
                executedCount = mySqlCommand.ExecuteNonQuery();

                //事务提交
                mySqlTransaction.Commit();
            }
            catch
            {
                //事务回滚
                mySqlTransaction.Rollback();
            }
            return executedCount;
        }

        /// <summary>
        /// 获得数据集DataSet
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        /// 
        //DataTable tbl = ds.Tables[0];
        //foreach (DataRow row in tbl.Rows)
        //    foreach (DataColumn col in tbl.Columns)               
        //        MessageBox.Show(row[col].ToString());

        public DataTable getMysqlSelectDataTable(string mysqlCommandString)
        {
            DataSet dataSet = new DataSet();
            try
            {
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mysqlCommandString, MysqlDataBaseConnection);
                mySqlDataAdapter.Fill(dataSet, "data");
                return dataSet.Tables[0];
            }
            catch (System.Exception e)
            {
                MessageBox.Show("获取数据失败：" + e.Message);
                return new DataTable();
            }            
        }


        public DataRowCollection getMysqlSelectDataRows(string mysqlCommandString)
        {
            return getMysqlSelectDataTable(mysqlCommandString).Rows;
        }


    }
}
