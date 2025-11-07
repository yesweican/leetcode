public class Solution {
    public int PoorPigs(int buckets, int minutesToDie, int minutesToTest) {
       if (buckets==1)
            return 0;
       
       int n=(int)(minutesToTest/minutesToDie)+1;

       int result = 1; int capacity = n;
       while(capacity<buckets)
       {
           capacity *=n;
           result++;
       }

       return result;

    }
}