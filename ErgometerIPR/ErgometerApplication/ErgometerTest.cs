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

        private enum state {WARMUP, WORKLOAD, COOLINGDOWN, STOP};
        private state currentstate;
        private int workloadStarted;
        private int workloadHearthbeat;
        private List<Workload> workloads;

        public ErgometerTest(int weight, int length , int age, char gender)
        {
            this.weight = weight;
            this.length = length;
            this.age = age;
            this.gender = gender;
            currentstate = state.WARMUP;
            workloads = new List<Workload>();
            MainClient.ComPort.Write("SET PW 25");

            Console.WriteLine(CalculateVOMaxTest());
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
                        if(max - min > 10) //Hartslag niet stabiel
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
                        if (workloadHearthbeat > CalculateMaximumHeartRate())
                        {
                            workloadStarted = MainClient.GetLastMeting().Seconds;
                            currentstate = state.COOLINGDOWN;
                        }
                        workloads.Add(new Workload(MainClient.GetLastMeting().Power, workloadHearthbeat));
                        MainClient.ComPort.Write("PW " + GetWorkloadPower(workloads.Count-1));

                        workloadStarted = MainClient.GetLastMeting().Seconds;
                        workloadHearthbeat = 0;
                        Console.WriteLine("3:00 gefietst, workload" + (workloads.Count - 1) + " af, nieuwe waardes maken");
                    }
                    else if (MainClient.GetLastMeting().Seconds - workloadStarted > 160 && workloadHearthbeat == 0)
                    {
                        List<ErgometerLibrary.Meting> last80 = MainClient.Metingen.GetRange(MainClient.Metingen.Count - 80, 80);
                        workloadHearthbeat = FindAvergeValue(MainClient.Metingen, x => x.HeartBeat);
                        Console.WriteLine("2:40 gefiets, gemiddelde harstslag berekenen:" + workloadHearthbeat);
                    }
                    break;
                case state.COOLINGDOWN:
                    MainClient.ComPort.Write("SET PW 25");
                    if(MainClient.GetLastMeting().Seconds - workloadStarted > 360)
                    {
                        currentstate = state.STOP;
                    }
                    break;
            }
        }

        //          WORKLOAD                //

        private int GetWorkloadPower(int workload)
        {
            if (gender == 'V')
            {
                if (workload == 1)
                {
                    if (workloadHearthbeat < 80)
                        return 125;
                    else if (workloadHearthbeat < 89)
                        return 100;
                    else if (workloadHearthbeat < 100)
                        return 75;
                    else
                        return 50;
                }
                else
                {
                    return MainClient.GetLastMeting().Power + 25;
                }
            }
            else if(gender == 'M')
            {
                if(workload == 1)
                {
                    if (workloadHearthbeat < 90)
                        return 150;
                    else if (workloadHearthbeat < 105)
                        return 125;
                    else
                        return 100;
                }
                else if(workload == 2)
                {
                    if(workloadHearthbeat < 120)
                    {
                        if (MainClient.GetLastMeting().Power == 150)
                            return 225;
                        else if (MainClient.GetLastMeting().Power == 125)
                            return 200;
                        else
                            return 175;
                    }
                    else if(workloadHearthbeat < 135)
                    {
                        if (MainClient.GetLastMeting().Power == 150)
                            return 200;
                        else if (MainClient.GetLastMeting().Power == 125)
                            return 175;
                        else
                            return 150;
                    }
                    else
                    {
                        if (MainClient.GetLastMeting().Power == 150)
                            return 175;
                        else if (MainClient.GetLastMeting().Power == 125)
                            return 150;
                        else
                            return 125;
                    }
                }
                else
                {
                    return MainClient.GetLastMeting().Power + 25;
                }
            }

            return 25;
        }

        //          CALCULATOR FUNCTIONS    //

        public double CalculateVOMax()
        {
            Workload wa = workloads[workloads.Count - 2];
            Workload wb = workloads.Last();

            var LmA = 0.32643 + 0.55275 * wa.getKiloponds() + 0.014429 * Math.Pow(wa.getKiloponds(), 2) + 0.00025271 * Math.Pow(wa.getKiloponds(), 3);            var LmB = 0.32643 + 0.55275 * wb.getKiloponds() + 0.014429 * Math.Pow(wb.getKiloponds(), 2) + 0.00025271 * Math.Pow(wb.getKiloponds(), 3);            var VOABS = LmB + ((LmB - LmA) / (wb.heartrate - wa.heartrate)) * (220 - age - wb.heartrate);            return VOABS * 1000 / weight;
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
