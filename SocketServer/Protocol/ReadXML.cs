using System;
using System.Xml;
using SocketServer.RabbitMQ;
using SuperSocket.Common;

namespace SocketServer.Protocol
{
    public class ReadXML
    {

        public void LoadConfig()
        {
            XmlDocument config = new XmlDocument();
            //加载xml配置文件
            var location = AppDomain.CurrentDomain.BaseDirectory + "ProtocalConfig.xml";
            config.Load(location);
            //读取RabbitMQ配置
            XmlNodeList xnl0 = config.SelectNodes("/protocal-configuration/conveyor/MQConfigSetting");
            foreach (XmlNode xn in xnl0)
            {
                MQConfigSetting.IP                 = xn.Attributes["IP"].Value;
                MQConfigSetting.Port                = xn.Attributes["Port"].Value.ToInt32();
                MQConfigSetting.RequestedHeartbeat = xn.Attributes["RequestedHeartbeat"].Value.ToInt32();
                MQConfigSetting.UserName           = xn.Attributes["UserName"].Value;
                MQConfigSetting.Password           = xn.Attributes["Password"].Value;
            }
            //读取server配置
            XmlNodeList xnl1 = config.SelectNodes("/protocal-configuration/conveyor/Server");
            foreach (XmlNode xn in xnl1)
            {
                Comm.serverIP   = xn.Attributes["IP"].Value;
                Comm.serverPort = xn.Attributes["Port"].Value.ToInt32();
            }
            //读取protocol配置
            XmlNodeList xnl2 = config.SelectNodes("/protocal-configuration/conveyor/Message");
            foreach (XmlNode xn in xnl2)
            {
                string proConfig;
                proConfig     = xn.Attributes["Protocol"].Value;
                var start     = proConfig.IndexOf("{") + 1;
                var end       = proConfig.IndexOf("}") - 1;
                var bodyTotal = proConfig.Substring(start, (end - start) + 1);
                var bodySplit = bodyTotal.Split(';');
                int num = 0;
                foreach (var body in bodySplit)
                {
                    var bodyValue = body.Split(':');
                    Dat.Content.DB2Type.Add(bodyValue[num], bodyValue[num + 1]);
                }
            }
            //读取数据块配置
            XmlNodeList xnl3 = config.SelectNodes("/protocal-configuration/Message");
            foreach (XmlNode xn in xnl3)
            {
                string operationID;
                operationID = xn.Attributes["OperationID"].Value;
                switch (operationID)
                {
                    case "1":
                        var aheadMsg = xn.Attributes["Message"].Value;
                        Dat.Content.Messages.Add(operationID, aheadMsg);
                        break;
                    case "2":
                        var backMsg = xn.Attributes["Message"].Value;
                        Dat.Content.Messages.Add(operationID, backMsg);
                        break;
                    case "3":
                        var leftMsg = xn.Attributes["Message"].Value;
                        Dat.Content.Messages.Add(operationID, leftMsg);
                        break;
                    case "4":
                        var rightMsg = xn.Attributes["Message"].Value;
                        Dat.Content.Messages.Add(operationID, rightMsg);
                        break;
                    case "5":
                        var stopMsg = xn.Attributes["Message"].Value;
                        Dat.Content.Messages.Add(operationID, stopMsg);
                        break;
                    case "6":
                        var upMsg = xn.Attributes["Message"].Value;
                        Dat.Content.Messages.Add(operationID, upMsg);
                        break;
                    case "7":
                        var downMsg = xn.Attributes["Message"].Value;
                        Dat.Content.Messages.Add(operationID, downMsg);
                        break;
                    case "8":
                        var stayMsg = xn.Attributes["Message"].Value;
                        Dat.Content.Messages.Add(operationID, stayMsg);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}