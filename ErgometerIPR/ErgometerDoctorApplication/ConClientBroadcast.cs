using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgometerDoctorApplication
{
    public class ConClientBroadcast : Panel
    { 

        public ConClientBroadcast() : base()
        {

            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ConClientBroadcast";
            this.Size = new System.Drawing.Size(584, 459);
            this.TabIndex = 0;

            buttonBroadcast = new Button();
            textBoxBroadcast = new TextBox();

            // 
            // buttonLogin
            // 
            this.buttonBroadcast.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.buttonBroadcast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBroadcast.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBroadcast.Location = new System.Drawing.Point(200, 20);
            this.buttonBroadcast.Name = "buttonCreate";
            this.buttonBroadcast.Size = new System.Drawing.Size(168, 31);
            this.buttonBroadcast.TabIndex = 3;
            this.buttonBroadcast.Text = "Broadcast";
            this.buttonBroadcast.UseVisualStyleBackColor = true;
            this.buttonBroadcast.Click += new System.EventHandler(this.buttonBroadcast_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxBroadcast.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.textBoxBroadcast.Location = new System.Drawing.Point(20, 20);
            this.textBoxBroadcast.MaxLength = 16;
            this.textBoxBroadcast.Name = "textBoxPassword";
            this.textBoxBroadcast.Size = new System.Drawing.Size(167, 20);
            this.textBoxBroadcast.TabIndex = 2;
            this.textBoxBroadcast.KeyDown += TextBoxBroadcast_KeyDown;

            this.Controls.Add(textBoxBroadcast);
            this.Controls.Add(buttonBroadcast);


        }

        private void TextBoxBroadcast_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonBroadcast_Click(this, new EventArgs());
            }
        }

        private void buttonBroadcast_Click(object sender, EventArgs e)
        {
            MainClient.SendNetCommand(new ErgometerLibrary.NetCommand(textBoxBroadcast.Text, MainClient.Session));
            textBoxBroadcast.Text = "";
        }

        public System.Windows.Forms.TextBox textBoxBroadcast;
        public System.Windows.Forms.Button buttonBroadcast;
    }
}
