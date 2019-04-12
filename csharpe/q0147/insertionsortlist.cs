/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode InsertionSortList(ListNode head) {
            ListNode current, prev1, next1;
            ListNode temp, prev2, next2;

            if (head == null)
                return null; ;

            current = head;
            prev1 = current;
            current = current.next;
            next1=null;
            if(current!=null)
                next1 = current.next;
            prev2 = null; next2 = null;

            while (current != null)
            {
                temp = head;
                //find spot to insert
                while ((temp != next1) && (temp.val<=current.val))
                {
                    prev2 = temp;
                    temp = temp.next;
                    if(temp!=null)
                        next2 = temp.next;

                }

                if (temp == next1)
                {
                    //Nothing need to be done, 
                    prev1 = current;
                    current = current.next;
                    if(current!=null)
                        next1 = current.next;

                }
                else
                {
                    //temp.val > current.vall
                    if (temp == head)
                    {
                        //placed in front of head
                        current.next = head;
                        head = current;
                    }
                    else
                    {
                        //placed in the middle of list
                        prev2.next = current;
                        current.next = temp;
                    }
                    prev1.next = next1;
                    current = next1;
                    if(current!=null)
                        next1 = current.next;
                }
            }

            return head;      
    }
}