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
    List<int> result;
    public IList<int> PreorderTraversal(TreeNode root) {
        result = new List<int>();
        if(root!=null)
            Traversal(root);
        return result;

    }

    private void Traversal(TreeNode root)
    {
        result.Add(root.val);
        if(root.left!=null)
            Traversal(root.left);
        if(root.right!=null)
            Traversal(root.right);
    }
}