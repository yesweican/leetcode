public class Solution
{
    int perimeter;
    int[][] directions = new int[4][] {
    new int[] {-1,0},
    new int[] {0, -1},
    new int[] {1,0},
    new int[] {0, 1}};
    bool[][] visited;
    int[][] data; 
    public int IslandPerimeter(int[][] grid)
    {
        perimeter = 0;
        data = grid;

        visited = new bool[grid.Length][];
        for (int i = 0; i < grid.Length; i++)
        {
            visited[i] = new bool[grid[0].Length];
        }

        int startX = -1, startY=-1;
        bool found = false;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    startX = i;
                    startY = j;
                    found = true;
                    break;
                }

            }
            if (found)
                break;
        }

        DFS(startX, startY);

        return perimeter;

    }

    private void DFS(int x, int y)
    {
        int perimeterCount = 0;

        visited[x][y] = true;

        for(int i=0; i<4; i++)
        {
            var direction = directions[i];
            int newX = x + direction[0];
            int newY = y + direction[1];

            if(newX<0 || newY<0 || newX>=data.Length || newY>=data[0].Length)
            {
                perimeterCount++;
            }
            else
            {
                if (data[newX][newY] == 0)
                    perimeterCount++;
                else
                {
                    //if newX/newY never visited
                    if (visited[newX][newY] == false)
                    {
                        DFS(newX, newY);
                    }
                }
            }
        }

        perimeter += perimeterCount;
    }
}