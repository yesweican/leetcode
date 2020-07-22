using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    public class q103
    {
 // Definition for a binary tree node.
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

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            Stack<TreeNode> stackBuffer = new Stack<TreeNode>();
            List<IList<int>> Results = new List<IList<int>>();

            if (root == null)
                return (IList<IList<int>>)Results;

            bool oddLevel = true;
            queue.Enqueue(root);

            while(queue.Count>0)
            {
                List<int> currentLevel = new List<int>();
                int temp = queue.Count;
                while (temp > 0)
                {
                    TreeNode node = queue.Dequeue();
                    temp--;

                    if(!oddLevel)
                    {
                        stackBuffer.Push(node);
                    }
                    else
                    {
                        currentLevel.Add(node.val);
                    }

                    ////Typical BFS
                    if(node.left!=null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }

                if (!oddLevel)
                {
                    TreeNode node2 = null;
                    while (stackBuffer.Count>0)
                    {
                        node2 = stackBuffer.Pop();
                        currentLevel.Add(node2.val);
                    }
                    //flip the oddLevel
                    oddLevel = true;
                }
                else
                {
                    //flip the oddLevel
                    oddLevel = false;
                }

                Results.Add((IList<int>)currentLevel);

                //Combined this over to the logic above..
                //if (oddLevel)
                //    oddLevel = false;
                //else
                //    oddLevel = true;
            }


            return (IList<IList<int>>)Results;

        }

    }
}
