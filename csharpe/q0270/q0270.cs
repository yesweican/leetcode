using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{

    public class TreeNode 
    {
       public int val;
       public TreeNode left;
       public TreeNode right;
       public TreeNode(int x) { val = x; }
    }
    public class q270
    {
        public int ClosestValue(TreeNode root, double target)
        {

            double gap = double.MaxValue;
            int closest = -1;

            ///We don't need recursion here...
            while (root!=null)
            {
                if (Math.Abs(root.val - target) < gap)
                {
                    gap = Math.Abs(root.val - target);
                    closest = root.val;
                }

                if (target == root.val)
                    break;
                else
                {
                    if (target < root.val)
                    {
                        root = root.left;
                    }
                    else
                    {
                        root = root.right;
                    }
                }

            }

            return closest;

        }
    }
}
