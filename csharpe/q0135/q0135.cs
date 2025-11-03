public class Solution {
    public int Candy(int[] ratings) {
        int l = ratings.Length;
        int[] heights = new int[l];

       
        heights[0] = 1;
        for (int i=1; i<l; i++)
        {
            heights[i]=1;
            if(ratings[i]>ratings[i-1])
                heights[i] = Math.Max(1, heights[i-1]+1);
        } 

        int total = heights[l-1];
        for(int i=l-2; i>=0; i--)
        {
            if(ratings[i]>ratings[i+1])
                heights[i] = Math.Max(heights[i], heights[i+1]+1);

            total += heights[i];
        }

        return total; 
    }
}