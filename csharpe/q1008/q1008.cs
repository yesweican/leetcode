using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q1008
    {
       public class TreeNode {
           public int val;
           public TreeNode left;
           public TreeNode right;
           public TreeNode(int x) { val = x; }
       }

        public TreeNode BstFromPreorder(int[] preorder)
        {
            return BuildBSTPreorder(preorder, 0, preorder.Length-1); 
        }

        private TreeNode BuildBSTPreorder(int[] preorder, int left, int right)
        {
            int rootvalue = preorder[left];
            if(left==right)
                return new TreeNode(rootvalue);

            TreeNode root = new TreeNode(rootvalue);

            if (preorder[left + 1] > rootvalue)
            {
                root.left = null;
                root.right = BuildBSTPreorder(preorder, left+1, right);
            }
            else
            {
                int rightchildstart = -1;
                for (int i = left; i <= right; i++)
                {
                    if (preorder[i] > rootvalue)
                    {
                        rightchildstart = i;
                        break;
                    }
                }

                if (rightchildstart == -1)
                {
                    root.right = null;
                    root.left = BuildBSTPreorder(preorder, left + 1, right);

                }
                else
                {
                    root.left = BuildBSTPreorder(preorder, left + 1, rightchildstart - 1);
                    root.right = BuildBSTPreorder(preorder, rightchildstart, right);
                }

            }

            return root;

        }
    }
}
