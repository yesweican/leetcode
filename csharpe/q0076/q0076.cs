public class Solution {
    int[] needed;
    int[] window;
    public string MinWindow(string s, string t)
    {
        needed = new int[58];
        window = new int[58];

        char[] data1 = s.ToCharArray();
        char[] data2 = t.ToCharArray();

        for(int i=0; i<data2.Length; i++)
        {
            char c = data2[i];
            int offset = (int)(c-'A');
            needed[offset]++;
        }

        int left = 0, right = 0;
        int minLength = Int32.MaxValue;
        int minLeft = -1, minRight = -1;

        int c2 = data1[left];
        int offset2 = (int)(c2-'A');
        window[offset2] += 1;
        
        while(right<data1.Length)
        {
            //expand to the right until satisfied!
            while(!checkWindowSatisfied())
            {
                right++;

                if(right>=data1.Length)
                {
                    break;
                }
                else
                {
                    c2 = data1[right];
                    offset2 = (int)(c2-'A');
                    window[offset2] += 1;
                }
            }

            if(checkWindowSatisfied())
            {
                //remove the beginning useless characters
                while(checkWindowSatisfied())
                {
                    int currentLength = right - left + 1;

                    if(currentLength<minLength)
                    {
                        minLength = currentLength;
                        minLeft = left;
                        minRight = right;
                    }

                    //moving left forward
                    char c3 = data1[left];
                    int offset3 = (int)(c3-'A'); 
                    window[offset3]--;
                    left++;
                }



                //adding IF or not here
                //window[data1[left]]--;
                //left++;

                if (left > (data1.Length - 1))
                    break;
            }
            else
            {
                break;
            }
        }

        if(minLength == Int32.MaxValue)
        {
            return "";
        }
        else
        {
            string temp = s.Substring(minLeft, minLength);
            return temp;
        }
    }

    private bool checkWindowSatisfied()
    {
        for(int i=0; i<58; i++)
        {
            if (window[i] < needed[i])
                return false;
        }

        //all >= 0;
        return true;
    }
}