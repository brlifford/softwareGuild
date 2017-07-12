using System;

namespace Warmups.BLL
{
    public class Arrays
    {
        //Given an array of ints, return true if 6 appears as either the first or 
        //last element in the array. The array will be length 1 or more. 

        //FirstLast6({ 1, 2, 6}) -> true
        //FirstLast6({ 6, 1, 2, 3}) -> true
        //FirstLast6({ 13, 6, 1, 2, 3}) -> false

        public bool FirstLast6(int[] numbers)
        {
            if(numbers[0] == 6)
            {
                return true;
            }
            else if (numbers[numbers.Length-1] == 6)
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }

        //Given an array of ints, return true if the array is length 1 or more, 
        //and the first element and the last element are equal. 

        //SameFirstLast({ 1, 2, 3}) -> false
        //SameFirstLast({ 1, 2, 3, 1}) -> true
        //SameFirstLast({ 1, 2, 1}) -> true

        public bool SameFirstLast(int[] numbers)
        {
            if (numbers.Length == 1)
            {
                return true;
            }
            else if (numbers [0] == numbers [numbers.Length -1])
            {
                return true;
            }
            else
            {
                return false;
            }

            throw new NotImplementedException();
        }

        //Return an int array length n containing the first n digits of pi.

        //MakePi(3) -> {3, 1, 4}

        public int[] MakePi(int n)
        {
            string stringPi = Math.PI.ToString();
            string stringPiFixed = stringPi.Remove(1, 1);
            int[] returnPi = new int[n];
            string stringPiDigit;
            int piDigit;
            for (int i = 0; i < n; i++)
            {
                stringPiDigit = stringPiFixed.Substring(i, 1);
                
                piDigit = int.Parse(stringPiDigit);
               
                returnPi[i] = piDigit;
                
            }
            
            return returnPi;
            throw new NotImplementedException();
        }

        //Given 2 arrays of ints, a and b, return true if they have the same first 
        //element or they have the same last element. Both arrays will be length 1 or more. 

        //CommonEnd({ 1, 2, 3}, {7, 3}) -> true
        //CommonEnd({ 1, 2, 3}, {7, 3, 2}) -> false
        //CommonEnd({ 1, 2, 3}, {1, 3}) -> true

        public bool CommonEnd(int[] a, int[] b)
        {
            if (a[0] == b[0])
            {
                return true;
            }
            else if (a[a.Length - 1] == b[b.Length - 1])
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }

        //Given an array of ints, return the sum of all the elements. 

        //Sum({ 1, 2, 3}) -> 6
        //Sum({ 5, 11, 2}) -> 18
        //Sum({ 7, 0, 0}) -> 7

        public int Sum(int[] numbers)
        {
            int sumValue = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                sumValue += numbers[i];
            }
            return sumValue;
            throw new NotImplementedException();
        }

        //Given an array of ints, return an array with the elements "rotated left" 
        //so {1, 2, 3} yields {2, 3, 1}. 

        //RotateLeft({ 1, 2, 3}) -> {2, 3, 1}
        //RotateLeft({ 5, 11, 9}) -> {11, 9, 5}
        //RotateLeft({ 7, 0, 0}) -> {0, 0, 7}

        public int[] RotateLeft(int[] numbers)
        {
            int[] firstNum = new int[1];
            firstNum[0] = numbers[0];
            int[] firstHalf = new int[numbers.Length];
            for (int i = 1; i < numbers.Length; i++)
            {
                firstHalf[i - 1] = numbers[i];
            }
            int[] finalArray = new int[numbers.Length];
            for (int j = 0; j <firstHalf.Length; j++)
            {
                finalArray[j] = firstHalf[j];
            }
            finalArray[finalArray.Length - 1] = firstNum[0];
            return finalArray;
            throw new NotImplementedException();
        }

        //Given an array of ints length 3, return a new array with the elements in 
        //reverse order, so for example {1, 2, 3} becomes {3, 2, 1}. 

        public int[] Reverse(int[] numbers)
        {
            //int[] firstNum = new int[1];
            //int[] secondNum = new int[1];
            //int[] thirdNum = new int[1];
            int[] finalArray = new int[numbers.Length];
            //firstNum[0] = numbers[0];
            //secondNum[0] = numbers[1];
            //thirdNum[0] = numbers[2];
            for(int i = 0; i<finalArray.Length; i++)
            {
                finalArray[i] = numbers[numbers.Length- 1 - i];
            }
            return finalArray;
            throw new NotImplementedException();
        }

        //Given an array of ints, figure out which is larger between the first and 
        //last elements in the array, and set all the other elements to be that 
        //value. Return the changed array. 

        //HigherWins({ 1, 2, 3}) -> {3, 3, 3}
        //HigherWins({ 11, 5, 9}) -> {11, 11, 11}
        //HigherWins({ 2, 11, 3}) -> {3, 3, 3}

        public int[] HigherWins(int[] numbers)
        {
            int[] highNum = new int[numbers.Length];
            if (numbers[0] > numbers[numbers.Length - 1])
            {
                highNum[0] = numbers[0];
                for (int i = 0; i<numbers.Length; i++)
                {
                    highNum[i] = highNum[0];
                   
                   
                }
                return highNum;
            }
            else
            {
                highNum[0] = numbers[numbers.Length - 1];
                for (int j = 0; j<numbers.Length; j++)
                {
                    highNum[j] = highNum[0];
                    
                }
                return highNum;
            }
            throw new NotImplementedException();
        }

        //Given 2 int arrays, a and b, each length 3, return a new array length 2 
        //containing their middle elements. 

        //GetMiddle({ 1, 2, 3}, {4, 5, 6}) -> {2, 5}
        //GetMiddle({ 7, 7, 7}, {3, 8, 0}) -> {7, 8}
        //GetMiddle({ 5, 2, 9}, {1, 4, 5}) -> {2, 4}

        public int[] GetMiddle(int[] a, int[] b)
        {
            int[] middleReturn = new int[2];

            middleReturn[0] = a[1];
            middleReturn[1] = b[1];
            return middleReturn;
            
            throw new NotImplementedException();
        }

        //Given an int array , return true if it contains an even number (HINT: Use Mod (%)). 

        //HasEven({ 2, 5}) -> true
        //HasEven({ 4, 3}) -> true
        //HasEven({ 7, 5}) -> false

        public bool HasEven(int[] numbers)
        {
            bool isEven = false;
            int currentNum = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                currentNum = numbers[i];
                if (currentNum % 2 == 0)
                {
                    isEven = true;
                }
                else
                {
                    continue;
                }
            }
            return isEven;
            throw new NotImplementedException();
        }

        //Given an int array, return a new array with double the length where its 
        //last element is the same as the original array, and all the other elements 
        //are 0. The original array will be length 1 or more. Note: by default, a 
        //new int array contains all 0's. 

        //KeepLast({ 4, 5, 6}) -> {0, 0, 0, 0, 0, 6}
        //KeepLast({ 1, 2}) -> {0, 0, 0, 2}
        //KeepLast({ 3}) -> {0, 3}

        public int[] KeepLast(int[] numbers)
        {
            int[] lastNum = new int[(numbers.Length * 2)];
            lastNum[lastNum.Length - 1] = numbers[numbers.Length - 1];
            return lastNum;
            throw new NotImplementedException();
        }

        //Given an int array, return true if the array contains 2 twice, or 3 twice. 

        //Double23({ 2, 2, 3}) -> true
        //Double23({ 3, 4, 5, 3}) -> true
        //Double23({ 2, 3, 2, 2}) -> false

        public bool Double23(int[] numbers)
        {
            int hasNumTwo = 0;
            int hasNumThree = 0;
            for (int i = 0; i< numbers.Length; i++)
            {
                if(numbers[i] == 2) 
                {
                    hasNumTwo++;
                    
                }
                else if(numbers[i] == 3)
                {
                    hasNumThree++;
                }
            }
            if ((hasNumTwo >1 && hasNumTwo< 3) || (hasNumThree > 1 && hasNumThree <3))
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }

        //Given an int array length 3, if there is a 2 in the array immediately 
        //followed by a 3, set the 3 element to 0. Return the changed array. 

        //Fix23({ 1, 2, 3}) ->{1, 2, 0}
        //Fix23({ 2, 3, 5}) -> {2, 0, 5}
        //Fix23({ 1, 2, 1}) -> {1, 2, 1}

        public int[] Fix23(int[] numbers)
        {
            int locNumThree;
            for(int i = 0; i<numbers.Length; i++)
            {
                if(numbers[i] == 2)
                {
                    if (numbers[i+1] == 3)
                    {
                        locNumThree = i+1;
                        numbers[locNumThree] = 0;
                        return numbers;
                    }
                    else
                    {
                        return numbers;
                    }
                }
                else
                {
                    continue;
                }
               
            }
            return numbers;
            throw new NotImplementedException();
        }

        //We'll say that a 1 immediately followed by a 3 in an array is an "unlucky" 1. 
        //Return true if the given array contains an unlucky 1 in the first 2 or last 2 
        //positions in the array.

        //Unlucky1({ 1, 3, 4, 5}) -> true
        //Unlucky1({ 2, 1, 3, 4, 5}) -> true
        //Unlucky1({ 1, 1, 1}) -> false

        public bool Unlucky1(int[] numbers)
        {
            for (int i = 0; i<numbers.Length; i++)
            {
                if(numbers[i] == 1)
                {
                    if (numbers[i + 1] == 3)
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
                    continue;
                }
            }
            throw new NotImplementedException();
        }

        //Given 2 int arrays, a and b, return a new array length 2 containing, 
        //as much as will fit, the elements from a followed by the elements from b. 
        //The arrays may be any length, including 0, but there will be 2 or more 
        //elements available between the 2 arrays. 

        //Make2({ 4, 5}, {1, 2, 3}) -> {4, 5}
        //Make2({ 4}, {1, 2, 3}) -> {4, 1}
        //Make2({ }, {1, 2}) -> {1, 2}


        public int[] Make2(int[] a, int[] b)
        {
            int[] newNums = new int[2];
            for (int i = 0; i<a.Length; i++)
            {
                if(a.Length == 2)
                {
                    return a;
                }
                else if (a.Length == 0)
                {
                    continue;
                }
                else
                {
                    newNums[i] = a[i];
                    continue;
                }
                
            }
            if(a.Length == 1)
            {
                newNums[1] = b[0];
            }
            else
            {
                for(int i = 0; i<b.Length; i++)
                {
                    newNums[i] = b[i];
                }
            }
            return newNums;
            throw new NotImplementedException();
        }

    }
}
