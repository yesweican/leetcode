using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    /// <summary>
    ///  Binary Tree Level Order Traversal II
    /// </summary>
    public class q107
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

        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null)
                return (IList<IList<int>>)result;

            Stack<IList<int>> stack = new Stack<IList<int>>();

            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(root);

            while(queue.Count>0)
            {
                int n = queue.Count;

                List<int> newrow = new List<int>();

                while(n>0)
                {
                    TreeNode temp = queue.Dequeue();
                    newrow.Add(temp.val);

                    if (temp.left != null)
                        queue.Enqueue(temp.left);

                    if (temp.right != null)
                        queue.Enqueue(temp.right);

                    n--;

                }

                stack.Push(newrow);
            }

            while(stack.Count>0)
            {
                result.Add((IList<int>)stack.Pop());
            }

            return (IList<IList<int>>)result;
        }

    }
}
