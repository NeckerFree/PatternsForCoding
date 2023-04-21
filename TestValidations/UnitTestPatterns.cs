using Algorithms;

namespace TestValidations
{
    public class UnitTestPatterns
    {
        [Theory]
        [InlineData(new int[] {1, 2, 3, 4, 6},6, new int[] { 1, 3 } )]
        [InlineData(new int[] { 2, 5, 9, 11 }, 11, new int[] { 0,2 })]
        public void ValidateTwoPointers(int[] input,int target, int[] expected)
        {
           int[] actual= Patterns.TargetSum(input, target);
            Assert.Equal(expected, actual);
        }
    }
}