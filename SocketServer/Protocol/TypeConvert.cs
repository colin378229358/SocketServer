/**********************************************************************************************
* 命名空间: JSConSim.MySocketFile
* 类 名：   TypeConvert
* 创建日期：2016/11/2 16:17:37
*
* Ver   负责人  机器名    变更内容
* ────────────────────────────────────────────────
* V0.01 陈珂  CHENKE-PC  初版
*
* Copyright (c)  NBA@Funmore.Inc.2016 Corporation. All rights reserved.
*┌───────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　  │
*│　版权所有：安吉汽车物流有限公司智能物流事业部　　　　                │
*└───────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTypeConvert
{
    /// <summary>
    /// 功 能：   数据类型转换
    /// Function: Data Type Convert
    /// 修改时间、版本：2016/11/2 16:17:37/4.0.30319.42000
    /// 修改人： ANJI-CEVA/chenke
    /// </summary>
    public class TypeConvert
    {
        /// <summary>
        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ByteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2")+" ";
                }
            }
            return returnStr;
        }

        /*将int数值转换为占一个字节的byte数组，本方法适用于(高位在前，低位在后)的顺序  */
        public static byte[] UInt8ToByte(int value, int index, byte[] src)
        {
            src[index] = (byte)((value >> 1) & 0xFF);
            return src;
        }

        /*将int数值转换为占二个字节的byte数组，本方法适用于(高位在前，低位在后)的顺序  */
        public static byte[] UInt16ToByte(int value,int index,byte[] src)
        {
            src[index] = (byte)((value >> 8) & 0xFF);
            src[index+1] = (byte)(value & 0xFF);
            return src;
        }

        /*将int数值转换为占四个字节的byte数组，本方法适用于(高位在前，低位在后)的顺序  */
        public static byte[] UInt32ToByte(int value, int index, byte[] src)
        {
            src[index]   = (byte)((value >> 24) & 0xFF);
            src[index+1] = (byte)(value >> 16 & 0xFF);
            src[index+2] = (byte)((value >> 8) & 0xFF);
            src[index+3] = (byte)(value & 0xFF);
            return src;
        }

    }
}
