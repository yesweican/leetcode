/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public bool IsValidBST(TreeNode root) {
        
        if(root!=null)
             return ValidateBST(root).Valid;   
        else 
            return true;
    }
    
            public  ValidationResult ValidateBST(TreeNode root)
        {
            ValidationResult currentNodeResult = new ValidationResult() { Valid=true };

            if (root.left != null)
            {
                ValidationResult result1 = ValidateBST(root.left);
                if (result1.Valid == false)
                {
                    currentNodeResult.Valid = false;
                    currentNodeResult.Minimum = -1;
                    currentNodeResult.Maximum = -1;

                    return currentNodeResult;
                }
                else
                {
                    if (result1.Maximum >= root.val)
                    {
                        currentNodeResult.Valid = false;
                        currentNodeResult.Minimum = -1;
                        currentNodeResult.Maximum = -1;

                        return currentNodeResult;
                    }
                    else
                        currentNodeResult.Minimum = result1.Minimum;
                }
            }
            else
            {
                 currentNodeResult.Minimum = root.val;
            }

            if (root.right != null)
            {
                ValidationResult result2 = ValidateBST(root.right);
                if (result2.Valid == false)
                {
                    currentNodeResult.Valid = false;
                    currentNodeResult.Minimum = -1;
                    currentNodeResult.Maximum = -1;

                    return currentNodeResult;
                }
                else
                {
                    if (result2.Minimum <= root.val)
                    {
                        currentNodeResult.Valid = false;
                        currentNodeResult.Minimum = -1;
                        currentNodeResult.Maximum = -1;

                        return currentNodeResult;
                    }
                    else
                        currentNodeResult.Maximum = result2.Maximum;
                }
            }
            else
            {
                 currentNodeResult.Maximum = root.val;
            }

            return currentNodeResult;
        }
}

    public class ValidationResult
    {
        public bool Valid { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
    }