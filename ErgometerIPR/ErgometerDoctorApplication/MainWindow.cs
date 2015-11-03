using ErgometerLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgometerDoctorApplication
{
    public partial class MainWindow : Form
    {
        private int request;
        public bool updateSession;

        public MainWindow()
        {
            InitializeComponent();
            MainClient.Init(this);

            updateSession = false;
            conPanelLogin.BringToFront();
            request = 2;
            updateTimer.Start();
            
        }

        private void BtnActiveSessions_Click(object sender, EventArgs e)
        {
            this.HeaderLabel.Text = "Actieve Sessies";

            if(MainClient.activesessions.Count > 0)
            {
                conActiveSessions.labelActiveSessions.Text = "";
                conActiveSessions.updateActiveSessions(MainClient.activesessions);
            }
            else
            {
                conActiveSessions.updateActiveSessions(MainClient.activesessions);
                conActiveSessions.labelActiveSessions.Text = "Er zijn geen actieve sessies.";
            }

            conActiveSessions.BringToFront();
        }

        private void BtnClientData_Click(object sender, EventArgs e)
        {
            this.HeaderLabel.Text = "Clientenbestand";
            

            if (MainClient.users.Count > 0)
            {
                conClientData.updateUsers(MainClient.users);
            }

            conClientData.BringToFront();
        }

        private void BtnBroadcast_Click(object sender, EventArgs e)
        {
            this.HeaderLabel.Text = "Broadcast";
            conClientBroadcast.BringToFront();
        }

        private void BtnSessionHistory_Click(object sender, EventArgs e)
        {
            this.HeaderLabel.Text = "Sessie geschiedenis";

            if (MainClient.oldSessionsData.Count > 0)
            {
                conSessionHistory.labelSessionHistory.Text = "";
                conSessionHistory.updateHistory(MainClient.oldSessionsData);
            }
            else
            {
                conSessionHistory.updateHistory(MainClient.oldSessionsData);
                conSessionHistory.labelSessionHistory.Text = "Er zijn geen oude sessies.";
            }

            conSessionHistory.BringToFront();
        }
        public void validateLogin()
        {
            string error = "";
            bool connect = MainClient.Connect(conPanelLogin.textBoxPassword.Text, out error);

            if (connect)
            {
                conPanelLogin.textBoxPassword.Text = "";
                conPanelLogin.labelLoginInfo.Text = "";

                if (MainClient.activesessions.Count > 0)
                {
                    conActiveSessions.labelActiveSessions.Text = "";
                    conActiveSessions.updateActiveSessions(MainClient.activesessions);
                }

                showDashboard();
            }
            else
            {
                conPanelLogin.labelLoginInfo.Text = error;
                showLoginScreen();
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            MainClient.Disconnect();
            showLoginScreen();
        }

        private void showDashboard()
        {
            conPanelLogin.Visible = false;
            MainContainer.Visible = true;
            panel1.Visible = true;
            MenuPanel.Visible = true;
            menuStrip1.Visible = true;
        }

        private void showLoginScreen()
        {
            MainContainer.Visible = false;
            panel1.Visible = false;
            MenuPanel.Visible = false;
            menuStrip1.Visible = false;
            conPanelLogin.Visible = true;
            conPanelLogin.BringToFront();
        }

        private void updateTimer_tick(object sender, EventArgs e)
        {
            if (updateSession)
            {
                BtnActiveSessions_Click(this, new EventArgs());
                updateSession = false;
            }

            if (request == 0)
                MainClient.SendNetCommand(new NetCommand(NetCommand.RequestType.USERS, MainClient.Session));
            else if (request == 1)
                MainClient.SendNetCommand(new NetCommand(NetCommand.RequestType.SESSIONDATA, MainClient.Session));
            else if (request == 2)
                MainClient.SendNetCommand(new NetCommand(NetCommand.RequestType.ALLSESSIONS, MainClient.Session));

            request ++;
            if (request > 2)
            {
                request = 0;
            }
        }
    }
}
