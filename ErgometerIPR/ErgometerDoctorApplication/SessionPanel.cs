using System.Windows.Forms;

namespace ErgometerDoctorApplication
{
    class SessionPanel : Panel
    {
        private int Session;
        private string name;
        private bool IsNew;
        private double timestamp;

        public SessionPanel(int session, string name, bool isNew,double timestamp) : base()
        {
            this.timestamp = timestamp;
            Session = session;
            this.name = name;
            IsNew = isNew;

            this.Location = new System.Drawing.Point(0, 0);
            this.Size = new System.Drawing.Size(180, 100);
            this.BackColor = System.Drawing.Color.DarkGray;

            this.Click += SessionPanel_Click;
            this.MouseEnter += SessionPanel_MouseEnter;
            this.MouseLeave += SessionPanel_MouseLeave;
            this.Cursor = Cursors.Hand;

            this.labelTimestamp = new Label();
            this.labelName = new System.Windows.Forms.Label();

            // 
            // labelActiveSessions
            // 
            this.labelName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(10, 10);
            this.labelName.ForeColor = System.Drawing.Color.White;
            this.labelName.Name = "labelActiveSessions";
            this.labelName.Size = new System.Drawing.Size(103, 21);
            this.labelName.TabIndex = 3;
            this.labelName.Text = name;
            this.labelName.Click += SessionPanel_Click;
            this.labelName.MouseEnter += SessionPanel_MouseEnter;
            this.labelName.MouseLeave += SessionPanel_MouseLeave;
            this.labelName.Cursor = Cursors.Hand;

            this.labelTimestamp.Name = "labelTimeStamp";
            this.labelTimestamp.Anchor = AnchorStyles.None;
            this.labelTimestamp.Text = ErgometerLibrary.Helper.MillisecondsToTime(timestamp);
            this.labelTimestamp.Location = new System.Drawing.Point(10, 40);
            this.labelTimestamp.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimestamp.ForeColor = System.Drawing.Color.White;
            this.labelTimestamp.Size = new System.Drawing.Size(103, 21);
            this.labelTimestamp.Click += SessionPanel_Click;
            this.labelTimestamp.MouseEnter += SessionPanel_MouseEnter;
            this.labelTimestamp.MouseLeave += SessionPanel_MouseLeave;

            if (isNew)
                labelTimestamp.Visible = false;

            this.Controls.Add(labelName);
            this.Controls.Add(labelTimestamp);
        }

        private void SessionPanel_MouseEnter(object sender, System.EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Gray;
            this.labelName.ForeColor = System.Drawing.Color.WhiteSmoke;
            labelTimestamp.ForeColor = System.Drawing.Color.WhiteSmoke;
        }

        private void SessionPanel_MouseLeave(object sender, System.EventArgs e)
        {
            this.BackColor = System.Drawing.Color.DarkGray;
            this.labelName.ForeColor = System.Drawing.Color.White;
            this.labelTimestamp.ForeColor = System.Drawing.Color.White;
        }

        private void SessionPanel_Click(object sender, System.EventArgs e)
        {
            if(IsNew)
                MainClient.StartNewClient(name, Session);
            else
                MainClient.StartOldClient(name, Session);
        }

        public System.Windows.Forms.Label labelName;
        public Label labelTimestamp;
    }
}