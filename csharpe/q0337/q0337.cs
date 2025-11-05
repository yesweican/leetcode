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
    
    Dictionary<TreeNode, int> dp1;
    Dictionary<TreeNode, int> dp2;
    
    public int Rob(TreeNode root) {
        int result=0;
        if (root == null)
            return result;
        
        dp1 = new Dictionary<TreeNode, int>();
        dp2 = new Dictionary<TreeNode, int>();

        int temp1 = root.val + RobSubTree(true, root.left) + RobSubTree(true, root.right);
        int temp2 = RobSubTree(false, root.left) + RobSubTree(false, root.right);

        result = Math.Max(temp1, temp2);
        return result;       
    }
    
    private int RobSubTree(bool parentRobbed, TreeNode subRoot)
    {
    
        if (subRoot == null)
            return 0;
        
        if(parentRobbed)
        {
            if(dp1.Keys.Contains(subRoot))
            {
                return dp1[subRoot];
            }
        }
        else
        {
            if (dp2.Keys.Contains(subRoot))
            {
                return dp2[subRoot];
            }
        }

        int result = 0;

        if(parentRobbed)
        {
            int temp = 0;
            temp +=  (subRoot.left != null) ? RobSubTree(false, subRoot.left) : 0;
            temp +=  (subRoot.right != null) ? RobSubTree(false, subRoot.right) : 0;
            result = temp;
        }
        else
        {
            result = Math.Max(result, subRoot.val + RobSubTree(true, subRoot.left) + RobSubTree(true, subRoot.right));
            result = Math.Max(result, RobSubTree(false, subRoot.left) + RobSubTree(false, subRoot.right));
        }
        
        if (parentRobbed)
        {
            if (!dp1.Keys.Contains(subRoot))
            {
                dp1.Add(subRoot, result);
            }
        }
        else
        {
            if (!dp2.Keys.Contains(subRoot))
            {
                dp2.Add(subRoot, result);
            }
        }

        return result;    
    }
}