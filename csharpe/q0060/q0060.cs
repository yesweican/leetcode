public class Solution {
    int[] factors;
    List<int> buffer;
    StringBuilder ret;
    public string GetPermutation(int n, int k)
    {
        factors = new int[10];
        buffer = new List<int>();
        ret = new StringBuilder();

        factors[0] = 1;

        for (int i = 1; i < 10; i++)
        {
            factors[i]=factors[i-1]*i;
            buffer.Add(i);
        }

        k--; //WHY this step???Make it zero based??

        //changing N method
        while (n>0) {
            int topD = k/(factors[n-1]);
            char c = (char)('0'+buffer[topD]);

            ret.Append(c);

            k -= topD*factors[n-1];
            n -= 1;

            buffer.RemoveAt(topD);
        }

        return ret.ToString();
    }

}