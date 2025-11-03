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
public class Solution
{

    private List<IList<int>> result = new List<IList<int>>();
    int[] buffer;
    public IList<IList<int>> PathSum(TreeNode root, int targetSum)
    {
        result = new List<IList<int>>();
        buffer = new int[5001];

        DFSTraversal(root, targetSum, 0, 0);

        return result;

    }

    private void DFSTraversal(TreeNode root, int targetSum, int level, int pathSum)
    {
        if (root == null)
            return;

        buffer[level] = root.val;

        int newSum = pathSum + root.val;

        //if root is leaf and check PathSum
        if (root.left == null && root.right == null)
        {
            if (newSum == targetSum)
            {
                List<int> newPath = new List<int>();
                for(int i=0; i<=level; i++)
                {
                    newPath.Add(buffer[i]);
                }
                result.Add(newPath);                
            }

            return;
        }

        if (root.left != null)
        {
            DFSTraversal(root.left, targetSum, level + 1, newSum);
        }

        if (root.right != null)
        {
            DFSTraversal(root.right, targetSum, level + 1, newSum);
        }

    }
}