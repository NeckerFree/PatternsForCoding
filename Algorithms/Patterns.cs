using System.Drawing;
using System.Security.Cryptography;

namespace Algorithms
{
    public class Patterns
    {
    //    procedure three-way-partition(A : array of values, mid : value) :
    //i ← 0
    //j ← 0
    //k ← size of A - 1

    //while j <= k:
    //    if A[j] < mid:
    //        swap A[i] and A[j]
    //        i ← i + 1
    //        j ← j + 1
    //    else if A[j] > mid:
    //        swap A[j] and A[k]
    //        k ← k - 1
    //    else:
    //        j ← j + 1

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
    }
}