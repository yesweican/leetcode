    public class NQueenSolver
    {
        public int[] positions;
        private int size;
        private int solutions;
        public IList<IList<string>> results;

        public NQueenSolver(int size)
        {
            this.size = size;
            this.positions = new int[size];
            for (int i=0; i <= (size - 1); i++)
            {
                this.positions[i] = -1;
            }

            this.solutions = 0;
            this.results = new List<IList<string>>();
        }

        public NQueenSolver():this(9)
        {
        }

        public void SolveProblem()
        {
            Put_Queen(0);
            //Print Solution Count
            Console.WriteLine("Total Solutions {0}", solutions);
        }

        public void Put_Queen(int currentRow)
        {
            if (currentRow == size)
            {
                //Output current solution
                results.Add(ShowFullBoard());
                //results.Add(positions.Clone());
                solutions++;
            }
            else
            {
                for (int column=0; column <= (size-1); column++)
                {
                    if(Validate(currentRow, column))
                    {
                        positions[currentRow] = column;
                        Put_Queen(currentRow + 1);
                    }
                }
            }
        }

        private bool Validate(int currentRow, int Column)
        {
            for (int i = 0; i <= (currentRow - 1); i++)
            {
                if((positions[i]==Column)
                    ||((positions[i]-i)== (Column - currentRow))
                    ||((positions[i]+i)==(Column + currentRow)))
                {
                    return false;
                }
            }

            return true;

        }

        private IList<string> ShowFullBoard()
        {
            IList<string> solution = new List<string>();
            for(int row=0; row <=(size-1); row++)
            {
                string line="";
                for (int col=0; col<=(size-1); col++)
                {
                    if(positions[row]==col)
                    {
                        line+="Q";
                    }
                    else
                    {
                        line+=".";
                    }
                }
                solution.Add(line);
                //Console.WriteLine(line);
            }

            //Console.WriteLine("+ - - - - - - - - ");
            return (IList<string>)solution;
        }

    }

public class Solution {
    public IList<IList<string>> SolveNQueens(int n) {
        NQueenSolver solver=new NQueenSolver(n);
        solver.SolveProblem();
        return solver.results;
    }
}
