using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConstructBinaryTreeApp
{
    public class Traversal2
    {
        public void PostOrder(TreeNode root)
        {
            List<int> results = new List<int>();

            if (root == null)
            {
                //return results;
                return;
            }

            Stack s1 = new Stack();
            Stack s2 = new Stack();

            s1.Push(root);

            while (s1.Count > 0)
            {
                TreeNode temp = (TreeNode)s1.Pop();

                s2.Push(temp);

                if (temp.left != null)
                    s1.Push(temp.left);
                if (temp.right != null)
                    s1.Push(temp.right);
            }

            while(s2.Count>0)
            {
                TreeNode temp = (TreeNode)s2.Pop();
                results.Add(temp.val);
                Console.Write(temp.val);
            }
        }
    }
}
