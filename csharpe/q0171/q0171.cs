public class Solution {
    public int TitleToNumber(string columnTitle) {
        char[] characters = columnTitle.ToCharArray();
        int result = 0; char c0 = (char)('A'-1);
        
        for (int i=0; i<characters.Length; i++)
        {
            int temp = characters[i]-c0;
            result = result * 26 + temp;
        }
        
        return result;
        
    }
}