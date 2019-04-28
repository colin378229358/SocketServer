/**********************************************************************************************
* 命名空间: myWCS.Log
* 类 名：   TxtLog
* 创建日期：2016/10/21 16:32:53
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
using System.Windows.Controls;


namespace MyLog
{
    /// <summary>
    /// 功 能：   中文功能的描述
    /// Function: 英文功能描述
    /// 修改时间、版本：2016/10/21 16:32:53/4.0.30319.42000
    /// 修改人： ANJI-CEVA/chenke
    /// </summary>
    public class TxtLog:ILogService
    {
        private readonly TextBox _infoBox;
        public TxtLog(TextBox tipInfo)
        {
            _infoBox = tipInfo;
        }

        public void Debug(object message)
        {
            Warn(message);
        }

        public void DebugFormatted(string format, params object[] args)
        {
            InfoFormatted(format, args);
        }

        public void Info(object message)
        {
            _infoBox.Dispatcher.InvokeAsync(() => _infoBox.Text += $"{DateTime.Now}     {message}\r\n");
        }

        public void InfoFormatted(string format, params object[] args)
        {
            _infoBox.Dispatcher.InvokeAsync(() => _infoBox.Text += DateTime.Now + string.Format(format, args) + "\r\n");
        }

        public void Warn(object message)
        {
            Info(message);
        }

        public void Warn(object message, Exception exception)
        {
            Info(message);
            Info(exception.ToString());
        }

        public void WarnFormatted(string format, params object[] args)
        {
            InfoFormatted(format, args);
        }

        public void Error(object message)
        {
            Info(message);
        }

        public void Error(object message, Exception exception)
        {
            Warn(message, exception);
        }

        public void ErrorFormatted(string format, params object[] args)
        {
            InfoFormatted(format, args);
        }

        public void Fatal(object message)
        {
            Info(message);
        }

        public void Fatal(object message, Exception exception)
        {
            Warn(message, exception);
        }

        public void FatalFormatted(string format, params object[] args)
        {
            InfoFormatted(format, args);
        }

        public bool IsDebugEnabled { get; }
        public bool IsInfoEnabled { get; }
        public bool IsWarnEnabled { get; }
        public bool IsErrorEnabled { get; }
        public bool IsFatalEnabled { get; }
    }
}

