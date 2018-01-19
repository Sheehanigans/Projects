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
            int Diff21;

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

            //if (a > 0 || b > 0)
            //{
            //    return isPosNeg;
            //}
            //else if (a > 0 && b > 0)
            //{
            //    return negative = true;
            //}
            //return false;

        }

        public string NotString(string s)
        {
            throw new NotImplementedException();
        }

        public string MissingChar(string str, int n)
        {
            throw new NotImplementedException();
        }

        public string FrontBack(string str)
        {
            throw new NotImplementedException();
        }

        public string Front3(string str)
        {
            throw new NotImplementedException();
        }

        public string BackAround(string str)
        {
            throw new NotImplementedException();
        }

        public bool Multiple3or5(int number)
        {
            throw new NotImplementedException();
        }

        public bool StartHi(string str)
        {
            throw new NotImplementedException();
        }

        public bool IcyHot(int temp1, int temp2)
        {
            throw new NotImplementedException();
        }

        public bool Between10and20(int a, int b)
        {
            throw new NotImplementedException();
        }

        public bool HasTeen(int a, int b, int c)
        {
            throw new NotImplementedException();
        }

        public bool SoAlone(int a, int b)
        {
            throw new NotImplementedException();
        }

        public string RemoveDel(string str)
        {
            throw new NotImplementedException();
        }

        public bool IxStart(string str)
        {
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
