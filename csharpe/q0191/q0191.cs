public class Solution {
    public int HammingWeight(uint n) {
        int counter = 0;
        
        while(n>0)
        {
            if((n & 1)==1)
            {
                counter++;
            }
            n>>=1;
        }
        
        return counter;
    }
}