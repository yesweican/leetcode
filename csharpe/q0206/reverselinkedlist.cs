/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode ReverseList(ListNode head) {
        
            ListNode currentNode = head;
            ListNode lastNode = null, nextNode = null;
            ListNode newTail = null, newHead = null;

            while (currentNode != null)
            {
                if (currentNode == head)
                {
                    newTail = currentNode;
                    nextNode = currentNode.next;
                    lastNode = currentNode;
                    lastNode.next = null;
                    currentNode = nextNode;
                    //what if head is also tail
                    if (currentNode == null)
                    {
                        newHead = lastNode;
                        break;
                    }
                }
                else
                {
                    //at the Tail end?
                    if (currentNode.next == null)
                    {
                        newHead = currentNode;
                        currentNode.next = lastNode;
                        currentNode= null;
                    }
                    else //not at the tail
                    {
                        nextNode = currentNode.next;
                        currentNode.next = lastNode;
                        lastNode = currentNode;
                        currentNode = nextNode;
                    }
                }

            }

            return newHead;      
    }
}