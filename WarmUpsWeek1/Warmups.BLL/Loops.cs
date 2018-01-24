using System;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            string stringTimes = "";

            int count = 0;

            while (count < n)
            {
                stringTimes += str;
                count++;
            }
            return stringTimes;
        }

        public string FrontTimes(string str, int n)
        {
            string frontTimes = "";

            string front = str.Substring(0, 3);

            int count = 0;

            while  (count < n)
            {
                frontTimes += front;
                count++;
            }
            return frontTimes;
        }

        public int CountXX(string str)
        {
            int countXX = 0;

            for (int i = str.IndexOf("xx"); i != -1; i = str.IndexOf("xx", i + 1))
            {
                countXX++;
            }
            return countXX;
        }

        public bool DoubleX(string str)
        {
            bool IsDouble;
            int IndexOfFirstX = 0;
            bool FoundFirstX = false;
            while (!FoundFirstX)
            {
                for (int i = 0; i < str.Length - 1; i++)
                {
                    if (str.Substring(i, 1) == "x")
                    {
                        IndexOfFirstX = i;
                        FoundFirstX = true;
                        break;
                    }
                }
                if (FoundFirstX == false)
                {
                    return false;
                }
            }
            if (str.Substring(IndexOfFirstX + 1, 1) == "x")
            {
                IsDouble = true;
            }
            else
            {
                IsDouble = false;
            }
            return IsDouble;
        }

        public string EveryOther(string str)
        {
            string everyOther = "";

            for(int i = 0; i < str.Length; i += 2)
            {
                everyOther += str.Substring(i, 1);
            }
            return everyOther;
        }

        public string StringSplosion(string str)
        {
            string splosion = "";

            for(int i = 0; i < str.Length; i++)
            {
                splosion += str.Substring(0, i + 1);
            }
            return splosion;
        }

        public int CountLast2(string str)
        {
            int last2 = 0;

            string last = str.Substring(str.Length - 2);

            for (int i = 0; i < str.Length - 2; i++)
            {
                string sub = str.Substring(i, 2);

                if (sub == last)
                {
                    last2++;
                }
            }
            return last2;
        }

        public int Count9(int[] numbers)
        {
            int count9 = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 9)
                {
                    count9++;
                }
            }
            return count9;
        }

        public bool ArrayFront9(int[] numbers)
        {
            bool front9 = false;

            for (int i = 0; i < 4; i++)
            {
                if (numbers[i] == 9)
                {
                    front9 = true;
                }
            }
            return front9;
        }

        public bool Array123(int[] numbers)
        {
            bool arrary123 = false;

            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i] == 1 
                    && numbers[i + 1] == 2
                    && numbers [i + 2] == 3)
                {
                    arrary123 = true;
                }
            }
            return arrary123;
        }

        public int SubStringMatch(string a, string b)
        {
            int len = Math.Min(a.Length, b.Length);
            int match = 0;

            for (int i = 0; i < len - 1; i++)
            {
                if ((a[i] == b[i]) && (a[i + 1] == b[i + 1]))
                {
                    match++;
                }
            }
            return match;
        }

        public string StringX(string str)
        {
            string x = "";
            
            for (int i = 1; i < str.Length - 1; i++)
            {
                if (str.Substring(i, 1) != "x")
                {
                    x += str.Substring(i, 1);
                }
            }

            x = str.Substring(0, 1) + x;
            x = x + str.Substring(str.Length - 1, 1);
            return x;
        }

        public string AltPairs(string str)
        {
            string alt = "";

            for (int i = 0; i < str.Length; i += 4)
            {
                alt += str[i];
                if (i + 1 < str.Length)
                {
                    alt += str[i + 1];
                }
            }
            return alt;
        }

        public string DoNotYak(string str)
        {
            string yak = "";
            string temp = "";

            if (str.Contains("yak"))
            {
                temp = str.Replace("yak","");
                yak += temp;
            }
            return yak;
        }

        public int Array667(int[] numbers)
        {
            int array = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == 6 && numbers[i + 1] == 6)
                {
                    array++;
                }
                else if (numbers[i] == 6 && numbers[i + 1] == 7)
                {
                    array++;
                }
            }
            return array;
        }

        public bool NoTriples(int[] numbers)
        {
            bool noTrips = true;

            for (int i = 0; i < numbers.Length - 3; i++)
            {
                if (numbers[i] == numbers[i + 1] && numbers[i] == numbers[i + 2])
                {
                    noTrips = false;
                }
            }
            return noTrips;
        }

        public bool Pattern51(int[] numbers)
        {
            bool pattern51 = false;

            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if ((numbers[i] + 5 == (numbers[i + 1]) && Math.Abs(numbers[i + 2] - (numbers[i] - 1)) <= 2))
                {
                    pattern51 = true;
                }
            }
            return pattern51;
        }

    }
}
