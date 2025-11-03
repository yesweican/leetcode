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
        if (root == null) return null;

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);

        while(queue.Count>0)
        {
            int countNode = queue.Count;
            Node previous = null;
            while(countNode>0)
            {
                Node temp = queue.Dequeue();
                if(previous!=null) previous.next = temp;
                    countNode--;
                if(temp.left!=null) queue.Enqueue(temp.left);
                if(temp.right!=null) queue.Enqueue(temp.right);
                    previous = temp;
            }
        }
        return root;       
    }
}