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
    public int SumOfLeftLeaves(TreeNode root) {
        int localSum = 0;
        if(root.left==null && root.right==null) {
            return 0;
        }

        if(root.left!=null) {
            localSum +=sumOfLeftLeaves2(root.left, true);
        } 
        
        if(root.right!=null) {
            localSum +=sumOfLeftLeaves2(root.right, false);
        }

        return localSum;
    }
    private int sumOfLeftLeaves2(TreeNode root, bool beLeft) {
        int localSum = 0;
        if(root.left==null && root.right==null) {
            if(beLeft)
                return root.val;
            else
                return 0;
        }

        if(root.left!=null) {
            localSum +=sumOfLeftLeaves2(root.left, true);
        } 
        
        if(root.right!=null) {
            localSum +=sumOfLeftLeaves2(root.right, false);
        }

        return localSum;
    }    
}