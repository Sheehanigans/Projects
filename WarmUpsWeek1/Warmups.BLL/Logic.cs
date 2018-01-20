using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        public bool GreatParty(int cigars, bool isWeekend)
        {
            bool greatParty = false;

            if (!isWeekend && cigars >= 40 && cigars <= 60)
            {
                greatParty = true; 
            }
            else if (isWeekend && cigars >= 40)
            {
                greatParty = true;
            }
            return greatParty; 
        }
        
        public int CanHazTable(int yourStyle, int dateStyle)
        {
            int canHazTable = 1;

            if (yourStyle >= 8 || dateStyle >= 8)
            {
                canHazTable = 2;
            }
            else if (yourStyle <= 2 || dateStyle <= 2)
            {
                canHazTable = 0;
            }
            return canHazTable;
        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            bool playOutside = false;

            if (isSummer && temp >= 60 && temp <= 100)
            {
                playOutside = true;
            }
            else if (!isSummer && temp >= 60 && temp <= 90)
            {
                playOutside = true;
            }
            return playOutside;
        }
        
        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            int speeding = 0;

            if ((!isBirthday || isBirthday) && speed <= 60)
            {
                speeding = 0;
            }
            else if (isBirthday && speed < 66)
            {
                speeding = 0;
            }
            else if ((!isBirthday && speed >= 60 && speed <= 80) 
                || (isBirthday && speed >= 65 && speed <= 85))
            {
                speeding = 1;
            }
            else if (!isBirthday && speed < 80)
            {
                speeding = 2;
            }
            return speeding; 
        }
        
        public int SkipSum(int a, int b)
        {
            int skipSum = 0;

            int sum = a + b;

            if (sum > 9 && sum < 20)
            {
                skipSum = 20; 
            }
            else if (sum < 10 || sum > 19)
            {
                skipSum = sum;
            }
            return skipSum;
        }
        
        public string AlarmClock(int day, bool vacation)
        {
            string alarmClock = "";

            if (!vacation && day >= 1 && day <= 5)
            {
                alarmClock = "7:00";
            }
            else if (!vacation && (day < 1 || day > 5))
            {
                alarmClock = "10:00";
            }
            return alarmClock;
        }
        
        public bool LoveSix(int a, int b)
        {
            bool loveSix = false;

            int sum = a + b;

            if (a == 6 || b == 6)
            {
                loveSix = true;
            }
            else if (sum == 6)
            {
                loveSix = true;
            }
            return loveSix;
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            bool inRange = false;

            if (!outsideMode && (n >= 1 && n <= 10))
            {
                inRange = true;
            }
            else if (outsideMode && (n <= 1 || n > 10))
            {
                inRange = true;
            }
            return inRange;
        }
        
        public bool SpecialEleven(int n)
        {
            bool specialEleven = false;

            if (n % 11 == 1)
            {
                specialEleven = true;
            } 
            else if (n % 11 == 0)
            {
                specialEleven = true;
            }
            return specialEleven;
        }
        
        public bool Mod20(int n)
        {
            bool mod20 = false;

            if (n % 20 == 1 || n % 20 == 2)
            {
                mod20 = true;
            }
            return mod20;
        }
        
        public bool Mod35(int n)
        {
            bool mod35 = false;

            bool three = n % 3 == 0;
            bool five = n % 5 == 0;

            if (three && five)
            {
                mod35 = false;
            }
            else if (three || five)
            {
                mod35 = true;
            }
            return mod35;
        }
        
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            bool answerCell = true;

            if (isAsleep)
            {
                answerCell = false;
            }
            else if (isMorning && isMom)
            {
                answerCell = true;
            }
            else if (isMorning)
            {
                answerCell = false;
            }
            return answerCell;
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {
            bool twoIsOne = false;

            if (a + b == c)
            {
                twoIsOne = true;
            }
            else if (b + c == a)
            {
                twoIsOne = true;
            } 
            else if (c + a == b)
            {
                twoIsOne = true;
            }
            return twoIsOne;
        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            bool areInOrder = false;

            if (b > a && c > b)
            {
                areInOrder = true;
            }
            else if (bOk && c > b)
            {
                areInOrder = true;
            }
            return areInOrder;
        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            bool inOrderEqual = false; 

            if (!equalOk && a < b && b < c)
            {
                inOrderEqual = true; 
            }
            else if (equalOk && (a == b || b == c))
            {
                inOrderEqual = true;
            }
            return inOrderEqual;
        }
        
        public bool LastDigit(int a, int b, int c)
        {
            bool lastDigit = false;
            
            if ((a % 10 == b % 10) || (b % 10 == c % 10) || (a % 10 == c % 10))
            {
                lastDigit = true;
            }
            return lastDigit;
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            int rollDice = 0;

            if (noDoubles && die1 == die2)
            {
                die1 += 1;
            }

            int rolls = die1 + die2;
            rollDice = rolls;

            return rollDice;
        }

    }
}
