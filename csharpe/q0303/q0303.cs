public class NumArray {
    
    private int[] dict;

    public NumArray(int[] nums) {
            dict = new int[nums.Length];

            var sum = 0;

            for(int x = 0; x < nums.Length; x++)
            {
                sum = sum + nums[x];
                dict[x] = sum;
            }        
    }
    
    public int SumRange(int left, int right) {
            if (left == 0)
                return dict[right];
            else
                return dict[right] - dict[left - 1];        
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(left,right);
 */