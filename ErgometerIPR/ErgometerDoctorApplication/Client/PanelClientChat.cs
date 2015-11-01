using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErgometerLibrary;
using ErgometerLibrary.Chat;

namespace ErgometerDoctorApplication
{
    public class PanelClientChat : Panel
    {


        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label connectionLabel;

        private int Session { get; }

        public PanelClientChat(int session, string name) : base()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.connectionLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();

            Session = session;

            this.panel3 = new System.Windows.Forms.Panel();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(390, 36);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            this.flowLayoutPanel1.SizeChanged += new System.EventHandler(this.FlowLayoutPanel1_SizeChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.connectionLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(385, 24);
            this.panel2.TabIndex = 0;
            // 
            // connectionLabel
            // 
            this.connectionLabel.AutoSize = true;
            this.connectionLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.connectionLabel.Location = new System.Drawing.Point(4, 4);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(112, 13);
            this.connectionLabel.TabIndex = 0;
            this.connectionLabel.Text = "Now connected with: " + name;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 100);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(310, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 90);
            this.button1.TabIndex = 1;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(4, 4);
            this.richTextBox1.MaxLength = 250;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(300, 90);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.HorizontalScroll.Enabled = false;
            this.panel3.HorizontalScroll.Visible = false;
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Location = new System.Drawing.Point(0, 0);

            this.panel3.Name = "panel3";
            this.panel3.TabIndex = 1;
            // 
            // container
            // 
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "container";
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseWheel);

            passChatMessage = new ChatDelegate(this.AddChatItem);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 1)
            {
                AddChatItem(new ChatMessage("Doctor", richTextBox1.Text, true));
                MainClient.SendNetCommand(new NetCommand(richTextBox1.Text, true, Session));
                richTextBox1.ResetText();
            }
        }

        public void AddChatItem(ChatMessage chat)
        {
            flowLayoutPanel1.Controls.Add(new ChatItem(chat));
        }

        private void panel3_MouseWheel(object sender, MouseEventArgs e)
        {
            panel3.Focus();
        }

        private void FlowLayoutPanel1_SizeChanged(object sender, System.EventArgs e)
        {
            if (flowLayoutPanel1.Size.Height > panel3.Size.Height)
            {
                panel2.Width = 375;
                flowLayoutPanel1.Width = 380;
                panel3.VerticalScroll.Value = panel3.VerticalScroll.Maximum;
            }
        }

        private bool textBoxIsEmpty()
        {
            string[] text = richTextBox1.Text.Split();
            foreach (string s in text)
            {
                if (s != " ")
                {
                    return false;
                }
            }
            return true;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
                e.Handled = true;
            }
        }

        public delegate void ChatDelegate(ChatMessage chat);
        public ChatDelegate passChatMessage;
    }
}
