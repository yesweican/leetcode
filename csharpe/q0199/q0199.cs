using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class q199
    {
        public IList<int> RightSideView(TreeNode root) 
        {
            List<int> result=new List<int>();

            if (root == null)
                return result;
        
            Queue<TreeNode> que = new Queue<TreeNode>();
            Queue<TreeNode> que2 = new Queue<TreeNode>();
            que.Enqueue(root);

            while (que.Count > 0)
            {
                TreeNode lastT=null;
                while (que.Count > 0)
                {
                    lastT = que.Dequeue();
                    if (lastT.left!=null)
                        que2.Enqueue(lastT.left);
                    if (lastT.right != null)
                        que2.Enqueue(lastT.right);
                }
                result.Add(lastT.val);

                //Moving Nodes from que2 to que
                while (que2.Count > 0)
                {
                    TreeNode temp;
                    temp = que2.Dequeue();
                    que.Enqueue(temp);
                }
            }

            return result;
        }

        /// <summary>
        /// /Slightly faster solution
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> RightSideViewBetter(TreeNode root)
        {
            List<int> result = new List<int>();

            if (root == null)
                return result;

            Queue<TreeNode> que = new Queue<TreeNode>();
            que.Enqueue(root);

            while (que.Count > 0)
            {
                TreeNode lastT = null;

                int queuesize = que.Count;
                for(int i=0; i<queuesize; i++)
                {
                    lastT = que.Dequeue();
                    if (lastT.left != null)
                        que.Enqueue(lastT.left);
                    if (lastT.right != null)
                        que.Enqueue(lastT.right);

                    if(i==queuesize-1)
                    result.Add(lastT.val);
                }
            }

            return result;
        }

    }
}
