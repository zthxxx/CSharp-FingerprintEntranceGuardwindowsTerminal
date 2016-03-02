using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testCSharpSerial
{
    class AnalysisPacketBytesData
    {
        public int atLeastPacketBytesCount;
        public byte[] AnalysisPacketStratData;//包头
        public byte[] AnalysisAddressData;//地址
        public byte AnalysisPacketSignByte;//包标识
        public byte[] AnalysisPacketFollowLengthData;//后续字节长度
        public int AnalysisPacketFollowLength;//后续字节长度
        public int AnalysisPacketUserDataLength;//用户数据字节长度 为后续字节长度减响应与检验共3字节
        public byte AnalysisResponseCommandByte;//响应指令
        public byte[] AnalysisUserSendData;//实际传输数据
        public byte[] AnalysisCheckSumData;//校验和
        public int AnalysisCheckSum;//校验和值
        public bool isThePacketEnd = true;
        public Queue<byte> receiveBytesDataFIFO;
        private byte[] standardPocketStartData;
        private byte[] standardPocketAddresData;
        private byte standarUserIDHead;
        public AnalysisPacketBytesData()
        {
            memberInitialise();
        }
        public void memberInitialise()//初始化成员
        {
            atLeastPacketBytesCount = 12;
            AnalysisPacketStratData = new byte[2];
            AnalysisAddressData = new byte[4];
            AnalysisPacketSignByte = 0x00;
            AnalysisPacketFollowLengthData = new byte[2];
            AnalysisPacketFollowLength = 0;
            AnalysisResponseCommandByte = 0x00;
            AnalysisCheckSumData = new byte[2];
            receiveBytesDataFIFO = new Queue<byte>();
            standardPocketStartData = GlobalVariableClass.fingerprintPocketData.PACKET_STRAT_DATA;
            standardPocketAddresData = GlobalVariableClass.fingerprintPocketData.PACKET_ADDRESS_DATA;
            standarUserIDHead = GlobalVariableClass.fingerprintPocketData.USER_ID_PREFIX_BYTE;
        }
        private byte[] queueDataPop(ref byte[] queueTpBytesData, int outCount)
        {
            if (receiveBytesDataFIFO.Count < outCount)
                return null;
            if (queueTpBytesData.Length < outCount)
                return null;
            int elementCount = 0;
            for (elementCount = 0; elementCount < outCount; elementCount++)
            {
                queueTpBytesData[elementCount] = receiveBytesDataFIFO.Dequeue();
            }

            return queueTpBytesData;
        }
        private byte queueDataPop(ref byte queueTpBytesData, int outCount)
        {
            if (receiveBytesDataFIFO.Count < outCount) return 0;
            if (outCount > 1) return 0;
            queueTpBytesData = receiveBytesDataFIFO.Dequeue();
            return queueTpBytesData;
        }
        public int getValueFromBytesToInt(byte[] bytes)
        {
            int byteNumIndex = 1;
            int SumValue = 0;
            foreach (byte byteNum in bytes)
            {
                SumValue += (int)byteNum << (8 * (bytes.Length - byteNumIndex));
                byteNumIndex += 1;
            }
            return SumValue;
        }
        public bool dataLoadFromQueue()//从队列导入数据
        {
            if (isThePacketEnd)
            {
                if (receiveBytesDataFIFO.Count < atLeastPacketBytesCount) return false;//至少大于基础解析字节长
                do
                {
                    if (receiveBytesDataFIFO.Count == 0) return false;//至少长度不能为零
                    AnalysisPacketStratData[0] = AnalysisPacketStratData[1];
                    AnalysisPacketStratData[1] = receiveBytesDataFIFO.Dequeue();
                } while (!AnalysisPacketStratData.SequenceEqual(standardPocketStartData));
                if (receiveBytesDataFIFO.Count < atLeastPacketBytesCount - 2) return false;//至少大于基础解析字节长除开包头2字节

                queueDataPop(ref AnalysisAddressData, 4);
                queueDataPop(ref AnalysisPacketSignByte, 1);
                queueDataPop(ref AnalysisPacketFollowLengthData, 2);
                AnalysisPacketFollowLength = getValueFromBytesToInt(AnalysisPacketFollowLengthData);
                AnalysisPacketUserDataLength = AnalysisPacketFollowLength - 3;//后续字节长除开响应与检验和的3字节
            }            
            if (receiveBytesDataFIFO.Count < AnalysisPacketFollowLength)//小于加上用户数据长度
            {
                isThePacketEnd = false;
                return false;
            }
            else
            {
                queueDataPop(ref AnalysisResponseCommandByte, 1);
                AnalysisUserSendData = new byte[AnalysisPacketUserDataLength];
                queueDataPop(ref AnalysisUserSendData, AnalysisPacketUserDataLength);
                queueDataPop(ref AnalysisCheckSumData, 2);
                AnalysisCheckSum = getValueFromBytesToInt(AnalysisCheckSumData);
                isThePacketEnd = true;
                return true;
            }            
        }
        public bool checkPacketCheckSumData()
        {
            int thePacketCheckSum;
            int count = 0;
            bool isPacketSumRight = false;
            thePacketCheckSum = AnalysisPacketSignByte + AnalysisPacketFollowLength + AnalysisResponseCommandByte;
            for(count = 0; count < AnalysisPacketUserDataLength; count++)
            {
                thePacketCheckSum += AnalysisUserSendData[count];
            }
            if(thePacketCheckSum == AnalysisCheckSum)
            {
                isPacketSumRight = true;
            }
            return isPacketSumRight;
        }

        public void dataInitialise(byte[] bytesData)//导出数据 只用数组没用FIFO缓冲  不安全 因此放弃此方法
        {
            if (!(bytesData.Length >= atLeastPacketBytesCount)) return;//基础解析字节长12
            Array.Copy(bytesData, 0, AnalysisPacketStratData, 0, 2);
            Array.Copy(bytesData, 2, AnalysisAddressData, 0, 4);
            AnalysisPacketSignByte = bytesData[6];
            Array.Copy(bytesData, 7, AnalysisPacketFollowLengthData, 0, 2);
            AnalysisPacketFollowLength = getValueFromBytesToInt(AnalysisPacketFollowLengthData) - 3;
            AnalysisResponseCommandByte = bytesData[9];
            AnalysisUserSendData = new byte[AnalysisPacketFollowLength];
            Array.Copy(bytesData, 10, AnalysisUserSendData, 0, AnalysisPacketFollowLength);
            Array.Copy(bytesData, 10 + AnalysisPacketFollowLength, AnalysisCheckSumData, 0, 2);
        }
        private String ByteToHexString(byte[] hexBytes, bool isUseSegmentationSign)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string hexFormatString = "";
            string segmentationSign = "";
            if (isUseSegmentationSign)
            {
                segmentationSign = " ";
            }
            foreach (byte oneByte in hexBytes)
            {
                hexFormatString = oneByte.ToString("X2").ToUpper() + segmentationSign;
                stringBuilder.Append(hexFormatString);
            }
            return stringBuilder.ToString();
        }
        private String ByteToHexString(byte[] hexBytes)
        {
            return ByteToHexString(hexBytes, true);
        }

        private String ByteToASCIIString(byte[] bcd)
        {
            StringBuilder sb = new StringBuilder();
            string szHexFormatStr;
            szHexFormatStr = Encoding.ASCII.GetString(bcd);
            sb.Append(szHexFormatStr);
            return sb.ToString();
        }

        public int GetUserIDInt(byte[] userIDHexBytes)
        {
            int userIDNum = 0;
            if (userIDHexBytes[0] == standarUserIDHead)//用户ID头标记
            {
                userIDNum = (userIDHexBytes[1] & 0x00FF) << 8;
                userIDNum += (userIDHexBytes[2] & 0x00FF);
                return userIDNum;
            }
            return 0;
        }

        private String DataToTimeFormat(byte[] timeData)//20160101123045的ASCII码时间戳格式化成2016/01/01 12:30:45 
        {
            string timeFormat = "";
            byte[] timeASCIIArray;
            timeASCIIArray = new byte[2];
            Array.Copy(timeData, 0, timeASCIIArray, 0, 2);
            timeFormat = ByteToASCIIString(timeASCIIArray);
            Array.Copy(timeData, 2, timeASCIIArray, 0, 2);
            timeFormat += ByteToASCIIString(timeASCIIArray) + "/";
            Array.Copy(timeData, 4, timeASCIIArray, 0, 2);
            timeFormat += ByteToASCIIString(timeASCIIArray) + "/";
            Array.Copy(timeData, 6, timeASCIIArray, 0, 2);
            timeFormat += ByteToASCIIString(timeASCIIArray) + " ";
            Array.Copy(timeData, 8, timeASCIIArray, 0, 2);
            timeFormat += ByteToASCIIString(timeASCIIArray) + ":";
            Array.Copy(timeData, 10, timeASCIIArray, 0, 2);
            timeFormat += ByteToASCIIString(timeASCIIArray) + ":";
            Array.Copy(timeData, 12, timeASCIIArray, 0, 2);
            timeFormat += ByteToASCIIString(timeASCIIArray);
            return timeFormat;
        }
        public void DataToTimeFormatAndUserID(byte[] timeUserData, byte[] packetAddressData, out string timeFormatString, out string userIDString, out string userAddressString)//将时间戳与用户ID解析分开
        {
            byte timeDataBytesLength = 14; ;
            byte[] timeASCIIBytes = new byte[timeDataBytesLength];
            byte[] userIDHexBytes;
            int userIDNum = 0;
            Array.Copy(timeUserData, 0, timeASCIIBytes, 0, timeDataBytesLength);
            timeFormatString = DataToTimeFormat(timeASCIIBytes);

            userIDHexBytes = new byte[timeUserData.Length - timeDataBytesLength];
            Array.Copy(timeUserData, timeDataBytesLength, userIDHexBytes, 0, timeUserData.Length - timeDataBytesLength);
            userIDNum = GetUserIDInt(userIDHexBytes);
            userIDString = userIDNum.ToString("D4");

            userAddressString = ByteToHexString(packetAddressData, false);
        }
        public void DataToTimeFormatAndUserID(byte[] timeUserData, out string timeFormatString, out string userIDString)//将时间戳与用户ID解析分开
        {
            byte timeDataBytesLength = 14; ;
            byte[] timeASCIIBytes = new byte[timeDataBytesLength];
            byte[] userIDHexBytes;
            int userIDNum = 0;
            Array.Copy(timeUserData, 0, timeASCIIBytes, 0, timeDataBytesLength);
            timeFormatString = DataToTimeFormat(timeASCIIBytes);

            userIDHexBytes = new byte[timeUserData.Length - timeDataBytesLength];
            Array.Copy(timeUserData, timeDataBytesLength, userIDHexBytes, 0, timeUserData.Length - timeDataBytesLength);
            userIDNum = GetUserIDInt(userIDHexBytes);
            userIDString = userIDNum.ToString("D4");
        }
        private String DataToTimeFormatAndUserID(byte[] timeUserData)//将时间戳与用户ID解析分开
        {
            string timeFormatString = "";
            string userIDString = "";
            DataToTimeFormatAndUserID(timeUserData, out timeFormatString, out userIDString);
            return timeFormatString + "  " + userIDString;
        }
        public string getPacketStratDataHex()//返回包头数据
        {
            return ByteToHexString(AnalysisPacketStratData);
        }
        public string getPacketAddressDataHex()//返回地址数据
        {
            return ByteToHexString(AnalysisAddressData);
        }
        public string getPacketSignDataHex()//返回包标识数据
        {
            return AnalysisPacketSignByte.ToString("X2").ToUpper() + " ";
        }
        public string getPacketFollowLengthDataHex()//返回后续长度字节数据
        {
            return ByteToHexString(AnalysisPacketFollowLengthData);
        }
        public string getPacketResponseCommandDataHex()//返回响应指令数据
        {
            return AnalysisResponseCommandByte.ToString("X2").ToUpper() + " ";
        }
        public string getPacketUserSendDataHex()//返回用户发送数据
        {
            switch (AnalysisPacketSignByte)
            {
                case 0x01:
                case 0x02:
                case 0x06:
                    return DataToTimeFormatAndUserID(AnalysisUserSendData);
                    break;
                case 0x05:
                    return DataToTimeFormat(AnalysisUserSendData);
                    break;
            }

            return ByteToHexString(AnalysisUserSendData);
        }
        public string getPacketCheckSumDataHex()//返回校验和数据
        {
            return ByteToHexString(AnalysisCheckSumData);
        }
        public string getPacketAllDataHex()
        {
            return getPacketStratDataHex() + getPacketAddressDataHex() + getPacketSignDataHex() + getPacketFollowLengthDataHex() + getPacketResponseCommandDataHex() + ByteToHexString(AnalysisUserSendData) + getPacketCheckSumDataHex();
        }
        public string getPacketPacketSignDataMeaing()//返回包标识含义
        {
            string signBitMeaing = "";
            switch (AnalysisPacketSignByte)
            {
                case 0x00:
                    signBitMeaing = "无";
                    break;
                case 0x01:
                    signBitMeaing = "当前用户ID";
                    break;
                case 0x02:
                    signBitMeaing = "新增用户ID";
                    break;
                case 0x03:
                    signBitMeaing = "当前用户指纹";
                    break;
                case 0x04:
                    signBitMeaing = "新增用户指纹";
                    break;
                case 0x05:
                    signBitMeaing = "时间戳";
                    break;
                case 0x06:
                    signBitMeaing = "导入用户ID";
                    break;
                case 0x07:
                    signBitMeaing = "导入用户指纹";
                    break;
                case 0x08:
                    signBitMeaing = "校对时间";
                    break;
                case 0x09:
                    signBitMeaing = "删除用户ID";
                    break;
                case 0x10:
                    signBitMeaing = "清除所有用户";
                    break;
                case 0x11:
                    signBitMeaing = "上位机故障后重启";
                    break;
                case 0x12:
                    signBitMeaing = "导出所有用户指纹";
                    break;
                case 0x13:
                    signBitMeaing = "请求重发上一包";
                    break;
            }
            return signBitMeaing;
        }
        public string getPacketResponseCommandDataMeaing()//返回响应指令含义
        {
            string responseBitMeaing = "";
            switch (AnalysisResponseCommandByte)
            {
                case 0x00:
                    responseBitMeaing = "无";
                    break;
                case 0x01:
                    responseBitMeaing = "接受成功";
                    break;
                case 0x02:
                    responseBitMeaing = "接收失败";
                    break;
                case 0x03:
                    responseBitMeaing = "包头";
                    break;
                case 0x04:
                    responseBitMeaing = "包间";
                    break;
                case 0x05:
                    responseBitMeaing = "包尾";
                    break;
                case 0x06:
                    responseBitMeaing = "时间读取失败";
                    break;
                case 0x07:
                    responseBitMeaing = "指纹读取失败";
                    break;
                case 0x08:
                    responseBitMeaing = "用户为空";
                    break;
                case 0x09:
                    responseBitMeaing = "校验和错误";
                    break;
                case 0x10:
                    responseBitMeaing = "重发上一包请求";
                    break;
                case 0x11:
                    responseBitMeaing = "清除用户成功";
                    break;
                case 0x12:
                    responseBitMeaing = "清除用户失败";
                    break;
                case 0x13:
                    responseBitMeaing = "重置时间成功";
                    break;
                case 0x14:
                    responseBitMeaing = "重置时间失败";
                    break;
            }
            return responseBitMeaing;
        }
    }
}
