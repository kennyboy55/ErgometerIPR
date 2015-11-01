using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgometerApplication
{
    public class PanelLogin:Panel
    {
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        public System.Windows.Forms.Label lblVerification;
        public System.Windows.Forms.TextBox textBoxPassword;
        public System.Windows.Forms.TextBox textBoxUsername;
        public System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label lblLoginTitle;
        private System.Windows.Forms.PictureBox pictureBoxBike;
        private ClientApplicatie app;

        public PanelLogin(ClientApplicatie app):base()
        {
            this.app = app;
            this.pictureBoxBike = new System.Windows.Forms.PictureBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.lblLoginTitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblVerification = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBike)).BeginInit();
            // 
            // panelLogin
            // 
            this.Controls.Add(this.pictureBoxBike);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.lblLoginTitle);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblVerification);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "panelLogin";
            this.Size = new System.Drawing.Size(800, 600);
            this.TabIndex = 0;
            // 
            // pictureBoxBike
            // 
            this.pictureBoxBike.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxBike.Image = global::ErgometerApplication.Properties.Resources.flatbike;
            this.pictureBoxBike.Location = new System.Drawing.Point(137, 131);
            this.pictureBoxBike.Name = "pictureBoxBike";
            this.pictureBoxBike.Size = new System.Drawing.Size(250, 250);
            this.pictureBoxBike.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBike.TabIndex = 4;
            this.pictureBoxBike.TabStop = false;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.Location = new System.Drawing.Point(468, 338);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(168, 31);
            this.buttonLogin.TabIndex = 3;
            this.buttonLogin.Text = "Aanmelden";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPassword.Location = new System.Drawing.Point(467, 287);
            this.textBoxPassword.MaxLength = 16;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(167, 20);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.KeyDown += TextBoxPassword_KeyDown;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxUsername.Location = new System.Drawing.Point(468, 231);
            this.textBoxUsername.MaxLength = 16;
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(167, 20);
            this.textBoxUsername.TabIndex = 2;
            this.textBoxUsername.KeyDown += TextBoxPassword_KeyDown;
            // 
            // lblLoginTitle
            // 
            this.lblLoginTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLoginTitle.AutoSize = true;
            this.lblLoginTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginTitle.Location = new System.Drawing.Point(461, 141);
            this.lblLoginTitle.Name = "lblLoginTitle";
            this.lblLoginTitle.Size = new System.Drawing.Size(87, 32);
            this.lblLoginTitle.TabIndex = 1;
            this.lblLoginTitle.Text = "Log In";
            // 
            // lblVerification
            // 
            this.lblVerification.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVerification.AutoSize = true;
            this.lblVerification.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVerification.Location = new System.Drawing.Point(140, 415);
            this.lblVerification.Name = "lvlVerification";
            this.lblVerification.Size = new System.Drawing.Size(200, 21);
            this.lblVerification.TabIndex = 1;
            this.lblVerification.Text = "Verification label";
            this.lblVerification.Visible = false;
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(464, 207);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(128, 21);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Gebruikersnaam";
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblPassword.Location = new System.Drawing.Point(464, 263);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(103, 21);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "Wachtwoord";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBike)).EndInit();
        }

        private void TextBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin_Click(this, new EventArgs());
            }
        }

        public void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            this.app.validateLogin(username,password);
        }
    }
}
