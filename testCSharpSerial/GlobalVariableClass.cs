using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testCSharpSerial
{
    public static class GlobalVariableClass
    {
        public static FingerprintPocketData fingerprintPocketData = new FingerprintPocketData(true);
        public delegate void addOneRecordToDataGridView(string timeString, string userIDNum, string userAddressString);
        public static event addOneRecordToDataGridView AddDutyRecordDataGridViewEvent;
        public delegate void multicastDataBaseObject(MysqlClientLinkClass dataBaseObject);
        public static event multicastDataBaseObject multicastDataBaseObjectEvent;
        public delegate void configFinishedJump();
        public static bool todayDutylog = true;
        public static bool historyDutylog = false;

        public struct FingerprintPocketData
        {
            public byte[] PACKET_STRAT_DATA;
            public byte[] PACKET_ADDRESS_DATA;
            public byte[] PACKET_ADDRESS_READ_REQUEST_DATA;
            public byte USER_ID_PREFIX_BYTE;
            public FingerprintPocketData(bool isInitialise)
            {
                PACKET_STRAT_DATA = new byte[] { 0xEF, 0x02 };
                PACKET_ADDRESS_DATA = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF };
                PACKET_ADDRESS_READ_REQUEST_DATA = new byte[] { 0xFF, 0xEE, 0xDD, 0xCC };
                USER_ID_PREFIX_BYTE = 0xAB;
            }
        }
        public static void addDutyRecord(string timeString, string userIDNum, string userAddressString)
        {
            if (AddDutyRecordDataGridViewEvent != null)
            {
                AddDutyRecordDataGridViewEvent(timeString, userIDNum, userAddressString);
            }
        }
        public static void multicastMysqlDataBaseObject(MysqlClientLinkClass dataBaseObject)
        {
            if (multicastDataBaseObjectEvent != null)
            {
                multicastDataBaseObjectEvent(dataBaseObject);
            }
        }
    }
}
