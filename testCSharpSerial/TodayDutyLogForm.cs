using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testCSharpSerial
{
    class TodayDutyLogForm : DutyLogTableForm
    {
        
        public TodayDutyLogForm(string dutyLogTableTitle) :base (dutyLogTableTitle)
        {
            
        }
        protected override string seachDutyLogSql()
        {
            string dutyDataTable = "select cdt,f_id,addr from f_user where cdt >='" + DateTime.Now.ToShortDateString() + "'";//今日记录
            return dutyDataTable;
        }
    }
}
