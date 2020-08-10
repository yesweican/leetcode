using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge05
{
    /// <summary>
    /// Need to optimize this solution!
    /// </summary>
    public class q437
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

        public class TreeNodeX
        {
            public TreeNode node { get; set; }
            public int sumFromRoot { get; set; }
        }

        public int solutionCounter;

        public int PathSum(TreeNode root, int sum)
        {
            solutionCounter = 0;
            RecursiveTreeTraversal(new List<TreeNodeX>(), root, sum);

            return solutionCounter;
        }

        private void RecursiveTreeTraversal(List<TreeNodeX> prefixes, TreeNode root, int sum)
        {
            //First procoess the current root and prefixes

            //if (root.val == sum)
            //    solutionCounter++;

            ////Epic Fail here
            ////int currentSum = prefixes.Count>0 ? prefixes[prefixes.Count - 1].sumFromRoot: 0  + root.val;
            int currentSum = (prefixes.Count > 0 ? prefixes[prefixes.Count - 1].sumFromRoot : 0) + root.val;

            if (currentSum == sum)
                solutionCounter++;

            foreach (var temp in prefixes)
            {
                if ((currentSum - temp.sumFromRoot) == sum)
                    solutionCounter++;
            }

            if (root.left == null && root.right == null)
                return;

            //Generate the prefix for further processing
            List<TreeNodeX> newPrefixes = new List<TreeNodeX>(prefixes);
            TreeNodeX rootX = new TreeNodeX() { node = root, sumFromRoot = currentSum };
            newPrefixes.Add(rootX);

            //Recursively Call the Left and Right
            if(root.left!=null)
            {
                RecursiveTreeTraversal(newPrefixes, root.left, sum);
            }

            if(root.right!=null)
            {
                RecursiveTreeTraversal(newPrefixes, root.right, sum);
            }

        }

        public void testPathSum()
        {
            TreeNode node1 = new TreeNode(10);
            TreeNode node2 = new TreeNode(5);
            TreeNode node3 = new TreeNode(-3);

            node1.left = node2;
            node1.right = node3;

            TreeNode node4 = new TreeNode(2);
            TreeNode node5 = new TreeNode(1);
            node2.left = node4; 
            node2.right = node5;

            int t = PathSum(node1, 7);
            Console.WriteLine(t);
        }


    }
}
