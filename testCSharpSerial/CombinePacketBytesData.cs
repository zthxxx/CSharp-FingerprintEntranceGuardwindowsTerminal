using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testCSharpSerial
{
    class CombinePacketBytesData
    {

        public int minPacketBytesCount;
        public byte[] SendPacketStratData;//包头
        public byte[] SendPacketAddressData;//地址
        public byte SendPacketSignByte;//包标识
        public byte[] SendPacketFollowLengthData;//后续字节长度
        public int SendPacketFollowLength;//后续字节长度
        public byte SendResponseCommandByte;//响应指令
        public byte[] SendUserSendData;//实际传输数据位
        public byte[] SendCheckSumData;//校验和
        public CombinePacketBytesData()
        {
            memberInitialise();
        }
        public void memberInitialise()//初始化成员
        {
            minPacketBytesCount = 12;
            SendPacketStratData = GlobalVariableClass.fingerprintPocketData.PACKET_STRAT_DATA;
            SendPacketAddressData = GlobalVariableClass.fingerprintPocketData.PACKET_ADDRESS_DATA;
            SendPacketSignByte = 0x00;
            SendPacketFollowLengthData = new byte[2];
            SendPacketFollowLength = 0;
            SendResponseCommandByte = 0x00;
            SendCheckSumData = new byte[2];
        }

        public byte[] getOnePacketSendData(byte packetSignByte, byte responseCommandByte, byte[] userSendData)
        {
            int circleSumCount = 0;
            int packetAllDataSumLength = minPacketBytesCount;
            int checkSum = 0;
            int userSendDataLength = userSendData.Length;
            byte[] packetSendData;
            SendPacketSignByte = packetSignByte;
            SendResponseCommandByte = responseCommandByte;

            SendPacketFollowLength = userSendDataLength + 3;
            SendPacketFollowLengthData[0] = BitConverter.GetBytes(SendPacketFollowLength)[1];
            SendPacketFollowLengthData[1] = BitConverter.GetBytes(SendPacketFollowLength)[0];

            packetAllDataSumLength += userSendDataLength;
            packetSendData = new byte[packetAllDataSumLength];

            Array.Copy(SendPacketStratData, 0, packetSendData, 0, 2);
            Array.Copy(SendPacketAddressData, 0, packetSendData, 2, 4);
            packetSendData[6] = SendPacketSignByte;
            Array.Copy(SendPacketFollowLengthData, 0, packetSendData, 7, 2);
            packetSendData[9] = SendResponseCommandByte;
            Array.Copy(userSendData, 0, packetSendData, 10, userSendDataLength);

            for (circleSumCount = 6; circleSumCount < packetAllDataSumLength - 2; circleSumCount++)
            {
                checkSum += packetSendData[circleSumCount];
            }
            SendCheckSumData[0] = BitConverter.GetBytes(checkSum)[1];
            SendCheckSumData[1] = BitConverter.GetBytes(checkSum)[0];

            Array.Copy(SendCheckSumData, 0, packetSendData, 10 + userSendDataLength, 2);
            return packetSendData;
        }
    }
}
