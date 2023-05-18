using Algorithms;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        [Fact]
        //[MemberData(nameof(GetGoatExperienceMemberData))]
        //[InlineData()]
        public void ValidateCountIslandsDFS()
        {
            int[,] input = new int[5, 5] {
                { 0, 1, 1, 1, 0 },
                { 0, 0, 0, 1, 1 },
                { 0, 1, 1, 1, 0 },
                { 0, 1, 1, 0, 0 },
                { 0, 0, 0, 0, 0 }
                };
            int actual = Patterns.CountIslandsDFS(input);
            Assert.Equal(1, actual);
        }

        [Fact]
        public void ValidateCountIslandsDFS2()
        {
            int[,] input = new int[5, 5] {
                { 1, 1, 0, 0, 0 },
                { 0, 1, 0, 0, 1 },
                { 1, 0, 0, 1, 1 },
                { 0, 0, 0, 0, 0 },
                { 1, 0, 1, 0, 1 }
                };
            int actual = Patterns.CountIslandsDFS(input);
            Assert.Equal(1, actual);
        }

        [Fact]
        public void TestValidateMergeIntervals1()
        {
            int[][] intervals = { new int[] { 1, 4 }, new int[] { 2, 5 }, new int[] { 7, 9 } };
            int[][] expected = { new int[] { 1, 5 }, new int[] { 7, 9 } };
            int[][] actual = Patterns.MergeIntervals(intervals);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestValidateMergeIntervals2()
        {
            int[][] intervals = { new int[] { 6, 7 }, new int[] { 2, 4 }, new int[] { 5, 9 } };
            int[][] expected = { new int[] { 2, 4 }, new int[] { 5, 9 } };
            int[][] actual = Patterns.MergeIntervals(intervals);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestValidateMergeIntervals3()
        {
            int[][] intervals = { new int[] { 1, 4 }, new int[] { 2, 6 }, new int[] { 3, 5 } };
            int[][] expected = { new int[] { 1, 6 } };

            int[][] actual = Patterns.MergeIntervals(intervals);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 4, 0, 3, 1 }, 2)]
        [InlineData(new int[] { 8, 3, 5, 2, 4, 6, 0, 1 }, 7)]
        public void FindMissingNumberCyclicSort(int[] numbers, int expected)
        {
            int actual = Patterns.FindMissingNumber(numbers);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindMissingNumber()
        {
            int[] numbers = { 3, 0, 1 };
            int actual = Patterns.FindMissingNumber(numbers);
            Assert.Equal(2, actual);
        }

    }
}