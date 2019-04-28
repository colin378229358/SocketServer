using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveMQReceive
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitConsumer();
        }
        public void InitConsumer()
        {
            ////创建连接工厂
            //IConnectionFactory factory = new ConnectionFactory("tcp://localhost:61616");
            ////通过工厂创建连接
            //IConnection connection = factory.CreateConnection();
            ////连接服务器端的标识
            //connection.ClientId = "firstQueueListener";
            ////启动连接
            //connection.Start();
            ////通过连接创建对话
            //ISession session = connection.CreateSession();
            ////通过会话创建一个消费者
            //IMessageConsumer consumer = session.CreateConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQQueue("firstQueue"), "filter = 'demo'");
            ////注册监听事件
            //consumer.Listener += new MessageListener(consumer_Listener);
        }
        void consumer_Listener(IMessage message)
        {
            //ITextMessage msg = (ITextMessage)message;
            //ReceiveMessage.Invoke(new DelegateRevMessage(RevMessage), msg);
        }

        //public delegate void DelegateRevMessage(ITextMessage message);
        //public void RevMessage(ITextMessage message)
        //{
        //    ReceiveMessage.Text += string.Format(@"接收到:{0}{1}", message.Text, Environment.NewLine);
        //}
    }
}
