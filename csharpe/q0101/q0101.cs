using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int x) { val = x; }
     * }
     */

    public class q101
    {
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;

            return Compare(root.left, root.right);
        }

        private bool Compare(TreeNode leftchild, TreeNode rightchild)
        {
            if (leftchild == null && rightchild == null)
                return true;

            if (leftchild != null && rightchild != null)
            {
                if (leftchild.val == rightchild.val)
                {
                    return Compare(leftchild.right, rightchild.left) && Compare(leftchild.left, rightchild.right);
                }
            }

            return false;
        }
    }
}
