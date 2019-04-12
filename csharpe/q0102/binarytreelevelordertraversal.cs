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
    
    List<IList<int>> results2 = new List<IList<int>>();   
    public IList<IList<int>> LevelOrder(TreeNode root) {
        
        if(root!=null)
        {
            ArrayList l = new ArrayList();
            l.Add(root);
            DoLevelTraversal(l);           
        }

            return (IList<IList<int>>)results2;      
    }
 
    public void DoLevelTraversal(ArrayList lastLevelNodes)
    {
            ArrayList currentLevel = new ArrayList();
            if (lastLevelNodes.Count == 0)
                return;

            List<int> temp = new List<int>();

            foreach (TreeNode node in lastLevelNodes)
            {
                temp.Add(node.val);

                if (node.left != null)
                    currentLevel.Add(node.left);
                if (node.right != null)
                    currentLevel.Add(node.right);
            }

            results2.Add((IList<int>)temp);

            DoLevelTraversal(currentLevel);

            return;
   }
    
}