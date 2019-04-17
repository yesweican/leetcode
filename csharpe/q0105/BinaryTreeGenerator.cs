using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConstructBinaryTreeApp
{
    public class BinaryTreeGenerator
    {
        private int[] preorder;
        private int[] inorder;

        public TreeNode BuildTree(int[] predata, int[] indata)
        {
            preorder = predata;
            inorder = indata;
            if ((predata.Length==0)||(predata.Length != indata.Length))
                return null;
            TreeNode result = BuildTree2(0, predata.Length-1, 0, predata.Length-1);
            return result;
        }

        private TreeNode BuildTree2(int in_left, int in_right, int pre_left, int pre_right)
        {
            //start with preorder[pre_left]
            int currentroot = preorder[pre_left];
            TreeNode rootNode = new TreeNode(preorder[pre_left]);
            if (pre_left == pre_right)
            {
                //leaf node
                return rootNode;
            }
            else
            {
                //find the position of the position in inorder[]
                int temp = -1;
                for (int i = in_left; i <= in_right; i++)
                {
                    if (inorder[i] == currentroot)
                    {
                        temp = i;
                        break;
                    }
                }

                if (temp > in_left)
                {
                    //there is a left subtree
                    rootNode.left = BuildTree2(in_left, temp-1, pre_left+1, pre_left+(temp-in_left));
                }
                else
                {
                    rootNode.left=null;
                }

                if (temp < in_right)
                {
                    //there is a left subtree
                    rootNode.right = BuildTree2(temp + 1, in_right, pre_left + (temp - in_left) + 1, pre_right);
                }
                else
                {
                    rootNode.right=null;
                }
            }

            return rootNode;

        }
    }
}
