using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q543
    {
        int maxLength=0;

        public int DiameterOfBinaryTree(TreeNode root)
        {
            int test = BranchLength(root);
            return maxLength;

        }

        private int BranchLength(TreeNode root)
        {
            if (root == null)
                return 0;

            int temp = 0;
            int leftbranch = 0;
            int rightbranch = 0;
            if(root.left!=null)
            {
                leftbranch = BranchLength(root.left);
                if (temp < leftbranch)
                    temp = leftbranch;
            }
            if (root.right != null)
            {
                rightbranch = BranchLength(root.right);
                if (temp < rightbranch)
                    temp = rightbranch;
            }

            if (maxLength < (leftbranch + rightbranch))
                maxLength = (leftbranch + rightbranch);

            return temp + 1;

        }
    }
}
