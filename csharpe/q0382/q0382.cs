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
public class Solution {
    Random r;
    ListNode root;
    public Solution(ListNode head) {
        r = new Random();
        root = head;
    }
    
    public int GetRandom() {
        double d = r.NextDouble();
        int target = (int)(d * Count());

        ListNode current = root;
        while(target>0)
        {
            target--;
            current=current.next;
        }

        return current.val;
    }

    private int Count()
    {
        int count = 0;
        ListNode current = root;
        while(current!=null)
        {
            count++;
            current = current.next;
        }
        return count;
    }

}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(head);
 * int param_1 = obj.GetRandom();
 */