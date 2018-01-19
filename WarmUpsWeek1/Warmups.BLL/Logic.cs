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
            //throw new NotImplementedException();
        }
        
        public int SkipSum(int a, int b)
        {
            throw new NotImplementedException();
        }
        
        public string AlarmClock(int day, bool vacation)
        {
            throw new NotImplementedException();
        }
        
        public bool LoveSix(int a, int b)
        {
            throw new NotImplementedException();
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            throw new NotImplementedException();
        }
        
        public bool SpecialEleven(int n)
        {
            throw new NotImplementedException();
        }
        
        public bool Mod20(int n)
        {
            throw new NotImplementedException();
        }
        
        public bool Mod35(int n)
        {
            throw new NotImplementedException();
        }
        
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            throw new NotImplementedException();
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {
            throw new NotImplementedException();
        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            throw new NotImplementedException();
        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            throw new NotImplementedException();
        }
        
        public bool LastDigit(int a, int b, int c)
        {
            throw new NotImplementedException();
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            throw new NotImplementedException();
        }

    }
}
