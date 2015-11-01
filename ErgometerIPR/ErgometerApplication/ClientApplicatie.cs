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
        private int count;

        public ClientApplicatie()
        {
            InitializeComponent();
            MainClient.Init(this);
            count = 0;
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

                    if (count >= 10)
                    {
                        count = 0;
                        panelGraphView.updateAllCharts(MainClient.Metingen);
                    }

                    count++;
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
                        panelClientContainer.BringToFront();
                        chat = panelClientChat;
                        this.labelUsername.Text = panelLogin.textBoxUsername.Text;
                        panelTopBar.Visible = true;
                        updateTimer.Start();
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

        private void ClientApplicatie_Resize(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;
            if (control.Size.Width < 980)
            {
                panelGraphView.Visible = false;
                panelClientChat.Width = 400;
                panelDataViewLeft.Dock = DockStyle.Fill;
            }
            if (control.Size.Width >= 980 && control.Size.Width < 1368)
            {
                panelGraphView.Visible = true;
                panelDataViewLeft.Width = 250;
                panelClientChat.Width = 400;
                panelDataViewLeft.Dock = DockStyle.Left;
            }
            if (control.Size.Width >= 1368)
            {
                panelGraphView.Visible = true;
                panelDataViewLeft.Width = 400;
                panelDataViewLeft.Dock = DockStyle.Left;
            }

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