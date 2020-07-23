using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    /// <summary>
    /// Game of Life
    /// </summary>
    public class q289
    {
        public class LifeCell
        {
            public int Status { get; set; } //1 or 0

            public int NeighborCount { get; set; } //count of live neighbors
        }

        public void GameOfLife(int[][] board)
        {
            //produce the LifeCell board
            LifeCell[,] buffer = GetLifeCellBoard(board);
            //get the new board out from the LifeCell board
            var newboard = GetNextBoardFromCellBoard(buffer);

            for (int i = 0; i < board.Length; i++)
            {
                board[i] = newboard[i];
            }
        }

        private LifeCell[,] GetLifeCellBoard(int[][] board)
        {
            int height = board.Length; int width = board[0].Length;
            //LifeCell[][] temp = new LifeCell[height][width];//error
            LifeCell[,] temp = new LifeCell[height, width];

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    temp[row, col] = new LifeCell();
                    temp[row, col].Status = board[row][col];
                    temp[row, col].NeighborCount = 0;

                    ////////////////////
                    // 0 * *
                    // 0 x 0
                    // * * 0
                    ////////////////////
                    if (row > 0)
                    {
                        if (board[row - 1][col] == 1)
                        {
                            temp[row, col].NeighborCount++;
                        }

                        if (col > 0)
                        {
                            if (board[row - 1][col - 1] == 1)
                            {
                                temp[row, col].NeighborCount++;
                            }
                        }
                    }


                    if (row < (height - 1))
                    {
                        if (board[row + 1][col] == 1)
                        {
                            temp[row, col].NeighborCount++;
                        }

                        if (col < (width - 1))
                        {
                            if (board[row + 1][col + 1] == 1)
                            {
                                temp[row, col].NeighborCount++;
                            }
                        }
                    }

                    ////////////////////
                    // * 0 0
                    // * x *
                    // 0 0 *
                    ////////////////////

                    if (col > 0)
                    {
                        if (board[row][col - 1] == 1)
                        {
                            temp[row, col].NeighborCount++;
                        }

                        if (row < (height - 1))
                        {
                            if (board[row + 1][col - 1] == 1)
                            {
                                temp[row, col].NeighborCount++;
                            }
                        }
                    }


                    if (col < (width - 1))
                    {
                        if (board[row][col + 1] == 1)
                        {
                            temp[row, col].NeighborCount++;
                        }

                        if (row > 0)
                        {
                            if (board[row - 1][col + 1] == 1)
                            {
                                temp[row, col].NeighborCount++;
                            }
                        }
                    }
                }
            }


            return temp;
        }

        private int[][] GetNextBoardFromCellBoard(LifeCell[,] cellboard)
        {
            int height = cellboard.GetLength(0); int width = cellboard.GetLength(1);
            //LifeCell[][] temp = new LifeCell[height][width];//error
            int[][] temp = new int[height][];

            for (int row = 0; row < height; row++)
            {
                int[] temprow = new int[width];
                for (int col = 0; col < width; col++)
                {
                    switch (cellboard[row, col].NeighborCount)
                    {
                        case 0:
                        case 1: //rule #1
                            temprow[col] = 0;
                            break;
                        case 2: //rule #2
                            temprow[col] = cellboard[row, col].Status;
                            break;
                        case 3: //rule #4 - reproduction
                            temprow[col] = 1;
                            break;
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8: //rule #3 - overpopulation
                            temprow[col] = 0;
                            break;
                    }
                }
                temp[row] = temprow;
            }

            return temp;
        }
    }
}
