using RationalNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparableExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<RationalNumbers> rationals = new List<RationalNumbers>();
            rationals.Add(new RationalNumbers(10, 2));
            rationals.Add(new RationalNumbers(4, 5));
            rationals.Add(new RationalNumbers(9, 3));
            rationals.Add(new RationalNumbers(6, 7));
            rationals.Add(new RationalNumbers(1, 3));
            rationals.Add(new RationalNumbers(9, 2));
            rationals.Add(new RationalNumbers(7, 6));
            rationals.Add(new RationalNumbers(2, 8));
            rationals.Sort(); //able to use because we used IComparable
            
            foreach(var number in rationals)
            {
                Console.Write($"{number.Numerator} / {number.Denominator}  ");
                Console.WriteLine($"Decimal value: {(double) number.Numerator/ (double)number.Denominator}");
            }
            Console.ReadLine();
        }
    }
}
