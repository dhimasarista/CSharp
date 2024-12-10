public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return [i, j];
                }
            }
        }
        return Array.Empty<int>();
    }
    public bool IsValid(string s)
    {
        string[] brackets = { "()", "[]", "{}" };
        char[] split = s.ToCharArray();
        for (int j = 0; j < split.Length - 1; j++)
        {
            string value = $"{split[j]}{split[j + 1]}";
            for (int i = 0; i < brackets.Length; i++)
            {
                if (value == brackets[i])
                {
                    s = s.Remove(j, 2);
                    split = s.ToCharArray();
                    j = -1;
                    break;
                }
            }
        }
        return s.Length == 0;
    }
}