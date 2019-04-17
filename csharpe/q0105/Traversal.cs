using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConstructBinaryTreeApp
{
    public class Traversal
    {
        public void InOrder(TreeNode t)
        {
            if (t.left != null)
            {
                InOrder(t.left);
            }
            Console.Write(t.val);
            if (t.right!=null)
            {
                InOrder(t.right);
            }
        }

        public void PreOrder(TreeNode t)
        {
            Console.Write(t.val);
            if (t.left != null)
            {
                PreOrder(t.left);
            }
            if (t.right != null)
            {
                PreOrder(t.right);
            }
        }
    }
}
