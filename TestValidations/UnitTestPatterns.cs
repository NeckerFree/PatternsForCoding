using Algorithms;

namespace TestValidations
{
    public class UnitTestPatterns
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 6 }, 6, new int[] { 1, 3 })]
        [InlineData(new int[] { 2, 5, 9, 11 }, 11, new int[] { 0, 2 })]
        public void ValidateTwoPointers(int[] input, int target, int[] expected)
        {
            int[] actual = Patterns.TargetSum(input, target);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 0, 2, 1, 0 }, new int[] { 0, 0, 1, 1, 2 })]
        [InlineData(new int[] { 2, 2, 0, 1, 2, 0 }, new int[] { 0, 0, 1, 2, 2, 2 })]
        [InlineData(new int[] { 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2 })]
        [InlineData(new int[] { 1, 2, 2, 2, 1, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2 })]
        public void ValidateDutchFlagChallenge(int[] input, int[] expected)
        {
            int[] actual = Patterns.DutchFlag(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { -1, 0, 2, 3 }, 3, 2)]
        [InlineData(new int[] { -1, 4, 2, 1, 3 }, 5, 4)]
        [InlineData(new int[] { 5, 1, 3, 4, 7 }, 12, 4)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 50, 4)]
        public void ValidateSumTriplet(int[] input, int target, int output)
        {
            int actual = Patterns.TripletSum(input, target);
            Assert.Equal(output, actual);
        }
    }

}