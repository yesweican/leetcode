using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    public class q662
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

        public int WidthOfBinaryTree(TreeNode root)
        {
            int result = 0;

            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(root);

            while(queue.Count>0)
            {
                int temp = queue.Count;
                if (result < temp)
                    result = temp;

                while(temp>0)
                {
                    TreeNode node = queue.Dequeue();

                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);

                    temp--;

                }

            }

            return result;

        }
    }
}
