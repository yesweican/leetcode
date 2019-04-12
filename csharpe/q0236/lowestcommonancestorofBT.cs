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
             // Base case
            if (root == null)
                return null;

            // If either n1 or n2 matches with root, report
            // the presence by returning root (Note that if a key is
            // ancestor of other, then the ancestor key becomes LCA
            if (root == n1 || root == n2)
                return root;

            // Look for keys in left and right subtrees
            TreeNode left_lca = LowestCommonAncestor(root.left, n1, n2);
            TreeNode right_lca = LowestCommonAncestor(root.right, n1, n2);

            // If both of the above calls return Non-NULL, then one key
            // is present in once subtree and other is present in other,
            // So this node is the LCA
            if (left_lca != null && right_lca != null)
                return root;

            // Otherwise check if left subtree or right subtree is LCA
            return (left_lca != null) ? left_lca : right_lca;       
    }
}