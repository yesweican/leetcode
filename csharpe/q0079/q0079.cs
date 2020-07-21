using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class q079
    {
        int[][] directions;
        int rows;
        int cols;

        public bool Exist(char[][] board, string word)
        {
            directions = new int[][] {new int[] { -1, 0 },new int[] { +1, 0 },new int[] { 0, -1 },new int[] { 0, +1 } }; ;
            rows = board.Length;
            cols = board[0].Length;

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    if (board[i][j] == word[0])
                    {
                        Console.WriteLine(i.ToString() + "," + j.ToString());
                        //if fail try other start point!
                        char saved = board[i][j]; board[i][j] = '$';
                        bool temp = dps(board, word, 0, i, j);
                        board[i][j] = saved;
                        if (temp) return true;
                    }
                }

            return false;
        }

        bool dps(char[][] board, string word, int index, int i, int j)
        {
            if(index==(word.Length-1)) return true;
            
            index++;

            foreach (var dir in directions)
            {
                int r=i+dir[0]; int c=j+dir[1];
                if ((r >= 0) && (r < rows) && (c >= 0) && (c < cols))
                {
                    if (board[r][c] == word[index])
                    {
                        char saved = board[r][c]; board[r][c] = '$';
                        Console.WriteLine(r.ToString()+","+c.ToString());
                        //if fail try other direction
                        bool temp = dps(board, word, index, r, c);
                        board[r][c] = saved;
                        if (temp) return true;
                    }
                    else
                        continue;
                }
            }

             return false;
        }
    }
}
