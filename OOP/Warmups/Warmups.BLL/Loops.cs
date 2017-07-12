using System;

namespace Warmups.BLL
{
    public class Loops
    {
        //Given a string and a non-negative int n, return a larger string that is n 
        //copies of the original string. 

        //StringTimes("Hi", 2) -> "HiHi"
        //StringTimes("Hi", 3) -> "HiHiHi"
        //StringTimes("Hi", 1) -> "Hi"

        public string StringTimes(string str, int n)
        {
            string wordMultiply = str;
            if (str.Length < n * str.Length)
            {
                wordMultiply = str + str;
                if (wordMultiply.Length < n * str.Length)
                {
                    wordMultiply = wordMultiply + str;
                    return wordMultiply;
                }
                else
                {
                    return wordMultiply;
                }

            }
            else
            {
                return wordMultiply;
            }

            throw new NotImplementedException();
        }

        //Given a string and a non-negative int n, we'll say that the front of the 
        //string is the first 3 chars, or whatever is there if the string is less 
        //than length 3. Return n copies of the front; 

        //FrontTimes("Chocolate", 2) -> "ChoCho"
        //FrontTimes("Chocolate", 3) -> "ChoChoCho"
        //FrontTimes("Abc", 3) -> "AbcAbcAbc"

        public string FrontTimes(string str, int n)
        {
            if (str.Length > 3)
            {
                string frontString = str.Remove(3);
                string wordMultiply = frontString;
                for (int i = 1; i <= n; i++)
                {
                    if (wordMultiply.Length < n * frontString.Length)
                    {
                        wordMultiply = wordMultiply + frontString;
                    }
                    else
                    {
                        return wordMultiply;
                    }
                }
            }
            else
            {
                string wordMultiply = str;
                for (int i = 1; i <= n; i++)
                {
                    if (wordMultiply.Length < n * str.Length)
                    {
                        wordMultiply = wordMultiply + str;
                    }
                    else
                    {
                        return wordMultiply;
                    }
                }
            }

            throw new NotImplementedException();
        }

        //Count the number of "xx" in the given string. We'll say that overlapping 
        //is allowed, so "xxx" contains 2 "xx". 

        //CountXX("abcxx") -> 1
        //CountXX("xxx") -> 2
        //CountXX("xxxx") -> 3

        public int CountXX(string str)
        {
            int numX = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'x')
                {
                    if (i == str.Length - 1)
                    {
                        return numX;
                    }
                    else if (str[i + 1] == 'x')
                    {
                        numX++;

                    }
                    else
                    {
                        return numX;
                    }
                }
                else
                {
                    continue;
                }
            }
            throw new NotImplementedException();
        }

        //Given a string, return true if the first instance of "x" in the string is 
        //immediately followed by another "x". 

        //DoubleX("axxbb") -> true
        //DoubleX("axaxxax") -> false
        //DoubleX("xxxxx") -> true

        public bool DoubleX(string str)
        {
            if (str.Contains("x"))
            {
                int locOfX = str.IndexOf('x');
                for (int i = locOfX; i < str.Length; i++)
                {
                    if (i == str.Length - 1)
                    {
                        return false;
                    }
                    else if (str[i + 1] == 'x')
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }

        //Given a string, return a new string made of every other char starting with 
        //the first, so "Hello" yields "Hlo". 

        //EveryOther("Hello") -> "Hlo"
        //EveryOther("Hi") -> "H"
        //EveryOther("Heeololeo") -> "Hello"

        public string EveryOther(string str)
        {
            string newWord = str.Substring(0, 1);
            for (int i = 1; i < str.Length; i++)
            {
                if (i % 2 == 0)
                {
                    newWord = newWord + str[i];
                }
                else
                {
                    continue;
                }
            }
            return newWord;
            throw new NotImplementedException();
        }

        //Given a non-empty string like "Code" return a string like "CCoCodCode".  
        //(first char, first two, first 3, etc)

        //StringSplosion("Code") -> "CCoCodCode"
        //StringSplosion("abc") -> "aababc"
        //StringSplosion("ab") -> "aab"

        public string StringSplosion(string str)
        {
            string newWord = "";
            for (int i = 0; i < str.Length; i++)
            {
                newWord = newWord + str.Substring(0, i + 1);
            }
            return newWord;
            throw new NotImplementedException();
        }

        //Given a string, return the count of the number of times that a substring 
        //length 2 appears in the string and also as the last 2 chars of the string, 
        //so "hixxxhi" yields 1 (we won't count the end substring). 

        //CountLast2("hixxhi") -> 1
        //CountLast2("xaxxaxaxx") -> 1
        //CountLast2("axxxaaxx") -> 2

        public int CountLast2(string str)
        {
            string lastTwo = str.Substring(str.Length - 2);
            string firstPart = str.Remove(str.Length - 2);
            int countLast = 0;
            for (int i = 0; i < firstPart.Length; i++)
            {
                if (firstPart[i] == lastTwo[0])
                {
                    if (i == firstPart.Length - 1)
                    {
                        return countLast;
                    }
                    else if (firstPart[i + 1] == lastTwo[1])
                    {
                        countLast++;
                    }
                }
                else
                {
                    continue;
                }
            }
            return countLast;
            throw new NotImplementedException();
        }

        //Given an array of ints, return the number of 9's in the array. 

        //Count9({ 1, 2, 9}) -> 1
        //Count9({ 1, 9, 9}) -> 2
        //Count9({ 1, 9, 9, 3, 9}) -> 3

        public int Count9(int[] numbers)
        {
            int numNines = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 9)
                {
                    numNines++;
                }
                else
                {
                    continue;
                }
            }
            return numNines;
            throw new NotImplementedException();
        }

        //Given an array of ints, return true if one of the first 4 elements in the 
        //array is a 9. The array length may be less than 4. 

        //ArrayFront9({ 1, 2, 9, 3, 4}) -> true
        //ArrayFront9({ 1, 2, 3, 4, 9}) -> false
        //ArrayFront9({ 1, 2, 3, 4, 5}) -> false

        public bool ArrayFront9(int[] numbers)
        {
            if (numbers.Length > 3)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (numbers[i] == 9)
                    {
                        return true;
                    }
                    else if (i == 3)
                    {
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            else
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] == 9)
                    {
                        return true;
                    }
                    else if (i == numbers.Length - 1)
                    {
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            throw new NotImplementedException();
        }

        //Given an array of ints, return true if .. 1, 2, 3, .. appears in the array somewhere. 

        //Array123({ 1, 1, 2, 3, 1}) -> true
        //Array123({ 1, 1, 2, 4, 1}) -> false
        //Array123({ 1, 1, 2, 1, 2, 3}) -> true

        public bool Array123(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 1 && numbers[i + 1] == 2 && numbers[i + 2] == 3)
                {
                    return true;
                }
                else if (i == numbers.Length - 1 || i + 1 == numbers.Length - 1)
                {
                    return false;
                }
                else
                {
                    continue;
                }
            }
            throw new NotImplementedException();
        }

        //Given 2 strings, a and b, return the number of the positions where they 
        //contain the same length 2 substring. So "xxcaazz" and "xxbaaz" yields 3, 
        //since the "xx", "aa", and "az" substrings appear in the same place in 
        //both strings. 

        //SubStringMatch("xxcaazz", "xxbaaz") -> 3
        //SubStringMatch("abc", "abc") -> 2
        //SubStringMatch("abc", "axc") -> 0

        public int SubStringMatch(string a, string b)
        {
            int numSame = 0;
            string compareA;
            string compareB = "";
            string smallerString;

            if (a.Length < b.Length)
            {
                smallerString = a;
            }
            else
            {
                smallerString = b;
            }
            for (int i = 0; i < smallerString.Length; i++)
            {
                if (i == smallerString.Length - 1)
                {
                    break;
                }
                else
                {
                    compareA = a.Substring(i, 2);
                    compareB = b.Substring(i, 2);
                    if (compareA == compareB)
                    {
                        numSame++;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return numSame;
            throw new NotImplementedException();
        }
        //Given a string, return a version where all the "x" have been removed. 
        //Except an "x" at the very start or end should not be removed. 

        //StringX("xxHxix") -> "xHix"
        //StringX("abxxxcd") -> "abcd"
        //StringX("xabxxxcdx") -> "xabcdx"

        public string StringX(string str)
        {
            string charXStart = "";
            string charXEnd = "";
            string newWord = "";

            if (str.Substring(0, 1) == "x")
            {
                charXStart = "x";
            }
            else
            {
                charXStart = "";

            }
            if (str.Length > 1)
            {
                if (str.Substring(str.Length - 1) == "x")
                {
                    charXEnd = "x";
                }
                else
                {
                    charXEnd = "";
                }
            }
            else
            {
                charXEnd = "";
            }
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != 'x')
                {
                    newWord = newWord + str.Substring(i,1);
                }
                else
                {
                    continue;
                }
            }
            return charXStart + newWord + charXEnd;
            throw new NotImplementedException();
        }

        //Given a string, return a string made of the chars at indexes 0,1, 4,5, 8,9 ... 
        //so "kittens" yields "kien". 

        //AltPairs("kitten") -> "kien"
        //AltPairs("Chocolate") -> "Chole"
        //AltPairs("CodingHorror") -> "Congrr"

        public string AltPairs(string str)
        {
            string firstTwo = "";
            string secondTwo ="";
            string thirdTwo = "";
            string newWord = "";

            for(int i = 0; i<str.Length; i++)
            {
                if(i < 2)
                {
                    firstTwo = firstTwo + str.Substring(i, 1);
                }
                else if (i >3 && i < 6)
                {
                    secondTwo = secondTwo + str.Substring(i, 1);
                }
                else if (i > 7 && i < 10)
                {
                    thirdTwo = thirdTwo + str.Substring(i, 1);
                }
                else
                {
                    continue;
                }
            }
            newWord = firstTwo + secondTwo + thirdTwo;
            return newWord;
            throw new NotImplementedException();
        }

        //Suppose the string "yak" is unlucky. Given a string, return a version where 
        //all the "yak" are removed, but the "a" can be any char. The "yak" strings 
        //will not overlap. 

        //DoNotYak("yakpak") -> "pak"
        //DoNotYak("pakyak") -> "pak"
        //DoNotYak("yak123ya") -> "123ya"

        public string DoNotYak(string str)
        {
            string newWord = "";
            for(int i = 0; i<str.Length; i++)
            {
                if(i == str.Length -1 || (i + 1) == str.Length - 1)
                {
                    continue;
                }
                if(str[i] == 'y')
                {
                    if(str[i + 1] == 'a')
                    {
                        if(str[i+2] == 'k')
                        {
                            newWord = str.Remove(i, 3);
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
                else
                {
                    continue;
                }
            }
            if(newWord == "")
            {
                return str;
            }
            else
            {
                return newWord;
            }
            throw new NotImplementedException();
        }

        //Given an array of ints, return the number of times that two 6's are next to 
        //each other in the array. Also count instances where the second "6" is 
        //actually a 7. 

        //Array667({ 6, 6, 2}) -> 1
        //Array667({ 6, 6, 2, 6}) -> 1
        //Array667({ 6, 7, 2, 6}) -> 1

        public int Array667(int[] numbers)
        {
            int countSixSix = 0;
            for(int i = 0; i<numbers.Length; i++)
            {
                if(i == numbers.Length - 1)
                {
                    continue;
                }
                if(numbers[i] == 6)
                {
                    if(numbers[i+1] == 6 || numbers[i+1] == 7)
                    {
                        countSixSix++;
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
            return countSixSix;
            throw new NotImplementedException();
        }

        //Given an array of ints, we'll say that a triple is a value appearing 3 
        //times in a row in the array. Return true if the array does not contain 
        //any triples. 

        //NoTriples({ 1, 1, 2, 2, 1}) -> true
        //NoTriples({ 1, 1, 2, 2, 2, 1}) -> false
        //NoTriples({ 1, 1, 1, 2, 2, 2, 1}) -> false

        public bool NoTriples(int[] numbers)
        {
            bool tripleFree = true;
            for(int i = 0; i < numbers.Length; i++)
            {
                if(i == numbers.Length - 1 || i + 1 == numbers.Length - 1)
                {
                    continue;
                }
                if(numbers[i] == numbers[i+1] && numbers[i+1] == numbers[i+2])
                {
                    tripleFree = false;
                    
                }
                else
                {
                    continue;
                }
            }
            return tripleFree;
            throw new NotImplementedException();
        }

        //Given an array of ints, return true if it contains a 2, 7, 1 pattern -- a 
        //value, followed by the value plus 5, followed by the value minus 1.

        //Pattern51({ 1, 2, 7, 1}) -> true
        //Pattern51({ 1, 2, 8, 1}) -> false
        //Pattern51({ 2, 7, 1}) -> true
        //[TestCase(new[] { 1, 2, 7, 1 }, true)]
        //[TestCase(new[] { 1, 2, 8, 1 }, false)]
        //[TestCase(new[] { 2, 7, 1 }, true)]
        //[TestCase(new[] { 6, 4, 9, 3, 2 }, true)]
        //[TestCase(new[] { 2, 7 }, false)]

        public bool Pattern51(int[] numbers)
        {
            bool isPattern = false;
            for(int i = 0; i < numbers.Length; i++)
            {
                if (i == numbers.Length - 1 || i + 1 == numbers.Length - 1)
                {
                    continue;
                }
                if(numbers[i] == numbers[i+1] - 5)
                {
                    if(numbers[i] == (numbers[i + 2] + 1))
                    {
                        isPattern = true;
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
            return isPattern;
            throw new NotImplementedException();
        }

    }
}
