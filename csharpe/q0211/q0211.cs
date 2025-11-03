public class WordDictionary {

        private TrieNode root;
    /** Initialize your data structure here. */
    public WordDictionary() {
            root = new TrieNode();   
    }
    
    public void AddWord(string word) {
            TrieNode node = root;
            for (int i = 0; i < word.Length; i++)
            {
                int index = word[i] - 'a';
                // 孩子是否被初始化
                if (node.children[index] == null)
                {
                    // 初始化孩子
                    node.children[index] = new TrieNode();
                }
                // 移动到孩子节点，继续下一层操作
                node = node.children[index];
            }

            node.isWord = true;
            node.word = word;     
    }
    
    public bool Search(string word) {
            return find(word, root, 0);    
    }
    
        private bool find(String word, TrieNode node, int index)
        {
            if (node == null) return false;
            // 或者写node.word.equals(word)
            if (index == word.Length) return node.isWord;
            // 这种情况是.
            // 只要下边有不是null的节点就可以继续下一层的操作了
            if (word[index] == '.')
            {
                foreach (TrieNode temp in node.children)
                {
                    if (find(word, temp, index + 1))
                    {
                        return true;
                    }
                }
                // 这种情况是字母
            }
            else
            {
                int tempIndex = word[index] - 'a';
                TrieNode temp = node.children[tempIndex];

                return find(word, temp, index + 1);
            }

            return false;
        }
    
    
            private class TrieNode
        {
            public TrieNode[] children;
            public bool isWord;
            public String word;
            public TrieNode()
            {
                children = new TrieNode[26];
                isWord = false;
                word = "";
            }
        }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */