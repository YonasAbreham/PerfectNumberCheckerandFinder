using System.Collections.Generic;

namespace BusinessLogic.PerfectNumber
{
    public interface IPerfectNumberService
    {
        List<int> FindPerfectNumbers(int start, int end);
        bool IsPerfectNumber(int number);
    }
}