using System.Collections.Generic;
using System.Linq;
using SocketServer.Model;
using MyLog;
using Robot.Comm;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using SuperSocketTest;

namespace SocketServer.Protocol
{
    public class Comm
    {
        public static string serverIP;
        public static int serverPort;

        MySocketServer mySocketServer = new MySocketServer();
        ServerConfig serverConfig     = new ServerConfig();
        public Dictionary<string,MySession> robotsDictionary=new Dictionary<string, MySession>(); 

        #region 启动通信配置
        public void StartServer()
        {
            serverConfig.Ip   = "";
            serverConfig.Port = 2000;

            if (mySocketServer.Setup(serverConfig))
            {

            }
            else
            {
                return; ;
            }

            if (mySocketServer.Start())
            {
                TxtPrint.txtLog.Info("Server  OK!");
                LogHelper.WriteLog("Server  OK!");
            }
            else
            {
                return;
            }

            mySocketServer.NewSessionConnected += new SessionHandler<MySession>(MyServer_NewSessionConnected);
            mySocketServer.NewRequestReceived  += new RequestHandler<MySession, StringRequestInfo>(MyServer_NewRequestReceived);
        }

        void MyServer_NewSessionConnected(MySession session)
        {
            if (session.Connected)
            {
                TxtPrint.txtLog.Info(session.RemoteEndPoint);
                session.Send("Welcome Sweet Robot");

                LogHelper.WriteLog(session.RemoteEndPoint.ToString());
            }
        }

        void MyServer_NewRequestReceived(MySession session, StringRequestInfo requestInfo)
        {
            var bodyInfo = requestInfo.Body;
            if (bodyInfo.Substring(0, 3) == "NUM")
            {
                for (int i = 1; i <= 99; i++)
                {
                    var id = "ID" + i.ToString("00");
                    if (bodyInfo.Equals("NUM" + i.ToString("00")))
                    {
                        TxtPrint.txtLog.Info(id + "已注册");
                        LogHelper.WriteLog(id + "已注册");

                        robotsDictionary[id] = session;   //用新的session替换原有session
                        //break;
                    }
                    //else
                    //{
                    //    robotsDictionary.Add(id, session);
                    //    TxtPrint.txtLog.Info(id + "机器人注册成功！");
                    //    LogHelper.WriteLog(id + "机器人注册成功！");
                    //    break;
                    //}
                }
            }








            #region  10台机器人注册消息
            //if (requestInfo.Body.Equals("NUM01"))
            //{
            //    if (robotsDictionary.ContainsKey("ID01"))
            //    {
            //        TxtPrint.txtLog.Info("ID01已注册");
            //        LogHelper.WriteLog("ID01已注册");
            //        robotsDictionary["ID01"] = session;   //用新的session替换原有session
            //        return;
            //    }
            //    else
            //    {
            //        robotsDictionary.Add("ID01", session);
            //        TxtPrint.txtLog.Info("ID01机器人注册成功！");
            //        LogHelper.WriteLog("ID01机器人注册成功！");
            //    }
            //}
            //else if (requestInfo.Body.Equals("NUM02"))
            //{
            //    if (robotsDictionary.ContainsKey("ID02"))
            //    {
            //        TxtPrint.txtLog.Info("ID02已注册");
            //        LogHelper.WriteLog("ID02已注册");
            //        robotsDictionary["ID02"] = session;   //用新的session替换原有session
            //        return;
            //    }
            //    else
            //    {
            //        robotsDictionary.Add("ID02", session);
            //        TxtPrint.txtLog.Info("ID02机器人注册成功！");
            //        LogHelper.WriteLog("ID02机器人注册成功！");
            //    }
            //}
            //else if (requestInfo.Body.Equals("NUM03"))
            //{
            //    if (robotsDictionary.ContainsKey("ID03"))
            //    {
            //        TxtPrint.txtLog.Info("ID03已注册");
            //        LogHelper.WriteLog("ID03已注册");
            //        robotsDictionary["ID03"] = session;   //用新的session替换原有session
            //        return;
            //    }
            //    else
            //    {
            //        robotsDictionary.Add("ID03", session);
            //        TxtPrint.txtLog.Info("ID03机器人注册成功！");
            //        LogHelper.WriteLog("ID03机器人注册成功！");
            //    }
            //}
            //else if (requestInfo.Body.Equals("NUM04"))
            //{
            //    if (robotsDictionary.ContainsKey("ID04"))
            //    {
            //        TxtPrint.txtLog.Info("ID04已注册");
            //        LogHelper.WriteLog("ID04已注册");
            //        robotsDictionary["ID04"] = session;   //用新的session替换原有session
            //        return;
            //    }
            //    else
            //    {
            //        robotsDictionary.Add("ID04", session);
            //        TxtPrint.txtLog.Info("ID04机器人注册成功！");
            //        LogHelper.WriteLog("ID04机器人注册成功！");
            //    }
            //}
            //else if (requestInfo.Body.Equals("NUM05"))
            //{
            //    if (robotsDictionary.ContainsKey("ID05"))
            //    {
            //        TxtPrint.txtLog.Info("ID05已注册");
            //        LogHelper.WriteLog("ID05已注册");
            //        robotsDictionary["ID05"] = session;   //用新的session替换原有session
            //        return;
            //    }
            //    else
            //    {
            //        robotsDictionary.Add("ID05", session);
            //        TxtPrint.txtLog.Info("ID05机器人注册成功！");
            //        LogHelper.WriteLog("ID05机器人注册成功！");
            //    }
            //}
            //else if (requestInfo.Body.Equals("NUM06"))
            //{
            //    if (robotsDictionary.ContainsKey("ID06"))
            //    {
            //        TxtPrint.txtLog.Info("ID06已注册");
            //        LogHelper.WriteLog("ID06已注册");
            //        robotsDictionary["ID06"] = session;   //用新的session替换原有session
            //        return;
            //    }
            //    else
            //    {
            //        robotsDictionary.Add("ID06", session);
            //        TxtPrint.txtLog.Info("ID06机器人注册成功！");
            //        LogHelper.WriteLog("ID06机器人注册成功！");
            //    }
            //}
            //else if (requestInfo.Body.Equals("NUM07"))
            //{
            //    if (robotsDictionary.ContainsKey("ID07"))
            //    {
            //        TxtPrint.txtLog.Info("ID07已注册");
            //        LogHelper.WriteLog("ID07已注册");
            //        robotsDictionary["ID07"] = session;   //用新的session替换原有session
            //        return;
            //    }
            //    else
            //    {
            //        robotsDictionary.Add("ID07", session);
            //        TxtPrint.txtLog.Info("ID07机器人注册成功！");
            //        LogHelper.WriteLog("ID07机器人注册成功！");
            //    }
            //}
            //else if (requestInfo.Body.Equals("NUM08"))
            //{
            //    if (robotsDictionary.ContainsKey("ID08"))
            //    {
            //        TxtPrint.txtLog.Info("ID08已注册");
            //        LogHelper.WriteLog("ID08已注册");
            //        robotsDictionary["ID08"] = session;   //用新的session替换原有session
            //        return;
            //    }
            //    else
            //    {
            //        robotsDictionary.Add("ID08", session);
            //        TxtPrint.txtLog.Info("ID08机器人注册成功！");
            //        LogHelper.WriteLog("ID08机器人注册成功！");
            //    }
            //}
            //else if (requestInfo.Body.Equals("NUM09"))
            //{
            //    if (robotsDictionary.ContainsKey("ID09"))
            //    {
            //        TxtPrint.txtLog.Info("ID09已注册");
            //        LogHelper.WriteLog("ID09已注册");
            //        robotsDictionary["ID09"] = session;   //用新的session替换原有session
            //        return;
            //    }
            //    else
            //    {
            //        robotsDictionary.Add("ID09", session);
            //        TxtPrint.txtLog.Info("ID09机器人注册成功！");
            //        LogHelper.WriteLog("ID09机器人注册成功！");
            //    }
            //}
            //else if (requestInfo.Body.Equals("NUM10"))
            //{
            //    if (robotsDictionary.ContainsKey("ID10"))
            //    {
            //        TxtPrint.txtLog.Info("ID10已注册");
            //        LogHelper.WriteLog("ID10已注册");
            //        robotsDictionary["ID10"] = session;   //用新的session替换原有session
            //        return;
            //    }
            //    else
            //    {
            //        robotsDictionary.Add("ID10", session);
            //        TxtPrint.txtLog.Info("ID10机器人注册成功！");
            //        LogHelper.WriteLog("ID10机器人注册成功！");
            //    }
            //}          
            #endregion

            #region 过度测试代码

            //if (requestInfo.Body.Equals("AHEAD"))
            //{
            //    SendTransfer(requestInfo);
            //}
            //else if (requestInfo.Body.Equals("BACK"))
            //{
            //    SendTransfer(requestInfo);
            //}
            //else if (requestInfo.Body.Equals("LEFT"))
            //{
            //    SendTransfer(requestInfo);
            //}
            //else if (requestInfo.Body.Equals("RIGHT"))
            //{
            //    SendTransfer(requestInfo);
            //}
            //else if (requestInfo.Body.Equals("STOP"))
            //{
            //    SendTransfer(requestInfo);
            //}
            //else if (requestInfo.Body.Equals("DUP"))
            //{
            //    SendTransfer(requestInfo);
            //}
            //else if (requestInfo.Body.Equals("DDOWN"))
            //{
            //    SendTransfer(requestInfo);
            //}
            //else if (requestInfo.Body.Equals("OUT9_ON"))
            //{
            //    SendTransfer(requestInfo);
            //}
            //else if (requestInfo.Body.Equals("OUT9_OFF"))
            //{
            //    SendTransfer(requestInfo);
            //}
            //else if (requestInfo.Body.Equals("OUT10_ON"))
            //{
            //    SendTransfer(requestInfo);
            //}
            //else if (requestInfo.Body.Equals("OUT10_OFF"))
            //{
            //    SendTransfer(requestInfo);
            //}
            #endregion

            //#region 发送控制消息                        
            SendCtrlCommend(requestInfo);
            //#endregion
        }
        #endregion

        #region 消息转发功能
        //private void SendTransfer(StringRequestInfo requestInfo)
        //{
        //    foreach (var session in mySocketServer.GetAllSessions())
        //    {
        //         session.Send(requestInfo.Parameters[0]);
        //    }
        //}
        #endregion

        #region   发送机器人控制指令
        private void SendCtrlCommend(StringRequestInfo requestInfo)
        {
            var msg = requestInfo.Body;
            if (msg.Contains("ID"))
            {
                var id   = msg.Split(':')[0];
                var ctrl = msg.Split(':')[1];
                if (robotsDictionary.ContainsKey(id))
                {
                    TxtPrint.txt_Send.Info("*" + ctrl+"#" + "->" + id);
                    robotsDictionary[id].Send("*"+ctrl+"#");
                    LogHelper.WriteLog("*" + ctrl + "#" + "->" + id);
                }
                else
                {
                    TxtPrint.txtLog.Info(id + "没注册！");
                    LogHelper.WriteLog(id + "没注册！");
                }
            }
            //if (clientsDictionary.Count == 0)
            //{
            //    TxtPrint.txtLog.Info("没有注册成功的客户端！");
            //    return;
            //}
            //else if (robotsDictionary.Count == 0)
            //{
            //    TxtPrint.txtLog.Info("没有注册成功的机器人！");
            //    return;
            //}

            //foreach (var robot in robotsDictionary)
            //{
            //    #region  给所有连接上的机器人发送控制消息
            //    if (robotsDictionary["NUM1"].Connected)
            //    {
            //        robotsDictionary["NUM1"].Send(requestInfo.Parameters[0]);
            //    }
            //    else
            //    {
            //        TxtPrint.txtLog.Info(robotsDictionary["NUM1"].RemoteEndPoint.ToString() + "断开连接！");
            //        robotsDictionary.Remove("NUM1");
            //    }
            //    #endregion
            //}
        }
        #endregion

        #region 按键发送功能

        public void Send()
        {
            foreach (var session in mySocketServer.GetAllSessions())
            {
                session.Send(DB2Message.Content.db2Msg, 0, DB2Message.Content.db2Msg.Length);
            }
        }
        #endregion

    }
}