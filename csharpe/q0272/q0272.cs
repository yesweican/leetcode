using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q272
    {
        /* Class to sort using inorder traversal */
        /* https://www.geeksforgeeks.org/inorder-tree-traversal-without-recursion/  */

        public IList<int> closestKValues(TreeNode root, int k, double target)
        {
            List<TreeNode> list = new List<TreeNode>();
            List<int> newList = new List<int>();

            if (root == null)
            {
                return newList;
            }


            Stack<TreeNode> s = new Stack<TreeNode>();
            TreeNode curr = root;

            // traverse the tree  
            while (curr != null || s.Count > 0)
            {

                /* Reach the left most TreeNode of the curr TreeNode */
                while (curr != null)
                {
                    /* place pointer to a tree TreeNode on the stack 
                     * before traversing the TreeNode's left subtree */
                    s.Push(curr);
                    curr = curr.left;
                }

                /* Current must be NULL at this point */
                curr = s.Pop();
                //////////////////
                list.Add(curr);

                Console.Write(curr.val + " ");

                /* we have visited the TreeNode and its left subtree.  
                 * Now, it's right subtree's turn */
                curr = curr.right;
            }

            int total = list.Count;

            //two pointers
            int start = 0, end = k-1;

            if (total > k)//otherwise forget about this
            {
                bool bContinue=true;
                //need the second part of the condition
                while (bContinue && (end < (total - 1)))
                {
                    double gap1 = Math.Abs(list[start].val - target);
                    double gap2 = Math.Abs(list[end + 1].val - target);

                    if (gap2 > gap1)
                        break;
                    start++;
                    end++;
                }
            }

            for (int i = start; i <= end; i++)
            {
                newList.Add(list[i].val);
            }

            return newList;

        }


    }
}
