using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q236
    {
        /// <summary>
        /// This method returns LCA 
        /// Improved upon the Geeks4Geeks method which used 2 global boolean
        /// variable unnecessarily, because there only two possibilities
        /// 1. either one node IS the ancestor of the other, and is the LCA
        /// 2. or the two nodes belongs to left subtree and right subtree (of LCA) respectively
        /// </summary>
        /// <param name="root"></param>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode n1, TreeNode n2)
        {
            // Base case
            if (root == null)
                return null;

            // If either n1 or n2 matches with root, report
            // the presence by returning root (Note that if a key is
            // ancestor of other, then the ancestor key becomes LCA
            if (root == n1 || root == n2)
                return root;

            // Look for keys in left and right subtrees
            TreeNode left_lca = LowestCommonAncestor(root.left, n1, n2);
            TreeNode right_lca = LowestCommonAncestor(root.right, n1, n2);

            // If both of the above calls return Non-NULL, then one key
            // is present in one subtree and other is present in other,
            // So this node is the LCA
            if (left_lca != null && right_lca != null)
                return root;

            // This happen when n1->n2 or n2->n1
            // Otherwise check if left subtree or right subtree is LCA
            return (left_lca != null) ? left_lca : right_lca;
        }
    }
}
