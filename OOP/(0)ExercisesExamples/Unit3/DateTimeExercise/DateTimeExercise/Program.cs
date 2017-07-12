using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            Console.WriteLine(now.ToString("MM/dd/yyyy"));

            string today = now.DayOfWeek.ToString();
            Console.WriteLine(today);

            string ticks = now.Ticks.ToString();
            Console.WriteLine(ticks);

            DateTime future = DateTime.Now.AddHours(100);
            Console.WriteLine(future.ToString());

            Console.ReadKey();
        }
    }
}
