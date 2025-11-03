public class Solution {
    bool[] bInitials= new bool[26];
    char[][] boardData;
    int boardHeight, boardWidth;
    Trie myTrie = new Trie();
    int[][] directions = new int[4][] { new int[2] { 1, 0 }, new int[2] { -1, 0 },new int[2] { 0, 1 }, new int[2] { 0, -1 } };
    HashSet<string> hset = new HashSet<string>();

    public IList<string> FindWords(char[][] board, string[] words) 
    {
        boardData = board;
        boardHeight = board.Length;
        boardWidth = board[0].Length;  

        for (int i = 0; i < words.Length; i++)
        {
            char c = words[i][0];

            int j = (int)(c - 'a');
            bInitials[j] = true;

            myTrie.Insert(words[i]);
        }

        for (int i = 0; i < boardHeight; i++)
        {
            for (int j = 0; j < boardWidth; j++)
            {
                char c = board[i][j];
                if (bInitials[(int)(c - 'a')])
                {
                        DFS("", i, j, null);
                }
            }

        }

        List<string> results = new List<string>();
        foreach (var v in hset)
        {
            results.Add(v);
                
        }

        return (IList<string>)results;
    }

    private void DFS(string prefix, int row, int col, TrieNode? start)
    {
        char c = boardData[row][col]; 
            
        boardData[row][col] = '*';

        string currentString = prefix + c.ToString();

        TrieNode? node = myTrie.SearchNextChar(start, c);
        if (node != null) {
            if (node.endOfWord)
            {
                if (!hset.Contains(currentString)) {
                    hset.Add(currentString);
                }
            }

            foreach (var d in directions)
            {
                int newRow = row + d[0];
                int newCol = col + d[1];

                if (newRow >= 0 && newRow < boardHeight && newCol >= 0 && newCol < boardWidth) 
                {
                    char newC = boardData[newRow][newCol];
                    if (newC != '*') {
                        DFS(currentString, newRow, newCol, node);
                    }
                }
            }
        }

        boardData[row][col] = c; //recover the old value
    }
}

    public class Trie
    {
        TrieNode root;

        /** Initialize your data structure here. */
        public Trie()
        {
            root = new TrieNode();
        }

        public TrieNode Root
        {
            get { return root; }
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            char[] chars = word.ToCharArray();
            int length = chars.Length;

            TrieNode tempRoot = root;

            for (int i = 0; i < length; i++)
            {
                if (tempRoot.children.Keys.Contains(chars[i]))
                {
                    tempRoot = tempRoot.children[chars[i]];
                    //adding word to existing Node
                    if ((length - 1) == i)
                    {
                        tempRoot.endOfWord = true;
                        tempRoot.word = word;
                    }
                }
                else
                {
                    TrieNode newNode = new TrieNode();
                    //adding word to a new Node
                    if ((length - 1) == i)
                    {
                        newNode.endOfWord = true;
                        newNode.word = word;
                    }

                    tempRoot.children.Add(chars[i], newNode);
                    tempRoot = newNode;
                }
            }
        }

        /** Returns Search Result . */
        public TrieNode? Search(string word)
        {
            var node = this.Root;
            foreach (char c in word)
            {
                if (!node.children.ContainsKey(c))
                    return null;
                node = node.children[c];
            }
            return node;
        }

        /** Returns Search Result Per Character. */
        public TrieNode? SearchNextChar(TrieNode? start, char c)
        {
            var node = start==null ? this.Root: start;
            if (!node.children.ContainsKey(c))
                    return null;
                node = node.children[c];
            return node;
        }

    }


    public class TrieNode
    {
        public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
        public bool endOfWord;

        public TrieNode() 
        { 
            //initialization
            this.endOfWord = false; 
        }
        public string word { get; set; }
        //extra property
    }