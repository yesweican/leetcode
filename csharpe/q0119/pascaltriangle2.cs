public class Solution {
    public IList<int> GetRow(int rowIndex) {
           int line=rowIndex+1;
        
            int[,] data = new int[line, line];
            data[0, 0] = 1;

            for (int row = 1; row < line; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    if ((col == 0) || (col == row))
                        data[row, col] = 1;
                    else
                        data[row, col] = data[row - 1, col - 1] + data[row - 1, col];

                }
            }

            List<int> results = new List<int>();

            for (int i = 0; i < line; i++)
            {
                results.Add(data[line-1, i]);
                Console.Write(data[line - 1, i]);
            }

            Console.WriteLine("");
            return (IList<int>)results;      
    }
}