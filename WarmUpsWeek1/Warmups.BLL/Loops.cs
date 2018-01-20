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

        // WTF?????????

        public bool DoubleX(string str)
        {
            bool doubleX = true;

            int i = str.IndexOf("x");

            if (i == -1 || i == str.Length - 1)
            {
                doubleX = false;
            }            
            return doubleX;
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

        // WTF ?????????????

        public string StringSplosion(string str)
        {
            string splosion = "";

            int length = str.Length;

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



            return count9;
            
            //throw new NotImplementedException();
        }

        public bool ArrayFront9(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public bool Array123(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public int SubStringMatch(string a, string b)
        {
            throw new NotImplementedException();
        }

        public string StringX(string str)
        {
            throw new NotImplementedException();
        }

        public string AltPairs(string str)
        {
            throw new NotImplementedException();
        }

        public string DoNotYak(string str)
        {
            throw new NotImplementedException();
        }

        public int Array667(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public bool NoTriples(int[] numbers)
        {
            throw new NotImplementedException();
        }

        public bool Pattern51(int[] numbers)
        {
            throw new NotImplementedException();
        }

    }
}
