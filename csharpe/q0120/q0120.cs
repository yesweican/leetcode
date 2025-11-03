public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) {
        int N = triangle.Count;
        int[] buffer1 = new int[N];
        int[] buffer2 = new int[N];

        buffer1[0] = triangle[0][0];
        for(int i=1; i<N; i++)
        {
            for(int j=0;j<=i; j++)
            {
                if(j==0) {
                    buffer2[j] = buffer1[j] + triangle[i][0];
                }
                else
                {
                    if (j == i)
                    {
                        buffer2[j] = buffer1[j-1] + triangle[i][j];
                    }
                    else
                    {
                        buffer2[j] = Math.Min(buffer1[j - 1], buffer1[j]) + triangle[i][j];
                    }
                }
            }

            int[] temp = buffer1;
            buffer1 = buffer2;
            buffer2 = temp;
        }

        int result = Int32.MaxValue;
        for(int i=0; i<N; i++)
        {
            if (result > buffer1[i])
                result = buffer1[i];
        }

        return result;
    }
}