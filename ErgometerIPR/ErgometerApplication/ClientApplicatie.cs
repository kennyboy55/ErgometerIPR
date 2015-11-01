using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Timers;
using ErgometerLibrary;

namespace ErgometerApplication
{
    public partial class ClientApplicatie : Form
    {
        public PanelClientChat chat;
        public ErgometerTest ergotest;

        public ClientApplicatie()
        {
            InitializeComponent();
            MainClient.Init(this);
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            

            if(MainClient.Doctor.Connected)
            {
                MainClient.ComPort.Write("ST");
                string response = MainClient.ComPort.Read();
                if (response != "err")
                {
                    Meting m = MainClient.SaveMeting(response);

                    heartBeat.updateValue(m.HeartBeat);
                    RPM.updateValue(m.RPM);
                    speed.updateValue(m.Speed);
                    distance.updateValue(m.Distance);
                    power.updateValue(m.Power);
                    energy.updateValue(m.Energy);
                    actualpower.updateValue(m.ActualPower);
                    time.updateValue(m.Seconds);
                }
                else
                {
                    logout("De Ergometer is niet meer verbonden.", Color.Red);
                }
            }
        }

        public void validateLogin(string username, string password)
        {
            if (username.Length > 0)
            {
                if (password.Length == 0)
                {
                    panelLogin.lblVerification.Text = "Vul een wachtwoord in.";
                    panelLogin.lblVerification.ForeColor = Color.Red;
                    panelLogin.lblVerification.Visible = true;
                }
                if (password.Length > 0)
                {
                    string error = "";
                    bool connect = MainClient.Connect(SerialPort.GetPortNames()[0], username, password, out error);

                    if (connect)
                    {
                        panelGatherInfo.BringToFront();
                        
                        this.labelUsername.Text = panelLogin.textBoxUsername.Text;
                        
                    }
                    else
                    {
                        panelLogin.lblVerification.Text = error;
                        panelLogin.lblVerification.ForeColor = Color.Red;
                        panelLogin.lblVerification.Visible = true;
                    }
                        
                }
            }
            else
            {
                panelLogin.lblVerification.Text = "Vul een gebruikersnaam in.";
                panelLogin.lblVerification.ForeColor = Color.Red;
                panelLogin.lblVerification.Visible = true;
            }
        }

        public void updateStepsText(string text)
        {
            steps.setText(text);
        }

        internal void CreateNewTest(char geslacht, int leeftijd, int gewicht, int lengte)
        {
            panelTopBar.Visible = true;
            panelClientContainer.BringToFront();
            chat = panelClientChat;
            updateTimer.Start();
            ergotest = new ErgometerTest()
        }

        private void buttonLogOff_Click(object sender, EventArgs e)
        {
            logout("U bent uitgelogd.", Color.Blue);
        }

        private void logout(string message, System.Drawing.Color cl)
        {
            panelLogin.BringToFront();
            panelTopBar.Visible = false;
            panelLogin.lblVerification.Text = message;
            panelLogin.lblVerification.ForeColor = cl;
            panelLogin.lblVerification.Visible = true;
            panelLogin.textBoxUsername.Text = "";
            panelLogin.textBoxPassword.Text = "";
            MainClient.Disconnect();
            updateTimer.Stop();
        }
    }
}