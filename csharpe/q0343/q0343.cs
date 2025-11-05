public class Solution {
    public int IntegerBreak(int n) {
        int[] data = new int[60];
        data[1]=1;
        data[2]=1;
        data[3]=2;
        data[4]=4;
        data[5]=6;
        data[6]=9;
        int temp=0;
        for(int i=7; i<=n; i++) 
        {
            temp = Math.Max(data[i-2]*2, data[i-3]*3);
            data[i] = temp;
        }

        return data[n];
    }
}