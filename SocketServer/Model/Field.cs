using System;

namespace SocketServer.Model
{
    public class Field
    {
        public virtual string SequenceNo { get; set; }
        public virtual string Name { get; set; }
        public virtual string Pos { get; set; }
        public virtual string Length { get; set; }
        public virtual string Type { get; set; }
        public virtual string MapName { get; set; }
        public virtual string Value { get; set; }

        //private static bool flag_control = true;

        public byte[] ToByte()
        {
            byte[] bytes;
            //if (string.Equals(Type, "Boolean")&&(flag_control))
            //{
            //    bytes = new byte[1] {0};
            //    flag_control = false;
            //}
            //else
            //{
            bytes = new byte[System.Int32.Parse(Length)];
            //}


            switch (Type)
            {
                case "UInt16":
                    if (Value == "")
                    {
                        Value = "0";
                    }
                    bytes = UInt16ToByte(Convert.ToUInt16(Value));
                    break;

                case "UInt32":
                    if (Value == "")
                    {
                        Value = "0";
                    }
                    bytes = UInt32ToByte(Convert.ToUInt32(Value));
                    break;

                case "Byte":
                    if (Value == "")
                    {
                        Value = "0";
                    }
                    bytes = UInt8ToByte(Convert.ToByte(Value));
                    break;

                case "Boolean":
                    //bytes[0] = (byte)((Convert.ToByte(Value) >> 1) & 0xFF);
                    break;

                default:
                    break;
            }
            return bytes;
        }

        //public static byte[] BoolToByte(uint value)
        //{
        //    //byte[] src = new byte[1];
        //    bytes[0] = (byte)((value>>1) & 0xFF);
        //    return bytes;
        //}

        /*将int数值转换为占一个字节的byte数组，
        本方法适用于(高位在前，低位在后)的顺序  */
        public static byte[] UInt8ToByte(uint value)
        {
            byte[] src = new byte[1];
            src[0] = (byte)((value >> 1) & 0xFF);
            return src;
        }

        /*将int数值转换为占二个字节的byte数组，
         本方法适用于(高位在前，低位在后)的顺序  */
        public static byte[] UInt16ToByte(uint value)
        {
            byte[] src = new byte[2];
            src[0] = (byte)((value >> 8) & 0xFF);
            src[1] = (byte)(value & 0xFF);
            return src;
        }

        /*将int数值转换为占四个字节的byte数组，
        本方法适用于(高位在前，低位在后)的顺序  */
        public static byte[] UInt32ToByte(uint value)
        {
            byte[] src = new byte[4];
            src[0] = (byte)((value >> 24) & 0xFF);
            src[1] = (byte)(value >> 16 & 0xFF);
            src[2] = (byte)((value >> 8) & 0xFF);
            src[3] = (byte)(value & 0xFF);
            return src;
        }
    }
}