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
    List<TreeNode> sortedList = new List<TreeNode>();
    public int[] FindMode(TreeNode root) {
        process(root);

        int current = sortedList[0].val;
        int running = 1, maxRunning = 1;
        List<int> result = new List<int>();
        result.Add(current);

        for(int i=1; i<sortedList.Count; i++) {
            TreeNode next = sortedList[i];
            if(next.val == current) {
                running++;


            } else {
                current = next.val;
                running = 1;
            }


            if(running>maxRunning) {
                result = new List<int>();
                result.Add(current);
                maxRunning = running;                    
            } else {
                if(running == maxRunning) {
                    result.Add(current);
                }
            }

        }
        return result.ToArray();
    }

    private void process(TreeNode r){
        if(r.left!=null) {
            process(r.left);
        }
        sortedList.Add(r);
        if(r.right!=null) {
            process(r.right);
        }
    }
}