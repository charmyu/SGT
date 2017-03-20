using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationProtocol
{
    public class DataPackage
    {
        byte PackageHead;
        byte PackageTail;
        /// <summary>
        /// 校验和:从第二个字节（Length）开始到最后一个字节的和的低8位
        /// </summary>
        byte Checksum;
        /// <summary>
        /// 长度:所有数据的字节包含校验和这两个本身
        /// </summary>
        byte Length;
        /// <summary>
        /// 发送者ID:默认为0x77 。
        /// </summary>
        byte SendID;
        /// <summary>
        /// 命令
        /// </summary>
        byte Cmd;
        /// <summary>
        /// 接受者ID:接受者可以为系统中的主监控模块或电源模块，主控ID为0x3B，各电源模块ID为0x01，0x02 … 0xNN(NN为系统中电源模块总数量)。
        /// </summary>
        byte TargetID;
        /// <summary>
        /// 附加数据:对于设置参命令Data的第一个字节为参数代码，后续为参数值。
        /// </summary>
        Byte Data;
        
        public DataPackage(byte packageHead, byte packageTail, byte checksum, byte length, byte sendID, byte cmd, byte targetID, byte data)
        {
            PackageHead = packageHead;
            PackageTail = packageTail;
            Checksum = checksum;
            Length = length;
            SendID = sendID;
            Cmd = cmd;
            TargetID = targetID;
            Data = data;
        }
    }
}
