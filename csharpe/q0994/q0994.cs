using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    class q994
    {
        public int OrangesRotting(int[][] grid)
        {
            HashSet<string> freshOranges = new HashSet<string>();
            HashSet<string> rottenOranges = new HashSet<string>();
            int[][] directions = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };

            //preparation
            for (int y = 0; y < grid.Length; y++)
            {
                for (int x = 0; x < grid[0].Length; x++)
                {
                    if (grid[y][x] == 1)
                        freshOranges.Add(y.ToString() + "-" + x.ToString());

                    if (grid[y][x] == 2)
                        rottenOranges.Add(y.ToString() + "-" + x.ToString());
                }
            }

            bool processing = true; int counter = 0;

            while (processing)
            {
                processing = false;
                HashSet<string> infected = new HashSet<string>();

                for (int y = 0; y < grid.Length; y++)
                {
                    for (int x = 0; x < grid[0].Length; x++)
                    {
                        string temp = y.ToString()+"-"+x.ToString();
                        if (freshOranges.Contains(temp))
                        {
                            foreach(var direction in directions)
                            {
                                int y0 = y + direction[0];
                                int x0 = x + direction[1];

                                bool foundbad = false;
                                //make sure not going off bound
                                if ((x0 >= 0) && (x0 < grid[0].Length) && (y0 >= 0) && (y0 < grid.Length))
                                {
                                    string temp0 = y0.ToString() + "-" + x0.ToString();
                                    if (rottenOranges.Contains(temp0))
                                    {
                                        infected.Add(temp);
                                        foundbad = true;
                                        break;
                                    }
                                }

                                //only need one neighbor to be bad
                                if (foundbad)
                                    break;

                            }
                        }
                    }
                }

                if (infected.Count > 0)
                {
                    //move over from infected to Rotten
                    foreach (var str in infected)
                    {
                        rottenOranges.Add(str);
                        freshOranges.Remove(str);
                    }

                    processing = true;
                    counter++;
                }

            }//end of while

            if (freshOranges.Count > 0)
            {
                return -1;
            }
            return counter;

        }

        public int OrangesRotting2(int[][] grid)
        {
            int[][] directions = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
            int[][] grid2 = new int[grid.Length][];

            //preparation
            for (int y = 0; y < grid.Length; y++)
            {
                grid2[y]=new int[grid[0].Length];
                for (int x = 0; x < grid[0].Length; x++)
                {
                    grid2[y][x] = grid[y][x];
                }
            }

            bool processing = true; int counter = 0;

            while (processing)
            {
                processing = false;

                for (int y = 0; y < grid.Length; y++)
                {
                    for (int x = 0; x < grid[0].Length; x++)
                    {
                        if (grid[y][x]==1)
                        {
                            foreach (var direction in directions)
                            {
                                int y0 = y + direction[0];
                                int x0 = x + direction[1];

                                bool foundbad = false;
                                //make sure not going off bound
                                if ((x0 >= 0) && (x0 < grid[0].Length) && (y0 >= 0) && (y0 < grid.Length))
                                {
                                    if (grid[y0][x0]==2)
                                    {
                                        grid2[y][x] = 2;
                                        foundbad = true;
                                        processing = true;
                                        break;
                                    }
                                }
                                //only need one neighbor to be bad
                                if (foundbad)
                                    break;

                            }
                        }
                    }
                }

                //copy from grid2 back to grid
                if (processing)
                {
                    for (int y = 0; y < grid.Length; y++)
                    {
                        for (int x = 0; x < grid[0].Length; x++)
                        {
                            grid[y][x] = grid2[y][x];
                        }
                    }
                    counter++;
                }

            }//end of while

            int freshcount = 0;
            for (int y = 0; y < grid.Length; y++)
            {
                for (int x = 0; x < grid[0].Length; x++)
                {
                    if (grid[y][x] == 1)
                    {
                        freshcount++;
                    }
                }
            }


            if (freshcount > 0)
            {
                return -1;
            }
            return counter;

        }
    }
}
