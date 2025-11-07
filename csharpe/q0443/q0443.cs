public class Solution {
    public int Compress(char[] chars) {
        int front = 0;
        int back = 0;
        int current = 0;
        int l=chars.Length;

        while (true)
        {
            char c0 = chars[back];
            chars[current] = c0;
            current++;
              
            front++;
            while(front<l && chars[front]==c0)
                front++;

            int running = front - back;
            if(running > 1)
            {
                string s = running.ToString();
                for(int i=0; i<s.Length; i++)
                {
                    chars[current + i] = s[i];
                }
                current+=s.Length;
            }

            back = front;

            if(front==l)
            {
                break;
            }
        }

        return current;       
    }
}