using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q328
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
        public ListNode OddEvenList(ListNode head)
        {
            ListNode currentNode = head;
            ListNode dummy = new ListNode(-1);
            ListNode dummyTail = dummy; ;

            while (currentNode != null)
            {
                ListNode evenNode = currentNode.next;

                if ( evenNode != null)
                {
                    ListNode nextOddNode = evenNode.next;

                    dummyTail.next = evenNode;
                    dummyTail = dummyTail.next;
                    //dummyTail.next = null;

                    //if next oddNode exists
                    if(nextOddNode!=null)
                    {
                        currentNode.next = nextOddNode;
                        currentNode = nextOddNode;
                    }
                    else //no more odd node
                    {
                        break;
                    }

                }
                else //currentNode is the last odd Node without EVEN follower;
                {
                    break;
                }


            }

            //point last odd noe to the first Even Node;
            currentNode.next = dummy.next;
            dummyTail.next = null;

            return head;

        }
    }
}
