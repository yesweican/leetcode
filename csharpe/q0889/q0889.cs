using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q889
    {
        int[] postdata;
        int[] predata;
        public TreeNode BuildTree(int[] preorder, int[] postorder) 
        {
            postdata=postorder;
            predata=preorder;
        
            if ((postorder.Length==0)||(postorder.Length != preorder.Length))
                    return null;

           TreeNode result = BuildTree2(0, preorder.Length-1, 0, postorder.Length-1);
            return result;        
        }
    
         private TreeNode BuildTree2(int pre_left, int pre_right, int post_left, int post_right)
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
                   //find the position of the position in preorder[]
                   int leftchildroot = predata[pre_left+1];
                   int rightchildroot = postdata[post_right-1];

                   //no unique answer if only one subtree
                   if(leftchildroot == rightchildroot)
                   {
                       rootNode.left = null;
                       rootNode.right = BuildTree2(pre_left+1, pre_right, post_left, post_right-1);
                   }
                   else
                   {
                       int temp=-1;

                       for(int i=post_left; i<post_right; i++)
                       {
                           if(leftchildroot==postdata[i])
                           {
                               temp=i;
                               break;
                           }
                       }
                       int lefttreesize=temp-post_left+1;
                       rootNode.left = BuildTree2(pre_left+1, pre_left+lefttreesize, post_left, post_left+lefttreesize-1);
                       rootNode.right = BuildTree2(pre_left+lefttreesize + 1, pre_right, temp+1, post_right-1);
                   }
                }
                return rootNode;
             }    
        
    
    }//end of class
}
