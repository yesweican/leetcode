/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
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
    List<ListNode> data;
    public TreeNode SortedListToBST(ListNode head)
    {
        if(head==null)
            return null;

        data = new List<ListNode>();
        ListNode current = head;
        while (current!= null)
        {
            data.Add(current);
            current=current.next;
        }

        return processToBST(0, data.Count - 1);
    }

    private TreeNode processToBST(int start, int end)
    {
        if (start == end)
            return new TreeNode(data[start].val);

        int mid = start + (end-start+1) / 2;
        TreeNode root = new TreeNode(data[mid].val);
        if (start < mid)
            root.left = processToBST(start, mid - 1);
        if (mid < end)
            root.right = processToBST(mid + 1, end);
        return root;
    }
}