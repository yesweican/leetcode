/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public class NodeRelation
    {
        public NodeRelation(TreeNode x, TreeNode y, bool z)
        {
            this.parent = x;
            this.child = y;
            this.isLeft = z;

        }
        public TreeNode parent { get; set; }
        public TreeNode child { get; set; }
        public Boolean isLeft { get; set; }
    }    
    
    public TreeNode DeleteNode(TreeNode root, int key) {            
         NodeRelation nodes = FindNode(null, root, key, false);
        if(nodes==null)
            return root;

        TreeNode temp = RemoveChild(nodes.parent, nodes.child, nodes.isLeft);

        if (nodes.parent == null)
            return temp;
        else
            return root;        
    }
    
    private NodeRelation FindNode(TreeNode parent, TreeNode root, int key, bool isLeft)
    {
        if (root == null)
            return null;

        if (key == root.val)
            return new NodeRelation( parent, root, isLeft);

        if (key > root.val)
            return FindNode(root, root.right, key, false) ;

        if (key < root.val)
            return FindNode(root, root.left, key, true);

        return null;
    }

    private TreeNode RemoveChild(TreeNode parent, TreeNode child, Boolean isLeft)
    {
        if(child.left == null)
        {
            if(parent == null)
            {
                return child.right;
            }
            else
            {
                if(isLeft)
                {
                    parent.left = child.right;
                }
                else
                {
                    parent.right = child.right;
                }

                return null;
            }
        }

        if(child.right == null)
        {
            if (parent == null)
            {
                return child.left;
            }
            else
            {
                if (isLeft)
                {
                    parent.left = child.left;
                }
                else
                {
                    parent.right = child.left;
                }

                return null;
            }
        }

        //child.left != null, && child.right != null
        TreeNode childright = child.right;
        while(childright.left != null)
        {
            childright = childright.left;
        }
        childright.left = child.left;

        if(parent==null)
        {
            return child.right;
        }
        else
        {
            if (isLeft)
                parent.left = child.right;
            else
                parent.right = child.right;
            return null;
        }
    }
    

}