using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToDateTime
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void CreateDateTimeObjects()
        {
            //current date local time
            DateTime currentDateTime = DateTime.Now;
            //current date UTC time
            DateTime utcNow = DateTime.UtcNow;
            //current date 12:00:00 AM
            DateTime onlyDate = DateTime.Today;


            DateTime aDate = new DateTime(); //January 1st, 0001
            DateTime specificDate = new DateTime(2008, 6, 15, 21, 15, 7);

            string input = Console.ReadLine();
            DateTime userDate = DateTime.Parse(input);//commonly used date formats ok
            //use space between date and time

            DateTime tryUserDate;
            while(true)
            {
                Console.Write("enter a date: ");
                input = Console.ReadLine();

                if (DateTime.TryParse(input, out tryUserDate))
                {
                    break;
                }

                Console.WriteLine("That is not a valid date.");
            }
        }

        static void DifferenceofDates()
        {
            // will always select the next new years day
            DateTime newYears = new DateTime(DateTime.Today.Year + 1, 1, 1);

            //subtract current date from new years day to get # days until then.
            DateTime now = DateTime.Today;

            //last day of current month
            DateTime lastDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);

            TimeSpan timeUntilNewYears = newYears.Subtract(now);
            Console.WriteLine("It is {0} days until New Years", timeUntilNewYears.Days);
        }

        static void DayOfWeekAndYear()
        {
            DateTime nextIndependence = new DateTime(DateTime.Today.Year + 1, 7, 4);

            switch(nextIndependence.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    Console.WriteLine("{0:d} is on the weekend", nextIndependence);
                    break;
                default:
                    Console.WriteLine("{0:d} is on a weekday", nextIndependence);
                    break;
            }

            Console.WriteLine("{0:d} is on the {1} day of the year.", nextIndependence, nextIndependence.DayOfYear); //185th day of year
        }

        static void ManipulatingDateValues()
        {
            DateTime now = DateTime.Now;

            DateTime dueDate = now.AddDays(30).AddHours(5);//method chaining

            TimeSpan ts = new TimeSpan(30, 5, 0, 0);
            DateTime d = dueDate.Add(ts);//same as method above don't forget to create variable to store result
            //dueDate = dueDate.Add(ts) will also work if you just want to overwrite
        }
    }
}
