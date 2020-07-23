using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    /// <summary>
    /// The Maze
    /// </summary>
    public class q490
    {
        public class MazePoint
        {
            public int Row { get; set; }
            public int Column { get; set; }
        }

        int[,] _maze;
        int width;
        int height;
        HashSet<int> visited;
        Stack<MazePoint> stack;

        public bool HasPath(int[][] maze, int[] start, int[] destination)
        {
            width = maze[0].Length;
            height = maze.Length;

            _maze = new int[width, height];
            for (int i = 0; i < width; i++)
            {
                //convert maze data store
                for (int j = 0; j < height; j++)
                {
                    _maze[i, j] = maze[j][i];
                }
            }

            visited = new HashSet<int>();
            stack = new Stack<MazePoint>();

            MazePoint start2 = new MazePoint() { Row = start[0], Column = start[1] };
            stack.Push(start2);

            /////////////////////////////////
            ////essentially Broadth First Search
            /////////////////////////////////
            while (stack.Count > 0)
            {
                MazePoint current = stack.Pop();
                if (visited.Contains(coordToIndex(current)))
                    continue;
                if ((current.Row == destination[0]) && (current.Column == destination[1]))
                    return true;

                visited.Add(coordToIndex(current));
                foreach (var next in Neighbors(current))
                {
                    stack.Push(next);
                }
            }

            return false;
        }

        private IEnumerable<MazePoint> Neighbors(MazePoint point)
        {
            int[][] directions = { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
            foreach (int[] offsets in directions)
            {
                MazePoint neighbor = new MazePoint();
                neighbor.Row = point.Row;////y
                neighbor.Column = point.Column;////x

                while (((neighbor.Column + offsets[0]) >= 0)
                    && ((neighbor.Column + offsets[0]) < width)
                    && ((neighbor.Row + offsets[1]) >= 0)
                    && ((neighbor.Row + offsets[1]) < height)
                    && (_maze[neighbor.Column + offsets[0], neighbor.Row + offsets[1]] == 0))
                {
                    neighbor.Column = neighbor.Column + offsets[0];
                    neighbor.Row = neighbor.Row + offsets[1];
                }
                yield return neighbor;

            }

        }

        private int coordToIndex(MazePoint point)
        {
            return point.Row * width + point.Column;
        }
    }
}
