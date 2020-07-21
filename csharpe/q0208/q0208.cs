using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{

    public class q208
    {
        TrieNode root;

        /** Initialize your data structure here. */
        public q208()
        {
            root = new TrieNode();
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            char[] chars= word.ToCharArray();
            int length = chars.Length;

            TrieNode currNode = root;

            for (int i = 0; i < length; i++)
            {
                if (currNode.children.Keys.Contains(chars[i]))
                {
                    currNode = currNode.children[chars[i]];
                    //update existing Node
                    if ((length - 1) == i)
                    {
                        currNode.endOfWord = true;
                    }

                }
                else
                {
                    TrieNode newNode = new TrieNode();

                    if ((length-1) == i)
                    {
                        newNode.endOfWord = true;
                    }

                    //Add branches if necessary
                    currNode.children.Add(chars[i], newNode);
                    currNode = newNode;
                }
            }
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            char[] chars = word.ToCharArray();
            int length = chars.Length;

            TrieNode currNode = root;

            for (int i = 0; i < chars.Count(); i++)
            {
                if (currNode.children.Keys.Contains(chars[i]))
                {
                    currNode = currNode.children[chars[i]];

                    if ((length-1) == i)
                    {
                        if (currNode.endOfWord == true)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            char[] chars = prefix.ToCharArray();
            int length = chars.Length;

            TrieNode currNode = root;
            for (int i = 0; i < length; i++)
            {
                if (currNode.children.Keys.Contains(chars[i]))
                {
                    currNode = currNode.children[chars[i]];
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

    }
}
