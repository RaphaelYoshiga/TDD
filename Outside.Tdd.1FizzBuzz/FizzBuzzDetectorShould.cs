using System;
using Shouldly;
using Xunit;

namespace Outside.Tdd._1FizzBuzz
{
    public class FizzBuzzDetectorShould
    {
        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(4, "4")]
        public void PrintNumbers(int number, string expectedResult)
        {
            var result = FizzBuzzDetector.IdentifyFizzBuzz(number);
            result.ShouldBe(expectedResult);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        public void PrintFizzForMultiplesOfThree(int number)
        {
            var result = FizzBuzzDetector.IdentifyFizzBuzz(number);
            result.ShouldBe("Fizz");
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public void PrintBuzzForMultiplesOfFive(int number)
        {
            var result = FizzBuzzDetector.IdentifyFizzBuzz(number);
            result.ShouldBe("Buzz");
        }

        [Theory]
        [InlineData(15)]
        [InlineData(45)]
        [InlineData(90)]
        public void PrintFizzBuzzForMultiplesOfThreeAndFive(int number)
        {
            var result = FizzBuzzDetector.IdentifyFizzBuzz(number);
            result.ShouldBe("FizzBuzz");
        }
    }

    public class FizzBuzzDetector
    {
        public static string IdentifyFizzBuzz(int i)
        {
            if (i % 15 == 0)
                return "FizzBuzz";

            if (i % 5 == 0)
                return "Buzz";

            return i % 3 == 0 ? "Fizz" : i.ToString();
        }
    }
}
