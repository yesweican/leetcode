using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
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
    /// <summary>
    /// Generate BST from preorder
    /// </summary>

    public class q1008
    {
        public TreeNode BstFromPreorder(int[] preorder)
        {
            if (preorder.Length == 0)
                return null;
            if(preorder.Length==1)
            {
                return new TreeNode(preorder[0]);
            }

            return generateBST(preorder, 0, preorder.Length-1);
        }

        private TreeNode generateBST(int[] preorder, int start, int end)
        {
            int rootVal = preorder[start];
            TreeNode root = new TreeNode(rootVal);

            if (start == end)
                return root;

            int mid = -1;
            for (int i = start; i <= end; i++)
            {
                if (preorder[i] > rootVal)
                {
                    mid = i;
                    break;
                }
            }

            if(mid!=-1)
            {
                if (mid == (start + 1))
                    root.left = null;
                else
                    root.left = generateBST(preorder, start + 1, mid - 1);

                root.right = generateBST(preorder, mid, end);
            }
            else
            {
                root.right = null;
                root.left = generateBST(preorder, start + 1, end);
            }

            return root;

        }
    }
}
