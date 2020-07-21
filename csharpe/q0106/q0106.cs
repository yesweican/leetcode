using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q106
    {
        int[] postdata;
        int[] indata;
        public TreeNode BuildTree(int[] inorder, int[] postorder) 
        {
            postdata=postorder;
            indata=inorder;
        
            if ((postorder.Length==0)||(postorder.Length != inorder.Length))
                    return null;

           TreeNode result = BuildTree2(0, inorder.Length-1, 0, postorder.Length-1);
            return result;        
        }
    
         private TreeNode BuildTree2(int in_left, int in_right, int post_left, int post_right)
         {

              //start with postorder[post_left]
              int currentroot = postdata[post_right];
              TreeNode rootNode = new TreeNode(postdata[post_right]);

              if (post_left == post_right)
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
                       if (indata[i] == currentroot)
                       {
                           temp = i;
                           break;
                       }
                   }
                   //temp is the val of ROOT
                   if (temp > in_left)
                   {
                       //there is a left subtree
                       rootNode.left = BuildTree2(in_left, temp-1, post_left, post_left+(temp-in_left)-1);
                   }
                   else
                   {
           		   rootNode.left=null;
                   }

                   if (temp < in_right)
                   {
                       //there is a left subtree
                       rootNode.right = BuildTree2(temp + 1, in_right, post_left + (temp - in_left), post_right-1);
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
