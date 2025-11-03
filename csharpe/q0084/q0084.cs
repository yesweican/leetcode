public class Solution
{
    public int LargestRectangleArea(int[] heights)
    {
        int maxArea = Int32.MinValue;
        int[] newHeights = new int[heights.Length+2];

        Array.Copy(heights, 0, newHeights, 1, heights.Length);

        Stack<int> stack = new Stack<int>();

        for(int i=0; i<newHeights.Length; i++)
        {
            if(stack.Count==0)
            {
                stack.Push(i);
            }
            else
            {
                int currentHeight = newHeights[i];
                int currentTopIndex = stack.Peek();
                int currentTopValue = newHeights[currentTopIndex];

                while(currentHeight < currentTopValue)
                {
                    ////New to Pop out
                    int height = currentTopValue; 
                    stack.Pop();
                    currentTopIndex = stack.Peek();
                    currentTopValue = newHeights[currentTopIndex];

                    int area = height * (i - currentTopIndex - 1);

                    if (area > maxArea)
                        maxArea = area;
                }

                if(currentHeight == currentTopValue)
                {
                    stack.Pop();
                }

                stack.Push(i);

            }

        }

        return maxArea!=Int32.MinValue?maxArea:0;
    }

}