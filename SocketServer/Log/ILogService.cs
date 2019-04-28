/**********************************************************************************************
* 命名空间: myWCS.Log
* 类 名：   ILogService
* 创建日期：2016/10/21 16:33:32
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

namespace MyLog
{
    /// <summary>
    /// 功 能：   中文功能的描述
    /// Function: 英文功能描述
    /// 修改时间、版本：2016/10/21 16:33:32/4.0.30319.42000
    /// 修改人： ANJI-CEVA/chenke
    /// </summary>
    public interface ILogService
    {
            bool IsDebugEnabled { get; }
            bool IsErrorEnabled { get; }
            bool IsFatalEnabled { get; }
            bool IsInfoEnabled { get; }
            bool IsWarnEnabled { get; }

            void Debug(object message);
            void DebugFormatted(string format, params object[] args);
            void Error(object message);
            void Error(object message, Exception exception);
            void ErrorFormatted(string format, params object[] args);
            void Fatal(object message);
            void Fatal(object message, Exception exception);
            void FatalFormatted(string format, params object[] args);
            void Info(object message);
            void InfoFormatted(string format, params object[] args);
            void Warn(object message);
            void Warn(object message, Exception exception);
            void WarnFormatted(string format, params object[] args);
        }
}
