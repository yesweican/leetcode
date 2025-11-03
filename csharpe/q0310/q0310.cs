public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
        V = n;
        adj = new List<int>[ n ];
        degree = new List<int>();
        for (int i = 0; i < n; i++) {
            adj[i] = new List<int>();
            degree.Add(0);
        }

        for(int j=0; j<edges.Length; j++) {
            AddEdge(edges[j][0], edges[j][1]);
        }

        return (IList<int>) RootForMinimumHeight();
    }

    private int V; // No. of vertices
 
    // Pointer to an array containing adjacency lists
    private List<int>[] adj;
 
    // List which stores degree of all vertices
    private List<int> degree;
 
    public void AddEdge(int v, int w) // To add an edge
    {
        adj[v].Add(w); // Add w to v’s list
        adj[w].Add(v); // Add v to w’s list
        degree[v]++; // increment degree of v by 1
        degree[w]++; // increment degree of w by 1
    }
 
    // function to get roots which give minimum height
    public List<int> RootForMinimumHeight()
    {
        Queue<int> q = new Queue<int>();
 
        // first enqueue all leaf nodes in queue
        for (int i = 0; i < V; i++) {
            if (degree[i] <= 1)
                q.Enqueue(i);
        }
 
        // loop until total vertex remains less than 2
        while (V > 2) {
            int popEle = q.Count;
            V -= popEle; // popEle number of vertices will
                         // be popped
 
            for (int i = 0; i < popEle; i++) {
                int t = q.Dequeue();
 
                // for each neighbour, decrease its degree
                // and if it become leaf, insert into queue
                foreach(int j in adj[t])
                {
                    degree[j]--;
                    if (degree[j] == 1)
                        q.Enqueue(j);
                }
            }
        }
 
        // copying the result from queue to result List
        List<int> res = new List<int>();
        while (q.Count > 0) {
            res.Add(q.Dequeue());
        }
        return res;
    }
}