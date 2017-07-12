using System;

namespace Warmups.BLL
{
    public class Strings
    {
        //Given a string name, e.g. "Bob", return a greeting of the form "Hello Bob!". 

        //SayHi("Bob") -> "Hello Bob!"
        //SayHi("Alice") -> "Hello Alice!"
        //SayHi("X") -> "Hello X!"

        public string SayHi(string name)
        {
            return $"Hello {name}!";
        }

        //Given two strings, a and b, return the result of putting them together 
        //in the order abba, e.g. "Hi" and "Bye" returns "HiByeByeHi". 

        //Abba("Hi", "Bye") -> "HiByeByeHi"
        //Abba("Yo", "Alice") -> "YoAliceAliceYo"
        //Abba("What", "Up") -> "WhatUpUpWhat"

        public string Abba(string a, string b)
        {
            return $"{a}{b}{b}{a}";
            throw new NotImplementedException();
        }

        //The web is built with HTML strings like "<i>Yay</i>" which draws Yay 
        //as italic text. In this example, the "i" tag makes <i> and </i> which 
        //surround the word "Yay". Given tag and word strings, create the HTML 
        //string with tags around the word, e.g. "<i>Yay</i>". 

        //MakeTags("i", "Yay") -> "<i>Yay</i>"
        //MakeTags("i", "Hello") -> "<i>Hello</i>"
        //MakeTags("cite", "Yay") -> "<cite>Yay</cite>"

        public string MakeTags(string tag, string content)
        {
            return $"<{tag}>{content}</{tag}>";
            throw new NotImplementedException();
        }

        //Given an "out" string length 4, such as "<<>>", and a word, return a 
        //new string where the word is in the middle of the out string, e.g. "<<word>>".

        //Hint: Substrings are your friend here

        //InsertWord("<<>>", "Yay") -> "<<Yay>>"
        //InsertWord("<<>>", "WooHoo") -> "<<WooHoo>>"
        //InsertWord("[[]]", "word") -> "[[word]]"

        public string InsertWord(string container, string word)
        {
            string startContainer = container.Substring(0, 2);
            string endContainer = container.Substring(2);
            return $"{startContainer}{word}{endContainer}";
            throw new NotImplementedException();
        }

        //Given a string, return a new string made of 3 copies of the last 2 
        //chars of the original string. The string length will be at least 2. 

        //MultipleEndings("Hello") -> "lololo"
        //MultipleEndings("ab") -> "ababab"
        //MultipleEndings("Hi") -> "HiHiHi"

        public string MultipleEndings(string str)
        {
            string newSong;
            if (str.Length < 3)
            {
                return $"{str}{str}{str}";
            }
            else
            {
                newSong = str.Substring(str.Length - 2);
                return $"{newSong}{newSong}{newSong}";
            }
            throw new NotImplementedException();
        }

        //Given a string of even length, return the first half. So the 
        //string "WooHoo" yields "Woo". 

        //FirstHalf("WooHoo") -> "Woo"
        //FirstHalf("HelloThere") -> "Hello"
        //FirstHalf("abcdef") -> "abc"

        public string FirstHalf(string str)
        {
            int wordLength = str.Length;
            int halfWord = wordLength / 2;
            string newWord = str.Substring(0, halfWord);
            return newWord;
            throw new NotImplementedException();
        }

        //Given a string, return a version without the first and last char, 
        //so "Hello" yields "ell". The string length will be at least 2. 

        //TrimOne("Hello") -> "ell"
        //TrimOne("java") -> "av"
        //TrimOne("coding") -> "odin"

        public string TrimOne(string str)
        {
            string firstHalf = str.Substring(1);
            int firstLength = firstHalf.Length;
            string secondHalf = firstHalf.Substring(0,firstLength - 1);
            return secondHalf;
            throw new NotImplementedException();
        }

        //Given 2 strings, a and b, return a string of the form short+long+short, 
        //with the shorter string on the outside and the longer string on the 
        //inside. The strings will not be the same length, but they may be empty (length 0). 

        //LongInMiddle("Hello", "hi") -> "hiHellohi"
        //LongInMiddle("hi", "Hello") -> "hiHellohi"
        //LongInMiddle("aaa", "b") -> "baaab"

        public string LongInMiddle(string a, string b)
        {
            string shortString;
            string longString;
            if (a.Length < b.Length)
            {
                shortString = a;
                longString = b;

            }
            else
            {
                shortString = b;
                longString = a;
            }
            return $"{shortString}{longString}{shortString}";
            throw new NotImplementedException();
        }

        //Given a string, return a "rotated left 2" version where the first 2 chars 
        //are moved to the end. The string length will be at least 2. 

        //Rotateleft2("Hello") -> "lloHe"
        //Rotateleft2("java") -> "vaja"
        //Rotateleft2("Hi") -> "Hi"

        public string RotateLeft2(string str)
        {
            if (str.Length < 3)
            {
                return str;
            }
            string moveBack = str.Substring(0,2);
            string moveUp = str.Substring(2);
            string newWord = moveUp + moveBack;
            return newWord;

            throw new NotImplementedException();
        }

        //Given a string, return a "rotated right 2" version where the last 2 chars 
        //are moved to the start. The string length will be at least 2. 

        //RotateRight2("Hello") -> "loHel"
        //RotateRight2("java") -> "vaja"
        //RotateRight2("Hi") -> "Hi"

        public string RotateRight2(string str)
        {
            if (str.Length < 3)
            {
                return str;
            }
            string moveUp = str.Substring(str.Length - 2);
            string moveBack = str.Remove(str.Length - 2);
            string newWord = moveUp + moveBack;
            return newWord;
            throw new NotImplementedException();
        }

        //Given a string, return a string length 1 from its front, unless front is 
        //false, in which case return a string length 1 from its back. The string 
        //will be non-empty. 

        //TakeOne("Hello", true) -> "H"
        //TakeOne("Hello", false) -> "o"
        //TakeOne("oh", true) -> "o"

        public string TakeOne(string str, bool fromFront)
        {
            string frontOne = str.Substring(0,1);
            string backOne = str.Substring(str.Length - 1);
            if(fromFront == true)
            {
                return frontOne;
            }
            else
            {
                return backOne;
            }

            throw new NotImplementedException();
        }

        //Given a string of even length, return a string made of the middle two chars, 
        //so the string "string" yields "ri". The string length will be at least 2. 

        //MiddleTwo("string") -> "ri"
        //MiddleTwo("code") -> "od"
        //MiddleTwo("Practice") -> "ct"

        public string MiddleTwo(string str)
        {
            int wordLength = str.Length;
            int halfLength = wordLength / 2;
            string firstHalf = str.Substring(halfLength - 1, 2);
            return firstHalf;
            throw new NotImplementedException();
        }

        //Given a string, return true if it ends in "ly". 

        //EndsWithLy("oddly") -> true
        //EndsWithLy("y") -> false
        //EndsWithLy("oddy") -> false

        public bool EndsWithLy(string str)
        {
            if (str.Contains("ly"))
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }

        //Given a string and an int n, return a string made of the first and 
        //last n chars from the string. The string length will be at least n. 

        //FrontAndBack("Hello", 2) -> "Helo"
        //FrontAndBack("Chocolate", 3) -> "Choate"
        //FrontAndBack("Chocolate", 1) -> "Ce"

        public string FrontAndBack(string str, int n)
        {
            string firstHalf = str.Substring(0, n);
            string secondHalf = str.Substring(str.Length - n);
            return firstHalf + secondHalf;
            throw new NotImplementedException();
        }

        //Given a string and an index, return a string length 2 starting at 
        //the given index. If the index is too big or too small to define a 
        //string length 2, use the first 2 chars. The string length will be 
        //at least 2. 

        //TakeTwoFromPosition("java", 0) -> "ja"
        //TakeTwoFromPosition("java", 2) -> "va"
        //TakeTwoFromPosition("java", 3) -> "ja"

        public string TakeTwoFromPosition(string str, int n)
        {
            string fromFront = str.Substring(0, 2);
            string fromBack;

            if ((2 + n) > str.Length)
            {
                return fromFront; 
            }
            else
            {
                fromBack = str.Substring(n, 2);
                return fromBack;
            }
            throw new NotImplementedException();
        }

        //Given a string, return true if "bad" appears starting at index 0 or 1 in 
        //the string, such as with "badxxx" or "xbadxx" but not "xxbadxx". The 
        //string may be any length, including 0.

        //HasBad("badxx") -> true
        //HasBad("xbadxx") -> true
        //HasBad("xxbadxx") -> false

        public bool HasBad(string str)
        {
            bool hasBadInString = str.Contains("bad");
            int badStringLoc;
            if(hasBadInString == true)
            {
                badStringLoc = str.IndexOf("b");
                if(badStringLoc <2)
                {
                    return true;
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

            throw new NotImplementedException();
        }

        //Given a string, return a string length 2 made of its first 2 chars. If 
        //the string length is less than 2, use '@' for the missing chars. 

        //AtFirst("hello") -> "he"
        //AtFirst("hi") -> "hi"
        //AtFirst("h") -> "h@"

        public string AtFirst(string str)
        {
            if (str.Length < 1)
            {
                return $"@@";
            }
            else if (str.Length == 1)
            {
                return $"{str}@";
            }
            else
            {
                return str.Substring(0, 2);
            }
            throw new NotImplementedException();
        }

        //Given 2 strings, a and b, return a new string made of the first char of 
        //a and the last char of b, so "yo" and "java" yields "ya". If either 
        //string is length 0, use '@' for its missing char. 

        //LastChars("last", "chars") -> "ls"
        //LastChars("yo", "mama") -> "ya"
        //LastChars("hi", "") -> "h@"

        public string LastChars(string a, string b)
        {
            string partA;
            string partB;

            if (a.Length > 0)
            {
                partA = a.Substring(0, 1);
            }
            else
            {
                partA = "@";
            }

            if (b.Length > 0)
            {
                partB = b.Substring(b.Length - 1);
            }
            else
            {
                partB = "@";
            }

            return partA + partB;
            throw new NotImplementedException();
        }

        //Given two strings, append them together (known as "concatenation") and 
        //return the result. However, if the concatenation creates a double-char, 
        //then omit one of the chars, so "abc" and "cat" yields "abcat". 

        //ConCat("abc", "cat") -> "abcat"
        //ConCat("dog", "cat") -> "dogcat"
        //ConCat("abc", "") -> "abc"

        public string ConCat(string a, string b)
        {
            string evalPartA;
            string evalPartB;
            bool sameChar;
            string partB;
            if (a.Length > 0)
            {
                evalPartA = a.Substring(a.Length - 1); //get last char for eval
                if (b.Length > 0)
                {
                    evalPartB = b.Substring(0, 1); // get first char for eval
                    if (evalPartA == evalPartB) // are they equal?
                    {
                        sameChar = true;
                        if (sameChar == true)
                        {
                            partB = b.Remove(0, 1); // if equal, remove first char from b
                            return a + partB;
                        }
                        
                    }
                    else
                    {
                        return a + b;
                    }
                }
                else
                {
                    return a;
                }
                
            }
            else
            {
                return b;
            }
            throw new NotImplementedException();
        }

        //Given a string of any length, return a new string where the last 2 chars, 
        //if present, are swapped, so "coding" yields "codign". 

        //SwapLast("coding") -> "codign"
        //SwapLast("cat") -> "cta"
        //SwapLast("ab") -> "ba"

        public string SwapLast(string str)
        {
            string partA;
            string partB;
            string firstPart;
            if(str.Length > 1)
            {
                partA = str.Substring(str.Length - 1);
                partB = str.Substring(str.Length - 2, 1);
                firstPart = str.Substring(0, str.Length - 2);
                return firstPart + partA + partB;
            }
            else
            {
                return str;
            }
            throw new NotImplementedException();
        }

        //Given a string, return true if the first 2 chars in the string also 
        //appear at the end of the string, such as with "edited". 

        //FrontAgain("edited") -> true
        //FrontAgain("edit") -> false
        //FrontAgain("ed") -> true

        public bool FrontAgain(string str)
        {
            string evalA;
            string evalB;
            if (str.Length > 3)
            {
                evalA = str.Substring(0, 2);
                evalB = str.Substring(str.Length - 2);
                if(evalA == evalB)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
            throw new NotImplementedException();
        }

        //Given two strings, append them together (known as "concatenation") and 
        //return the result. However, if the strings are different lengths, omit 
        //chars from the longer string so it is the same length as the shorter 
        //string. So "Hello" and "Hi" yield "loHi". The strings may be any length. 

        //MinCat("Hello", "Hi") -> "loHi"
        //MinCat("Hello", "java") -> "ellojava"
        //MinCat("java", "Hello") -> "javaello"

        public string MinCat(string a, string b)
        {
            string partA;
            string partB;
            if (a.Length < b.Length)
            {
                partA = a;
                partB = b.Remove(0, (b.Length - a.Length));
                return partA + partB;
            }
            else if (a.Length > b.Length)
            {
                partB = b;
                partA = a.Remove(0, a.Length - b.Length);
                return partA + partB;
            }
            else
            {
                return a + b;
            }
            throw new NotImplementedException();
        }

        //Given a string, return a version without the first 2 chars. Except keep 
        //the first char if it is 'a' and keep the second char if it is 'b'. The 
        //string may be any length.

        //TweakFront("Hello") -> "llo"
        //TweakFront("away") -> "aay"
        //TweakFront("abed") -> "abed"

        public string TweakFront(string str)
        {
            
            if (str.Length < 2)
            {
                return str;
            }

            string evalA = str.Substring(0, 1);
            string evalB = str.Substring(1, 1);
            string lastHalf = str.Substring(2);

            if (evalA == "a")
            {
                if(evalB == "b")
                {
                    return evalA + evalB + lastHalf;
                }
                else
                {
                    return evalA + lastHalf;
                }
            }
            else if(evalB == "b")
            {
                return evalB + lastHalf;
            }
             
            else
            {
                return lastHalf;
            }

            throw new NotImplementedException();
        }

        //Given a string, if the first or last chars are 'x', return the string 
        //without those 'x' chars, and otherwise return the string unchanged. 

        //StripX("xHix") -> "Hi"
        //StripX("xHi") -> "Hi"
        //StripX("Hxix") -> "Hxi"

        public string StripX(string str)
        {
            string newWord = str;
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            if(str.Substring(0,1) == "x")
            {
                newWord = str.Remove(0, 1);
            }
            if(newWord.Length > 1)
            {
                if (str.Substring(str.Length - 1) == "x")
                {
                    newWord = newWord.Remove(newWord.Length - 1);
                    return newWord;
                }
                else
                {
                    return newWord;
                }
            }
            else
            {
                return newWord;
            } 
            throw new NotImplementedException();
        }
    }
}
