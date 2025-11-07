public class Solution {
    public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)  
    {
        int n = profits.Length;
        int[] data= new int[n];
        for(int i=0; i<n; i++)
        {
            data[i] = i;
        }
        //sort projects by capital requirement
        var ordered = data.OrderBy(x=>capital[x]).ToArray();

        PriorityQueue<int, int> que = new PriorityQueue<int, int>();
        int pos = 0;

        for(int j=0; j<k; j++)
        {
            int origindex;
            //adding projects from ordered to que
            while(pos<n && capital[ordered[pos]]<=w)
            {
                origindex = ordered[pos];
                //the smaller the proirity closer to the front                
                que.Enqueue(origindex, -profits[origindex]);
                pos++;
            }

            if(que.Count==0)
                break;

            var best = que.Dequeue();
            w += profits[best];
        } 

        return w;
    }
}