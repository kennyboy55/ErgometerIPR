using ErgometerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ErgometerApplication
{
    class MainClient
    {

        public static ComPort ComPort { get; }
        public static TcpClient Doctor { get; set; }
        public static List<Meting> Metingen { get; }
        public static List<ChatMessage> Chat { get; }

        public static string Name;

        public static int Session;
        public static bool Loggedin;

        private static Thread t;
        private static bool running;

        public static string HOST = "127.0.0.1";
        public static int PORT = 8888;

        public static ClientApplicatie Client;

        static MainClient()
        {
            ComPort = new ComPort();
            Doctor = new TcpClient();
            Metingen = new List<Meting>();
            Chat = new List<ChatMessage>();

            Name = "Unknown";
            Session = 0;
            Loggedin = false;
        }

        public static void Init(ClientApplicatie client)
        {
            Client = client;
        }

        public static bool Connect(string comport, string name, string password, out string error)
        {
            error = "Succes";

            if (!ComPort.IsOpen())
            {
                if (ComPort.Connect(comport))
                {
                    ComPort.Write("RS");
                    string temp = ComPort.Read();
                    if (temp == "err")
                    {
                        ComPort.Disconnect();
                        error = "De Ergometer is niet verbonden";
                        return false;
                    }
                    Thread.Sleep(200);
                    ComPort.Write("CM");
                    ComPort.Read();
                    Thread.Sleep(200);

                    ComPort.Write("ST");
                    string response = ComPort.Read();

                    SaveMeting(response);
                }
                else
                {
                    error = "De ergometer is niet verbonden";
                    return false;
                }
            }

            if (Doctor == null || !Doctor.Connected)
            {
                if (Doctor == null)
                    Doctor = new TcpClient();

                try
                {
                    Doctor.Connect(HOST, PORT);
                }
                catch (Exception e)
                {
                    error = "Server is niet online.";
                    return false;
                }

                Name = name;

                NetCommand net = NetHelper.ReadNetCommand(Doctor);
                if (net.Type == NetCommand.CommandType.SESSION)
                    Session = net.Session;
                else
                    throw new Exception("Session not assigned");

                running = true;

                t = new Thread(run);
                t.IsBackground = true;
                t.Start();
            }

            if(! Loggedin)
            {
                NetCommand command = new NetCommand(name, false, password, Session);
                NetHelper.SendNetCommand(Doctor, command);

                NetCommand response = NetHelper.ReadNetCommand(Doctor);
                if (response.Type == NetCommand.CommandType.RESPONSE && response.Response == NetCommand.ResponseType.LOGINWRONG)
                {
                    Loggedin = false;
                    error = "De inloggegevens zijn onjuist.";
                    return false;
                }

                Loggedin = true;
            }

            return true;
        }

        public static void Disconnect()
        {
            if (ComPort.IsOpen())
            {
                if (ComPort.Disconnect())
                {
                    
                }
                else
                    throw new Exception("Comport was unable to disconnect");
            }

            if (Doctor != null && Doctor.Connected)
            {
                NetHelper.SendNetCommand(Doctor, new NetCommand(NetCommand.CommandType.LOGOUT, Session));
                Loggedin = false;
                running = false;
                Doctor.Close();
                Doctor = null;
            }
        }

        public static Meting SaveMeting(string meting)
        {
            Meting m = null;

            try
            {
                 m = Meting.Parse(meting);
            }
            catch(Exception e)
            {
                return new Meting(0, 0, 0, 0, 0, 0, 0, 0, 0);
            }
            

            Metingen.Add(m);
            if (Doctor.Connected)
            {
                NetHelper.SendNetCommand(Doctor, new NetCommand(m, Session));
            }

            return m;
        }

        public static Meting GetLastMeting()
        {
            if (Metingen.Count > 1)
                return Metingen.Last();
            else
                return new Meting(0, 0, 0, 0, 0, 0, 0, 0, 0);
        }

        public static void run()
        {
            while(running)
            {
                if(Doctor.Connected)
                {
                    NetCommand command = NetHelper.ReadNetCommand(Doctor);
                    ParseCommand(command);
                }
            }

            if(Doctor != null)
                Doctor.Close();
        }

        private static void ParseCommand(NetCommand command)
        {
            switch(command.Type)
            {
                case NetCommand.CommandType.VALUESET:
                    ParseValueSet(command);
                    break;
                case NetCommand.CommandType.CHAT:
                    ChatMessage chat = new ChatMessage(command.DisplayName, command.ChatMessage, true);
                    Chat.Add(chat);
                    Client.chat.Invoke(Client.chat.passChatMessage, new Object[] { chat });
                    break;
                case NetCommand.CommandType.RESPONSE:
                    Console.WriteLine(command.Response.ToString());
                    break;
                case NetCommand.CommandType.SESSION:
                    Session = command.Session;
                    break;
                case NetCommand.CommandType.ERROR:
                    Console.WriteLine("An error occured, ignoring");
                    break;
                default:
                    throw new FormatException("Error in Netcommand: Received command not recognized");
            }
        }

        public static void SendNetCommand(NetCommand command)
        {
            if(! NetHelper.SendNetCommand(Doctor, command))
            {
                Disconnect();
            }
        }

        private static void ParseValueSet(NetCommand command)
        {
            switch(command.Value)
            {
                case NetCommand.ValueType.DISTANCE:
                    ComPort.Write("RS");
                    ComPort.Read();
                    Thread.Sleep(200);
                    ComPort.Write("CM");
                    ComPort.Read();
                    Thread.Sleep(700);
                    ComPort.Write("PD " + command.SetValue.ToString());
                    ComPort.Read();
                    break;
                case NetCommand.ValueType.ENERGY:
                    ComPort.Write("RS");
                    ComPort.Read();
                    Thread.Sleep(200);
                    ComPort.Write("CM");
                    ComPort.Read();
                    Thread.Sleep(700);
                    ComPort.Write("PE " + command.SetValue.ToString());
                    ComPort.Read();
                    break;
                case NetCommand.ValueType.POWER:
                    ComPort.Write("CM");
                    ComPort.Read();
                    Thread.Sleep(200);
                    ComPort.Write("PW " + command.SetValue.ToString());
                    ComPort.Read();
                    break;
                case NetCommand.ValueType.TIME:
                    ComPort.Write("RS");
                    ComPort.Read();
                    Thread.Sleep(200);
                    ComPort.Write("CM");
                    ComPort.Read();
                    Thread.Sleep(700);
                    string temp = (command.SetValue / 60) + "";
                    if(temp.Length < 2)
                    {
                        temp = "0" + temp;
                    }
                    string temp2 = (command.SetValue % 60) + "";
                    if (temp2.Length < 2)
                    {
                        temp2 = "0" + temp2;
                    }

                    string time = temp + temp2;
                    ComPort.Write("PT " + time);
                    ComPort.Read();
                    break;
                default:
                    throw new FormatException("Error in NetCommand: ValueSet is not recognized");
            }
        }
    }
}
