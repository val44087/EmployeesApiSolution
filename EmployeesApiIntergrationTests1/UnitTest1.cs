using System;
using Xunit;

namespace EmployeesApiIntergrationTests1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int a = 10, b = 21;
            int answer = a + b;

            Assert.Equal(31, answer);
        }

        [Theory]
        [InlineData(2,2,4)]
        [InlineData(2, 3, 5)]
        [InlineData(10, -5, 5)]
        public void IKnowHowToAdd(int a, int b, int expected)
        {
            
            int answer = a + b;

            Assert.Equal(expected, answer);
        }
    }
}
