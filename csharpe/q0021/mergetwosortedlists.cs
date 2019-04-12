/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
             ListNode head1=l1; ListNode curr1 = head1;
            ListNode head2=l2; ListNode curr2 = head2; 
            ListNode prev = null;
        
        if(l2==null)
            return l1;

            while (curr1!=null)
            {
                bool bInserted = false;
                while(curr2!=null)
                {
                    if(curr1.val<curr2.val)
                    {
                        //insert curr1;
                        if(curr2==head2)
                        {
                            //insert in the very front
                            head1 = curr1.next;
                            curr1.next=curr2;
                            head2 = curr1;
                        }
                        else
                        {
                            //insert in the middle
                            head1=curr1.next;
                            prev.next=curr1;
                            curr1.next=curr2;
                        }
                        bInserted=true;
                        //newly inserted became the previous node
                        prev=curr1;
                        break;
                    }

                    prev=curr2;
                    curr2=curr2.next;

                }

                if (bInserted==false)
                {
                    //if curr1 is greater then each one of the second list
                    prev.next = curr1;
                    head1 = null;
                    break;
                }
              
                curr1=head1;
            }

            return head2;       
    }
}