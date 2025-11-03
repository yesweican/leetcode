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
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode dummy = new ListNode(-1);
            dummy.next = head;
            bool toContinue = true;
            ListNode beginningNode = head; ;
            ListNode lastTail = dummy;
            ListNode trailingNode = null;

            while(toContinue)
            {
                ListNode current = beginningNode;
                toContinue = false;
                int counter = 0;
                Stack<ListNode> stack = new Stack<ListNode>();
                while(counter<k && current!=null)
                {
                    stack.Push(current);
                    current = current.next;
                    counter++;
                }

                if(counter == k)
                {
                    trailingNode = current;
                    //reverse the k-node group
                    while(stack.Count>0)
                    {
                        ListNode temp = stack.Pop();
                        lastTail.next = temp;
                        temp.next = null;
                        lastTail = temp;
                    }

                    beginningNode = trailingNode;
                    toContinue = true;
                }
                else
                {
                    lastTail.next = beginningNode;
                }
            }

            dummy = dummy.next;
            return dummy;
        }
}