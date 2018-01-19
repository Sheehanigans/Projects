using System;

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            return aSmile == bSmile;
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            return (isWeekday == false || isVacation == true);
        }

        public int SumDouble(int a, int b)
        {
            if (a == b)
            {
                return (2 * (a + b));
            }
            return (a + b);
        }

        public int Diff21(int n)
        {
            if (21 < n)
            {
                return Math.Abs(2 * (n - 21));

            }
            return Math.Abs(n - 21);
        }

        public bool ParrotTrouble(bool isTalking, int hour)
        {
            if (isTalking)
            {
                if (hour < 7 || hour > 20)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Makes10(int a, int b)
        {
            bool doesMake10 = true;

            if (a == 10 || b == 10 || a + b == 10)
            {
                return doesMake10; 
            }
            return false;
        }

        public bool NearHundred(int n)
        {
            bool isNearHundred = false; 

            if ((90 <= n && n <= 110) || (190 <= n && n <= 210))
            {
                isNearHundred = true;
            }
            return isNearHundred;
        }

        public bool PosNeg(int a, int b, bool negative)
        {
            bool isPosNeg = true;

            if (a > 0 || b > 0)
            {
                return isPosNeg;
            }
            else if (negative = true && (a > 0 && b > 0));
            {
                return isPosNeg;
            }
        }

        public string NotString(string s)
        {

            if (s.Contains("not"))
            {
                return s;
            } else
            {
                return ("not " + s);
            }
        }

        public string MissingChar(string str, int n)
        {
            return str.Remove(n, 1);
        }

        public string FrontBack(string str)
        {
            throw new NotImplementedException();
        }
        //{
        //    char front;
        //    char back;

        //    string flipped = str.ToCharArray();

        //}

        public string Front3(string str)
        {
            string Front3 = (str + str + str);

            if (str.Length < 3)
            {
                return Front3;
            }
            else
            {
                return str.Substring(0, 3) + str.Substring(0, 3) + str.Substring(0, 3);
            }
        } 

        public string BackAround(string str)
        {
            char last = str[str.Length - 1];

            string backAround = (last + str + last);

            return backAround;
        }

        public bool Multiple3or5(int number)
        {
            bool multiple3or5 = true;

            bool mult3 = (number % 3 == 0);
            bool mult5 = (number % 5 == 0);

            if (mult3 || mult5)
            {
                return multiple3or5;
            }

            return false;
        }

        public bool StartHi(string str)
        {
            //bool startHi = true;

            //if (str.StartsWith("hi"))
            //{
            //    return startHi;
            //}
            //return false;

            throw new NotImplementedException();

        }

        public bool IcyHot(int temp1, int temp2)
        {
            bool icyHot = true;

            if (temp1 < 0 && temp2 > 100)
            {
                return icyHot;
            }
            else if (temp1 > 100 && temp2 < 0)
            {
                return icyHot;
            }
            return false;
        }

        public bool Between10and20(int a, int b)
        {
            bool between = true;

            if ((a > 10 && a < 20) || (b > 10 && b < 20))
            {
                return between;
            }
            return false;
        }

        public bool HasTeen(int a, int b, int c)
        {
            bool teen = true;

            if ((a >= 13 && a <= 19) || (b >= 13 && b <= 19) || (c >= 13 && c <= 19))
            {
                return teen;
            }
            return false;
        }

        public bool SoAlone(int a, int b)
        {
            bool soAlone = true;
            bool notAlone = false;

            if ((a >= 13 && a <= 19) && (b >= 13 && b <= 19))
            {
                return notAlone;
            }
            else if ((a >= 13 && a <= 19) || (b >= 13 && b <= 19))
            {
                return soAlone;
            }
            return false;
        }

        public string RemoveDel(string str)
        {
            if (str.Contains("del"))
            {
                string removeDel = str.Remove(1, 3);
                return removeDel;
            }
            return str;
        }

        public bool IxStart(string str)
        {
            //bool isLetter = true;
            //string letters = 

            //if (str.Contains("\w"+"ix"))
            //{
            //    return isLetter;
            //}
            //return false;

            throw new NotImplementedException();

        }

        public string StartOz(string str)
        {
            throw new NotImplementedException();
        }

        public int Max(int a, int b, int c)
        {
            throw new NotImplementedException();
        }

        public int Closer(int a, int b)
        {
            throw new NotImplementedException();
        }

        public bool GotE(string str)
        {
            throw new NotImplementedException();
        }

        public string EndUp(string str)
        {
            throw new NotImplementedException();
        }

        public string EveryNth(string str, int n)
        {
            throw new NotImplementedException();
        }
    }
}
