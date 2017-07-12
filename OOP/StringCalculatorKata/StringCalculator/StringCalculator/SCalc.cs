using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class SCalc
    {
        public int Add(string userInput)
        {
            if (userInput.Length > 0 )
            {
                int newTotal = 0;
                string[] inputSplit;
                string delimiterChange = "";

                if (userInput.Contains(",") || userInput.Contains("\n"))
                {
                    if (userInput.Contains("//"))
                    {
                        delimiterChange = userInput.Substring(2, 1);
                        inputSplit = userInput.Split(',', '\n', delimiterChange[0]);
                    }
                    else
                    {
                        inputSplit = userInput.Split(',', '\n');
                    }
                    

                    for(int i = 0; i < inputSplit.Length; i++)
                    {
                        newTotal = newTotal + int.Parse(inputSplit[i]);
                    }
                    return newTotal;
                    //string a = userInput.Substring(0, 1);
                    //string b = userInput.Substring(userInput.Length - 1);
                    //int aNum = int.Parse(a);
                    //int bNum = int.Parse(b);
                    //return aNum + bNum;
                }
                else
                {
                    return int.Parse(userInput);
                }
                
            }

            
            return 0;
            
        }
        //public int Add(string a, string b, string c)
        //{
        //    if(int.TryParse(a, out int aNum) && int.TryParse(b, out int bNum) && int.TryParse(c, out int cNum))
        //    return aNum + bNum + cNum;
        //}
    }
}
