using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testCSharpSerial
{
    class HistoryDutyLogForm : DutyLogTableForm
    {
        public HistoryDutyLogForm(string dutyLogTableTitle) :base (dutyLogTableTitle)
        {
        }
        protected override string seachDutyLogSql()
        {
            string dutyDataTable = "select cdt,f_id,addr from f_user ";//今日记录
            return dutyDataTable;
        }
    }
}
