/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class BSTIterator {
    
    public List<TreeNode> nodeList = null;
    private int current = -1;
    public BSTIterator(TreeNode root) {
        nodeList = new List<TreeNode>();
        
        InOrderTraversal(root);
    }
    
    public int Next() {
        if(current == -1)
        {
            current = 0;
            return nodeList[0].val;            
        }
        else
        {
            current ++;
            return nodeList[current].val;
        }
    }
    
    public bool HasNext() {
        if(nodeList.Count>0 && current<(nodeList.Count-1))
            return true;
        return false;
    }
    
    private void InOrderTraversal(TreeNode root)
    {
        //if (root == null)
        //    return;

        if (root.left != null)
            InOrderTraversal(root.left);

        nodeList.Add(root);

        if (root.right != null)
            InOrderTraversal(root.right);

    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */