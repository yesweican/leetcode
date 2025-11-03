public class Solution {
    public string CountAndSay(int n) {
      int j = 1;
       char[] temp = j.ToString().ToCharArray();
      for (int i=2; i<=n; i++)    
      {
          temp = CountAndSay2(temp);
      }
        
        return new string(temp);
        
    }
    
        public char[] CountAndSay2(char[] characters) {
        char currentChar;
        int counter=1;
        currentChar = characters[0];        
        StringBuilder buffer = new StringBuilder();

        for(int i=1; i<characters.Length; i++)
        {
            if(characters[i]==currentChar)
            {
                counter+=1;
                
            }
            else
            {
                buffer.Append(counter.ToString());
                buffer.Append(currentChar.ToString());
                counter=1;
                currentChar=characters[i];
            }
        }
        
        buffer.Append(counter.ToString());
        buffer.Append(currentChar.ToString())     ;
        string temp = buffer.ToString();
            
        Console.WriteLine(temp);
        
        return temp.ToCharArray();
    }
}