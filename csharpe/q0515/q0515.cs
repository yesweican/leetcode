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
    public IList<int> LargestValues(TreeNode root) {
        List<int> result = new List<int>();
        Queue<TreeNode> queue = new Queue<TreeNode>();

        if(root == null)
            return result;
        queue.Enqueue(root);
        while(queue.Count>0) {
            int temp = queue.Count;
            int max = Int32.MinValue;
            for(int t=0; t<temp; t++) {
                TreeNode n = queue.Dequeue();
                if(max<n.val)
                    max = n.val;
                
                if(n.left!=null)
                    queue.Enqueue(n.left);
                if(n.right!=null)
                    queue.Enqueue(n.right);
            }
            result.Add(max);
        }

        return result;

    }
}