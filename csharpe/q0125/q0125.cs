public class Solution {
    public bool IsPalindrome(string s) {
        string alphabeta = "abcdefghijklmnopqrstuvwxyz0123456789";

        char[] characters = s.ToLower().ToCharArray();

        List<char> filterCharacters = new List<char>();

        for(int i=0; i<characters.Length; i++)
        {
            char c = characters[i];
            if (alphabeta.Contains(c))
                filterCharacters.Add(c);
        }

        if (filterCharacters.Count == 0)
            return true;

        int left = 0;
        int right = filterCharacters.Count- 1;

        while (left < right)
        {
            if (filterCharacters[left] != filterCharacters[right])
                return false;

            left++; right--;
        }

        return true;
        
    }
}