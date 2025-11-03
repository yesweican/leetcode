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
    bool result = true;

    public bool IsBalanced(TreeNode root) {
        if(root==null)
            return true;

        HeightOfTree(root);

        return result; 
    }

    private int HeightOfTree(TreeNode root) {
        if(result==false || root==null)
            return 0;
        int n1 = 0, n2 = 0;

        if(root.left!=null)
            n1=HeightOfTree(root.left);
        
        if(root.right!=null)
            n2=HeightOfTree(root.right);

        int d = n1>=n2? n1-n2: n2-n1;
        if(d>1)
            result = false;

        int temp = n1>=n2?n1+1:n2+1;

        return temp;
    }
}