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

        private enum state {WARMUP, WORKLOAD1, WORKLOAD2, WORKLOAD3, WORKLOAD4, COOLINGDOWN};
        private state currentstate;
        private int stateStarted;

        public ErgometerTest(int weight, int length , int age)
        {
            this.weight = weight;
            this.length = length;
            this.age = age;
            this.currentstate = state.WARMUP;
            stateStarted = 0;
        }

        private double CalculateMaximumHeartRate()
        {
            return 208 - (0.7 * age);
        }

        public void timerTick()
        {
            if(currentstate == state.WARMUP)
            {
                if (MainClient.Metingen.Last().Seconds > 30)
                {
                    List<ErgometerLibrary.Meting> last10 = MainClient.Metingen.GetRange(MainClient.Metingen.Count - 10, 10);
                    int max = FindMaxValue(MainClient.Metingen, x => x.HeartBeat);
                    int min = FindMaxValue(MainClient.Metingen, x => x.HeartBeat);
                };
            }
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
    }
}
