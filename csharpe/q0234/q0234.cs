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
    public bool IsPalindrome(ListNode head) {
        List<int> list1 = new List<int>();
        ListNode current = head;
        
        while(current!=null)
        {
            list1.Add(current.val);
            current=current.next;
        }
        
        int left = 0; int right = list1.Count-1;
        
        while(left < right)
        {
            if (list1[left]!=list1[right])
            {
                return false;
            }
            left++;
            right--;
        }
        
        return true;
        
    }
}