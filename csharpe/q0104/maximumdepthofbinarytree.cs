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
    int MaxDept= 0;
    public int MaxDepth(TreeNode root) {
            MaxDept = 0;
            if (root == null)
                return 0;

            MaxDeptProbe(root, 0);
            Console.WriteLine();
            return MaxDept;     
    }
 
        public void MaxDeptProbe(TreeNode root, int level)
        {
            if (root.left != null)
                MaxDeptProbe(root.left, level + 1);
            if (root.right != null)
                MaxDeptProbe(root.right, level + 1);

            if ((root.left == null) && (root.right == null))
            {
                if ((level + 1) > MaxDept)
                    MaxDept = level + 1;
            }
        }
    
}