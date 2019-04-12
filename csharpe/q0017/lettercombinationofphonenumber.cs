public class Solution {
            //DialPad 0,1, 2-9, example of Jagged Array Initialization
        char[][] dialPad = new char[][] 
            {
                new char[]{}, 
                new char[]{}, 
                new char[]{'a','b','c' }, 
                new char[]{'d','e', 'f'}, 
                new char[]{'g','h','i' }, 
                new char[]{'j','k','l' },
                new char[]{'m','n','o' }, 
                new char[]{'p','q','r','s' },
                new char[]{'t','u','v' }, 
                new char[]{ 'w','x','y','z'}
            };
        List<string> results;   
    
    public IList<string> LetterCombinations(string digits) {
            //cleanup the buffer
            results = new List<string>();
        
        if(digits.Length>0)DoConvertDigitsToLetters("", digits);

            return results;
   
    }
    
    
        void DoConvertDigitsToLetters(string prefix, string remainingdigits)
        {
            char firstdigit = remainingdigits[0];
            string newdigits = remainingdigits.Substring(1);
            bool lastlevel = (remainingdigits.Length==1);
            int firstnumber = (int)(firstdigit - '0');

            for (int i = 0; i < dialPad[firstnumber].Length; i++)
            {
                char temp = dialPad[firstnumber][i];
                string newPrefix = prefix + temp.ToString();
                if (lastlevel)
                {
                    results.Add(newPrefix);
                    //Console.WriteLine(newPrefix);
                }
                else
                    DoConvertDigitsToLetters(newPrefix, newdigits);

            }

        } 
}