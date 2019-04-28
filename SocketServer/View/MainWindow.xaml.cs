using System;
using System.Text;
using System.Threading;
using System.Windows;
using SocketServer.Protocol;
using MyLog;
using Robot.Comm;
//using RabbitMQ.Client;
//using RabbitMQ.Client.Events;
using SocketServer.RabbitMQ;

namespace SocketServer
{
    public delegate int DelStr();
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //实例化Socket
        Comm  comm= new Comm();
        //实例化RabbitMQ
        //private EventingBasicConsumer consumer = null;
        //private IModel channel = null;
        //private IConnection connection;
        //private ConnectionFactory factory;
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }


        #region 系统初始化
        private void Init()
        {
            #region 读取系统配置
            TxtPrint.txtLog   = new TxtLog(txt_Log);
            TxtPrint.txt_MQ   = new TxtLog(txt_MQ);
            TxtPrint.txt_Rec  = new TxtLog(txt_Rec);
            TxtPrint.txt_Send = new TxtLog(txt_Send);


            ReadXML readXml   =new ReadXML();
            readXml.LoadConfig();

            txt_IP.Text   += Comm.serverIP;
            txt_Port.Text += Comm.serverPort.ToString();
            #endregion

            #region 开启Socket服务
            comm.StartServer();
            comb_DB2.ItemsSource = Protocol.Dat.Content.DB2Type;
            comb_Msg.ItemsSource = Protocol.Dat.Content.Messages;
            #endregion

            #region 开启RabbitMQ服务
            //TxtPrint.txtLog.Info("MQ_IP:" + MQConfigSetting.IP);
            //TxtPrint.txtLog.Info("MQ_UserName:" + MQConfigSetting.UserName);
            //try
            //{
            //    factory = new ConnectionFactory();

            //    //factory.HostName = "47.98.235.69";
            //    //factory.Port = 3010;
            //    factory.HostName = MQConfigSetting.IP;
            //    factory.Port     = MQConfigSetting.Port;
            //    factory.UserName = MQConfigSetting.UserName;
            //    factory.Password = MQConfigSetting.Password;
            //    connection = factory.CreateConnection();
            //    channel = connection.CreateModel();
            //    //channel.BasicQos(0, 1, false);//手动应答
            //    consumer = new EventingBasicConsumer(channel);
            //    consumer.Received += CommandReceive_Excute;
            //    channel.QueueDeclare("hello", false, false, false, null);
            //    channel.BasicConsume("hello", true, consumer);  //自动应答
            //   //channel.BasicConsume("hello", false, consumer);
            //    TxtPrint.txtLog.Info($"RabbitMQ服务启动");

            //}
            //catch 
            //{
            //    TxtPrint.txtLog.Info($"RabbitMQ服务失败");
            //    //continue;
            //}
            #endregion
        }
        #endregion

        #region RabbitMQServer配置与转发
        //private void CommandReceive_Excute(object sender, BasicDeliverEventArgs e)
        //{
        //    try
        //    {
        //        var body = e.Body;
        //        string message = Encoding.UTF8.GetString(body);
        //        //TxtPrint.txtLog.Info($"Recevice:{message}");
        //        TxtPrint.txt_MQ.Info($"Recevice:{message}");
        //        var id   = message.Split(':')[0];
        //        var ctrl = message.Split(':')[1];
        //        TransferCtrlMsg(id, ctrl);
        //        //channel.BasicAck(e.DeliveryTag,false);   //手动应答
        //    }
        //    catch (Exception)
        //    {
               
        //        //throw;
        //    }
        //}

        //private void TransferCtrlMsg(string id, string ctrl)
        //{
        //    if (comm.robotsDictionary.ContainsKey(id))
        //    {
        //        TxtPrint.txt_Send.Info(ctrl + "->" + id);
        //        comm.robotsDictionary[id].Send(ctrl);
        //    }
        //    else
        //    {
        //        TxtPrint.txtLog.Info(id + "没注册！");
        //    }
        //}
        #endregion

        #region  按键处理事件
        private void BtnClickStart(object sender, RoutedEventArgs e)
        {
            TxtPrint.txtLog.Info("Server Start!");
        }

        private void BtnClickStop(object sender, RoutedEventArgs e)
        {

        }

        private void BtnClickClean(object sender, RoutedEventArgs e)
        {
            txt_Log.Clear();
            txt_MQ.Clear();
            txt_Rec.Clear();
            txt_Send.Clear();
        }

        private void BtnClickSend(object sender, RoutedEventArgs e)
        {
            var temp1 = comb_DB2.SelectionBoxItem.ToString();
            if(temp1=="") return;

            var robotID = temp1.Substring(1, 4);

            var temp2 = comb_Msg.SelectionBoxItem.ToString();
            if(temp2=="") return;

            var temp3 = temp2.Split(',')[1];
            var msg = temp3.Substring(0, temp3.Length - 1);



            if (comm.robotsDictionary.ContainsKey(robotID))
            {
                TxtPrint.txt_Send.Info(msg + "->" + robotID);
                comm.robotsDictionary[robotID].Send(msg);

                LogHelper.WriteLog(msg + "->" + robotID);
            }
            else
            {
                TxtPrint.txtLog.Info(robotID + "没注册！");
                LogHelper.WriteLog(robotID + "没注册！");
            }
            // comm.Send();
        }

        private void BtnClickUpdate(object sender, RoutedEventArgs e)
        {

            
        }

        #endregion
    }
}
