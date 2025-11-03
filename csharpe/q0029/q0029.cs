public class Solution {
    ////
    //// solution using bit shift operation and minus
    ////
    public int Divide(int dividend, int divisor) {
            long dividend2 = (long)dividend;
            long divisor2 = (long) divisor;
            long result = 0;
            int sign = 1;
            if ((dividend > 0 && divisor < 0) ||
                (dividend < 0 && divisor > 0))
                sign = -1;

            dividend2 = Math.Abs(dividend2);
            divisor2 = Math.Abs(divisor2);

            while(dividend2>=divisor2) // and > 0
            {
                long temp = divisor2; // the temp value went over
                long prevtemp = -1; // the temp value just before going OVER
                long multiple = 1;
                while(dividend2>=temp)
                {
                    prevtemp = temp;
                    temp <<= 1;
                    multiple <<= 1;
                }
                // Console.WriteLine(prevtemp.ToString());
                // Console.WriteLine(multiple.ToString());               
                dividend2 -= prevtemp;
                result |= multiple>>1; //or result += multiple;
            }
        
            result = result * sign;
        
            if(result>Int32.MaxValue)
                result=Int32.MaxValue;
            if(result<Int32.MinValue)
                result=Int32.MinValue;

            return (int) result;        
    }
}