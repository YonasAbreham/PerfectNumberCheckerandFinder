using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.PerfectNumber
{
    public class PerfectNumberService : IPerfectNumberService
    {

        public bool IsPerfectNumber(long number)
        {
            long sum = 0;

            if (number <= 0)
                return false;
            List<long> factors = Factor(number);//Find the factor of the given number           

            for (int i = 0; i < factors.Count - 1; i++)
                sum += factors[i];

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


        public bool IsPerfectNumberByPrimes(long number)
        {
            if (number <= 0)
                return false;

            int p = 1;

            while (true)
            {
                if (!IsPrime(p))
                {
                    p++;
                    continue;
                }

                int f1 = (int)Math.Pow(2, p - 1); //2^(p−1)
                int f2 = (int)Math.Pow(2, p) - 1; //2^p − 1

                if (!IsPrime(f2)) //  Mersenne prime?
                {
                    p++;
                    continue;
                }

                int nextPerfectNo = f1 * f2;

                if (number == nextPerfectNo)
                    return true;
                else if (number < nextPerfectNo)
                    return false;
                else
                {
                    // keep searching
                    p++;

                    // Or stop at some max p
                    //if (p > 20)
                    //    throw new Exception("Number too big")
                }
            }
        }

        public bool IsPrime(long number)
        {
            if (number < 2) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            List<long> y = new List<long>();

            var boundary = (long)Math.Floor(Math.Sqrt(number));

            // The numbers in beteween 2 till half of the value half of that number  then that means it's prime number
            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        private List<long> Factor(long number)
        {
            var factors = new List<long>();
            var max = Math.Sqrt(number);  // (store in double not an int) - Round down
            if (max % 1 == 0)
                factors.Add((long)max);

            for (int factor = 1; factor < max; ++factor)
            {
                if (number % factor == 0)
                {
                    factors.Add(factor);

                    factors.Add(number / factor);
                }
            }
            factors.Sort();

            return factors;
        }


    }
}