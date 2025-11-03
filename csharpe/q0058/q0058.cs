public class Solution {
    public int LengthOfLastWord(string s) {
        char[] characters = s.ToCharArray();
        int result=0;
        int stage=0;
        for(int i=characters.Length-1; i>=0; i--)
        {
            if(stage==0)
            {
                if(characters[i]!=' ')
                {
                    stage=1;
                    result++;
                }
                    
            }
            else
            {
                if(stage==1)
                {
                    if(characters[i]==' ')
                    {
                        stage=2;
                        break;
                    }
                    else
                    {
                        result++;
                    }
                }
            }
                
        }
        
       
        return result;
    }
}