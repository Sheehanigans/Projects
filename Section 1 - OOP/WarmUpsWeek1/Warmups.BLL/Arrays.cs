using System;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {
            bool firstLast = false;

            if (numbers[0] == 6 || numbers[numbers.Length - 1] == 6)
            {
                firstLast = true;
            }
            return firstLast;
        }

        public bool SameFirstLast(int[] numbers)
        {
            bool same = false;

            if (numbers.Length >= 1 
                && numbers[0] == numbers[numbers.Length - 1])  
            {
                same = true;
            }
            return same;
        }
        public int[] MakePi(int n)
        {
            double pi = Math.PI;
            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = (int) Math.Floor(pi);
                pi -= result[i];
                pi *= 10;
            }
            return result;
        }
        
        public bool CommonEnd(int[] a, int[] b)
        {
            bool common = false;

            if (a[0] == b[0] 
                || a[a.Length - 1] == b[b.Length -1])
            {
                common = true;
            }
            return common;
        }

        public int Sum(int[] numbers)
        {
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }
        
        public int[] RotateLeft(int[] numbers)
        {
            int[] rotate = { numbers[1], numbers[2], numbers[0] };

            return rotate;
        }

        public int[] Reverse(int[] numbers)
        {
            int[] reversedArray = new int[numbers.Length];
            int j = numbers.Length;
            for (int i = 0; i < numbers.Length; i++)
            {
                j--;
                reversedArray[i] = numbers[j];
            }

            return reversedArray;
        }
        
        public int[] HigherWins(int[] numbers)
        {
            int[] max = new int[3];
            max[0] = numbers[0];
            if (numbers[2] >= max[0])
            {
                max[0] = numbers[2];
            }
            max[1] = max[0];
            max[2] = max[0];
            return max;
        }
        
        public int[] GetMiddle(int[] a, int[] b)
        {
            int[] mid = new int[2];

            mid[0] = a[1];
            mid[1] = b[1];

            return mid;
        }
        
        public bool HasEven(int[] numbers)
        {
            bool even = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    even = true;
                }
            }
            return even;
        }
        
        public int[] KeepLast(int[] numbers)
        {
            int last = numbers[numbers.Length - 1];

            int[] zeros = new int[numbers.Length * 2];

            zeros[zeros.Length - 1] = last;

            return zeros;
        }
        
        public bool Double23(int[] numbers)
        {
            bool dubs = false;

            int two = 0;
            int three = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 2)
                {
                    two++;
                }
                else if (numbers[i] == 3)
                {
                    three++;
                }
            }

            if (two == 2)
            {
                dubs = true;
            }
            else if (three == 2)
            {
                dubs = true;
            }

            return dubs;

        }
        
        public int[] Fix23(int[] numbers)
        {
            int[] fix = { numbers[0], numbers[1], numbers[2] };

            if (numbers[0] == 2 && numbers[1] == 3)
            {
                fix[1] = 0;
            }
            else if (numbers[1] == 2 && numbers[2] == 3)
            {
                fix[2] = 0;
            }

            return fix;
        }
        
        public bool Unlucky1(int[] numbers)
        {
            bool unlucky = false;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == 1 && numbers[i + 1] == 3)
                {
                    unlucky = true;
                }
            }
            return unlucky;
        }
        
        public int[] Make2(int[] a, int[] b)
        {
            int[] make = new int[2];

            if (a.Length == 0)
            {
                make[0] = b[0];
                make[1] = b[1];
            }
            else if (a.Length == 1)
            {
                make[0] = a[0];
                make[1] = b[0];
            }
            else if (a.Length == 2)
            {
                make[0] = a[0];
                make[1] = a[1];
            }

            return make;
        }

    }
}
