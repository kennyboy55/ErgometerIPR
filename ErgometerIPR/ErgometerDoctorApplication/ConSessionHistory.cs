using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgometerDoctorApplication
{
    public class ConSessionHistory : Panel
    {
        private FlowLayoutPanel flowlayout;

        public ConSessionHistory() : base()
        {
            labelSessionHistory = new Label();

            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ConSessionHistory";
            this.Size = new System.Drawing.Size(584, 459);
            this.TabIndex = 0;
            // 
            // labelSessionHistory
            // 
            this.labelSessionHistory.Anchor = System.Windows.Forms.AnchorStyles.Top | AnchorStyles.Left;
            this.labelSessionHistory.AutoSize = true;
            this.labelSessionHistory.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSessionHistory.Location = new System.Drawing.Point(20, 20);
            this.labelSessionHistory.Name = "labelSessionHistory";
            this.labelSessionHistory.Size = new System.Drawing.Size(103, 21);
            this.labelSessionHistory.TabIndex = 3;
            this.labelSessionHistory.Text = "Er zijn geen oude sessies.";

            flowlayout = new FlowLayoutPanel();

            flowlayout.Dock = DockStyle.Fill;
            flowlayout.BackColor = System.Drawing.Color.WhiteSmoke;
            flowlayout.Location = new System.Drawing.Point(0, 0);
            flowlayout.Name = "flowlayout";
            flowlayout.Padding = new Padding(15);
            flowlayout.AutoScroll = true;

            this.Controls.Add(labelSessionHistory);
            this.Controls.Add(flowlayout);

            //this.Controls.Add(data);

            updateHistory(MainClient.oldSessionsData);

        }

        public System.Windows.Forms.Label labelSessionHistory;

        public void updateHistory(List<Tuple<string, double, int>> historys)
        {
            flowlayout.Controls.Clear();

            foreach (Tuple<string,double,int> sessiondata in historys)
            {
                flowlayout.Controls.Add(new SessionPanel(sessiondata.Item3, sessiondata.Item1, false,sessiondata.Item2));
            }
        }
    }
}
