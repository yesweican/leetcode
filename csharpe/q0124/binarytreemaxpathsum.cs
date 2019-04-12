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
        int Result = Int32.MinValue;
    public int MaxPathSum(TreeNode root) {
            Result = Int32.MinValue;
            if (root == null)
                return 0;

            int singlepath = MaxPathSumProbe(root);
            Console.WriteLine();
            return Result;        
    }
    
        public int MaxPathSumProbe(TreeNode root)
        {
            int temp = 0;
            int leftpathsum = 0;
            int rightpathsum = 0;
            if (root.left != null)
                leftpathsum = MaxPathSumProbe(root.left);
            if (root.right != null)
                rightpathsum = MaxPathSumProbe(root.right);

            temp = leftpathsum > 0 ? temp+leftpathsum: temp;
            temp = rightpathsum > 0 ? temp + rightpathsum : temp;
            if (Result < (root.val + temp))
                Result = root.val + temp;

            if ((root.left == null) && (root.right == null))
            {
                return root.val;
            }
            else
            {
                return leftpathsum>rightpathsum? (leftpathsum>0? root.val+leftpathsum:root.val):(rightpathsum>0?rightpathsum+root.val:root.val);
            }
        }
    
    
}