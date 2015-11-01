using ErgometerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgometerDoctorApplication.Client
{
    public class PanelClientSetData : Panel
    {

        private Panel panel6;
        private Label label3;
        private Panel panel5;
        private Label label4;
        private Panel panel3;
        private Label label2;
        private Panel panel2;
        private Label label1;
        private Button buttonTrapsnelheid;
        private TrackBar trackBar1;
        private Label label6;
        private Button buttonAfstand;
        private TextBox textBox2;
        private Label label5;
        private Button buttonTijd;
        private MaskedTextBox textBox1;

        private int Session;

        public PanelClientSetData(int session) : base()
        {
            Session = session;
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.MaskedTextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.buttonTijd = new System.Windows.Forms.Button();
            this.buttonAfstand = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonTrapsnelheid = new System.Windows.Forms.Button();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 

            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.buttonTrapsnelheid);
            this.panel6.Controls.Add(this.trackBar1);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 199);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(370, 112);
            this.panel6.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(4, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Trapsterkte aanpassen";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.buttonAfstand);
            this.panel5.Controls.Add(this.textBox2);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 124);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(370, 75);
            this.panel5.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(4, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Afstand instellen";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.buttonTijd);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Font = new System.Drawing.Font("Tunga", 8.25F);
            this.panel3.Location = new System.Drawing.Point(0, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(370, 72);
            this.panel3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tijd aanpassen";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(500, 52);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Eigenschappen fiets aanpassen";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(123, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(77, 25);
            this.textBox1.TabIndex = 1;
            this.textBox1.Mask = "00:00";
            this.textBox1.KeyDown += TextBox1_KeyDown;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.textBox2.Location = new System.Drawing.Point(124, 24);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(77, 25);
            this.textBox2.TabIndex = 1;
            this.textBox2.KeyDown += TextBox2_KeyDown;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(29, 42);
            this.trackBar1.Maximum = 400;
            this.trackBar1.Minimum = 25;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(221, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.Value = 25;
            // 
            // button1
            // 
            this.buttonTijd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonTijd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTijd.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.buttonTijd.Location = new System.Drawing.Point(282, 19);
            this.buttonTijd.Name = "button1";
            this.buttonTijd.Size = new System.Drawing.Size(75, 25);
            this.buttonTijd.TabIndex = 2;
            this.buttonTijd.Text = "Set";
            this.buttonTijd.UseVisualStyleBackColor = false;
            this.buttonTijd.Click += new System.EventHandler(this.buttonTijd_Click);
            // 
            // button2
            // 
            this.buttonAfstand.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonAfstand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAfstand.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.buttonAfstand.Location = new System.Drawing.Point(283, 24);
            this.buttonAfstand.Name = "button2";
            this.buttonAfstand.Size = new System.Drawing.Size(75, 25);
            this.buttonAfstand.TabIndex = 2;
            this.buttonAfstand.Text = "Set";
            this.buttonAfstand.UseVisualStyleBackColor = false;
            this.buttonAfstand.Click += new System.EventHandler(this.buttonAfstand_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(207, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "sec";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "m";
            // 
            // button3
            // 
            this.buttonTrapsnelheid.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonTrapsnelheid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTrapsnelheid.Location = new System.Drawing.Point(283, 42);
            this.buttonTrapsnelheid.Name = "button3";
            this.buttonTrapsnelheid.Size = new System.Drawing.Size(75, 25);
            this.buttonTrapsnelheid.TabIndex = 2;
            this.buttonTrapsnelheid.Text = "Set";
            this.buttonTrapsnelheid.UseVisualStyleBackColor = false;
            this.buttonTrapsnelheid.Click += new System.EventHandler(this.buttonTrapsnelheid_Click);

            Controls.Add(this.panel6);
            Controls.Add(this.panel5);
            Controls.Add(this.panel3);
            Controls.Add(this.panel2);
            Dock = System.Windows.Forms.DockStyle.Fill;
            Location = new System.Drawing.Point(0, 0);
            BackColor = System.Drawing.Color.White;
            Name = "panel1";
            Size = new System.Drawing.Size(370, 400);

        }

        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                buttonAfstand_Click(this, new EventArgs());
            }
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonTijd_Click(this, new EventArgs());
            }
        }

        private void buttonTrapsnelheid_Click(object sender, EventArgs e)
        {
            MainClient.SendNetCommand(new NetCommand(NetCommand.ValueType.POWER, trackBar1.Value, Session));
        }

        private void buttonAfstand_Click(object sender, EventArgs e)
        {
            MainClient.SendNetCommand(new NetCommand(NetCommand.ValueType.DISTANCE, int.Parse(textBox2.Text), Session));
            textBox2.Text = "";
        }

        private void buttonTijd_Click(object sender, EventArgs e)
        {
            int seconds = (int.Parse(textBox1.Text.Split(':')[0]) * 60) + int.Parse(textBox1.Text.Split(':')[1]);
            MainClient.SendNetCommand(new NetCommand(NetCommand.ValueType.TIME, seconds, Session));
            textBox1.Text = "";
        }
    }
}
