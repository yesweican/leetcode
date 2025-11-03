/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {
    StringBuilder builder;
    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        if(root == null) 
            return "()";

        builder = new StringBuilder();

        process(root);

        string temp = builder.ToString();
        //Console.WriteLine(temp);

        return temp;        
    }

    private void process(TreeNode root)
    {
        builder.Append("(");
        builder.Append(root.val.ToString());
        builder.Append(",");

        if(root.left!=null)
        {
            process(root.left);
        } else
        {
            builder.Append("()");
        }
        builder.Append(",");

        if(root.right!=null)
        {
            process(root.right);
        } else
        {
            builder.Append("()");
        }

        builder.Append(")");

    }

    Dictionary<int, int> bracketMap=null;
    Dictionary<int, int> bracketMap2=null;
    char[] buffer;
    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        buffer = data.ToCharArray();
        bracketMap = new Dictionary<int, int>();
        bracketMap2 = new Dictionary<int, int>();

        generateMap();

        TreeNode root = processSubTree(0, buffer.Length - 1);

        return root;       
    }

    private void generateMap()
    {
        Stack<int> bracketLocStack = new Stack<int>();
        for (int i = 0; i < buffer.Length; i++)
        {
            switch (buffer[i])
            {
                case '(':
                    bracketLocStack.Push(i);
                    break;
                case ')':
                    int leftpos = bracketLocStack.Pop();
                    bracketMap.Add(leftpos, i);
                    bracketMap2.Add(i, leftpos);
                    break;
                default:
                    break;
            }
        }
    }

    private TreeNode? processSubTree(int left, int right) { 

        if(right==(left+1))
        {
            return null;
        }

        StringBuilder builder2 = new StringBuilder();
        int start = left + 1;
        builder2.Append(buffer[start]);
        int end = start + 1;

        while ((buffer[end]!=','))
        {
            builder2.Append(buffer[end]);
            end++;
        }

        string s = builder2.ToString();
        int currentVal;
        Int32.TryParse(s, out currentVal);

        TreeNode root = new TreeNode(currentVal);
        int left1 = end + 1;
        int right1 = bracketMap[left1];

        TreeNode? node1 = processSubTree(left1, right1);

        int right2 = right-1;
        int left2 = bracketMap2[right2];

        TreeNode? node2 = processSubTree(left2, right2);

        root.left = node1;
        root.right = node2;

        return root;

    }    
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));