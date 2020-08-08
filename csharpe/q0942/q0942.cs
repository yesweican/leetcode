using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge05
{
    public class q942
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
            public int x { get; set; }
            public int y { get; set; }
            public int v { get; set; }
        }

        public class TreeNodeXComp: IComparer<TreeNodeX>
        {
            public int Compare(TreeNodeX n1, TreeNodeX n2)
            {
                if (n1.x > n2.x)
                    return 1;
                else
                {
                    if (n1.x < n2.x)
                    {
                        return -1;
                    }
                    else//n1.x==n2.x
                    {
                        if (n1.y < n2.y)
                            return 1;
                        else
                        {
                            if (n1.y > n2.y)
                                return -1;
                            else
                            {
                                if (n1.v > n2.v)
                                    return 1;
                                else
                                {
                                    if (n1.v < n2.v)
                                        return -1;
                                    else
                                        return 0;
                                }
                            }
                        }
                    }
                }    
            }
        }

        List<TreeNodeX> preorderNodes;

        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            preorderNodes = new List<TreeNodeX>();
            //Step 1 - preorder traversal populate preorderNodes;
            preorderTravesal(root, 0, 0);
            //Step 2 - re-sort the preordered nodes
            preorderNodes.Sort(new TreeNodeXComp());
            //Step 3 - generate the wanted results
            List<IList<int>> result = new List<IList<int>>();
            TreeNodeX previous=null;
            List<int> temp=null;
            foreach(var v in preorderNodes)
            {
                if ((previous == null)||(previous.x!=v.x))
                {
                    if (temp != null)
                        result.Add(temp);

                    temp = new List<int>();
                    temp.Add(v.v);
                    previous = v;
                }
                else
                {
                    temp.Add(v.v);
                }
            }
            result.Add(temp);

            return (IList<IList<int>>)result;
        }

        private void preorderTravesal(TreeNode root, int x0, int y0)
        {
            if(root.left!=null)
            {
                preorderTravesal(root.left, x0-1, y0-1);
            }

            TreeNodeX temp =new TreeNodeX() { node = root, x = x0, y = y0, v = root.val };
            preorderNodes.Add(temp);

            if (root.right != null)
            {
                preorderTravesal(root.right, x0 + 1, y0 - 1);
            }
        }



    }
}
