public class Solution {
    int [][] buffer;
    public int MaxSumSubmatrix(int[][] matrix, int k) {
        int height=matrix.Length;
        int width = matrix[0].Length;
        
        buffer = new int[height][];
        for(int i=0; i<height; i++)
        {
            buffer[i] = new int[width];
        }
        
        buffer[0][0]=matrix[0][0];
        for(int i=1; i<height; i++)
        {
           buffer[i][0]=buffer[i-1][0]+matrix[i][0];
        }
        for(int i=1; i<width; i++)
        {
           buffer[0][i]=buffer[0][i-1]+matrix[0][i];
        }
        
        for(int i=1; i<height; i++)
        {
            for(int j=1; j<width; j++)
            {
                buffer[i][j] = buffer[i-1][j]+buffer[i][j-1]-buffer[i-1][j-1]+matrix[i][j];
            }
        }
        
        int maxArea=Int32.MinValue;
        int area = -1;
        
        for(int x=0; x<height;x++)
        {
            for(int x2=x;x2<height; x2++)
            {
                for(int y=0; y<width;y++)
                {
                    for(int y2=y;y2<width; y2++)
                    {
                        //area = buffer[x2][y2]-buffer[x2][y]-buffer[x][y2]+buffer[x][y];
                            area = buffer[x2][y2];
                            if (y > 0)
                                area -= buffer[x2][y - 1];
                            if (x > 0)
                                area -= buffer[x - 1][y2];
                            if(x>0 && y>0)
                                area += buffer[x-1][y-1];
                        if(area<=k)
                        {
                            if(area>maxArea)
                                maxArea = area;
                        }
                    }
                }              
            }
        }
        
        return maxArea;
        
    }
}