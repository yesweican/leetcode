public class Solution {
         int _StairCount;
        int[] _Data;   
    
    public int ClimbStairs(int n) {
            if (n == 1)
                return 1;
            if (n == 2)
                return 2;
            _StairCount = n;
            _Data = new int[n];  
            _Data[0] = 1; 
            _Data[1] = 2;
            return F(_StairCount);
    }
    
    public int F(int n)
    {
            //Console.WriteLine(n);
            if (n == 1) return 1;
            if (n == 2) return 2;
            if (_Data[n - 1] > 0) 
                return _Data[n - 1];
            else
            {
                _Data[n - 1] = F(n - 1) + F(n - 2);
                return _Data[n - 1];
            }

    } 
}