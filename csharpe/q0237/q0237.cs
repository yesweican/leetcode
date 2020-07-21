using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
  
     public class ListNode
    {
       public int val;
       public ListNode next;
       public ListNode(int x) { val = x; }
     }

    public class q237
    {
        public void DeleteNode(ListNode node)
        {
            ListNode current = node;
            node = node.next;
            while(node!=null)
            {
                current.val = node.val;
                ListNode temp = node.next;

                if (temp != null)
                {
                    current = node;
                    node = temp;
                }
                else
                {
                    current.next = null;
                    break;
                }

            }
        }


    }
}
