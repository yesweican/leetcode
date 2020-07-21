using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class q083
    {

        public class ListNode
        {
             public int val;
             public ListNode next;
             public ListNode(int val = 0, ListNode next = null)
             {
                this.val = val;
                this.next = next;
             }
          }

        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode current = head;
            int curval = current.val;

            while(current!=null)
            {
                ListNode nextNode = current.next;

                //skipping as many nodes as possible
                while(nextNode!=null && nextNode.val==curval)
                {
                    nextNode = nextNode.next;
                }

                //update the current val when needed
                if (nextNode != null)
                {
                    curval = nextNode.val;
                }

                current.next = nextNode;
                current = nextNode;
            }

            return head;
        }
    }
}
