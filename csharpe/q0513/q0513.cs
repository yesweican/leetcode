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
    public int FindBottomLeftValue(TreeNode root) {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        int level = 0;
        queue.Enqueue(root);
        int lastLevelFirst=root.val;// = root.val;

        while(queue.Count>0) {
            int temp = queue.Count;
            List<TreeNode> currentList = new List<TreeNode>();

            for(int i=0; i<temp; i++) {
                TreeNode node = queue.Dequeue();
                currentList.Add(node);
            }

            //adding next level
            for(int j=0; j<currentList.Count; j++) {
                if(currentList[j].left!=null)
                    queue.Enqueue(currentList[j].left);
                if(currentList[j].right!=null)
                    queue.Enqueue(currentList[j].right);
            }

            lastLevelFirst = currentList[0].val;
        }
        return lastLevelFirst;
    }
}