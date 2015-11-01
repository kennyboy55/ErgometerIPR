using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgometerApplication
{
    public class ErgometerTest
    {
        private int weight;
        private int length;
        private int age;
        private char gender;

        private enum state {WARMUP, WORKLOAD, COOLINGDOWN};
        private state currentstate;
        private int workloadStarted;
        private int workloadHearthbeat;
        private int workloadnumber;

        public ErgometerTest(int weight, int length , int age, char gender)
        {
            this.weight = weight;
            this.length = length;
            this.age = age;
            this.gender = gender;
            currentstate = state.WARMUP;
            MainClient.ComPort.Write("SET PW 25");
        }

        public void timerTick()
        {
            switch(currentstate)
            {
                case state.WARMUP:
                    if (MainClient.GetLastMeting().Seconds > 30)
                    {
                        List<ErgometerLibrary.Meting> last10 = MainClient.Metingen.GetRange(MainClient.Metingen.Count - 10, 10);
                        int max = FindMaxValue(MainClient.Metingen, x => x.HeartBeat);
                        int min = FindMaxValue(MainClient.Metingen, x => x.HeartBeat);
                        if(max - min > 20) //Hartslag niet stabiel
                        {
                            return;
                        }
                        else
                        {
                            currentstate = state.WORKLOAD;
                            workloadStarted = MainClient.GetLastMeting().Seconds;
                            Console.WriteLine("Warmup is goed, hartslag stabiel, ga naar workload test");
                        }
                    }
                    break;
                case state.WORKLOAD:
                    if (MainClient.GetLastMeting().Seconds - workloadStarted > 180)
                    {
                        //Checken of de heartrate niet groter is dan 75%, anders stoppen
                        if(workloadnumber == 0)
                        {
                            if(workloadHearthbeat < 80)
                                MainClient.ComPort.Write("SET PW 125");
                            else if (workloadHearthbeat < 89)
                                MainClient.ComPort.Write("SET PW 100");
                            else if (workloadHearthbeat < 100)
                                MainClient.ComPort.Write("SET PW 75");
                            else if (workloadHearthbeat > 100)
                                MainClient.ComPort.Write("SET PW 50");
                        }
                        else
                        {
                            MainClient.ComPort.Write((MainClient.GetLastMeting().Power + 25).ToString());
                        }
                        workloadStarted = MainClient.GetLastMeting().Seconds;
                        workloadHearthbeat = 0;
                        workloadnumber++;
                        Console.WriteLine("3:00 gefietst, workload" + workloadnumber + " af, nieuwe waardes maken");
                    }
                    else if (MainClient.GetLastMeting().Seconds - workloadStarted > 160 && workloadHearthbeat == 0)
                    {
                        List<ErgometerLibrary.Meting> last80 = MainClient.Metingen.GetRange(MainClient.Metingen.Count - 80, 80);
                        workloadHearthbeat = FindAvergeValue(MainClient.Metingen, x => x.HeartBeat);
                        Console.WriteLine("2:40 gefiets, gemiddelde harstslag berekenen:" + workloadHearthbeat);
                    }
                    break;
                case state.COOLINGDOWN:
                    break;
            }
        }


        //          HELPER FUNCTIONS         //

        private double CalculateMaximumHeartRate()
        {
            return 208 - (0.7 * age);
        }

        public int FindMaxValue<T>(List<T> list, Converter<T, int> projection)
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Empty list");
            }
            int maxValue = int.MinValue;
            foreach (T item in list)
            {
                int value = projection(item);
                if (value > maxValue)
                {
                    maxValue = value;
                }
            }
            return maxValue;
        }

        public int FindMinValue<T>(List<T> list, Converter<T, int> projection)
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Empty list");
            }
            int minValue = int.MaxValue;
            foreach (T item in list)
            {
                int value = projection(item);
                if (value < minValue)
                {
                    minValue = value;
                }
            }
            return minValue;
        }

        public int FindAvergeValue<T>(List<T> list, Converter<T, int> projection)
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Empty list");
            }
            int totalvalue = 0;
            foreach (T item in list)
            {
                totalvalue += projection(item);
            }
            return totalvalue / list.Count;
        }
    }
}
