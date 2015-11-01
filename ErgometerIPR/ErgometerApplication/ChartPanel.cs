using ErgometerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ErgometerApplication
{
    public class ChartPanel : Panel
    {
        private Chart chart;
        private MetingType type;
        private ChartArea chartArea;
        private Series series;
        private SeriesChartType ChartType;

        public ChartPanel(MetingType type, SeriesChartType charttype) : base()
        {
            this.type = type;
            this.ChartType = charttype;

            this.chart = new Chart();
            this.chartArea = new ChartArea();
            this.chart.Titles.Add(new Title(type.ToString()));

            this.Location = new System.Drawing.Point(0, 0);

            this.Size = new System.Drawing.Size(400, 250);
            this.Controls.Add(chart);

            this.series = createSerie();
            this.chartArea.Name = "chartArea";

            this.chart.Size = new System.Drawing.Size(400, 250);

            this.chart.Dock = DockStyle.Fill;
            this.chart.Series.Add(series);
            this.chart.Text = "chart";


            this.chart.ChartAreas.Add(chartArea);

        }

        public void updateChart(List<Meting> metingen)
        {
            chart.Series[0] = createSerie();
            for (int i = 0; i < metingen.Count; i++)
            {
                chart.Series[0].Points.Add(getMetingType(metingen[i]));
            }
            chart.Update();
        }

        public Series createSerie()
        {
            Series serie = new Series();
            serie.Name = "series";
            serie.ChartType = ChartType;
            serie.ChartArea = "chartArea";
            serie.BorderWidth = 3;
            return serie;
        }

        public int getMetingType(Meting meting)
        {
            switch (type)
            {
                case MetingType.HEARTBEAT:
                    return meting.HeartBeat;
                case MetingType.RPM:
                    return meting.RPM;
                case MetingType.SPEED:
                    return (int)meting.Speed;
                case MetingType.DISTANCE:
                    return (int)meting.Distance;
                case MetingType.POWER:
                    return meting.Power;
                case MetingType.ENERGY:
                    return meting.Energy;
                case MetingType.SECONDS:
                    return meting.Seconds;
                case MetingType.ACTUALPOWER:
                    return meting.ActualPower;
                default:
                    return 0;
            }
        }

        public enum MetingType
        {
            HEARTBEAT,
            RPM,
            SPEED,
            DISTANCE,
            POWER,
            ENERGY,
            SECONDS,
            ACTUALPOWER
        }
    }
}
