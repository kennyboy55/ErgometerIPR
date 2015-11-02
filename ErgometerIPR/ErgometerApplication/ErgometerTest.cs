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

        private ClientApplicatie client;

        public ErgometerTest(int weight, int length , int age, char gender, ClientApplicatie client)
        {
            this.weight = weight;
            this.length = length;
            this.age = age;
            this.gender = gender;
            currentstate = state.WARMUP;

            MainClient.SwitchTestModeAudio();

            this.client = client;
            client.updateStepsText("U begint nu aan een warmup, probeer een tempo van 50 rpm aan te houden. De test gaat automatisch verder.");
			workloads = new List<Workload>();
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
                        int max = FindMaxValue(last10, x => x.HeartBeat);
                        int min = FindMinValue(last10, x => x.HeartBeat);
                        if(max - min > 10) //Hartslag niet stabiel
                        {
                            client.updateStepsText("Uw hartslag is niet stabiel, probeer een tempo van 50 rpm aan te houden. De test gaat automatisch verder.");
                            return;
                        }
                        else
                        {
                            currentstate = state.WORKLOAD;
                            MainClient.SwitchTestModeAudio();
                            workloadStarted = MainClient.GetLastMeting().Seconds;
                            client.updateStepsText("De warmup is voltooid. U begint nu aan de " + NumToText(GetCurrentWorkload()) + " workload.");
                        }
                    }
                    break;
                case state.WORKLOAD:
                    if (MainClient.GetLastMeting().Seconds - workloadStarted > 180)
                    {
                        //Checken of de heartrate niet groter is dan 75%, anders stoppen
                        if (workloadHearthbeat > (CalculateMaximumHeartRate() * 0.80))
                        {
                            workloadStarted = MainClient.GetLastMeting().Seconds;
                            currentstate = state.COOLINGDOWN;
                            MainClient.SwitchTestModeAudio();
                            client.updateStepsText("Uw hartslag heeft het kritieke punt bereikt, we beginnen nu aan de cooldown.");
                        }

                        int pw = GetWorkloadPower(GetCurrentWorkload());
                        workloads.Add(new Workload(MainClient.GetLastMeting().Power, workloadHearthbeat));
                        MainClient.ComPort.Write("PW " + pw);

                        client.updateStepsText("U heeft de workload afgerond, u begint nu aan de " + NumToText(GetCurrentWorkload()) + " workload. Uw nieuwe weerstand is " + pw + " Watt.");
                        MainClient.SwitchWorkloadAudio();

                        workloadStarted = MainClient.GetLastMeting().Seconds;
                        workloadHearthbeat = 0;
                        Console.WriteLine("3:00 gefietst, workload" + (GetCurrentWorkload()) + " af, nieuwe waardes maken");
                    }
                    else if (MainClient.GetLastMeting().Seconds - workloadStarted > 160 && workloadHearthbeat == 0)
                    {
                        List<ErgometerLibrary.Meting> last80 = MainClient.Metingen.GetRange(MainClient.Metingen.Count - 80, 80);
                        workloadHearthbeat = FindAvergeValue(MainClient.Metingen, x => x.HeartBeat);
                        Console.WriteLine("2:40 gefiets, gemiddelde harstslag berekenen:" + workloadHearthbeat);
                        client.updateStepsText("U bent nu met de " + NumToText(GetCurrentWorkload()) + " workload bezig. Uw gemiddelde hartslag is berekend als " + workloadHearthbeat + "bpm.");
                    }
                    else if(MainClient.GetLastMeting().Seconds - workloadStarted > 8 && MainClient.GetLastMeting().Seconds - workloadStarted < 10)
                    {
                        client.updateStepsText("U bent nu met de " + NumToText(GetCurrentWorkload()) + " workload bezig. De fiets staat nu ingesteld op " + MainClient.GetLastMeting().Power + " Watt");
                    }
                    break;
                case state.COOLINGDOWN:
                    MainClient.ComPort.Write("PW 25");
                    if(MainClient.GetLastMeting().Seconds - workloadStarted > 360)
                    {
                        currentstate = state.STOP;
                        MainClient.SwitchTestModeAudio();
                        client.updateStepsText("De test is afgelopen.");
                    }
                    else if(MainClient.GetLastMeting().Seconds - workloadStarted > 8 && MainClient.GetLastMeting().Seconds - workloadStarted < 10)
                    {
                        client.updateStepsText("U bent momenteel met de cooldown bezig.");
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

            var LmA = 0.32643 + 0.55275 * wa.getKiloponds() + 0.014429 * Math.Pow(wa.getKiloponds(), 2) + 0.00025271 * Math.Pow(wa.getKiloponds(), 3);
            var LmB = 0.32643 + 0.55275 * wb.getKiloponds() + 0.014429 * Math.Pow(wb.getKiloponds(), 2) + 0.00025271 * Math.Pow(wb.getKiloponds(), 3);
            var VOABS = LmB + ((LmB - LmA) / (wb.heartrate - wa.heartrate)) * (220 - age - wb.heartrate);
            return VOABS * 1000 / weight;
        }

        public double CalculateMET()
        {
            return CalculateVOMax() / 3.5;
        }

        public double CalculatePopulationAverage()
        {
            if(gender == 'M')
                return 51.86 - 0.28 * age;
            return 41.435 - 0.23 * age;
        }

        public string CalculateRating()
        {
            var dev = (gender == 'M') ? 6 : 5.5;
            var Zscore = (CalculateVOMax() - CalculatePopulationAverage()) / dev;
            if (Zscore >= 1)
            {
                return "Geweldig";
            }
            else if (Zscore < 1 && Zscore >= 0.5)
            {
                return "Goed";
            }
            else if (Zscore < 0.5 && Zscore >= -0.5)
            {
                return "Gemiddeld";
            }
            else if (Zscore < -0.5 && Zscore >= -1)
            {
                return "Redelijk";
            }
            else if (Zscore < -1)
            {
                return "Slecht";
            }
            return "Fout";
        }

        //          HELPER FUNCTIONS         //

        private int GetCurrentWorkload()
        {
            return workloads.Count + 1;
        }

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
