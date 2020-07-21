using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q1232
    {
        public bool CheckStraightLine(int[][] coordinates)
        {
            if (coordinates.Length <= 2)
                return true;
            bool samecolumn = (coordinates[1][1] == coordinates[0][1]);
            double delta = !samecolumn ? (coordinates[1][0] - coordinates[0][0]) / (coordinates[1][1] - coordinates[0][1]) : -1;

            for (int i = 2; i < coordinates.Length; i++)
            {
                if (samecolumn)
                {
                    if (coordinates[i][1] != coordinates[0][1])
                        return false;
                }
                else
                {
                    if (coordinates[i][1] == coordinates[0][1])
                        return false;

                    double delta2 = (coordinates[i][0] - coordinates[0][0]) / (coordinates[i][1] - coordinates[0][1]);
                    if (delta2 != delta)
                        return false;
                }

            }
            return true;
        }
    }
}
