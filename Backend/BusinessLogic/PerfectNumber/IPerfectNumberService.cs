using System.Collections.Generic;

namespace BusinessLogic.PerfectNumber
{
    public interface IPerfectNumberService
    {
        List<int> FindPerfectNumbers(int start, int end);
        bool IsPerfectNumber(long number);
        bool IsPerfectNumberByPrimes(long number);
        bool IsPrime(long number);
    }
}