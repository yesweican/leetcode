public class Solution {
    int[] table = new int[200];
    public int NumTrees(int n) {
        
        for (int i=0; i<200; i++)
            table[i]=-1;
        table[0]=1; table[1]=1;
        return catalan(n);
    }

        int catalan(int n) {
        int res = 0;
        int n1=0; int n2=0;
         
        // Base case
        if (n <= 1) {
            return 1;
        }
        
        if(table[n]!=-1)
            return table[n];
        
        for (int i = 0; i < n; i++) 
        {
            n1=(table[i]==-1)?catalan(i):table[i];
            n2=(table[n-i-1]==-1)?catalan(n - i - 1):table[n-i-1];
            res += n1 * n2;
        }
        
        table[n]=res;
        return res;
    }
    
}