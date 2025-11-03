public class Solution {
    public int[] data;    
    
    public bool Search(int[] nums, int target)
    {
        data = nums;
        return Search2(0, nums.Length - 1, target);
    }

    private bool Search2(int left, int right, int target)
    {
        if (left > right)
            return false;

        if (left == right)
            return data[left] == target;   
        
        if((right - left)<2)
            return data[left]==target || data[right]==target;
            
        int middle = left + (right - left) / 2;
        int temp = data[middle];    
        if (temp == target)
                return true;
            
        if(data[left]==data[right])
        {
            return Search2(left, middle, target) || Search2(middle + 1, right, target);
        }

        if(data[left]<data[right])//no rotation
        {
            if (target > temp)
                return Search2(middle + 1, right, target);
            else
                return Search2(left, middle - 1, target);
        } else {
            if(temp>=data[left]) //pivot to the right
            {
                if(target > temp)
                {
                    return Search2(middle + 1, right, target);
                }
                else
                {
                    if(target >= data[left]) // temp > target > data[left]
                       return Search2(left, middle - 1, target);
                    else  // temp > data[left] > target
                       return Search2(middle + 1, right, target);
                }
            }
            else // pivot point to the left
            {
                if (target < temp)
                {
                    return Search2(left, middle - 1, target);
                }
                else
                {
                    if (target >= data[left]) // target >= data[left] > temp
                        return Search2(left, middle - 1, target);
                    else  // data[left] > target > temp
                        return Search2(middle + 1, right, target);
                }
            }
        }
    }
}