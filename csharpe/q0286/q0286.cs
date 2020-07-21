using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class q286
    {
        /// <summary>
        /// My own method trying NOT to use Recursion
        /// Runtime: 1412 ms, faster than 5.17% of C# online submissions for Walls and Gates.
        /// Memory Usage: 35.4 MB, less than 100.00% of C# online submissions for Walls and Gates.
        /// </summary>
        /// <param name="rooms"></param>
        public void WallsAndGates(int[][] rooms)
        {
            int[,] data1 = new int[rooms[0].Length, rooms.Length]; 
            int[,] data2 = new int[rooms[0].Length, rooms.Length]; 

            for (int y = 0; y < rooms.Length; y++)
            {
                for (int x = 0; x < rooms[0].Length; x++)
                {
                    data1[x, y] = rooms[y][x];
                    data2[x, y] = rooms[y][x];
                }
            }

            bool processing =true;
            while (processing)
            {
                processing = false;
                for (int y = 0; y < rooms.Length; y++)
                {
                    for (int x = 0; x < rooms[0].Length; x++)
                    {
                        //if one cell is INF
                        if (data1[x, y] == 2147483647)
                        {
                            int tmp = 2147483647;
                            if ((x > 0) && (data1[x - 1, y] != -1) && (data1[x - 1, y] < tmp))
                                tmp = data1[x - 1, y];

                            if ((x < (rooms[0].Length - 1)) && (data1[x + 1, y]!=-1) && (data1[x + 1, y] < tmp))
                                tmp = data1[x + 1, y];

                            if ((y > 0) && (data1[x, y - 1] != -1) && (data1[x, y - 1] < tmp))
                                tmp = data1[x, y - 1];

                            if ((y < (rooms.Length - 1)) && (data1[x , y + 1]!= -1) && (data1[x , y + 1] < tmp))
                                tmp = data1[x, y + 1];

                            //found an INF to update
                            if (tmp < 2147483647)
                            {
                                data2[x, y] = tmp + 1;
                                processing = true;
                            }
                        }//end of if
                    }//end of for
                }//end of for

                //using the idea of rotten orange
                //all the none INF values will be final!
                if (processing)
                {
                    for (int y = 0; y < rooms.Length; y++)
                    {
                        for (int x = 0; x < rooms[0].Length; x++)
                        {
                            data1[x, y] = data2[x, y];
                        }//end of for
                    }//end of for
                }

            }//end of while

            for (int y = 0; y < rooms.Length; y++)
            {
                for (int x = 0; x < rooms[0].Length; x++)
                {
                     rooms[y][x] = data1[x, y];
                }
            }

        }

        /// <summary>
        /// My own method trying NOT to use Recursion - Improved Version but.....
        /// Runtime: 640 ms, faster than 5.14% of C# online submissions for Walls and Gates.
        /// Memory Usage: 34.8 MB, less than 100.00% of C# online submissions for Walls and Gates. 
        /// </summary>
        /// <param name="rooms"></param>
        public void WallsAndGates2(int[][] rooms)
        {
            int[][] rooms2 = new int[rooms.Length][];
            for (int y = 0; y < rooms.Length; y++)
            {
                rooms2[y] = new int[rooms[0].Length];
                for (int x = 0; x < rooms[0].Length; x++)
                {
                    rooms2[y][x] = rooms[y][x];
                }
            }

            bool processing = true;
            while (processing)
            {
                processing = false;
                for (int y = 0; y < rooms.Length; y++)
                {
                    for (int x = 0; x < rooms[0].Length; x++)
                    {
                        //if one cell is INF
                        if (rooms2[y][x]== 2147483647)
                        {
                            int tmp = 2147483647;
                            //having to check VEVERY direction perhaps is the issue
                            if ((x > 0) && (rooms[y][x-1] != -1) && (rooms[y][x-1] < tmp))
                                tmp = rooms[y][x-1];

                            if ((x < (rooms[0].Length - 1)) && (rooms[y][x+1] != -1) && (rooms[y][x+1]< tmp))
                                tmp = rooms[y][x+1];

                            if ((y > 0) && (rooms[y - 1][x] != -1) && (rooms[y - 1][x] < tmp))
                                tmp = rooms[y - 1][x];

                            if ((y < (rooms.Length - 1)) && (rooms[y + 1][x] != -1) && (rooms[y + 1][x] < tmp))
                                tmp = rooms[y + 1][x];

                            //found an INF to update
                            if (tmp < 2147483647)
                            {
                                rooms2[y][x] = tmp + 1;
                                processing = true;
                            }
                        }//end of if
                    }//end of for
                }//end of for

                //using the idea of rotten orange
                //all the none INF values will be final!
                if (processing)
                {
                    for (int y = 0; y < rooms.Length; y++)
                    {
                        for (int x = 0; x < rooms[0].Length; x++)
                        {
                            rooms[y][x] = rooms2[y][x];
                        }//end of for
                    }//end of for
                }

            }//end of while

        }

        /// <summary>
        /// My own method trying NOT to use Recursion - 2nd Try to improve this
        /// </summary>
        /// <param name="rooms"></param>
        public void WallsAndGates3(int[][] rooms)
        {
            int[][] directions = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
            int[][] rooms2 = new int[rooms.Length][];
            for (int y = 0; y < rooms.Length; y++)
            {
                rooms2[y] = new int[rooms[0].Length];
                for (int x = 0; x < rooms[0].Length; x++)
                {
                    rooms2[y][x] = rooms[y][x];
                }
            }

            bool processing = true;
            while (processing)
            {
                processing = false;
                for (int y = 0; y < rooms.Length; y++)
                {
                    for (int x = 0; x < rooms[0].Length; x++)
                    {
                        //if one cell is INF
                        if (rooms2[y][x] == 2147483647)
                        {
                            int tmp = 2147483647;
                            bool found = false;

                            //having to check VEVERY direction perhaps WAS the issue?
                            foreach (var direction in directions)
                            {
                                int y0 = y + direction[0];
                                int x0 = x + direction[1];

                                if ((x0 >= 0) && (x0 < rooms[0].Length) && (y0 >= 0) && (y0 < rooms.Length))
                                {
                                    if ((rooms[y0][x0] != -1) && (rooms[y0][x0]<tmp))
                                    {
                                        tmp = rooms[y0][x0];
                                        found = true;
                                    }
                                }

                                if (found)
                                    break;

                            }

                            //found an INF to update
                            if (tmp < 2147483647)
                            {
                                rooms2[y][x] = tmp + 1;
                                processing = true;
                            }
                        }//end of if
                    }//end of for
                }//end of for

                //all the none INF values will be final!
                if (processing)
                {
                    for (int y = 0; y < rooms.Length; y++)
                    {
                        for (int x = 0; x < rooms[0].Length; x++)
                        {
                            rooms[y][x] = rooms2[y][x];
                        }//end of for
                    }//end of for
                }

            }//end of while

        }

    }
}
