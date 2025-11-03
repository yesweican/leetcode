public class Solution {
    //word frequency maps
    Dictionary<string, int> frequency = new Dictionary<string, int>();
    // pos->any word map
    HashSet<int> map = new HashSet<int>();
    
    public IList<int> FindSubstring(string s, string[] words) {
            List<int> result = new List<int>();
            int wordCount = words.Length;
            int wordLength = words[0].Length;
            for (int i = 0; i < wordCount; i++)
            {
                string word = words[i];
                if (!frequency.Keys.Contains(word))
                {
                    frequency.Add(word, 1);
                }
                else
                {
                    frequency[word] += 1;
                }
            }

            for(int i=0; i<s.Length - wordLength + 1; i++)
            {
                string temp = s.Substring(i, wordLength);
                if(frequency.Keys.Contains(temp))
                {
                    map.Add(i);
                }
            }

            for (int i = 0; i < s.Length - wordLength * wordCount + 1; i++)
            {
                Dictionary<string, int> frequency2 = new Dictionary<string, int>();
                bool success = true;
                for(int j=0; j<wordCount; j++)
                {
                    int start = i + j * wordLength;
                    if(map.Contains(start))
                    {
                        string word = s.Substring(start, wordLength);
                        if(!frequency2.Keys.Contains(word))
                        {
                            frequency2.Add(word, 1);
                        }
                        else
                        {
                            frequency2[word] += 1;
                        }
                    }
                    else
                    {
                        success = false;
                        break;
                    }
                }

                if(success)
                {
                    if (CompareFrequency(frequency, frequency2))
                        result.Add(i);
                } 
        }
        return result;          
    }
        
    private bool CompareFrequency(Dictionary<string, int>f1, Dictionary<string, int>f2)
    {
        if (f1.Keys.Count != f2.Keys.Count)
            return false;

        foreach(var v in f1.Keys)
        {
            if (!f2.Keys.Contains(v))
                return false;

            if (f1[v] != f2[v])
                return false;
        }

        return true;
    }        
}