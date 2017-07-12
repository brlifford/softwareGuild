using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SystemIOExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Quote> allData = new List<Quote>();
            ReadQuoteLine();

        }

        private static void ReadQuoteLine()
        {
            List<Quote> listData = new List<Quote>();
            FileInfo f = new FileInfo(@"C:\Users\brlif\Downloads\HistoricalQuotes.txt");

            using (TextReader r = f.OpenText())
            {
                string s = r.ReadLine();
                string[] header = s.Split(',');
                string[] newHeader = new string[6];

                //process header
                for (int i = 0; i < header.Length; i++)
                {
                    string cleanHeader = header[i].ToString().Substring(1, header[i].Length - 2);
                    newHeader[i] = cleanHeader;
                }

               


                //process quote
                while (!string.IsNullOrEmpty(s))
                {
                    s = r.ReadLine();
                    s = s.Replace("\"", "");
                    object[] quoteParts = new object[6];
                    quoteParts = s.Split(',');
                    
                    string str = "";
                    Quote newQuote = new Quote();
                    

                    for (int i = 0; i < quoteParts.Length; i++)
                    {
                        var objectPart = quoteParts[i];
                        if (i == 0)
                        {
                            str = objectPart.ToString();
                            DateTime datePart = DateTime.Parse(str);
                            newQuote.Date = datePart;

                        }

                        if (i == 2)
                        {
                            int volumePart = int.Parse(objectPart.ToString().Remove(objectPart.ToString().Length - 5));
                            newQuote.Volume = volumePart;
                        }


                        if (i == 1 || i == 3 || i == 4 || i == 5)
                        {
                            decimal decimalPart = decimal.Parse(objectPart.ToString());

                            
                            if (i == 1)
                            {
                                newQuote.Close = decimalPart;
                            }
                            if(i == 3)
                            {
                                newQuote.Open = decimalPart;
                            }
                            if(i == 4)
                            {
                                newQuote.High = decimalPart;
                            }
                            if(i == 5)
                            {
                                newQuote.Low = decimalPart;
                            }
                        }
                       

                    }
                    listData.Add(newQuote);
                    
                }
                //process each line

            }

        }
    }
}
