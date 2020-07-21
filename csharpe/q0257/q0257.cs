using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    /**
     * Definition for a binary tree node.    
     */
     public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
     }
 
    public class q257
    {
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            List<string>paths = new List<string>();

            if (root == null)
                return paths;

            DFS(root, root.val.ToString(), paths);
            return paths;
        }

        private void DFS(TreeNode root, string path, List<string>paths)
        {
            if(root.left==null && root.right==null)
            {
                //this root is a leaf
                paths.Add(path);
                return;
            }

            if(root.left!=null)
            {
                DFS(root.left, path+"->"+root.left.val, paths);
            }

            if(root.right!=null)
            {
                DFS(root.right, path+"->"+root.right.val, paths);
            }

        }

    }
}
