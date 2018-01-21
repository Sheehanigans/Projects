using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            return "Hello " + name + "!";
        }

        public string Abba(string a, string b)
        {
            string abba = a + b + b + a;

            return abba;
        }

        public string MakeTags(string tag, string content)
        {
            string tags = "<" + tag + ">" + content + "</"+ tag + ">";

            return tags;
        }

        public string InsertWord(string container, string word)
        {

            string front = container.Substring(0, 2);
            string back = container.Substring(2, 2);

            string inWord = front + word + back;
            return inWord;
        }

        public string MultipleEndings(string str)
        {
            string last2 = str.Substring(str.Length - 2, 2);

            string ending = last2 + last2 + last2;

            return ending;
        }

        public string FirstHalf(string str)
        {
            string half = str.Substring(0, str.Length / 2);

            string firstHalf = half;

            return firstHalf;
        }

        public string TrimOne(string str)
        {
            string middle = str.Substring(1, str.Length - 2);

            return middle;
        }

        public string LongInMiddle(string a, string b)
        {
            string longInMid = "";

            if (a.Length > b.Length)
            {
                longInMid = b + a + b;
            }
            else if (a.Length < b.Length)
            {
                longInMid = a + b + a;
            }
            return longInMid;
        }

        public string RotateLeft2(string str)
        {
            string rotate = "";

            if (str.Length <= 2)
            {
                rotate = str;
            }
            else
            {
                string first2 = str.Substring(0, 2);
                string theRest = str.Substring(2, str.Length - 2);
                rotate = theRest + first2;
            }
            return rotate;
        }

        public string RotateRight2(string str)
        {
            string rotate = "";

            if (str.Length <= 2)
            {
                rotate = str;
            }
            else
            {
                string first = str.Substring(0, str.Length - 2);
                string theRest = str.Substring(str.Length - 2, 2);
                rotate = theRest  + first;
            }
            return rotate; 
        }

        public string TakeOne(string str, bool fromFront)
        {
            string take1 = "";

            if (fromFront == false)
            {
                string back = str.Substring(str.Length - 1, 1);
                take1 = back;
            }
            else
            {
                string front = str.Substring(0, 1);
                take1 = front;
            }

            return take1;
        }

        public string MiddleTwo(string str)
        {
            int midNum = str.Length / 2;

            string midTwo = str.Substring(midNum - 1, 2);

            return midTwo;
        }

        public bool EndsWithLy(string str)
        {
            bool endsLy = false;

            if (str.Length < 2)
            {
                return endsLy;
            }

            string ly = str.Substring(str.Length - 2, 2);

            if (ly.Contains("ly"))
            {
                endsLy = true;
            }
            return endsLy;
        }

        public string FrontAndBack(string str, int n)
        {
            string fab = "";

            string front = str.Substring(0, n);
            string back = str.Substring(str.Length - n, n);

            fab = front + back;

            return fab;
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            if (n > str.Length - 2)
            {
                string twoPlus = str.Substring(0, 2);
                return twoPlus;
            }

            string two = str.Substring(n, 2);
            return two;
        }

        public bool HasBad(string str)
        {
            bool hasBad = false;


            if (str == "")
            {
                return false;
            }

            string bad0 = str.Substring(0, 3);
            string bad1 = str.Substring(1, 3);

            if (str.Length <= 3)
            {
                hasBad = false;
            }
            else if (bad0 == "bad")
            {
                hasBad = true;
            }
            else if (bad1 =="bad")
            {
                hasBad = true;
            }
            return hasBad;
        }

        public string AtFirst(string str)
        {
            string atFirst;

            if (str.Length == 0)
            {
                atFirst = "@@";
            }
            else if (str.Length == 1)
            {
                string oneChar = str.Substring(0, 1);
                atFirst = oneChar + "@";
            }
            else
            {
                string twoChar = str.Substring(0, 2);
                atFirst = twoChar;
            }
            return atFirst;
        }

        public string LastChars(string a, string b)
        {
            string lastChars;

            if (a == "" && b == "")
            {
                lastChars = "@@";
            }
            else if (a == "")
            {
                string beta = b.Substring(b.Length - 1, 1);
                lastChars = "@" + beta;
            }
            else if (b == "")
            {
                string alpha = a.Substring(0, 1);
                lastChars = alpha + "@";
            }
            else
            {
                string alpha = a.Substring(0, 1);
                string beta = b.Substring(b.Length - 1, 1);
                lastChars = alpha + beta;
            }
            return lastChars;
        }

        public string ConCat(string a, string b)
        {
            string cat;

            if (a == "" || b == "")
            {
                cat = a + b;
            }
            else if (a.Substring(a.Length - 1 ,1) == b.Substring(0, 1))
            {
                cat = a + b.Substring(1, b.Length - 1);
            }
            else
            {
                string coolCat = a + b;
                cat = coolCat;
            }
            return cat;
        }

        public string SwapLast(string str)
        {
            string swap;

            if (str.Length <= 1)
            {
                swap = str;
            }
            else if (str.Length == 2)
            {
                string last = str.Substring(str.Length - 2, 2);
                string lastA = last.Substring(last.Length - 2, 1);
                string lastB = last.Substring(last.Length - 1, 1);

                swap = lastB + lastA;
            } 
            else
            {
                string last = str.Substring(str.Length - 2, 2);
                string front = str.Substring(0, str.Length - 2);
                string lastA = last.Substring(last.Length - 2, 1);
                string lastB = last.Substring(last.Length - 1, 1);

                swap = front + lastB + lastA;
            }
            return swap;
        }

        public bool FrontAgain(string str)
        {
            bool again = false;

            string front = str.Substring(0, 2);
            string back = str.Substring(str.Length - 2, 2);

            if (front == back)
            {
                again = true;
            }
            return again;
        }

        public string MinCat(string a, string b)
        {
            string cat = "";

            if (a == "" || b == "")
            {
                cat = "";
            }
            else if (a.Length > b.Length)
            {
                string trimA = a.Remove(0, a.Length - b.Length);
                cat = trimA + b;
            }
            else if (b.Length > a.Length)
            {
                string trimB = b.Remove(0, b.Length - a.Length);
                cat = a + trimB;
            }
            return cat;
        }

        public string TweakFront(string str)
        {
            throw new NotImplementedException();
        }

        public string StripX(string str)
        {
            throw new NotImplementedException();
        }
    }
}
