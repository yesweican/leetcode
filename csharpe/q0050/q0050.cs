public class Solution {
    ///////
    /// Time-limit Exceeded 
    /// 
    public double MyPow(double x, int n) {
        if (n==0)
            return 1.0;
        
        if(n==Int32.MinValue)
        {
            if(x>1 || x<-1) return 0;
            if(x>-1 && x<1)
                return (double)Int32.MaxValue;
        }
        
        bool sign =true;
        if(n<0)
        {
            sign = false;
            n=-n;
        }

        Dictionary<int, double> dict = new Dictionary<int, double>();
        Dictionary<int, int> dict2 = new Dictionary<int, int>();
        
        dict.Add(0, 1.0);   dict.Add(1, x);
        dict2.Add(0, 1); dict2.Add(1,2);

        
        double temp = x; 
        int n2=2;   
        //int p2=2;     
        while (n2<=32)
        {
            temp=temp*temp;
            dict.Add(n2, temp);
            //p2= p2 * p2;
            //dict2.Add(n2, p2);
            n2=n2*2;
            
        }
        
        double result =1.0;
        int pos = 32;
        while (n>0)
        {
            if(n >= pos) {
                result = result * dict[pos];
                n=n-pos;
            }

            pos>>=1;            
        }
        
        if(sign)
            return result;
        else
            return 1/result;
        
    }
}