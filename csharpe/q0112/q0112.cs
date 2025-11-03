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
    public bool HasPathSum(TreeNode root, int targetSum) {
        if(root==null)
             return false;
        
        if(root.left == null && root.right==null)
        { 
            if(root.val == targetSum)
                return true;
            return false;
            
        }
        
        bool temp1 = false;
        if(root.left != null)
            temp1 = HasPathSum(root.left, targetSum - root.val);
        bool temp2 = false;
        if(root.right != null)
            temp2 = HasPathSum(root.right, targetSum - root.val);
        
        return temp1||temp2;
    }
}