using System;
using Shouldly;
using Xunit;

namespace Outside.Tdd._1FizzBuzz
{
    public class FizzBuzzDetectorShould
    {
        [Fact]
        public void PrintOne()
        {
            var result = FizzBuzzDetector.IdentifyFizzBuzz(1);
            result.ShouldBe("1");
        }

        [Fact]
        public void PrintTwo()
        {
            var result = FizzBuzzDetector.IdentifyFizzBuzz(2);
            result.ShouldBe("2");
        }

        [Fact]
        public void PrintFour()
        {
            var result = FizzBuzzDetector.IdentifyFizzBuzz(4);
            result.ShouldBe("4");
        }
    }

    public class FizzBuzzDetector
    {
        public static string IdentifyFizzBuzz(int i)
        {
            return i.ToString();
        }
    }
}
