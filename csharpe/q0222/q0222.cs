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
    int treeMaxHeight = 0;
    int nodeCountMaxLevel = 0;
    bool stop = false;
    Dictionary<int, int> powerOfTwo = null;    
    public int CountNodes(TreeNode root) {
        if(root==null)
            return 0;
                
        treeMaxHeight = 0;
        nodeCountMaxLevel = 0;
        stop = false;
        powerOfTwo = new Dictionary<int, int>();
        powerOfTwo.Add(0, 1);
    
        dfs(root,1);
         Console.WriteLine(treeMaxHeight);
        return (powerOfTwo[treeMaxHeight - 1] - 1 + nodeCountMaxLevel);
        
    }
    
    private void dfs(TreeNode node, int level)
    {
        if(!powerOfTwo.Keys.Contains(level))
        {
            powerOfTwo.Add(level, powerOfTwo[level - 1] * 2);
        }

        if(node.left == null & node.right == null)
        {
            if (treeMaxHeight == 0)
            {
                treeMaxHeight = level;
                Console.WriteLine(level);
            }


            if (treeMaxHeight != 0 && treeMaxHeight == level)
                nodeCountMaxLevel++;

            return;
        }

        if (node.left != null)
            dfs(node.left, level + 1);
        else
        {
            if(level<treeMaxHeight)
            {
                stop = true;
            }
        }

        if (stop == false && node.right != null)
            dfs(node.right, level + 1);
    }
}