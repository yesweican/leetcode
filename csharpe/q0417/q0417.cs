public class Solution {
    class cell
    {
        public int row;
        public int column;

        public IList<int>ToList()
        {
            return new List<int>() { row, column };
        }
    }
    int[][] pacificVisited;
    int[][] atlanticVisited;
    int[][] directions = new int[][] { new int[]{ -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
    
    public IList<IList<int>> PacificAtlantic(int[][] heights) {
        //get height and width
        int height = heights.Length;
        int width = heights[0].Length;
        //Initialize HashSet
        pacificVisited = new int[height][];
        atlanticVisited = new int[height][];
        for(int i=0; i<height; i++)
        {
            pacificVisited[i]=new int[width];
            atlanticVisited[i]=new int[width];
        }

        //Put edge into pacific queue, add them also into pacific hashset
        Queue<cell> pacificQueue = new Queue<cell>();

        for (int i = 0; i < width; i++)
        {
            cell temp = new cell() { row = 0, column = i };
            pacificQueue.Enqueue(temp);
            pacificVisited[0][i] = 1; ;
        }

        for (int j = 1; j < height; j++)
        {
            cell temp = new cell() { row = j, column = 0 };
            pacificQueue.Enqueue(temp);
            pacificVisited[j][0] = 1; ;
        }

        //While pacific queue not empty
         while (pacificQueue.Count > 0)
        {
            int localCount = pacificQueue.Count;

            while (localCount > 0)
            {
                cell temp = pacificQueue.Dequeue();
                localCount--;

                foreach(var direct in directions)
                {
                    if((temp.row + direct[0])>=0 && (temp.row + direct[0]) < height
                         && (temp.column + direct[1]) >= 0 && (temp.column + direct[1]) < width)
                    {
                        cell temp2 = new cell() { row = temp.row + direct[0], column = temp.column + direct[1] };
                        if (pacificVisited[temp2.row][temp2.column] == 0 && (heights[temp2.row][temp2.column] >= heights[temp.row][temp.column]))
                        {
                            //Add to pacificQueue
                            pacificQueue.Enqueue(temp2);
                            pacificVisited[temp2.row][temp2.column] = 1; ;
                        }
                    }
                }
            }
        }


        //do the same for Atlantic
        Queue<cell> atlanticQueue = new Queue<cell>();
        for (int i = 0; i < width; i++)
        {
            cell temp = new cell() { row = height - 1, column = i };
            atlanticQueue.Enqueue(temp);
            atlanticVisited[height - 1][i] = 1; ;
        }

        for (int j = 0; j < height - 1; j++)
        {
            cell temp = new cell() { row = j, column = width - 1 };
            atlanticQueue.Enqueue(temp);
            atlanticVisited[j][width - 1] = 1; ;
        }

        while (atlanticQueue.Count > 0)
        {
            int localCount = atlanticQueue.Count;

            while (localCount > 0)
            {
                cell temp = atlanticQueue.Dequeue();
                localCount--;

                foreach (var direct in directions)
                {
                    if ((temp.row + direct[0]) >= 0 && (temp.row + direct[0]) < height
                         && (temp.column + direct[1]) >= 0 && (temp.column + direct[1]) < width)
                    {
                        cell temp2 = new cell() { row = temp.row + direct[0], column = temp.column + direct[1] };
                        if (atlanticVisited[temp2.row][temp2.column] == 0 && (heights[temp2.row][temp2.column] >= heights[temp.row][temp.column]))
                        {
                            //Add to pacificQueue
                            atlanticQueue.Enqueue(temp2);
                            atlanticVisited[temp2.row][temp2.column] = 1; ;
                        }
                    }
                }
            }
        }
        //compare two hashset and get the intersection.
        List<IList<int>> result = new List<IList<int>>();

        for(int row = 0; row < height; row++)
        {
            for (int column = 0; column < width; column++)
            {
                if(pacificVisited[row][column] == 1 && atlanticVisited[row][column]==1)
                {
                    List<int> c = new List<int>() {row, column };
                    result.Add(c);
                }
            }
        }

        return result;      
    }
}