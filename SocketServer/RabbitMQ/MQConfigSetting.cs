using System.Xml.Serialization;

namespace SocketServer.RabbitMQ
{
    public class MQConfigSetting
    {
        /// <summary>
        /// 服务器IP
        /// </summary>
        [XmlAttribute]
        public static string IP { get; set; }
        /// <summary>
        /// 服务器PORT
        /// </summary>
        /// 
        public static int Port { get; set; }
        /// <summary>
        /// 请求心跳
        /// </summary>
        [XmlAttribute]
        public static int RequestedHeartbeat { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [XmlAttribute]
        public static string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [XmlAttribute]
        public static string Password { get; set; }
    }
}