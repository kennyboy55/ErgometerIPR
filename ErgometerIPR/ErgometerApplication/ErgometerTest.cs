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
        private int stateStarted;
        private int stateHearthbeat;

        public ErgometerTest(int weight, int length , int age, char gender)
        {
            this.weight = weight;
            this.length = length;
            this.age = age;
            this.gender = gender;
            currentstate = state.WARMUP;
            stateStarted = 0;
        }

        public void timerTick()
        {
            switch(currentstate)
            {
                case state.WARMUP:
                    if (MainClient.Metingen.Last().Seconds > 30)
                    {
                        List<ErgometerLibrary.Meting> last10 = MainClient.Metingen.GetRange(MainClient.Metingen.Count - 10, 10);
                        int max = FindMaxValue(MainClient.Metingen, x => x.HeartBeat);
                        int min = FindMaxValue(MainClient.Metingen, x => x.HeartBeat);
                        MainClient.ComPort.Write("SET PW 25");
                        if(max - min > 20) //Hartslag niet stabiel
                        {
                            return;
                        }
                        else
                        {
                            currentstate = state.WORKLOAD;
                            stateStarted = MainClient.Metingen.Last().Seconds;
                        }
                    }
                    break;
                case state.WORKLOAD:
                    if (stateStarted - MainClient.Metingen.Last().Seconds > 180)
                    {
                        //Bereken nieuwe kracht
                        //Zet nieuwe kracht
                        //State started weer op de huidige tijd zetten
                        //Checken of het niet groter dan 75% is
                        //stateHeartbeat weer op 0 zetten

                    }
                    else if (stateStarted - MainClient.Metingen.Last().Seconds > 160 && stateHearthbeat != 0)
                    {
                        List<ErgometerLibrary.Meting> last80 = MainClient.Metingen.GetRange(MainClient.Metingen.Count - 80, 80);
                        stateHearthbeat = FindAvergeValue(MainClient.Metingen, x => x.HeartBeat);
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
