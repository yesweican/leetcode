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

///// The advantage of this solution is its readability
public class Solution {
    public List<TreeNode> nodeList = null;
    public void RecoverTree(TreeNode root)
    {
        nodeList = new List<TreeNode>();

        InOrderTraversal(root);

        TreeNode firstNode = null;
        TreeNode secondNode = null;

        for (int i = 0; i < nodeList.Count; i++)
        {
            if (nodeList[i].val > nodeList[i + 1].val)
            {
                firstNode = nodeList[i];
                break;
            }
        }

        for (int i = nodeList.Count-1; i>=0 ; i--)
        {
            if (nodeList[i].val < nodeList[i - 1].val)
            {
                secondNode = nodeList[i];
                break;
            }
        }

        int temp = firstNode.val;
        firstNode.val = secondNode.val;
        secondNode.val = temp;

    }

    private void InOrderTraversal(TreeNode root)
    {
        //if (root == null)
        //    return;

        if (root.left != null)
            InOrderTraversal(root.left);

        nodeList.Add(root);

        if (root.right != null)
            InOrderTraversal(root.right);

    }
}