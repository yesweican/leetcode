public class Solution {
    public bool IsPowerOfThree(int n) {
        if (n <= 0)
            return false;
        if (n == 1)
            return true;
        int temp = n;

        while (temp > 1)
        {
            if (temp % 3 > 0)
                return false;
            else
                temp = temp / 3;
        }

        return true;        
    }
}