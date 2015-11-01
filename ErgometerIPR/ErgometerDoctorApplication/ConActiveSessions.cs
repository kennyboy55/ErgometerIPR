using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgometerDoctorApplication
{
    public class ConActiveSessions : Panel
    {

        private FlowLayoutPanel flowlayout;

        public ConActiveSessions() : base()
        {
            labelActiveSessions = new Label();
            // 
            // ConActiveSessions
            // 
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ConActiveSessions";
            this.Size = new System.Drawing.Size(584, 459);
            this.TabIndex = 0;
            // 
            // labelActiveSessions
            // 
            this.labelActiveSessions.Anchor = System.Windows.Forms.AnchorStyles.Top | AnchorStyles.Left;
            this.labelActiveSessions.AutoSize = true;
            this.labelActiveSessions.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActiveSessions.Location = new System.Drawing.Point(20, 20);
            this.labelActiveSessions.Name = "labelActiveSessions";
            this.labelActiveSessions.Size = new System.Drawing.Size(103, 21);
            this.labelActiveSessions.TabIndex = 3;
            this.labelActiveSessions.Text = "Er zijn geen actieve sessies.";

            flowlayout = new FlowLayoutPanel();

            flowlayout.Dock = DockStyle.Fill;
            flowlayout.BackColor = System.Drawing.Color.WhiteSmoke;
            flowlayout.Location = new System.Drawing.Point(0, 0);
            flowlayout.Name = "flowlayout";
            flowlayout.Padding = new Padding(15);
            flowlayout.AutoScroll = true;

            this.Controls.Add(labelActiveSessions);
            this.Controls.Add(flowlayout);

            //this.Controls.Add(data);

            updateActiveSessions(MainClient.activesessions);
            
        }

        public System.Windows.Forms.Label labelActiveSessions;

        public void updateActiveSessions(Dictionary<int, string> actives)
        {
            flowlayout.Controls.Clear();

            foreach (KeyValuePair<int, string> pair in actives)
            {

                flowlayout.Controls.Add(new SessionPanel(pair.Key, pair.Value, true,0));
            }
        }

		/*
        private void data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (data.Rows[e.RowIndex].Cells[1].Value != null)
            {
                MainClient.StartNewCLient(data.Rows[e.RowIndex].Cells[0].Value + "", int.Parse(data.Rows[e.RowIndex].Cells[1].Value + ""));
            }
        }

        public System.Windows.Forms.DataGridViewTextBoxColumn name;
        public System.Windows.Forms.DataGridViewTextBoxColumn sessionId;
        public System.Windows.Forms.DataGridView data;
        */
    }
}
