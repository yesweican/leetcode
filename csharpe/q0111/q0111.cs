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
public class Solution {
    int min;
    public int MinDepth(TreeNode root) {
       if(root == null)
          return 0;

       min = Int32.MaxValue;
       DFS(root, 1);

       return min;      
    }

    private void DFS(TreeNode r, int level)
    {
        if (r.left == null && r.right == null)
        {
            if(min>level)
                min = level;
            return;
        }

        if(r.left != null)
        {
            DFS(r.left, level+1);
        }

        if(r.right != null)
        {
            DFS(r.right, level+1);
        }
    }
}