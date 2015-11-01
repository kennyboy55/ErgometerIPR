using System;
using System.Windows.Forms;

namespace ErgometerDoctorApplication
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.BtnLogout = new System.Windows.Forms.Button();
            this.BtnSessionHistory = new System.Windows.Forms.Button();
            this.BtnBroadcast = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnClientData = new System.Windows.Forms.Button();
            this.BtnActiveSessions = new System.Windows.Forms.Button();
            this.LblHoofdvenster = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.MainContainer = new System.Windows.Forms.Panel();
            this.conActiveSessions = new ErgometerDoctorApplication.ConActiveSessions();
            this.conClientData = new ErgometerDoctorApplication.ConClientData();
            this.conSessionHistory = new ErgometerDoctorApplication.ConSessionHistory();
            this.conClientBroadcast = new ErgometerDoctorApplication.ConClientBroadcast();
            this.conPanelLogin = new ErgometerDoctorApplication.ConPanelLogin(this);
            this.updateTimer = new Timer();
            MainContainer.Visible = false;
            panel1.Visible = false;
            MenuPanel.Visible = false;
            menuStrip1.Visible = false;
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MenuPanel.Controls.Add(this.BtnLogout);
            this.MenuPanel.Controls.Add(this.BtnSessionHistory);
            this.MenuPanel.Controls.Add(this.BtnBroadcast);
            this.MenuPanel.Controls.Add(this.label2);
            this.MenuPanel.Controls.Add(this.label1);
            this.MenuPanel.Controls.Add(this.BtnClientData);
            this.MenuPanel.Controls.Add(this.BtnActiveSessions);
            this.MenuPanel.Controls.Add(this.LblHoofdvenster);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuPanel.Location = new System.Drawing.Point(0, 24);
            this.MenuPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(200, 537);
            this.MenuPanel.TabIndex = 0;

            // 
            // BtnLogout
            // 
            this.BtnLogout.BackColor = System.Drawing.Color.DarkGray;
            this.BtnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnLogout.FlatAppearance.BorderSize = 0;
            this.BtnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogout.ForeColor = System.Drawing.Color.White;
            this.BtnLogout.Location = new System.Drawing.Point(0, 205);
            this.BtnLogout.Name = "BtnLogout";
            this.BtnLogout.Size = new System.Drawing.Size(200, 35);
            this.BtnLogout.Text = "Uitloggen";
            this.BtnLogout.UseVisualStyleBackColor = false;
            this.BtnLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // BtnSessionHistory
            // 
            this.BtnSessionHistory.BackColor = System.Drawing.Color.DarkGray;
            this.BtnSessionHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnSessionHistory.FlatAppearance.BorderSize = 0;
            this.BtnSessionHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSessionHistory.ForeColor = System.Drawing.Color.White;
            this.BtnSessionHistory.Location = new System.Drawing.Point(0, 205);
            this.BtnSessionHistory.Name = "BtnSessionHistory";
            this.BtnSessionHistory.Size = new System.Drawing.Size(200, 35);
            this.BtnSessionHistory.TabIndex = 7;
            this.BtnSessionHistory.Text = "Sessie Geschiedenis";
            this.BtnSessionHistory.UseVisualStyleBackColor = false;
            this.BtnSessionHistory.Click += new System.EventHandler(this.BtnSessionHistory_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 180);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 4, 0, 0);
            this.label2.Size = new System.Drawing.Size(200, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "SESSIE BEHEER";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // updateTimer
            //
            this.updateTimer.Interval = 3000;
            this.updateTimer.Tick += new EventHandler(this.updateTimer_tick);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 50);
            this.label1.TabIndex = 5;
            // 
            // BtnBroadcast
            // 
            this.BtnBroadcast.BackColor = System.Drawing.Color.DarkGray;
            this.BtnBroadcast.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnBroadcast.FlatAppearance.BorderSize = 0;
            this.BtnBroadcast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBroadcast.ForeColor = System.Drawing.Color.White;
            this.BtnBroadcast.Location = new System.Drawing.Point(0, 95);
            this.BtnBroadcast.Name = "BtnBroadcast";
            this.BtnBroadcast.Size = new System.Drawing.Size(200, 35);
            this.BtnBroadcast.TabIndex = 7;
            this.BtnBroadcast.Text = "Broadcast";
            this.BtnBroadcast.UseVisualStyleBackColor = false;
            this.BtnBroadcast.Click += new System.EventHandler(this.BtnBroadcast_Click);
            // 
            // BtnClientData
            // 
            this.BtnClientData.BackColor = System.Drawing.Color.DarkGray;
            this.BtnClientData.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnClientData.FlatAppearance.BorderSize = 0;
            this.BtnClientData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClientData.ForeColor = System.Drawing.Color.White;
            this.BtnClientData.Location = new System.Drawing.Point(0, 60);
            this.BtnClientData.Name = "BtnClientData";
            this.BtnClientData.Size = new System.Drawing.Size(200, 35);
            this.BtnClientData.TabIndex = 4;
            this.BtnClientData.Text = "Clientenbestand";
            this.BtnClientData.UseVisualStyleBackColor = false;
            this.BtnClientData.Click += new System.EventHandler(this.BtnClientData_Click);
            // 
            // BtnActiveSessions
            // 
            this.BtnActiveSessions.BackColor = System.Drawing.Color.DarkGray;
            this.BtnActiveSessions.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnActiveSessions.FlatAppearance.BorderSize = 0;
            this.BtnActiveSessions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnActiveSessions.ForeColor = System.Drawing.Color.White;
            this.BtnActiveSessions.Location = new System.Drawing.Point(0, 25);
            this.BtnActiveSessions.Name = "BtnActiveSessions";
            this.BtnActiveSessions.Size = new System.Drawing.Size(200, 35);
            this.BtnActiveSessions.TabIndex = 3;
            this.BtnActiveSessions.Text = "Actieve Sessies";
            this.BtnActiveSessions.UseVisualStyleBackColor = false;
            this.BtnActiveSessions.Click += new System.EventHandler(this.BtnActiveSessions_Click);
            // 
            // LblHoofdvenster
            // 
            this.LblHoofdvenster.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblHoofdvenster.Location = new System.Drawing.Point(0, 0);
            this.LblHoofdvenster.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.LblHoofdvenster.Name = "LblHoofdvenster";
            this.LblHoofdvenster.Padding = new System.Windows.Forms.Padding(5, 4, 0, 0);
            this.LblHoofdvenster.Size = new System.Drawing.Size(200, 25);
            this.LblHoofdvenster.TabIndex = 0;
            this.LblHoofdvenster.Text = "HOOFDVENSTER";
            this.LblHoofdvenster.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DimGray;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.HeaderLabel);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(200, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 78);
            this.panel1.TabIndex = 2;
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.HeaderLabel.Location = new System.Drawing.Point(0, 0);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Padding = new System.Windows.Forms.Padding(8, 12, 0, 0);
            this.HeaderLabel.Size = new System.Drawing.Size(584, 50);
            this.HeaderLabel.TabIndex = 1;
            this.HeaderLabel.Text = "Actieve Sessies";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.ForeColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(0, 74);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(584, 4);
            this.panel3.TabIndex = 0;
            // 
            // MainContainer
            // 
            this.MainContainer.Controls.Add(this.conActiveSessions);
            this.MainContainer.Controls.Add(this.conClientData);
            this.MainContainer.Controls.Add(this.conSessionHistory);
            this.MainContainer.Controls.Add(this.conClientBroadcast);
            this.MainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContainer.Location = new System.Drawing.Point(200, 102);
            this.MainContainer.Name = "MainContainer";
            this.MainContainer.Size = new System.Drawing.Size(584, 459);
            this.MainContainer.TabIndex = 3;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.MinimumSize = new System.Drawing.Size(650, 550);
            this.Controls.Add(this.MainContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MenuPanel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.conPanelLogin);

            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Dokter applicatie";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

        }


        #endregion

        private Panel MenuPanel;
        private Label LblHoofdvenster;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private Button BtnActiveSessions;
        private Button BtnBroadcast;
        private Button BtnLogout;
        private Button BtnSessionHistory;
        private Button BtnClientData;
        private Label label2;
        private Label label1;
        private Panel panel1;
        private Panel panel3;
        public Label HeaderLabel;
        public Timer updateTimer;
        public Panel MainContainer;
        public ConActiveSessions conActiveSessions;
        public ConSessionHistory conSessionHistory;
        public ConClientData conClientData;
        public ConPanelLogin conPanelLogin;
        public ConClientBroadcast conClientBroadcast;

    }
}

