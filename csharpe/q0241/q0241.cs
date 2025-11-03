public class Solution {
    Dictionary<string, List<int>>dict;
    public IList<int> DiffWaysToCompute(string expression) {
        dict=new Dictionary<string, List<int>>();
        return Ways(expression);

    }

    private IList<int>Ways(string expr) {

        if(dict.Keys.Contains(expr))
            return dict[expr];

        List<int>results=new List<int>();
        List<int>vals1;
        List<int>vals2;
        for (int i=0; i<expr.Length; i++)
        {
            if (expr[i]!='+' && expr[i]!='-' && expr[i]!='*')
                continue;
            vals1 = (List<int>)Ways(expr.Substring(0,i));
            vals2 = (List<int>)Ways(expr.Substring(i+1));
            foreach (var a in vals1)
                foreach (var b in vals2)
                {
                    if (expr[i]=='+') results.Add(a+b);
                    else if (expr[i]=='-') results.Add(a-b);
                    else if (expr[i]=='*') results.Add(a*b);
                }
        }
        if (results.Count==0)
            results.Add(Int32.Parse(expr));

        if(!dict.Keys.Contains(expr))
            dict.Add(expr, results);
        return results;
    }
}