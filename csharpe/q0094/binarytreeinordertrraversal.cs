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
    
    List<int> results = new List<int>();
    public IList<int> InorderTraversal(TreeNode root) {
            DoInorderTraversal(root);
            return results;       
    }
    
        public void DoInorderTraversal(TreeNode root)
        {
            if(root==null)
                return;

            DoInorderTraversal(root.left);

            results.Add(root.val);
            
            DoInorderTraversal(root.right);

            return;
        }    
}