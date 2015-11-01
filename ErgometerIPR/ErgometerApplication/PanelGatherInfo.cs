using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgometerApplication
{
    public class PanelGatherInfo :Panel
    {
        private System.Windows.Forms.Label lblGeslacht;
        private System.Windows.Forms.Label lblLeeftijd;
        private System.Windows.Forms.Label lblLengte;
        private System.Windows.Forms.Label lblGewicht;
        public System.Windows.Forms.Label lblFeedback;
        public System.Windows.Forms.TextBox textBoxLeeftijd;
        public System.Windows.Forms.TextBox textBoxLengte;
        public System.Windows.Forms.TextBox textBoxGewicht;
        public System.Windows.Forms.ComboBox comboBoxGeslacht;
        public System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label lblInfoTitel;
        private System.Windows.Forms.PictureBox pictureBoxBike;
        private ClientApplicatie app;

        public PanelGatherInfo(ClientApplicatie app):base()
        {
            this.app = app;
            this.pictureBoxBike = new System.Windows.Forms.PictureBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBoxLeeftijd = new System.Windows.Forms.TextBox();
            this.textBoxLengte = new System.Windows.Forms.TextBox();
            this.textBoxGewicht = new TextBox();
            this.comboBoxGeslacht = new ComboBox();
            this.lblInfoTitel = new System.Windows.Forms.Label();
            this.lblGeslacht = new System.Windows.Forms.Label();
            this.lblGewicht = new System.Windows.Forms.Label();
            this.lblLeeftijd = new System.Windows.Forms.Label();
            this.lblLengte = new Label();
            this.lblFeedback = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBike)).BeginInit();
            // 
            // panelLogin
            // 
            this.Controls.Add(this.pictureBoxBike);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.comboBoxGeslacht);
            this.Controls.Add(this.textBoxGewicht);
            this.Controls.Add(this.textBoxLengte);
            this.Controls.Add(this.textBoxLeeftijd);
            this.Controls.Add(this.lblInfoTitel);
            this.Controls.Add(this.lblGeslacht);
            this.Controls.Add(this.lblGewicht);
            this.Controls.Add(this.lblLeeftijd);
            this.Controls.Add(this.lblFeedback);
            this.Controls.Add(this.lblLengte);
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
            this.buttonStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(468, 420);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(168, 31);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "Start Test";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxLeeftijd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxLeeftijd.Location = new System.Drawing.Point(467, 270);
            this.textBoxLeeftijd.MaxLength = 16;
            this.textBoxLeeftijd.Name = "textBoxLeeftijd";
            this.textBoxLeeftijd.Size = new System.Drawing.Size(167, 20);
            this.textBoxLeeftijd.TabIndex = 2;
            this.textBoxLeeftijd.KeyDown += TextBox_KeyDown;

            // 
            // textBoxPassword
            // 
            this.textBoxGewicht.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxGewicht.Location = new System.Drawing.Point(467, 390);
            this.textBoxGewicht.MaxLength = 16;
            this.textBoxGewicht.Name = "textBoxGewicht";
            this.textBoxGewicht.Size = new System.Drawing.Size(167, 20);
            this.textBoxGewicht.TabIndex = 2;
            this.textBoxGewicht.KeyDown += TextBox_KeyDown;
            // 
            // textBoxUsername
            // 
            this.textBoxLengte.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxLengte.Location = new System.Drawing.Point(468, 330);
            this.textBoxLengte.MaxLength = 16;
            this.textBoxLengte.Name = "textBoxLengte";
            this.textBoxLengte.Size = new System.Drawing.Size(167, 20);
            this.textBoxLengte.TabIndex = 2;
            this.textBoxLengte.KeyDown += TextBox_KeyDown;
            // 
            // comboBox
            // 
            this.comboBoxGeslacht.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxGeslacht.Location = new System.Drawing.Point(468, 210);
            this.comboBoxGeslacht.MaxLength = 16;
            this.comboBoxGeslacht.Name = "textBoxLengte";
            this.comboBoxGeslacht.Size = new System.Drawing.Size(167, 20);
            this.comboBoxGeslacht.TabIndex = 2;
            this.comboBoxGeslacht.Items.AddRange(new object[] { "Man", "Vrouw" });
            this.comboBoxGeslacht.SelectedIndex = 0;
            // 
            // lblLoginTitle
            // 
            this.lblInfoTitel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInfoTitel.AutoSize = true;
            this.lblInfoTitel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoTitel.Location = new System.Drawing.Point(461, 141);
            this.lblInfoTitel.Name = "lblLoginTitle";
            this.lblInfoTitel.Size = new System.Drawing.Size(87, 32);
            this.lblInfoTitel.TabIndex = 1;
            this.lblInfoTitel.Text = "Vul je gegevens in";
            // 
            // lblVerification
            // 
            this.lblFeedback.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFeedback.AutoSize = true;
            this.lblFeedback.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeedback.Location = new System.Drawing.Point(140, 415);
            this.lblFeedback.Name = "lvlVerification";
            this.lblFeedback.Size = new System.Drawing.Size(200, 21);
            this.lblFeedback.ForeColor = System.Drawing.Color.Red;
            this.lblFeedback.TabIndex = 1;
            this.lblFeedback.Text = "";
            // 
            // lblUsername
            // 
            this.lblGeslacht.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGeslacht.AutoSize = true;
            this.lblGeslacht.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeslacht.Location = new System.Drawing.Point(464, 180);
            this.lblGeslacht.Name = "lblUsername";
            this.lblGeslacht.Size = new System.Drawing.Size(128, 21);
            this.lblGeslacht.TabIndex = 1;
            this.lblGeslacht.Text = "Geslacht";
            // 
            // lblUsername
            // 
            this.lblLeeftijd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLeeftijd.AutoSize = true;
            this.lblLeeftijd.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeeftijd.Location = new System.Drawing.Point(464, 240);
            this.lblLeeftijd.Name = "lblUsername";
            this.lblLeeftijd.Size = new System.Drawing.Size(128, 21);
            this.lblLeeftijd.TabIndex = 1;
            this.lblLeeftijd.Text = "Leeftijd";
            // 
            // lblUsername
            // 
            this.lblLengte.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLengte.AutoSize = true;
            this.lblLengte.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLengte.Location = new System.Drawing.Point(464, 300);
            this.lblLengte.Name = "lblLengte";
            this.lblLengte.Size = new System.Drawing.Size(128, 21);
            this.lblLengte.TabIndex = 1;
            this.lblLengte.Text = "Lengte";
            // 
            // lblPassword
            // 
            this.lblGewicht.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGewicht.AutoSize = true;
            this.lblGewicht.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblGewicht.Location = new System.Drawing.Point(464, 360);
            this.lblGewicht.Name = "lblPassword";
            this.lblGewicht.Size = new System.Drawing.Size(103, 21);
            this.lblGewicht.TabIndex = 0;
            this.lblGewicht.Text = "Gewicht";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBike)).EndInit();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonStart_Click(this, new EventArgs());
            }
        }

        public void buttonStart_Click(object sender, EventArgs e)
        {
            char geslacht = comboBoxGeslacht.SelectedText == "Vrouw" ? 'V' : 'M';
            int leeftijd = 0;
            bool leeftijdOk = int.TryParse(textBoxLeeftijd.Text, out leeftijd);

            if(!leeftijdOk)
            {
                lblFeedback.Text = "Leeftijd is niet juist";
                textBoxLeeftijd.ForeColor = System.Drawing.Color.Red;
                return;
            }

            int gewicht = 0;
            bool gewichtOk = int.TryParse(textBoxGewicht.Text, out gewicht);

            if (!gewichtOk)
            {
                lblFeedback.Text = "Gewicht is niet juist";
                textBoxGewicht.ForeColor = System.Drawing.Color.Red;
                return;
            }

            textBoxGewicht.BackColor = System.Drawing.Color.Black;

            int lengte = 0;
            bool lengteOk = int.TryParse(textBoxLengte.Text, out lengte);

            if (!lengteOk)
            {
                lblFeedback.Text = "Lengte is niet juist";
                textBoxLengte.ForeColor = System.Drawing.Color.Red;
                return;
            }

            lblFeedback.Text = "";
            textBoxLengte.BackColor = System.Drawing.Color.Black;

            app.CreateNewTest(geslacht, leeftijd, gewicht, lengte);
        }
    }
}
