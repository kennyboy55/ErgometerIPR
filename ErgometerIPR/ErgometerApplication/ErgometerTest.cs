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

        private ClientApplicatie client;

        public ErgometerTest(int weight, int length , int age, char gender, ClientApplicatie client)
        {
            this.weight = weight;
            this.length = length;
            this.age = age;
            this.gender = gender;
            currentstate = state.WARMUP;
            workloadnumber = 1;
            this.client = client;
            client.updateStepsText("U begint nu aan een warmup, probeer een tempo van 50 rpm aan te houden. De test gaat automatisch verder.");
            MainClient.ComPort.Write("PW 25");
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
                            client.updateStepsText("Uw hartslag is not niet stabiel, probeer een tempo van 50 rpm aan te houden. De test gaat automatisch verder.");
                            return;
                        }
                        else
                        {
                            currentstate = state.WORKLOAD;
                            workloadStarted = MainClient.GetLastMeting().Seconds;
                            client.updateStepsText("De warmup is voltooid. U begint nu aan de " + NumToText(workloadnumber) + " workload.");
                        }
                    }
                    break;
                case state.WORKLOAD:
                    if (MainClient.GetLastMeting().Seconds - workloadStarted > 180)
                    {
                        //Checken of de heartrate niet groter is dan 75%, anders stoppen
                        if (workloadHearthbeat > CalculateMaximumHeartRate())
                        {
                            currentstate = state.COOLINGDOWN;
                            client.updateStepsText("Uw hartslag heeft het kritieke punt bereikt, we beginnen nu aan de cooldown.");
                        }

                        int pw = GetWorkloadPower(workloadnumber);
                        MainClient.ComPort.Write("PW " + pw);

                        client.updateStepsText("U heeft de workload afgerond, u begint nu aan de " + NumToText(workloadnumber) + " workload. Uw nieuwe weerstand is " + pw + " Watt.");

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
                        client.updateStepsText("U bent nu met de " + NumToText(workloadnumber) + " workload bezig. Uw gemiddelde hartslag is berekend als " + workloadHearthbeat + "bpm.");
                    }
                    else if(MainClient.GetLastMeting().Seconds - workloadStarted > 8 && MainClient.GetLastMeting().Seconds - workloadStarted < 10)
                    {
                        client.updateStepsText("U bent nu met de " + NumToText(workloadnumber) + " workload bezig. De fiets staat nu ingesteld op " + MainClient.GetLastMeting().Power + " Watt");
                    }
                    break;
                case state.COOLINGDOWN:
                    break;
            }
        }

        //          WORKLOAD                //


        private int GetWorkloadPower(int workload)
        {
            if (gender == 'V')
            {
                if (workloadnumber == 1)
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
                if(workloadnumber == 1)
                {
                    if (workloadHearthbeat < 90)
                        return 150;
                    else if (workloadHearthbeat < 105)
                        return 125;
                    else
                        return 100;
                }
                else if(workloadnumber == 2)
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

        public string NumToText(int num)
        {
            switch(num)
            {
                case 1:
                    return "eerste";
                case 2:
                    return "tweede";
                case 3:
                    return "derde";
                case 4:
                    return "vierde";
                case 5:
                    return "vijfde";
                case 6:
                    return "zesde";
                case 7:
                    return "zevende";
                case 8:
                    return "achste";
                case 9:
                    return "negende";
                default:
                    return "volgende";
            }
        }
    }
}
