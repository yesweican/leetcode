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
    int total;
    public int SumNumbers(TreeNode root) {
        total = 0;
        processNode(0, root);

        return total;
    }

    private void processNode(int prefixVal, TreeNode r)
    {
        int temp = prefixVal * 10+r.val;

        if(r.left==null && r.right==null)
        {
            total += temp;
        }
        else
        {
            if(r.left!=null)
                processNode(temp, r.left);
            if(r.right!=null)
                processNode(temp, r.right);
        }
    }
}