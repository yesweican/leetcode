using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    public class q1028
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
        public TreeNode RecoverFromPreorder(string S)
        {
            TreeNode root = new TreeNode();
            ProcessString(root, S);
            return root;
        }

        public void ProcessString(TreeNode r, string s)
        {
            int[] splitterPos = ProcessString2(s);

            string part0 = string.Empty; ;

            if (splitterPos[0] == -1)
            {
                r.val = Int32.Parse(s);
                return;
            }
            else
               part0 = s.Substring(0, splitterPos[0]);

            r.val = Int32.Parse(part0);

            string part1=string.Empty;
            if (splitterPos[1] != -1)
                part1 = s.Substring(splitterPos[0] + 1, splitterPos[1] - splitterPos[0] - 1);
            else
                part1 = s.Substring(splitterPos[0] + 1);

            if(part1!=string.Empty)
            {
                TreeNode node = new TreeNode();
                ProcessString(node, ProcessString3(part1));
                r.left = node; 
            }

            string part2=string.Empty;
            if(splitterPos[1]!=-1)
                part2 = s.Substring(splitterPos[1] + 1);

            if (part2 != string.Empty)
            {
                TreeNode node = new TreeNode();
                ProcessString(node, ProcessString3(part2));
                r.right = node;
            }


        }

        public int[] ProcessString2(string s)
        {
            char[] chars = s.ToCharArray();
            int[] result = new int[2] { -1, -1};
            int n = 0;

            int dashCount = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '-')
                    dashCount++;
                else
                {
                    if (dashCount == 1)
                    {
                        result[n] = i - 1;
                        n++;
                        if (n == 2)
                            break;
                    }

                    dashCount = 0;

                }
            }

            return result;
        }

        public string ProcessString3(string s)
        {
            char[] chars = s.ToCharArray();
            StringBuilder builder = new StringBuilder();

            int dashCount = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '-')
                {
                    if (dashCount >= 1)//skipping the first one
                        builder.Append(s[i]);

                    dashCount++;
                }
                else
                {
                    builder.Append(s[i]);
                    dashCount = 0;
                }
            }

            return builder.ToString();
        }
    }
}
