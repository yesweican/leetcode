public class Solution {
    public int MySqrt(int x) {
        if(x<=1)
            return x;

        long b=x;
        long a=x/2;

        while((a*a)>x &&(b*b)>x)
        {
            b=a;
            a=a/2;
        }

        long answer = -1;
        for(long i= b; i>=a; i--)
        {
            if(i*i<=x)
            {
                answer = i;
                break;
            }
        }

        return (int)answer;
    }
}