using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SuperSocket.Common;
using SuperSocket.SocketBase.Protocol;


namespace SuperSocketTest
{
    /// <summary>
    /// It is the kind of protocol that
    /// the first two bytes of each command are { 0x68, 0x68 }
    /// and the last two bytes of each command are { 0x0d, 0x0a }
    /// and the 16th byte (data[15]) of each command indicate the command type
    /// if data[15] = 0x10, the command is a keep alive one
    /// if data[15] = 0x1a, the command is position one
    /// </summary>
    class SocketFilter : BeginEndMarkReceiveFilter<BinaryRequestInfo>
    {
            private readonly static byte[] BeginMark = new byte[] { 0x68, 0x68 };
            private readonly static byte[] EndMark = new byte[] { 0x0d, 0x0a };

            public SocketFilter()
                : base(BeginMark, EndMark)
            {

            }

            protected override BinaryRequestInfo ProcessMatchedRequest(byte[] readBuffer, int offset, int length)
            {
                return new BinaryRequestInfo(BitConverter.ToString(readBuffer, offset + 15, 1), readBuffer.CloneRange(offset, length));
            }

    }

}
