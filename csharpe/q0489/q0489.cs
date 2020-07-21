using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class Robot
    {
        public bool Move()
        {
            return false;
        }

        public void Clean()
        {
        }

        public void TurnRight()
        {
        }

        public void TurnLeft()
        {
        }

    }
    public class q489
    {
        HashSet<string> visited = new HashSet<string>();
        Robot robert;

        public void CleanRoom(Robot robot)
        {
            robert = robot;
            //int dir = 0;
            dfs(0,0,0);

        }

        /// <summary>
        /// Eack call of this function, the robot turn 360*
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="currentdir"></param>
        private void dfs(int row, int col, int currentdir)
        {
            int[][] directions = new int[4][] { new int[] { 0, -1 }, new int[] { +1, 0 }, new int[] { 0, +1 }, new int[] { -1, 0 }, };
            string spot = row.ToString() + "," + col.ToString();

            if (visited.Contains(spot)) return;
            ////if never visited, then clean it and add it to the visited collection
            robert.Clean();
            visited.Add(spot);

            for (int k = 0; k < 4; k++)
            {
                int direction = (currentdir + k) % 4;
                int newrow;
                int newcol;

                if (robert.Move())
                {
                    newrow = row + directions[direction][0];
                    newcol = col + directions[direction][1];

                    dfs(newrow, newcol, direction);

                    //backtracking and recover the facing
                    robert.TurnRight();
                    robert.TurnRight();
                    robert.Move();
                    robert.TurnRight();
                    robert.TurnRight();

                }

                robert.TurnRight();
            }//end of for
 
        }

    }
}
