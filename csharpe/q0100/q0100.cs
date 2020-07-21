using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{


    public class q100
    {

         public class TreeNode
        {
          public int val;
          public TreeNode left;
          public TreeNode right;
          public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
          {
                 this.val = val;
                 this.left = left;
                 this.right = right;
          }
        }

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            else
                if (p == null || q == null)
                    return false;


            if (p.val != q.val)
                return false;

            if ((p.left == null && q.left != null)|| (p.left != null && q.left == null))
                return false;

            if ((p.right == null && q.right != null) || (p.right != null && q.right == null))
                return false;

            bool step1 = true;
            if (p.left != null && q.left != null)
                step1 = IsSameTree(p.left, q.left);

            bool step2 = true;
            if (p.right != null && q.right != null)
                step2 = IsSameTree(p.right, q.right);

            return step1 && step2;
        }
    }
}
