using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class q138a
    {
        public Node CopyRandomList(Node head)
        {
            if (head == null)
                return null;

            Node dummy = new Node(-1);
            //dummy.next = head;

            Node current = head;
            while(current!=null)
            {
                Node newNode = new Node(current.val);
                newNode.next = current.next;
                current.next = newNode;
                //current->clone->current.next
                current = newNode.next;
            }

            //fixing the random pointers
            current = head;
            while(current!=null)
            {
                Node temp = current.next;
                if(current.random!=null)
                {
                    Node random = current.random;
                    temp.random = random.next;
                }

                current = temp.next;
            }

            //splitting the mixed up linked list
            current = head;
            Node current2 = head.next;
            dummy.next = current2;

            while(current!=null)
            {
                Console.WriteLine(current.val);
                if(current2.next!=null)
                {
                    Node N1 = current2.next;
                    Node N2 = current2.next.next;
                    current.next = N1;
                    current2.next = N2;
                    current = N1;
                    current2 = N2;
                }
                else
                {
                    current.next = null;
                    current2.next = null;
                    //don't forget following
                    current = null;
                    current2 = null;
                }
            }

            dummy = dummy.next;
            return dummy;
        }
    }
}
