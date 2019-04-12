public class Solution 
{
    public void SolveSudoku(char[,] board) 
    {
            int[,] board2 = new int[9, 9];
            RemainingOptions[,] theoptions = new RemainingOptions[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i, j] == '.')
                    {
                        theoptions[i, j] = new RemainingOptions(0);
                        board2[i, j] = 0;
                    }
                    else
                    {
                        board2[i, j] = (int)(board[i, j] - '0');
                        theoptions[i, j] = new RemainingOptions(board2[i,j]);

                    }
                }
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int temp = board2[i, j];
                    //do following only if [i,j] not empty 
                    if (temp != 0)
                    {
                        for (int k = 0; k < 9; k++)
                        {
                            //process the rows
                            if (k != j)
                            {
                                theoptions[i, k].RemoveOption(temp);
                            }
                            //process the columns
                            if (k != i)
                            {
                                theoptions[k, j].RemoveOption(temp);
                            }
                        }

                        //process the cell
                        int i0 = (int)(i / 3) * 3; int i1 = i % 3;
                        int j0 = (int)(j / 3) * 3; int j1 = j % 3;

                        for (int m = 0; m < 3; m++)
                        {
                            for (int n = 0; n < 3; n++)
                            {
                                if ((m != i1) || (n != j1))
                                {
                                    theoptions[i0 + m, j0 + n].RemoveOption(temp);
                                }
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write("{0}", board[i, j]);
                }

                Console.WriteLine("");
            }

            SudokuSolution answer = DFSSudoku(board2, theoptions, 0,0);
            if (answer.Solved == true)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (board[i,j] == '.')
                        {
                           board[i, j] = (char)('0' + answer.board[i, j]);
                        }

                    }

                    Console.WriteLine("");
                }
            }
    }
    
            private SudokuSolution DFSSudoku(int[,] boardx, RemainingOptions[,] possibilities, int row, int col)
        {
            //int[,] newboardx = (int[,])boardx.Clone();
            SudokuSolution result = new SudokuSolution();

            while (boardx[row, col] != 0)
            {
                if (col < 8)
                {
                    col++;
                }
                else
                {//col=8
                    if (row < 8)
                    {
                        col = 0;
                        row++;
                    }
                }

                if ((col == 8) && (row == 8))
                    break;
            }

            //Last spot?
            if ((row == 8) && (col == 8))
            {
                int[,] newboardx = new int[9, 9];
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        newboardx[i, j] = boardx[i, j];
                    }

                //wrapping up solution
                if (possibilities[row, col].options.Count > 0)
                {
                    newboardx[8, 8] = (int)possibilities[8, 8].options[0];
                    result.board = newboardx;
                    result.Solved = true;
                }
                else
                {
                    //no Answer for this path
                    newboardx[8, 8] = -1;
                    result.board = newboardx;
                    result.Solved = false;
                }

                return result;
            }

            int nextrow = 0, nextcol = 0;

            if (col < 8)
            {
                nextrow = row;
                nextcol = col + 1;
            }
            else
            {//col=8
                if (row < 8)
                {
                    nextcol = 0;
                    nextrow = row + 1;
                }
            }

            
            if (possibilities[row, col].options.Count > 1)
            {
                foreach (int x in possibilities[row, col].options)
                {
                    int[,] newboardx = new int[9, 9];
                    for (int i = 0; i < 9; i++)
                        for (int j = 0; j < 9; j++)
                        {
                            newboardx[i, j] = boardx[i, j];
                        }

                    newboardx[row, col] = x;

                    //clone/copy the possibilities - except the current one
                    RemainingOptions[,] newpossibilities = CloneOptions(possibilities);

                    //for [row, col]
                    newpossibilities[row, col] = new RemainingOptions();
                    ArrayList tempList = new ArrayList();
                    tempList.Add(x);
                    newpossibilities[row, col].options = tempList;


                    //update possibilities - Clean Up here   
                    UpdateOptions(newpossibilities, x, row, col);
                    //Recursive Call forward from here

                    result = DFSSudoku(newboardx, newpossibilities, nextrow, nextcol);
                    if (result.Solved == true)
                    {
                        //result.board = newboardx;
                        return result;
                    }
                }

                //should not reach here???
                //result.board = newboardx;
                return result;

            }
            else
            {
                //possibilities[row, col].options.Count == 1 or == 0
                //clone/copy the possiblities - except the current one
                //update possbilities
                //if col<8, col++
                //if col==8 && row<8, col=0, row++
                if (possibilities[row, col].options.Count == 1)
                {
                    int[,] newboardx = new int[9, 9];
                    for (int i = 0; i < 9; i++)
                        for (int j = 0; j < 9; j++)
                        {
                            newboardx[i, j] = boardx[i, j];
                        }

                    int val = (int) possibilities[row, col].options[0];

                    newboardx[row, col] = val;

                    //clone/copy the possibilities - except the current one
                    RemainingOptions[,] newpossibilities = CloneOptions(possibilities);

                    //for [row, col]
                    newpossibilities[row, col] = new RemainingOptions();
                    ArrayList tempList = new ArrayList();
                    tempList.Add(val);
                    newpossibilities[row, col].options = tempList;

                    //update possibilities - Clean Up here   
                    UpdateOptions(newpossibilities, val, row, col);

                    //Recursive Call forward from here
                    return DFSSudoku(newboardx, newpossibilities, nextrow, nextcol);
                }
                else //Count==0
                {
                    //result.board= newboardx;
                    result.board[row, col] = -1;
                    result.Solved = false;
                    return result;
                }
            }
        }
    
    private RemainingOptions[,] CloneOptions(RemainingOptions[,] possibilities)
        {
            RemainingOptions[,] newpossibilities = new RemainingOptions[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    ArrayList tempList = new ArrayList();
                    newpossibilities[i, j] = new RemainingOptions();
                    foreach(int x in possibilities[i, j].options)
                    {
                        tempList.Add(x);
                    }
                    newpossibilities[i, j].options = tempList;
                }
            }

            return newpossibilities;
        }

private void UpdateOptions(RemainingOptions[,] possibilities, int val, int row, int col)
{

        //Console.WriteLine("Removing {0}:{1}:{2}", val, row, col);

        if ((val == 1) && (row == 0) && (col == 0))
            Console.WriteLine("Hello, World!");
        //do following only if [i,j] not empty 
        for (int k = 0; k < 9; k++)
        {
            //process the rows
            if (k != col)
            {
                possibilities[row, k].RemoveOption(val);
            }
            //process the columns
            if (k != row)
            {
                possibilities[k, col].RemoveOption(val);
            }
        }

        //process the cell
        int row0 = (int)(row / 3) * 3; int row1 = row % 3;
        int col0 = (int)(col / 3) * 3; int col1 = col % 3;

        for (int m = 0; m < 3; m++)
        {
            for (int n = 0; n < 3; n++)
            {
                if ((m != row1) || (n != col1))
                {
                    possibilities[row0 + m, col0 + n].RemoveOption(val);
                }
            }
        }

        return;
    }
    
}

public class SudokuSolution
{
    public int [,] board = new int[9,9];
    public bool Solved { get; set; }
    public SudokuSolution()
    {
        Solved = false;
    }
}

public class RemainingOptions
{
    public ArrayList options = null;

    public RemainingOptions()
    {
        options = new ArrayList();
    }

    public RemainingOptions(int n)
    {
        options = new ArrayList();
        if (n == 0)
        {
            for (int i = 1; i < 10; i++)
            {
                options.Add(i);
            }
        }
        else
        {
            options.Add(n);
        }

    }

    public void RemoveOption(int i)
    {
        options.Remove(i);
    }

}

