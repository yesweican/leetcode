public class Solution {
            
    List<IList<int>> results = new List<IList<int>>();
    public IList<IList<int>> Generate(int numRows) {
        if(numRows==0) return results;
            List<int> firstRow = new List<int>();
            firstRow.Add(1);
            results.Add(firstRow);
            if (numRows == 1)
                return results;

            List<int> secondRow = new List<int>();
            secondRow.Add(1);
            secondRow.Add(1);
            results.Add(secondRow);
            if (numRows == 2)
                return results;

            List<int> lastRow = secondRow;

            for (int i = 2; i < numRows; i++)
            {
                List<int> newrow = new List<int>();
                for (int j = 0; j < (i+1); j++)
                {
                    if ((j == 0) || (j == i))
                        newrow.Add(1);
                    else
                    {
                        newrow.Add(lastRow[j] + lastRow[j - 1]);
                    }
                }
                
                results.Add(newrow);
                lastRow=newrow;
            }

            return (IList<IList<int>>)results;        
    }
}