using System;

namespace Warmups.BLL
{
    public class Conditionals
    {
        //We have two children, a and b, and the parameters aSmile and bSmile indicate if each is smiling. 
        //We are in trouble if they are both smiling or if neither of them is smiling. 
        //Return true if we are in trouble. 

        //AreWeInTrouble(true, true) -> true
        //AreWeInTrouble(false, false) -> true
        //AreWeInTrouble(true, false) -> false


        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            return aSmile == bSmile;
        }

        //The parameter weekday is true if it is a weekday, and the parameter vacation is true 
        //if we are on vacation. We sleep in if it is not a weekday or we're on vacation. 
        //Return true if we sleep in. 

        //sleepIn(false, false) -> true
        //sleepIn(true, false) -> false
        //sleepIn(false, true) -> true

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            if (isVacation == true)
            {
                return true;
            }
            else if (isWeekday == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Given two int values, return their sum. However, if the two values are the same, 
        //then return double their sum. 

        //SumDouble(1, 2) -> 3
        //SumDouble(3, 2) -> 5
        //SumDouble(2, 2) -> 8

        public int SumDouble(int a, int b)
        {
            if (a == b)
            {
                return (a + b) * 2;
            }
            else
            {
                return a + b;
            }
        }

        //Given an int n, return the absolute value of the difference between n and 21, 
        //except return double the absolute value of the difference if n is over 21. 

        //Diff21(23) -> 4
        //Diff21(10) -> 11
        //Diff21(21) -> 0

        public int Diff21(int n)
        {
            if (n > 21)
            {
                return (Math.Abs(21 - n) * 2);
            }

            else
            {
                return Math.Abs(21 - n);
            }
            throw new NotImplementedException();
        }

        //We have a loud talking parrot. The "hour" parameter is the current hour 
        //time in the range 0..23. We are in trouble if the parrot is talking and 
        //the hour is before 7 or after 20. Return true if we are in trouble. 

        //ParrotTrouble(true, 6) -> true
        //ParrotTrouble(true, 7) -> false
        //ParrotTrouble(false, 6) -> false

        public bool ParrotTrouble(bool isTalking, int hour)
        {
            bool bedtime;
            if (hour < 7 || hour > 20)
            {
                bedtime = true;
                return isTalking == bedtime;
            }

            else
            {
                return false;
            }
            throw new NotImplementedException();
        }

        //Given two ints, a and b, return true if one if them is 10 or if their sum is 10. 

        //Makes10(9, 10) -> true
        //Makes10(9, 9) -> false
        //Makes10(1, 9) -> true

        public bool Makes10(int a, int b)
        {
            if (a == 10 || b == 10)
            {
                return true;
            }
            else if (a + b == 10)
            {
                return true;
            }
            else
            {
                return false;
            }

            throw new NotImplementedException();
        }

        //Given an int n, return true if it is within 10 of 100 or 200.
        //Hint: Check out the C# Math class for absolute value

        //NearHundred(103) -> true
        //NearHundred(90) -> true
        //NearHundred(89) -> false

        public bool NearHundred(int n)
        {
            if (Math.Abs(n - 100) <= 10 || Math.Abs(n - 200) <= 10)
            {
                return true;
            }

            else
            {
                return false;
            }
            throw new NotImplementedException();
        }

        //Given two int values, return true if one is negative and one is positive. 
        //Except if the parameter "negative" is true, then return true only if both are negative. 

        //PosNeg(1, -1, false) -> true
        //PosNeg(-1, 1, false) -> true
        //PosNeg(-4, -5, true) -> true

        public bool PosNeg(int a, int b, bool negative)
        {
            if (negative == true)
            {
                if (a < 0 && b < 0)
                {
                    return true;
                }
            }
            else if (a < 0 && b > 0)
            {
                return true;
            }
            else if (a > 0 && b < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }

        //Given a string, return a new string where "not " has been added to the front. 
        //However, if the string already begins with "not", return the string unchanged.

        //Hint: Look up how to use "SubString" in c#

        //NotString("candy") -> "not candy"
        //NotString("x") -> "not x"
        //NotString("not bad") -> "not bad"

        public string NotString(string s)

        {
            string not = "not ";
            if (s.Substring(0) != "not")
            {
                return not + s;
            }

            else
            {
                return s;
            }
            throw new NotImplementedException();
        }

        //Given a non-empty string and an int n, return a new string where the char at index n 
        //has been removed. The value of n will be a valid index of a char in the original 
        //string (Don't check for bad index). 

        //MissingChar("kitten", 1) -> "ktten"
        //MissingChar("kitten", 0) -> "itten"
        //MissingChar("kitten", 4) -> "kittn"

        public string MissingChar(string str, int n)
        {
            string strA = "";
            string strB = "";
            if (str != null)
            {
                strA = (str.Substring(0, n));
                strB = (str.Substring(n + 1));
                return strA + strB;

            }
            throw new NotImplementedException();
        }

        //Given a string, return a new string where the first and last chars have been exchanged. 

        //FrontBack("code") -> "eodc"
        //FrontBack("a") -> "a"
        //FrontBack("ab") -> "ba"

        public string FrontBack(string str)
        {
            string strA = (str.Substring(0, 1));
            int length = str.Length;
            if (length > 1)
            {
                string strB = (str.Substring(length - 1));
                string strMiddle = (str.Substring(1, length - 2));
                return strB + strMiddle + strA;
            }

            else
            {
                return strA;
            }

            throw new NotImplementedException();
        }
        //Given a string, we'll say that the front is the first 3 chars 
        //of the string. If the string length is less than 3, the front 
        //is whatever is there. Return a new string which is 3 copies of the front. 

        //Front3("Microsoft") -> "MicMicMic"
        //Front3("Chocolate") -> "ChoChoCho"
        //Front3("at") -> "atatat"

        public string Front3(string str)
        {
            if (str.Length < 3)
            {
                return (str + str + str);
            }
            else
            {
                string newStr = (str.Substring(0, 3));
                return newStr + newStr + newStr;
            }
            throw new NotImplementedException();
        }

        //Given a string, take the last char and return a new string 
        //with the last char added at the front and back, so "cat" 
        //yields "tcatt". The original string will be length 1 or more. 

        //BackAround("cat") -> "tcatt"
        //BackAround("Hello") -> "oHelloo"
        //BackAround("a") -> "aaa"

        public string BackAround(string str)
        {
            string strA = str.Substring(str.Length - 1);
            return strA + str + strA;

            throw new NotImplementedException();
        }

        //Return true if the given non-negative number is a multiple of 3 
        //or a multiple of 5. Use the % "mod" operator

        //Multiple3or5(3) -> true
        //Multiple3or5(10) -> true
        //Multiple3or5(8) -> false

        public bool Multiple3or5(int number)
        {
            if (number % 3 == 0 || number % 5 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }

        //Given a string, return true if the string starts with "hi" and false otherwise. 

        //StartHi("hi there") -> true
        //StartHi("hi") -> true
        //StartHi("high up") -> false

        public bool StartHi(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str.Length < 2)
                {
                    return false;
                }
                if (str[i] == 'h')
                {
                    if (str[i + 1] == 'i')
                    {
                        if (str.Length == 2 && str.Contains("hi"))
                        {
                            return true;
                        }
                        else if (str[i + 2] == ' ' || str[i + 2] == ',')
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            throw new NotImplementedException();
        }
        //Given two temperatures, return true if one is less than 0 and the other is greater than 100. 

        //IcyHot(120, -1) -> true
        //IcyHot(-1, 120) -> true
        //IcyHot(2, 120) -> false

        public bool IcyHot(int temp1, int temp2)
        {
            if (temp1 < 0 && temp2 > 100)
            {
                return true;
            }
            else if (temp1 > 100 && temp2 < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }

        //Given 2 int values, return true if either of them is in the range 10..20 inclusive. 

        //Between10and20(12, 99) -> true
        //Between10and20(21, 12) -> true
        //Between10and20(8, 99) -> false

        public bool Between10and20(int a, int b)
        {
            if (a >= 10 && a <= 20)
            {
                return true;
            }
            else if (b >= 10 && b <= 20)
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }

        //We'll say that a number is "teen" if it is in the range 13..19 inclusive. 
        //Given 3 int values, return true if 1 or more of them are teen. 

        //HasTeen(13, 20, 10) -> true
        //HasTeen(20, 19, 10) -> true
        //HasTeen(20, 10, 12) -> false

        public bool HasTeen(int a, int b, int c)
        {
            if (a >= 13 && a <= 19)
            {
                return true;
            }
            else if (b >= 13 && b <= 19)
            {
                return true;
            }
            else if (c >= 13 && c <= 19)
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }

        //We'll say that a number is "teen" if it is in the range 13..19 inclusive. 
        //Given 2 int values, return true if one or the other is teen, but not both. 

        //SoAlone(13, 99) -> true
        //SoAlone(21, 19) -> true
        //SoAlone(13, 13) -> false

        public bool SoAlone(int a, int b)
        {
            if (a == b)
            {
                return false;
            }
            else if (a >= 13 && a <= 19)
            {
                return true;
            }
            else if (b >= 13 && b <= 19)
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }

        //Given a string, if the string "del" appears starting at index 1, 
        //return a string where that "del" has been deleted. Otherwise, 
        //return the string unchanged. 

        //RemoveDel("adelbc") -> "abc"
        //RemoveDel("adelHello") -> "aHello"
        //RemoveDel("adedbc") -> "adedbc"

        public string RemoveDel(string str)
        {

            if (str.Contains("del"))
            {
                string strNew = str.Remove(1, 3);
                return strNew;
            }
            else
            {
                return str;
            }
            throw new NotImplementedException();
        }

        //Return true if the given string begins with "*ix", the '*' 
        //can be anything, so "pix", "9ix" .. all count. 

        //IxStart("mix snacks") -> true
        //IxStart("pix snacks") -> true
        //IxStart("piz snacks") -> false


        public bool IxStart(string str)
        {
            if (str.Contains("ix"))
            {
                return true;
            }

            else
            {
                return false;
            }
            throw new NotImplementedException();
        }

        //Given a string, return a string made of the first 2 chars (if present), 
        //however include first char only if it is 'o' and include the second 
        //only if it is 'z', so "ozymandias" yields "oz". 

        //StartOz("ozymandias") -> "oz"
        //StartOz("bzoo") -> "z"
        //StartOz("oxx") -> "o"

        public string StartOz(string str)
        {
            string newWord = "";
            for (int i = 0; i < 2; i++)
            {
                if (str.Length > 1)
                {
                    if (str.Substring(i, 1) == "o")
                    {
                        newWord = "o";
                    }
                    else if (str.Substring(i, 1) == "z")
                    {
                        newWord = newWord + "z";
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }
            return newWord;
            throw new NotImplementedException();
        }

        //Given three int values, a b c, return the largest. 

        //Max(1, 2, 3) -> 3
        //Max(1, 3, 2) -> 3
        //Max(3, 2, 1) -> 3

        public int Max(int a, int b, int c)
        {

            if (a < b)
            {
                if (b > c)
                {
                    return b;
                }
                else
                {
                    return c;
                }
            }
            else if (a > b)
            {
                if (a > c)
                {
                    return a;
                }
                else
                {
                    return c;
                }
            }
            throw new NotImplementedException();
        }

        //Given 2 int values, return whichever value is nearest to the value 10, 
        //or return 0 in the event of a tie. 

        //Closer(8, 13) -> 8
        //Closer(13, 8) -> 8
        //Closer(13, 7) -> 0

        public int Closer(int a, int b)
        {
            int resultA = Math.Abs(10 - a);
            int resultB = Math.Abs(10 - b);
            if (resultA == resultB)
            {
                return 0;
            }
            else if (resultA < resultB)
            {
                return a;
            }
            else
            {
                return b;
            }

            throw new NotImplementedException();
        }

        //Return true if the given string contains between 1 and 3 'e' chars. 

        //GotE("Hello") -> true
        //GotE("Heelle") -> true
        //GotE("Heelele") -> false

        public bool GotE(string str)
        {
            int numEs = 0;
            if (str.Contains("e"))
            {

                for (int i = 0; i < str.Length; i++)
                {
                    char current = str[i];
                    if (current == 'e')
                    {
                        numEs++;
                    }
                }
                if (numEs > 3)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }

        //Given a string, return a new string where the last 3 chars are now 
        //in upper case. If the string has less than 3 chars, uppercase whatever is there. 

        //EndUp("Hello") -> "HeLLO"
        //EndUp("hi there") -> "hi thERE"
        //EndUp("hi") -> "HI"

        public string EndUp(string str)
        {
            string strA;
            string strUpper;
            if (str.Length > 3)
            {
                strUpper = str.Substring(str.Length - 3);
                string partB = strUpper.ToUpper();
                strA = str.Substring(0, str.Length - 3);
                string newWord = strA + partB;
                return newWord;
            }
            else
            {
                string shortWord = str.ToUpper();
                return shortWord;
            }
            throw new NotImplementedException();
        }

        //Given a non-empty string and an int N, return the string made 
        //starting with char 0, and then every Nth char of the string. 
        //So if N is 3, use char 0, 3, 6, ... and so on. N is 1 or more. 

        //EveryNth("Miracle", 2) -> "Mrce"
        //EveryNth("abcdefg", 2) -> "aceg"
        //EveryNth("abcdefg", 3) -> "adg"

        public string EveryNth(string str, int n)
        {
            string partA = str.Substring(0, 1);
            string partB;
            int newN = n;

            while (newN < str.Length)
            {
                partB = str.Substring(newN, 1);
                partA += partB;
                newN += n;
            }

            return partA;

            throw new NotImplementedException();
        }
    }
}

