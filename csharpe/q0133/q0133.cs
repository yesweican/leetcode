/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    Dictionary<Node, Node> NodeMap;


    public Node CloneGraph(Node node)
    {
        if (node == null)
            return null;
        NodeMap = new Dictionary<Node, Node>();

        return BFS(node);
    }

    private Node BFS(Node node)
    {
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(node);

        Node newNode = new Node(node.val);
        NodeMap.Add(node, newNode);

        while(queue.Count>0)
        {
            int temp = queue.Count;

            List<Node> list = new List<Node>();
            for(int i=0; i<temp;i++)
            {
                list.Add(queue.Dequeue());  
            }

            foreach(var v in list)
            {
                Node mapped = NodeMap[v];
                foreach(var c in v.neighbors)
                {
                    if(NodeMap.Keys.Contains(c))
                    {
                        if(!mapped.neighbors.Contains(NodeMap[c]))
                            mapped.neighbors.Add(NodeMap[c]);//only if necessary
                        continue;
                    }
                    else
                    {
                        Node newC = new Node(c.val);
                        mapped.neighbors.Add(newC); //always here?
                        NodeMap.Add(c, newC);
                        queue.Enqueue(c);
                    }
                }
            }

        }

        return newNode;

    }
}