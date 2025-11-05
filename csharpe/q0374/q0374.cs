/** 
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is lower than the guess number
 *			      1 if num is higher than the guess number
 *               otherwise return 0
 * int guess(int num);
 */

public class Solution : GuessGame {
    public int GuessNumber(int n) {
        int low = 1; int high = n;
        
        while (low<=high)
        {
            if((high-low)<2)
            {
                if(guess(high)==0)
                    return high;
                else
                    return low;
            }
            
            int mid = low + (high - low) / 2;
            int temp = guess(mid);
            if(temp==-1)
            {
                high=mid-1;
            }
            else
            {
                if(temp==1)
                {
                    low=mid+1;
                }
                else
                {
                    return mid;
                }
            }
            
        }
        
        return -1;
    }
}