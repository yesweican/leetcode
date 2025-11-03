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
    Stack<ListNode> stack1;
    Stack<ListNode> stack2;

    public ListNode SortList(ListNode head)
    {
        stack1 = new Stack<ListNode>();
        stack2 = new Stack<ListNode>();

        ListNode current = head;
        while (current != null)
        {
            ProcessNode(current);
            current = current.next;
        }
            
        ListNode top = null;
        while(stack1.Count>0)
        {
            ListNode temp = stack1.Pop();
            temp.next = top;
            top = temp;
        }
            
        return top;
    }

    private void ProcessNode(ListNode node)
    {
        Console.WriteLine(stack1.Count.ToString());
        if (stack1.Count == 0) {
            stack1.Push(node);
            return;
        }

        ListNode top = stack1.Peek();// Count>0
        while ((top != null) && (top.val > node.val)) {
            ListNode temp = stack1.Pop();
            stack2.Push(temp);
            if (stack1.Count > 0)
                top = stack1.Peek();
            else
                top = null;
        }

        stack1.Push(node);

        while (stack2.Count > 0) {
            ListNode temp = stack2.Pop();
            stack1.Push(temp);
        }
    }
}