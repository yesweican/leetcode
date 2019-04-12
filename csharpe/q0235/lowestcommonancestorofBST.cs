/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode n1, TreeNode n2) {
            if (root == null)
                return null;

            // If both n1 and n2 are smaller than root, then LCA lies in left
            if (root.val > n1.val && root.val > n2.val)
                return LowestCommonAncestor(root.left, n1, n2);

            // If both n1 and n2 are greater than root, then LCA lies in right
            if (root.val < n1.val && root.val < n2.val)
                return LowestCommonAncestor(root.right, n1, n2);

            //// n1 < root < n2
            return root;        
    }
}