using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.PerfectNumber
{
    public class PerfectNumberService : IPerfectNumberService
    {
        public bool IsPerfectNumber(int number)
        {
            if (number <= 0)
                return false;

            int sum = 0;

            for (int i = 1; i < number; i++)
            {
                if (number % i == 0) // is divisor
                {
                    sum += i;
                }
            }

            if (sum == number)
                return true;
            return false;
        }

        public List<int> FindPerfectNumbers(int start, int end)
        {
            List<int> perfectNumbers = new List<int>();

            for (int i = start; i <= end; i++)
            {
                if (IsPerfectNumber(i))
                    perfectNumbers.Add(i);              
            }

            return perfectNumbers;
        }
    }
}