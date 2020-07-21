using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }

    public class q138
    {
        public Node CopyRandomList(Node head)
        {
            Dictionary<Node, Node> dict = new Dictionary<Node, Node>();
            if (head == null)
                return null;
            
            Node curr = head;
            Node dummy = new Node(-1);
            Node curr2 = dummy;

            while(curr!=null)
            {
                Node temp = new Node(curr.val);
                curr2.next = temp;
                dict.Add(curr, temp);//should we go the other way?

                curr2 = temp;
                curr = curr.next;
            }

            //fixing up the random pointer;
            curr = head;
            while(curr!=null)
            {
                Node random = curr.random;
                Node newNode = dict[curr];

                if(random!=null)
                {
                    newNode.random = dict[random];
                }

                curr = curr.next;
            }

            dummy = dummy.next;
            return dummy;
        }

    }
}
