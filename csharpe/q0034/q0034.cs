public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        int[] result = new int[2]{ -1, -1 };
        int index = Array.BinarySearch(nums, target);
        if (index < 0)
            return result;
        int current = index;

        while(current>=1 && nums[current-1]==target)
        {
            current--;
        }
        result[0]=current;

        current = index;
        while(current<(nums.Length-1) && nums[current+1]==target)
        {
            current++;
        }
        result[1]=current;

        return result;

    }
}