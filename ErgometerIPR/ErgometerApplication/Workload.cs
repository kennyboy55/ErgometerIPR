using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgometerApplication
{
    class Workload
    {
        public double watt{private set; get; }
        public double heartrate { private set; get; }

        public Workload(int watt, int heartrate)
        {
            this.watt = watt;
            this.heartrate = heartrate;
        }

        public double getKiloponds()
        {
            return watt / 50;
        }
    }
}
