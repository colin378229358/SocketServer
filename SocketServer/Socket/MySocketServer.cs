using System;
using System.Linq;
using MyLog;
using SuperSocket.Common;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace SuperSocketTest
{
    public class MySocketServer : AppServer<MySession, StringRequestInfo>
    {
        public MySocketServer() : base(new DefaultReceiveFilterFactory<MyReceiveFilter, StringRequestInfo>())
        {

        }

    }

    public class MyReceiveFilter : BeginEndMarkReceiveFilter<StringRequestInfo>
    {
        //开始和结束标记也可以是两个或两个以上的字节
        private readonly static byte[] BeginMark = new byte[] { (byte)'*' };
        private readonly static byte[] EndMark = new byte[] { (byte)'#' };

        public MyReceiveFilter()
            : base(BeginMark, EndMark) //传入开始标记和结束标记
        {

        }

        protected override StringRequestInfo ProcessMatchedRequest(byte[] readBuffer, int offset, int length)
        {
            //TODO: 通过解析到的数据来构造请求实例，并返回
            string str = System.Text.Encoding.Default.GetString(readBuffer);
            //TxtPrint.txtLog.Info(str);
            TxtPrint.txt_Rec.Info(str);

            var byteBody = readBuffer.Skip(1).Take(length - 2).ToArray();
            var strBody  = System.Text.Encoding.Default.GetString(byteBody);

            string[] strArr= {str};
            return new StringRequestInfo("*", strBody, strArr); ;
        }
    }
    public class MySession : AppSession<MySession, StringRequestInfo>
    {
        public new MySocketServer AppServer
        {
            get
            {
                return (MySocketServer)base.AppServer;
            }
        }
    }
}