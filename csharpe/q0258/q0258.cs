public class Solution {
    public int AddDigits(int num) {
        while(num>9)
        {
            num = process(num);
        }

        return num;
    }

    private int process(int n)
    {
        int result = 0;
        while(n>0)
        {
            int temp = n % 10;
            result += temp;
            n = (n-temp) / 10;
        }

        return result;

    } 
}