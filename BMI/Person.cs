using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMI
{
    class Person
    {
       
        
        public double Waist { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Neck { get; set; }
        public bool? IsMale { get; set; }
        public double Hip { get; set; }
       

        public Person()
        {
            Waist = 0;
            Weight = 0;
            Height = 0;
            Neck = 0;
            IsMale = true;
            

        }
        public string CalculateBodyFat()
        {
            double fatPercent;

            if (IsMale == true)
            {
                fatPercent = (86.010*Math.Log10(Waist - Neck) - 70.041*Math.Log10(Height)) + 36.76;
                return fatPercent.ToString();
            }
            else
            {
                fatPercent = 162.205*Math.Log10(Waist + Hip - Neck) - 97.684*Math.Log10(Height) - 78.387;
                return fatPercent.ToString();
            }
        }


        public string CalculateBMI()

        {
            double bmi = (Weight/Math.Pow(Height, 2))*703;
            return bmi.ToString();
            
        }

        double GetModifier(string activity)
        {
            switch (activity)
            {
                case "Very Light":
                    return 1.3;
                case "Light":
                    return 1.55;
                case "Moderate":
                    return 1.65;
                case "Heavy":
                    return 1.8;
                case "Very Heavy":
                    return 2.0;
                default:
                    return 0;
            }
        }
        public string CalculateMaintenenceCalories(string activity, double bodyFat)
        {
            double results;
            if (IsMale == true)
            {
                results = Weight*0.453592*24;
                if (bodyFat<=14)
                {
                    results *= 1.0;
                }
                else if (bodyFat>14 && bodyFat <= 20)
                {
                    results *= .95;
                }
                else if (bodyFat>20 && bodyFat <= 28)
                {
                    results *= .90;
                }
                else
                {
                    results *= .85;
                }
            }
            else
            {
                results = .9*Weight * 0.453592 * 24;
                if (bodyFat <= 18)
                {
                    results *= 1.0;
                }
                else if (bodyFat > 18 && bodyFat <= 28)
                {
                    results *= .95;
                }
                else if (bodyFat > 28 && bodyFat <= 38)
                {
                    results *= .90;
                }
                else
                {
                    results *= .85;
                }
                
            }
            results *= GetModifier(activity);
            return results.ToString();
        }
    }
}
