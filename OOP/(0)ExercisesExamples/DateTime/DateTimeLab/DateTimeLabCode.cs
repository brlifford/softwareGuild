using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeLab
{
    public class DateTimeLabCode
    {
        /// <summary>
        /// Returns a DateTime object that is
        /// set to the current day's date.
        /// </summary>
        public DateTime GetTheDateToday()
        {
            DateTime today = DateTime.Today;
            return today;
            
        }

        /// <summary>
        /// Returns a string that represents the date for 
        /// the month day and year passed into the method parameters 
        /// as integers. Expected Return value should be in format
        /// "12/25/15"
        /// </summary>
        public string GetShortDateStringFromParamaters(int month, int day, int year)
        {
            DateTime shortDate = new DateTime(year, month, day);
            string shorterYear = shortDate.Year.ToString().Substring(2);
            string shorterMonth = shortDate.Month.ToString();
            string shorterDay = shortDate.Day.ToString();
            string shortDateString = $"{shorterMonth}/{shorterDay}/{shorterYear}";
            return shortDateString;
            
        }

        /// <summary>
        /// Returns a DateTime object that is created based on
        /// a string representation provided by the user.  Should
        /// handle date formats such as "4/1/2015", "04.01.15", 
        /// "April 1, 2015", "25 Dec 2015"
        /// </summary>
        public DateTime GetDateTimeObjectFromString(string date)
        {
            DateTime userDate = new DateTime();
            userDate = DateTime.Parse(date);
            return userDate;
        }

        /// <summary>
        /// Returns a formatted date string based on a string
        /// object passed in from the calling code.  Format should
        /// be in the form "09.02.2005 01:55 PM"
        /// </summary>
        public string GetFormatedDateString(string date)
        {
            DateTime userDate = new DateTime();
            userDate = DateTime.Parse(date);
            string formatA = userDate.ToString("MM.dd.yyyy ");
            string stupidZero = "0";
            string formatB = userDate.ToString("h:mm tt");
            string formattedString = formatA + stupidZero + formatB;
            //string convertFormat(DateTime d)
            //{
            //    string stringDate = d.ToString();
            //    string formatMonth = "";
            //    if (d.Month.ToString().Length < 2)
            //    {
            //        formatMonth = $"0{d.Month}";
            //    }
            //    else
            //    {
            //        formatMonth = d.Month.ToString();
            //    }
            //    string formatDay = "";
            //    if (d.Day.ToString().Length < 2)
            //    {
            //        formatDay = $"0{d.Day}";
            //    }
            //    else
            //    {
            //        formatDay = d.Day.ToString();
            //    }
            //    string formatHour = "";
            //    if(d.Hour.ToString().Length > 1)
            //    {
            //        formatHour = ;
            //    }
            //    else
            //    {
            //        formatHour = d.Hour.ToString();
            //    }
            //    string formatDate = $"{formatMonth}.{formatDay}.{userDate.Year} {formatHour}:{userDate.Minute}";

                
            //    return formatDate;
            //}
            //string formattedString = convertFormat(userDate);
           
            return formattedString;
        }

        /// <summary>
        /// Returns a formatted date string that is six
        /// months in the future from the date passed in.
        /// The result should be formatted like "July 4, 1776"
        /// </summary>
        public string GetDateInSixMonths(string date)
        {
            DateTime userDate = DateTime.Parse(date);
            DateTime newDate = userDate.AddMonths(6);
            string formatDate = newDate.ToString("MMMM d, yyyy");
            return formatDate;
        }

        /// <summary>
        /// Returns a formatted date string that is thirty
        /// days in the past from the date passed in.
        /// The result should be formatted like "January 1, 2005"
        /// </summary>
        public string GetDateThirtyDaysInPast(string date)
        {
            DateTime userDate = DateTime.Parse(date);
            DateTime newDate = userDate.AddDays(-30);
            string formatDate = newDate.ToString("MMMM d, yyyy");
            return formatDate;
        }


        /// <summary>
        /// Returns an array of DateTime objects containing the next count
        /// number of wednesdays on or after the given date
        /// </summary>
        /// <param name="count">the number of wednesdays to return</param>
        /// <param name="startDate">the starting date</param>
        /// <returns>An array of date objects of size count</returns>
        public DateTime[] GetNextWednesdays(int count, string startDate)
        {
            DateTime userDate = DateTime.Parse(startDate);
            DateTime firstWednesday = userDate;
            for(int i = 0; i < 7; i++)
            {
                if(firstWednesday.DayOfWeek == DayOfWeek.Wednesday)
                {
                    break;
                }
                else
                {
                    firstWednesday = userDate.AddDays(i);
                }

            }
            
            DateTime[] dateArray = new DateTime[count];
            for(int i = 0; i < count; i++)
            {
                dateArray[i] = firstWednesday.AddDays(i * 7);
            }
            return dateArray;
            
        }
    }
}
