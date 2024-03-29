﻿using ErgometerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgometerDoctorApplication
{
    public class ClientThread
    {
        public int Session { get; }
        public string Name { get; }

        public bool IsOldData { get; }

        private SessionWindow window;

        public List<Meting> Metingen { get; set; }
        public List<ChatMessage> Chat { get; }

        public ClientThread(string name, int session, bool old)
        {
            Name = name;
            Session = session;
            IsOldData = old;

            window = new SessionWindow(Name, old, Session, this);
            window.FormClosed += Window_FormClosed;

            Metingen = new List<Meting>();
            Chat = new List<ChatMessage>();
        }

        private void Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainClient.RemoveActiveClient(this);
        }

        public void HandleCommand(NetCommand command)
        {
            switch (command.Type)
            {
                case NetCommand.CommandType.DATA:
                    if (command != null && command.Meting != null)
                    {
                        lock (Metingen)
                        {
                            Metingen.Add(command.Meting);
                        }
                        window.Invoke(window.updateMetingen, new Object[] { command.Meting });
                    }
                    break;
                case NetCommand.CommandType.CHAT:
                    ChatMessage chat = new ChatMessage(command.DisplayName, command.ChatMessage, command.IsDoctor);
                    Chat.Add(chat);
                    window.panelClientChat.Invoke(window.panelClientChat.passChatMessage, new Object[] { chat });
                    break;
                case NetCommand.CommandType.UITLEG:
                    window.steps.UitlegText.Invoke((MethodInvoker)(() => window.steps.UitlegText.Text = command.UitlegText));
                    break;
                case NetCommand.CommandType.PERSONDATA:
                    window.panelClientChat.Invoke(window.panelClientChat.passChatMessage, new Object[] { new ChatMessage("Test", "DATA Gewicht=" + command.Gewicht + " Geslacht=" + command.Geslacht + " Leeftijd=" + command.Leeftijd + " Lengte=" + command.Lengte + ".", false) });
                    Console.WriteLine("Not fully implemented");
                    //NOG DOEN
                    break;
                case NetCommand.CommandType.TESTRESULT:
                    window.panelClientChat.Invoke(window.panelClientChat.passChatMessage, new Object[] { new ChatMessage("Test", "DATA Vo2Max=" + command.VO2Max + " MET=" + command.MET + " PopulationAvg=" + command.PopulationAvg + " Zscore=" + command.ZScore + " Rating=" + command.Rating + ".", false) });
                    Console.WriteLine("Not fully implemented");
                    //NOG DOEN
                    break;
            }
        }

        public void run()
        {
            Application.Run(window);
        }

        public void stop()
        {
            window.Close();
            MainClient.RemoveActiveClient(this);
        }

        private void sendCommand(NetCommand command)
        {
            if(! IsOldData)
                MainClient.SendNetCommand(command);
        }
        
    }
}
