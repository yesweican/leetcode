using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q226
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
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;
            TreeNode temp1 = InvertTree(root.right);
            TreeNode temp2 = InvertTree(root.left);

            root.left = temp1;
            root.right = temp2;
            return root;
        }
    }
}
