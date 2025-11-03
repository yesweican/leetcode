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
    int[] data;
    public TreeNode SortedArrayToBST(int[] nums) {
        data = nums;
        return processToBST(0, nums.Length-1);
    }

    private TreeNode processToBST(int start, int end)
    {
        if(start==end)
            return new TreeNode(data[start]);

        int mid = (start + end)/2;
        TreeNode root = new TreeNode(data[mid]);
        if(start<mid)
            root.left = processToBST(start, mid-1);
        if(mid<end)
            root.right = processToBST(mid+1, end);
        return root;
    }
}