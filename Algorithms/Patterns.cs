using System.ComponentModel;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace Algorithms
{
    public class Patterns
    {
        public static int CountIslandsDFS(int[,] matrix)
        {
            int total = matrix.Length;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            bool[,] visited = new bool[rows, cols];
            int totalIslands = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 1 && visited[i, j] == false)
                    {
                        totalIslands++;
                        DFS(matrix, i, j, visited);
                    }
                }
            }
            return totalIslands;
        }

        private static void DFS(int[,] matrix, int i, int j, bool[,] visited)
        {
            int[] rowNbr = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] colNbr = { -1, 0, 1, -1, 1, -1, 0, 1 };
            visited[i, j] = true;
            for (int k = 0; k < 8; k++)
            {
                if (IsSafe(matrix, i + rowNbr[k], j + colNbr[k], visited) == true)
                {
                    DFS(matrix, i + rowNbr[k], j + colNbr[k], visited);
                }
            }
        }

        private static bool IsSafe(int[,] matrix, int row, int col, bool[,] visited)
        {
            return (row >= 0 && col >= 0 &&
                 row < matrix.GetLength(0) &&
                 col < matrix.GetLength(1) &&
                 matrix[row, col] == 1 &&
                 visited[row, col] == false);
        }

        public static int[] DutchFlag(int[] input)
        {
            //i ≤ j ≤ k.
            int i = 0;
            int j = 0;
            int k = input.Length - 1;
            while (j <= k)
            {

                if (input[j] < 1)
                {
                    (input[i], input[j]) = (input[j], input[i]);
                    i++;
                    j++;
                }
                else
                {
                    if (input[j] > 1)
                    {
                        (input[k], input[j]) = (input[j], input[k]);
                        k--;
                    }
                    else j++;
                }
            }
            return input;
        }

        public static int[] TargetSum(int[] input, int target)
        {
            int pointer1 = 0;
            int pointer2 = input.Length - 1;
            while (pointer1 < pointer2)
            {
                int sum = input[pointer1] + input[pointer2];
                if (sum == target) return new int[] { pointer1, pointer2 };
                if (sum < target) pointer1++;
                else pointer2--;
            }
            return new int[] { -1, -1 };
        }

        public static int TripletSum(int[] input, int target)
        {
            int n = input.Length;
            int count = 0;
            Array.Sort(input);
            for (int i = 0; i < n - 2; i++)
            {
                int left = i + 1;
                int right = n - 1;
                while (left < right)
                {
                    int sum = input[i] + input[left] + input[right];
                    if (sum >= target)
                    {
                        right--;
                    }
                    else
                    {
                        count = count + (right - left);
                        left++;
                    }
                }
            }
            return count;

        }

        public static int[][] MergeIntervals(int[][] intervals)
        {
            //{ 1, 4 },  { 2, 6 }, { 3, 5 }
            List<int[]> result = new List<int[]>();
            //Sort all intervals in increasing order of start time.
            Array.Sort(intervals, JaggedComparer());
            //Traverse sorted intervals starting from the first interval, 
            //Do the following for every interval.

            int[] previous = intervals[0];
            bool overlaps = false;
            for (int i = 1; i < intervals.Length; i++)
            {
                //If the current interval is not the first interval and it overlaps with the previous interval,
                int[] current = intervals[i];
                overlaps = current[0] <= previous[1];

                if (overlaps)
                {
                    //then merge it with the previous interval.Keep doing it while the interval overlaps with the previous one.         
                    previous = new int[] { previous[0], Math.Max(previous[1], current[1]) };
                    if (i == intervals.Length - 1)
                    {
                        result.Add(previous);
                    }
                }
                else
                {
                    //Otherwise, Add the current interval to the output list of intervals.

                    result.Add(previous);
                    previous = current;
                }
            }
            if (overlaps == false)
            {
                result.Add(previous);
            }
            return result.ToArray();
        }

        private static Comparison<int[]> JaggedComparer()
        {
            return new Comparison<int[]>((x, y) =>
            {
                return x[0] < y[0] ? -1 : (x[0] > y[0] ? 1 : 0);
            });
        }

        //public static int FindMissingNumber(int[] numbers)
        //{
        //    int count = 0;
        //    int missingValue = -1;
        //    while (count < numbers.Length)
        //    {
        //        int current = numbers[count];
        //        if (current < numbers.Length && current != count)
        //        {
        //            (numbers[count], numbers[current]) = (numbers[current], numbers[count]);
        //        }
        //        else
        //        {
        //            count++;
        //        }
        //    }
        //    count = 0;
        //    while (missingValue == -1)
        //    {
        //        if (count != numbers[count])
        //        {
        //            missingValue = count;
        //            break;
        //        }
        //        count++;
        //    }
        //    return missingValue;
        //}

        public static int FindMissingNumber(int[] numbers)
        {
            int count = 0;
            int arraylength = numbers.Length;
            int missingValue = arraylength;
            int current = -1;
            while (count < arraylength)
            {
                current = numbers[count];
                if (current < arraylength && current != count)
                {
                    (numbers[count], numbers[current]) = (numbers[current], numbers[count]);
                }
                else
                {
                    count++;
                }

            }
            count = 0;
            while (count < numbers.Length)
            {
                if (count != numbers[count])
                {
                    missingValue = count;
                    break;
                }
                count++;
            }
            return missingValue;
        }
    }
}
