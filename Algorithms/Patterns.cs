namespace Algorithms
{
    public class Patterns
    {
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