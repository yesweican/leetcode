using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q236a
    {
        List<TreeNode> path1;
        List<TreeNode> path2;
        /// <summary>
        /// This method using DFS is giving us about the SAME performance as the Geek4Geek
        /// LCA method, but much readable!
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            path1 = new List<TreeNode>();
            path2 = new List<TreeNode>();

            if (dfs1(root, 0, p) && dfs2(root, 0, q))
            {
                int index = 0;

                //Ffrom top to down, find out where the two pathes split
                while (index < path1.Count && index < path2.Count)
                {
                    if (path1[index] == path2[index])
                    {
                        index++;
                    }
                    else
                        break;
                }
                return path1[index - 1];
            }
            else
                return null;

        }

        private bool dfs1(TreeNode root, int level, TreeNode p)
        {
            if (path1.Count > level)
                path1[level] = root;
            else
                path1.Add(root);

            if (root == p)
                return true;

            if (root.left != null && dfs1(root.left, level + 1, p))
                return true;
            else
                if (root.right != null)
                return dfs1(root.right, level + 1, p);
            return false;
        }

        private bool dfs2(TreeNode root, int level, TreeNode q)
        {

            if (path2.Count > level)
                path2[level] = root;
            else
                path2.Add(root);

            if (root == q)
                return true;

            if (root.left != null && dfs2(root.left, level + 1, q))
                return true;
            else
                if (root.right != null)
                return dfs2(root.right, level + 1, q);
            return false;
        }

    }
}
