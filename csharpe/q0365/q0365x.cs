using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q365
    {
        /***
         * action 0: Fill x with water
         * action 1: Empty x to no water
         * action 2: Fill y with water
         * action 3: Empty y to no water
         * action 4: Pour water from x to y
         * action 5: Pour water from y to x
         * ********************************
         * Implement with DFS and HashSet for already visited status
         * 
         ****/
        public HashSet<string> visited=null;

        public bool CanMeasureWater(int x, int y, int z)
        {
            visited = new HashSet<string>();
            return ProcessWater(x,y,0,0,z);
        }

        private bool ProcessWater(int x, int y, int x2, int y2, int z)
        {
            if (x2 == z || y2 == z ||(x2+y2)==z)
                return true;
            /////Check whether x2/y2 visited before or not.
            string temp = x2.ToString() + "," + y2.ToString();
            Console.WriteLine(temp);

            if (visited.Contains(temp))
            {
                return false;
            }
            else
            {
                visited.Add(temp);
            }


            bool success = false;
            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            //Fill x with water
                            success = ProcessWater(x, y, x, y2, z);
                            if (success)
                                return true;
                        }
                        break;
                    case 1:
                        {
                            //Empty x to no water 
                            success = ProcessWater(x, y, 0, y2, z);
                            if (success)
                                return true;
                        }
                        break;
                    case 2:
                        {
                            //Fill y with water
                            success = ProcessWater(x, y, x2, y, z);
                            if (success)
                                return true;
                        }


                        break;
                    case 3:
                        {
                            //Empty y to no water
                            success = ProcessWater(x, y, x2, 0, z);
                            if (success)
                                return true;

                        }
                        break;
                    case 4:
                        {
                            //Pouring water from x to y
                            if ((x2 + y2) < y)
                            {
                                success = ProcessWater(x, y, 0, x2 + y2, z);
                            }
                            else
                            {
                                success = ProcessWater(x, y, x2 + y2 - y, y, z);
                            }

                            if (success)
                                return true;
                        }
                        break;
                    case 5:
                        {
                            //Pouring water from y to x
                            if ((x2 + y2) < x)
                            {
                                success = ProcessWater(x, y, x2 + y2, 0, z);
                            }
                            else
                            {
                                success = ProcessWater(x, y, x, x2 + y2 - x, z);
                            }

                            if (success)
                                return true;
                        }
                        break;
                }
            }

            //success must false here;
            return false;

        }
    }
}
