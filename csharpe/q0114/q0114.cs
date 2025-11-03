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
    
    List<TreeNode> buffer; 
    
    public void Flatten(TreeNode root) {
        
        if(root == null) return;
        
        
        buffer = new List<TreeNode>();
        preorder(root);
        
        //root is buffer[0];
        TreeNode last = root;
        for(int i=1; i<buffer.Count; i++)
        {
            last.right = buffer[i];
            last.left = null;
            last = buffer[i];
        }
    }
    
    private void preorder(TreeNode root)
    {
        buffer.Add(root);
        
        if(root.left!=null)
            preorder(root.left);
        
        if(root.right!=null)
            preorder(root.right);
    }
}