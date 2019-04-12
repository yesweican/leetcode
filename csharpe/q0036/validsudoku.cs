public class Solution {
        public bool IsValidSudoku(char[,] board)
        {
            int[,] data = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    //Console.Write("{0}", board[i,j]);
                    if (board[i, j] == '.')
                        data[i, j] = 0;
                    else
                    {
                        if (board[i, j] == '0')
                            return false;
                        data[i, j] = (int)(board[i, j] - '0');
                        if ((data[i, j] > 9) || (data[i, j] < 0))
                            return false;
                    }
                }

                //Console.WriteLine("");
            }

            bool result = ValidateSudoku2(data);

            return result;
        }

        public bool ValidateSudoku2(int[,] data)
        {
            for (int i = 0; i < 9; i++)
            {
                if(ValidateRow(data, i)==false)
                {
                    return false;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                if (ValidateColumn(data, i) == false)
                {
                    return false;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (ValidateCell(data, i, j) == false)
                        return false;
                }
            }

            return true;

        }

        public bool ValidateRow(int[,] data, int row)
        {
            RuleCheckResult result = new RuleCheckResult();
            for (int i = 0; i < 9; i++)
            {
                int num = data[row, i];
                if (num > 0)
                    result.numberCounts[num-1] = result.numberCounts[num-1]+1; 
            }

            return result.IsValid;
        }

        public bool ValidateColumn(int[,] data, int col)
        {
            RuleCheckResult result = new RuleCheckResult();

            for (int i = 0; i < 9; i++)
            {
                int num = data[i, col];
                if (num > 0)
                    result.numberCounts[num-1] = result.numberCounts[num-1] + 1;
            }

            return result.IsValid;
        }

        public bool ValidateCell(int[,] data, int cellrow, int cellcol)
        {
            RuleCheckResult result = new RuleCheckResult();
            int rowoffset = cellrow * 3;
            int coloffset = cellcol * 3;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int num = data[i+rowoffset , j+coloffset];
                    if (num > 0)
                    {
                        result.numberCounts[num-1] = result.numberCounts[num-1] + 1;
                    }

                }

            }

            return result.IsValid;
        }

}

    public class RuleCheckResult
    {
        public int[] numberCounts;


        public RuleCheckResult()
        {
            numberCounts = new int[9];
            for (int i = 0; i < 9; i++)
            {
                numberCounts[i] = 0;
            }
        }

        public bool IsValid
        {
            get
            {
                for (int i=0; i < 9; i++)
                {
                    if (numberCounts[i] > 1)
                        return false;
                      
                }

                return true;
            }
        }

    }