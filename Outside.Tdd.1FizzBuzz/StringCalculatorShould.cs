using Shouldly;
using Xunit;

namespace Outside.Tdd._1FizzBuzz
{
    public class StringCalculatorShould
    {
        private readonly StringCalculator _stringCalculator;

        public StringCalculatorShould()
        {
            _stringCalculator = new StringCalculator();
        }

        [Fact]
        public void DefaultToZeroOnEmptyString()
        {
            var result = _stringCalculator.Calculate("");
            result.ShouldBe(0);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("155", 155)]
        [InlineData("9", 9)]
        public void ReturnNumberIfOneArgument(string input, int expected)
        {
            var result = _stringCalculator.Calculate(input);
            result.ShouldBe(expected);
        }

        [Theory]
        [InlineData("1,1", 2)]
        [InlineData("10,1", 11)]
        [InlineData("99,11", 110)]
        public void SumNumbersSeparatedByComma(string input, int expected)
        {
            var result = _stringCalculator.Calculate(input);
            result.ShouldBe(expected);
        }
    }


    public class StringCalculator
    {
        public int Calculate(string input)
        {
            if (input == string.Empty)
                return 0;

            var splittedInput = input.Split(',');
            if (splittedInput.Length == 1)
                return int.Parse(input);

            return int.Parse(splittedInput[0]) + int.Parse(splittedInput[1]);
        }
    }
}
