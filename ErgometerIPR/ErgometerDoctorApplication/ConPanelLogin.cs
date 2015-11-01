using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgometerDoctorApplication
{
    public class ConPanelLogin:Panel
    {

        MainWindow mainWindow;

        public ConPanelLogin(Form mainWindow) : base()
        {
            this.mainWindow = (MainWindow)mainWindow;
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelLoginInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            // 
            // Container
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.labelLoginInfo);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBoxPassword);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPassword.Location = new System.Drawing.Point(15, 70);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(150, 20);
            this.textBoxPassword.TabIndex = 0;
            this.textBoxPassword.KeyDown += TextBoxPassword_KeyDown;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)Properties.Resources.imageDoctor);
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Location = new System.Drawing.Point(0, -150);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 175);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            // 
            // buttonLogin
            // 
            this.buttonLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonLogin.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(15, 105);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(150, 30);
            this.buttonLogin.TabIndex = 2;
            this.buttonLogin.Text = "Log In";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // labelPassword
            // 
            this.labelPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.Location = new System.Drawing.Point(11, 40);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(103, 21);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Wachtwoord";
            //
            // labelLoginInfo
            //
            this.labelLoginInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLoginInfo.AutoSize = true;
            this.labelLoginInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoginInfo.ForeColor = System.Drawing.Color.Red;
            this.labelLoginInfo.Location = new System.Drawing.Point(11, 140);
            this.labelLoginInfo.Name = "labelLoginInfo";
            this.labelLoginInfo.Size = new System.Drawing.Size(103, 21);
            this.labelLoginInfo.TabIndex = 4;
            this.labelLoginInfo.Text = "";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();

        }

        private void TextBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin_Click(this, new EventArgs());
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            mainWindow.validateLogin();
        }
        public System.Windows.Forms.TextBox textBoxPassword;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelPassword;
        public System.Windows.Forms.Label labelLoginInfo;
    }
    
}
