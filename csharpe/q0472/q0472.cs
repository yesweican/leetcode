public class Trie
{
    private TrieNode _root;

    public TrieNode root
    {
        get =>_root; 
    }

    public Trie()
    {
        _root = new TrieNode();
    }

    public void add(String s)
    {
        if (s.Length == 0) return;
        TrieNode cur = _root;
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (cur.children[c - 'a'] == null) cur.children[c - 'a'] = new TrieNode();
            cur = cur.children[c - 'a'];
        }
        cur.word = s;
    }
}

public class TrieNode
{
    public String word;
    public TrieNode[] children;
    public TrieNode()
    {
        word = null;
        children = new TrieNode[26];
    }

}

public class Solution
{
    public List<String> FindAllConcatenatedWordsInADict(String[] words)
    {
        List<String> res = new List<String>();
        if (words == null || words.Length == 0) return res;
        Trie trie = new Trie();
        foreach(var s in words) 
            trie.add(s);
        foreach (var s in words)
        {
            if (dfs(trie.root, trie.root, s, 0)) res.Add(s);
        }
        return res;
    }

    private bool dfs(TrieNode root, TrieNode cur, String s, int index)
    {
        if (index == s.Length) 
            return cur.word != null && cur.word != s;
        if (cur.children[s[index] - 'a'] == null) 
            return false;
        if (cur.children[s[index] - 'a'].word != null && dfs(root, root, s, index + 1)) 
            return true;
        return dfs(root, cur.children[s[index] - 'a'], s, index + 1);
    }

}