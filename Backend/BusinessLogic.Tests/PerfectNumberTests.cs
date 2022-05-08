using BusinessLogic.PerfectNumber;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace BusinessLogic.Tests
{
    public class PerfectNumberTests
    {

        PerfectNumberService pnService = new PerfectNumberService();

        [Fact]
        public void PerfectNoLogicTest()
        {
            List<int> numbers = new List<int> { 6, 28, 496, 8128 };
            numbers.ForEach(n =>
            {
                var result = pnService.IsPerfectNumber(n);
                Assert.True(result);
            });

            numbers.ForEach(n =>
            {
                var result = pnService.IsPerfectNumberByPrimes(n);
                Assert.True(result);
            });
        }

        [Fact]
        public void PerfectNoLogic_FailsForNonPositiveNumbers()
        {
            Assert.False(pnService.IsPerfectNumber(0));
            Assert.False(pnService.IsPerfectNumber(-1));
        }

        [Fact]
        public void PerfectNoFinderTest()
        {
            List<int> numbers = new List<int>();
            int start = 1, end = 30;

            var result = pnService.FindPerfectNumbers(start, end);
            result.Sort();

            Assert.Equal(2, result.Count);
            Assert.Equal(6, result[0]);
            Assert.Equal(28, result[1]);
        }

        [Fact]
        public void PerfectNoFinder_ReturnsEmptyWhenPerfectNumbersDontExist()
        {
            var result = pnService.FindPerfectNumbers(1, 5);
            Assert.Empty(result);

            result = pnService.FindPerfectNumbers(500, 700);
            Assert.Empty(result);
        }

        [Fact]
        public void Performance_Tests()
        {
            int number = 33550336;
            int loop = 100000;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < loop; i++)
            {
                pnService.IsPerfectNumber(number);
            }
            sw.Stop();
            var elapsed1 = sw.ElapsedMilliseconds;

            sw.Start();
            for (int i = 0; i < loop; i++)
            {
                ((IPerfectNumberService)pnService).IsPerfectNumberByPrimes(number);
            }
            sw.Stop();
            var elapsed2 = sw.ElapsedMilliseconds;

        }
    }
}
