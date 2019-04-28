using System.Collections.Generic;
using SuperSocket.Common;

namespace SocketServer.Model
{
    public class DB2Message
    {
        public DB2Message()
        {
            Joint();
        }

        public static DB2Message Content = new DB2Message();
        public byte[] db2Msg;
        public string db2Type;
        public int db2TypeMaxNum;
  
        #region DB2数据拼接
        public byte[] Joint()
        {
            List<byte> temp = new List<byte>();
            List<byte[]> tempNum = new List<byte[]>();

            //var tbMsg = Protocol.Dat.Content.Messages["TB"].ToByte();
            //var osMsg = Protocol.Dat.Content.Messages["OS"].ToByte();
            //var lctMsg = Protocol.Dat.Content.Messages["LCT"].ToByte();
            //var maMsg = Protocol.Dat.Content.Messages["MA"].ToByte();
            //var clsMsg = Protocol.Dat.Content.Messages["CLS"].ToByte();
            //var swapMsg = Protocol.Dat.Content.Messages["SWAP"].ToByte();
            //var rsMsg = Protocol.Dat.Content.Messages["RS"].ToByte();
            //var ltMsg = Protocol.Dat.Content.Messages["LT"].ToByte();

            var tbMsg_num = Protocol.Dat.Content.DB2Type["TB"].ToInt32();
            var osMsg_num = Protocol.Dat.Content.DB2Type["OS"].ToInt32();
            var lctMsg_num = Protocol.Dat.Content.DB2Type["LCT"].ToInt32();
            var maMsg_num = Protocol.Dat.Content.DB2Type["MA"].ToInt32();
            var clsMsg_num = Protocol.Dat.Content.DB2Type["CLS"].ToInt32();
            var swapMsg_num = Protocol.Dat.Content.DB2Type["SWAP"].ToInt32();
            var rsMsg_num = Protocol.Dat.Content.DB2Type["RS"].ToInt32();
            var ltMsg_num = Protocol.Dat.Content.DB2Type["LT"].ToInt32();

            var headMsg_fill = new byte[8] { 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB, 0xBB };
            var lctMsg_fill = new byte[1] { 0 };
            var swapMsg_fill = new byte[1] { 0 };
            var crcMsg_fill = new byte[4] { 0x00, 0x00, 0x00, 0x00 };
            var tailMsg_fill = new byte[8] { 0xEE, 0xEE, 0xEE, 0xEE, 0xEE, 0xEE, 0xEE, 0xEE };

            temp.AddRange(headMsg_fill);

            //for (int num = 0; num < tbMsg_num; num++)
            //{
            //    temp.AddRange(tbMsg);
            //}

            //for (int num = 0; num < lctMsg_num; num++)
            //{
            //    temp.AddRange(lctMsg);
            //    temp.AddRange(lctMsg_fill);
            //}

            //for (int num = 0; num < clsMsg_num; num++)
            //{
            //    temp.AddRange(clsMsg);
            //}

            //for (int num = 0; num < maMsg_num; num++)
            //{
            //    temp.AddRange(maMsg);
            //}

            //for (int num = 0; num < osMsg_num; num++)
            //{
            //    temp.AddRange(osMsg);
            //}

            //for (int num = 0; num < swapMsg_num; num++)
            //{
            //    temp.AddRange(swapMsg);
            //}

            //for (int num = 0; num < rsMsg_num; num++)
            //{
            //    temp.AddRange(rsMsg);
            //}

            //for (int num = 0; num < ltMsg_num; num++)
            //{
            //    temp.AddRange(ltMsg);
            //}

            temp.AddRange(crcMsg_fill);
            temp.AddRange(tailMsg_fill);
            db2Msg = temp.ToArray();

            return db2Msg;
        }
        #endregion

        public void Update()
        {
            var temp = db2Type.Substring(1,db2Type.Length-2).Split(',');

            //switch (temp[0])
            //{
            //    case "TB":
            //        if (IndexDb2Message() > Dat.Content.DB2Type["TB"].ToInt32())
            //        {
            //            MessageBox.Show("Out of Range");
            //            return;
            //        }
            //        TBWindow tbWindow = new TBWindow(IndexDb2Message);
            //        tbWindow.ShowDialog();
            //        break;

            //    case "OS":
            //        if (IndexDb2Message() > Dat.Content.DB2Type["OS"].ToInt32())
            //        {
            //            MessageBox.Show("Out of Range");
            //            return;
            //        }
            //        OSWindow osWindow = new OSWindow(IndexDb2Message);
            //        osWindow.ShowDialog();
            //        break;

            //    case "LCT":
            //        if (IndexDb2Message() > Dat.Content.DB2Type["LCT"].ToInt32())
            //        {
            //            MessageBox.Show("Out of Range");
            //            return;
            //        }
            //        LCTWindow lctWindow = new LCTWindow(IndexDb2Message);
            //        lctWindow.ShowDialog();
            //        break;

            //    case "MA":
            //        if (IndexDb2Message() > Dat.Content.DB2Type["MA"].ToInt32())
            //        {
            //            MessageBox.Show("Out of Range");
            //            return;
            //        }
            //        MAWindow maWindow = new MAWindow(IndexDb2Message);
            //        maWindow.ShowDialog();
            //        break;

            //    case "CLS":
            //        if (IndexDb2Message() > Dat.Content.DB2Type["CLS"].ToInt32())
            //        {
            //            MessageBox.Show("Out of Range");
            //            return;
            //        }
            //        CLSWindow clsWindow = new CLSWindow(IndexDb2Message);
            //        clsWindow.ShowDialog();
            //        break;

            //    case "SWAP":
            //        if (IndexDb2Message() > Dat.Content.DB2Type["SWAP"].ToInt32())
            //        {
            //            MessageBox.Show("Out of Range");
            //            return;
            //        }
            //        SWAPWindow swapWindow = new SWAPWindow(IndexDb2Message);
            //        swapWindow.ShowDialog();
            //        break;

            //    case "RS":
            //        if (IndexDb2Message() > Dat.Content.DB2Type["RS"].ToInt32())
            //        {
            //            MessageBox.Show("Out of Range");
            //            return;
            //        }
            //        RSWindow rsWindow = new RSWindow(IndexDb2Message);
            //        rsWindow.ShowDialog();
            //        break;

            //    case "LT":
            //        if (IndexDb2Message() > Dat.Content.DB2Type["LT"].ToInt32())
            //        {
            //            MessageBox.Show("Out of Range");
            //            return;
            //        }
            //        LTWindow ltWindow = new LTWindow(IndexDb2Message);
            //        ltWindow.ShowDialog();
            //        break;

            //    default:
            //        break;
            //}
        }

        private int IndexDb2Message()
        {
            return db2TypeMaxNum;
        }

        //DB2数据区的状态组顺序为TB LCT CLS MA OS SWAP RS LT 
        public int Offset(string msg,int index)
        {
            int offset=0;

            //var tbNum = Dat.Content.DB2Type["TB"].ToInt32();
            //var tbLength = Dat.Content.Messages["TB"].Length.ToInt32();
            //var lctNum = Dat.Content.DB2Type["LCT"].ToInt32();
            //var lctLength = Dat.Content.Messages["LCT"].Length.ToInt32();
            //var clsNum = Dat.Content.DB2Type["CLS"].ToInt32();
            //var clsLength = Dat.Content.Messages["CLS"].Length.ToInt32();
            //var maNum = Dat.Content.DB2Type["MA"].ToInt32();
            //var maLength = Dat.Content.Messages["MA"].Length.ToInt32();
            //var osNum = Dat.Content.DB2Type["OS"].ToInt32();
            //var osLength = Dat.Content.Messages["OS"].Length.ToInt32();
            //var swapNum = Dat.Content.DB2Type["SWAP"].ToInt32();
            //var swapLength = Dat.Content.Messages["SWAP"].Length.ToInt32();
            //var rsNum = Dat.Content.DB2Type["RS"].ToInt32();
            //var rsLength = Dat.Content.Messages["RS"].Length.ToInt32();
            //var ltNum = Dat.Content.DB2Type["LT"].ToInt32();
            //var ltLength = Dat.Content.Messages["LT"].Length.ToInt32();

            switch (msg)
            {
                //case "TB":
                //    offset = index*tbNum;
                //    break;

                //case "LCT":
                //    offset = tbNum*tbLength+index*lctNum;
                //    break;

                //case "CLS":
                //    offset = tbNum*tbLength+lctNum*lctLength+index*clsNum;
                //    break;

                //case "MA":
                //    offset = tbNum*tbLength+lctNum*lctLength+clsNum*clsLength+index*maNum;
                //    break;

                //case "OS":
                //    offset = tbNum*tbLength+lctNum*lctLength+clsNum*clsLength+maNum*maLength+index*osNum;
                //    break;

                //case "SWAP":
                //    break;

                //case "RS":
                //    offset= tbNum*tbLength+osNum*osLength+lctNum*lctLength+maNum*maLength+clsNum*clsLength+swapNum*swapLength+index*rsNum;
                //    break;

                //case "LT":
                //    offset = tbNum*tbLength+osNum*osLength+lctNum*lctLength+maNum*maLength+clsNum*clsLength+swapNum*swapLength+rsNum*rsLength+index*ltNum;
                //    break;

                default:
                    break;
            }

            return offset;
        }
    }
}