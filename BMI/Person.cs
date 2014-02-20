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
    }
}
