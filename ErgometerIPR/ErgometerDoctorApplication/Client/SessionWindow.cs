using ErgometerLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgometerDoctorApplication
{
    public partial class SessionWindow : Form
    {

        private bool ActiveSession { get; }
        private string ClientName { get; set; }
        public int Session { get; }

        private ClientThread client;

        private int count;

        public delegate void UpdateMetingen(Meting m);
        public UpdateMetingen updateMetingen;

        public delegate void UpdateGraph();
        public UpdateGraph updateGraph;

        public SessionWindow(string ClientName, bool old, int session, ClientThread parentthread)
        {
            this.ActiveSession = !old;
            this.ClientName = ClientName;
            this.client = parentthread;
            Session = session;

            count = 0;

            updateMetingen = new UpdateMetingen(this.SaveMeting);
            updateGraph = new UpdateGraph(this.LoadGraph);

            InitializeComponent();

            if(! ActiveSession)
            {
                panelClientChat.richTextBox1.Enabled = false;
                panelClientChat.button1.Enabled = false;
                panelDataViewLeft.Visible = false;
            }
        }

        public void ClientApplicatie_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (control.Size.Width < 980)
            {
                panelGraphView.Visible = false;
                panelClientChat.Width = 400;
                panelDataViewLeft.Dock = DockStyle.Fill;
            }
            if (control.Size.Width >= 980 && control.Size.Width < 1368)
            {
                panelGraphView.Visible = true;
                panelDataViewLeft.Width = 250;
                panelClientChat.Width = 400;
                panelDataViewLeft.Dock = DockStyle.Left;
            }
            if (control.Size.Width >= 1368)
            {
                panelGraphView.Visible = true;
                panelDataViewLeft.Width = 400;
                panelDataViewLeft.Dock = DockStyle.Left;
            }
        }

        public void SaveMeting(Meting m)
        {
          
            heartBeat.updateValue(m.HeartBeat);
            RPM.updateValue(m.RPM);
            speed.updateValue(m.Speed*100);
            distance.updateValue(m.Distance*100);
            power.updateValue(m.Power);
            energy.updateValue(m.Energy);
            actualpower.updateValue(m.ActualPower);
            time.updateValue(m.Seconds);

            if (count >= 10)
            {
                count = 0;
                panelGraphView.updateAllCharts(client.Metingen);
            }

            count++;
        }

        public void LoadGraph()
        {
            panelGraphView.updateAllCharts(client.Metingen);
        }
    }
}
