/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    public Node Connect(Node root) {
        bft(root);
        
        return root;
    }
    
    void bft(Node root)
    {
        if(root==null)
            return;
        
        Queue<Node> queue=new Queue<Node>();
        queue.Enqueue(root);
        
        while(queue.Count>0)
        {
            int l = queue.Count;
            Node temp = queue.Dequeue();
            temp.next = null;
            if(temp.left!=null)
                queue.Enqueue(temp.left);
            if(temp.right!=null)
                queue.Enqueue(temp.right);
            
            if(l>1)
            {
                for(int i=1; i<l; i++)
                {
                    Node temp2 = queue.Dequeue();
                    if(temp2.left!=null)
                        queue.Enqueue(temp2.left);
                    if(temp2.right!=null)
                        queue.Enqueue(temp2.right);                    
                    
                    temp.next = temp2;
                    temp2.next = null;
                    temp=temp2;
                }  
            }
        }
    }
}