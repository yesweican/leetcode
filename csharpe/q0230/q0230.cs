using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q230
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
            
       int counter;
       int result;
       bool Found;
        public int KthSmallest(TreeNode root, int k)
        {
            counter = 0;
            result = -1;
            Found = false;
            RootMid(root, k);
            return result;
        }

        void RootMid(TreeNode root, int k)
        {
            if (root.left != null)
                RootMid(root.left, k);
            counter++;
            if (counter == k)
            {
                Found = true;
                result = root.val;
                return;
            }
            if ((Found==false) && (root.right != null))
                RootMid(root.right, k);
        }
    }
}
