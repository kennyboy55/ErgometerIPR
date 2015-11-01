using ErgometerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ErgometerDoctorApplication
{
    class MainClient
    {

        public static TcpClient Server { get; set; }

        public static bool loggedin;

        private static Thread t;
        private static bool running;

        public static int Session;

        public static string HOST = "127.0.0.1";
        public static int PORT = 8888;


        //Server information
        public static List<ClientThread> clients;
        public static Dictionary<string, string> users;
        public static List<Tuple<string, double, int>> oldSessionsData;

        public static void RemoveActiveClient(ClientThread clientThread)
        {
            clients.Remove(clientThread);
        }

        public static Dictionary<int, string> activesessions;

        static MainClient()
        {
            Server = new TcpClient();

            loggedin = false;

            clients = new List<ClientThread>();
            users = new Dictionary<string, string>();
            activesessions = new Dictionary<int, string>();
            oldSessionsData = new List<Tuple<string, double, int>>();
        }

        public static bool Connect(string password, out string error)
        {
            error = "Succes";

            if (Server == null || !Server.Connected)
            {
                if (Server == null)
                    Server = new TcpClient();

                try
                {
                    Server.Connect(HOST, PORT);
                }
                catch (Exception e)
                {
                    error = "Server is niet online.";
                    return false;
                }

                NetCommand net = NetHelper.ReadNetCommand(Server);
                if (net.Type == NetCommand.CommandType.SESSION)
                    Session = net.Session;
                else
                    throw new Exception("Session not assigned");

                running = true;
                t = new Thread(run);
                t.IsBackground = true;
                t.Start();
            }

            if (!loggedin)
            {
                NetCommand command = new NetCommand("Doctor0tVfW", true, password, Session);
                NetHelper.SendNetCommand(Server, command);

                NetCommand response = NetHelper.ReadNetCommand(Server);
                if (response.Type == NetCommand.CommandType.RESPONSE && response.Response == NetCommand.ResponseType.LOGINWRONG)
                {
                    loggedin = false;
                    error = "Het wachtwoord is onjuist.";
                    return false;
                }

                loggedin = true;
            }

            
            SendNetCommand(new NetCommand(NetCommand.RequestType.SESSIONDATA, Session));
            Thread.Sleep(15);
            SendNetCommand(new NetCommand(NetCommand.RequestType.USERS, Session));

            Thread.Sleep(200);

            return true;
        }

        public static void Disconnect()
        {

            if (Server != null && Server.Connected)
            {
                NetHelper.SendNetCommand(Server, new NetCommand(NetCommand.CommandType.LOGOUT, Session));
                loggedin = false;
                running = false;
                Server.Close();
                Server = null;
            }
        }

        public static void run()
        {
            while (running)
            {
                if (loggedin && Server.Connected)
                {
                    NetCommand command = NetHelper.ReadNetCommand(Server);
                    HandleNetCommand(command);

                }
            }

            if(Server != null)
                Server.Close();
        }

        private static bool UsersBeingSent = false;
        private static int UsersSent = 0;
        private static int UsersLength = 0;

        private static bool SessionsBeingSent = false;
        private static int SessionsSent = 0;
        private static int SessionsLength = 0;

        private static bool ActiveSessionsBeingSent = false;
        private static int ActiveSessionsSent = 0;
        private static int ActiveSessionsLength = 0;

        private static void HandleNetCommand(NetCommand command)
        {
            switch (command.Type)
            {
                case NetCommand.CommandType.LENGTH:
                    switch (command.Length)
                    {
                        case NetCommand.LengthType.USERS:
                            users.Clear();
                            UsersBeingSent = true;
                            UsersSent = 0;
                            UsersLength = command.LengthValue;
                            break;
                        case NetCommand.LengthType.SESSIONS:
                            oldSessionsData.Clear();
                            SessionsBeingSent = true;
                            SessionsSent = 0;
                            SessionsLength = command.LengthValue;
                            break;
                        case NetCommand.LengthType.SESSIONDATA:
                            activesessions.Clear();
                            ActiveSessionsBeingSent = true;
                            ActiveSessionsSent = 0;
                            ActiveSessionsLength = command.LengthValue;
                            break;
                        default:
                            throw new FormatException("Error in NetCommand: Length type is not recognised");
                    }
                    break;
                case NetCommand.CommandType.ERROR:
                    Console.WriteLine("An error occured, ignoring");
                    break;
                case NetCommand.CommandType.USER:
                    if(UsersBeingSent)
                    {
                        users.Add(command.DisplayName, command.Password);
                        UsersSent++;
                        if (UsersSent >= UsersLength)
                            UsersBeingSent = false;
                    }
                    break;
                case NetCommand.CommandType.SESSIONDATA:
                    if (ActiveSessionsBeingSent)
                    {
                        activesessions.Add(command.Session, command.DisplayName);
                        ActiveSessionsSent++;
                        if (ActiveSessionsSent >= ActiveSessionsLength)
                            ActiveSessionsBeingSent = false;
                    }
                    if (SessionsBeingSent)
                    {
                        oldSessionsData.Add(new Tuple<string, double, int>(command.DisplayName, command.Timestamp, command.Session));
                        SessionsSent++;
                        if (SessionsSent >= SessionsLength)
                            SessionsBeingSent = false;
                    }
                    break;
                default:
                    HandToClient(command);
                    break;
            }
        }

        private static void HandToClient(NetCommand command)
        {
            foreach (ClientThread cl in clients)
            {
                if (cl.Session == command.Session)
                {
                    cl.HandleCommand(command);
                }
            }
        }

        public static void SendNetCommand(NetCommand command)
        {
            if(! NetHelper.SendNetCommand(Server, command))
            {
                Disconnect();
            }
        }

        private static bool IsSessionRunning(int session)
        {
            foreach (ClientThread cl in clients)
            {
                if (cl.Session == session)
                    return true;
            }

            return false;
        }

        public static void StartNewClient(string name, int session)
        {
            if (IsSessionRunning(session))
                return;

            //Start new client
            ClientThread cl = new ClientThread(name, session, false);
            clients.Add(cl);

            //Run client on new thread
            Thread thread = new Thread(new ThreadStart(cl.run));
            thread.IsBackground = true;
            thread.Start();
        }

        public static void StartOldClient(string name, int session)
        {
            if (IsSessionRunning(session))
                return;

            SendNetCommand(new NetCommand(NetCommand.RequestType.OLDDATA, session));
            SendNetCommand(new NetCommand(NetCommand.RequestType.CHAT, session));

            //Start new client
            ClientThread cl = new ClientThread(name, session, true);
            clients.Add(cl);

            //Run client on new thread
            Thread thread = new Thread(new ThreadStart(cl.run));
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
