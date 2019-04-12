/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public bool HasCycle(ListNode head) {
             ListNode slow = head, fast = head;
            while ((slow != null) && (fast != null) && (fast.next != null)) 
            {
                slow = slow.next;
                fast = fast.next.next;
 
                // If slow and fast meet at same point then loop is present
                if (slow == fast) {
                    return true;
                }
            }
            return false;       
    }
}