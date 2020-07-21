using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q124
    {
        int Result = int.MinValue;
        public int MaxPathSum(TreeNode root)
        {
            int test = LegSum(root);
            return Result;
        }

        public int LegSum(TreeNode root)
        {
            if ((root.left == null) && root.right == null)
                return root.val;

            int leftsum = int.MinValue;
            int rightsum = int.MinValue;

            if(root.left!=null)
            {
                leftsum = LegSum(root.left);
            }
            if(root.right!=null)
            { 
                rightsum = LegSum(root.right)
            }

            if (leftsum > Result)
                Result = leftsum;
            if (rightsum > Result)
                Result = rightsum;
            if(root.val>Result)
                Result = root.val;

            if(root.val>0)
            {
                if ((root.val + leftsum) > Result)
                    Result = root.val + leftsum;
                if ((root.val + rightsum) > Result)
                    Result = root.val + rightsum;
            }


            //test the long path
            if ((root.left != null) && (root.right != null))
            {
                int temp = root.val+leftsum+ rightsum;
                if (temp > Result)
                    Result = temp;
            }

            //but return the one leg value;
            if (leftsum > rightsum)
                return root.val+ leftsum;
            else
                return root.val+ rightsum;

        }
    }
}
