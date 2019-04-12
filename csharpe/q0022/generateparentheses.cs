public class Solution {
    
    ArrayList results = new ArrayList();    
    public IList<string> GenerateParenthesis(int n) {
            DoGenerate(n, 0, 0, "");
            return results.Cast<String>().ToList();        
    }
    
        public void DoGenerate(int n, int OpenCount, int ClosingCount, string Prefix)
        {
            if ((OpenCount == n) && (ClosingCount == n))
            {
                results.Add(Prefix);
                //Console.WriteLine("{0}", Prefix);
            }

            if (OpenCount < n)
            {
                DoGenerate(n, OpenCount+1, ClosingCount, Prefix+"(");
            }

            if ((ClosingCount < n) && (OpenCount > ClosingCount))
            {
                DoGenerate(n, OpenCount, ClosingCount + 1, Prefix + ")");
            }
        }    
}