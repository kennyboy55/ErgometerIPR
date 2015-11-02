using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgometerApplication
{
    public class PanelClientSteps : Panel
    {
        public Label UitlegText;
        public Label HeaderLabel;

        private string text;

        public PanelClientSteps() : base()
        {

            this.HeaderLabel = new System.Windows.Forms.Label();
            this.UitlegText = new System.Windows.Forms.Label();
            // 
            // initialize panel
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.UitlegText);
            this.Controls.Add(this.HeaderLabel);
            this.Dock = System.Windows.Forms.DockStyle.Top;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "PanelClientSteps";
            this.Size = new System.Drawing.Size(284, 150);
            this.Resize += PanelClientSteps_Resize;
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderLabel.Location = new System.Drawing.Point(12, 9);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(105, 21);
            this.HeaderLabel.TabIndex = 0;
            this.HeaderLabel.Text = "Uitleg";
            // 
            // UitlegText
            // 
            this.UitlegText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.UitlegText.AutoSize = true;
            this.UitlegText.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UitlegText.Location = new System.Drawing.Point(12, 35);
            this.UitlegText.Name = "UitlegText";
            this.UitlegText.Size = new System.Drawing.Size(800, 32);
            this.UitlegText.MaximumSize = new System.Drawing.Size(400, 0);
            this.UitlegText.TabIndex = 2;
            this.UitlegText.Text = text;
            this.UitlegText.TextChanged += UitlegText_TextChanged;
        }

        private void UitlegText_TextChanged(object sender, EventArgs e)
        {
            if (UitlegText.Size.Height + UitlegText.Location.Y + 10 > this.Size.Height)
                this.Size = new System.Drawing.Size(this.Size.Width, UitlegText.Size.Height + UitlegText.Location.Y + 10);
        }

        private void PanelClientSteps_Resize(object sender, EventArgs e)
        {
            UitlegText.MaximumSize = new System.Drawing.Size(this.Size.Width - 20, 0);
        }

        public void setText(string text)
        {
            this.UitlegText.Text = text;
        }
    }
}
