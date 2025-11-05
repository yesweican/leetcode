public class Solution {
    public bool ValidUtf8(int[] data) {
        ////0xxxxxxxx =>128=>0
        ////110xxxxxx =>224=>192
        ////1110xxxxx =>240=>224
        ////11110xxxx =>248=>240
        ////10xxxxxxx =>192=>128
        
        for(int i=0; i<data.Length; )
        {
            if((data[i] & 128)==0)
            {
                i++;
                continue;
            }
            
            if((data[i] & 224)==192)
            {
                Console.WriteLine("Hello #1");
                if((i+1)<data.Length)
                {
                    if((data[i+1] & 192)==128)
                    {
                        i+=2;
                        continue;
                    }

                }
                return false;               
            }
            
            if((data[i] & 240)==224)
            {
                if((i+2)<data.Length)
                {
                    if(((data[i+1] & 192)==128) && ((data[i+2] & 192)==128))
                    {
                        i+=3;
                        continue;
                    }

                }
                return false;               
            }
            if((data[i] & 248)==240)
            {
                if((i+3)<data.Length)
                {
                    if(((data[i+1] & 192)==128) && ((data[i+2] & 192)==128) &&  ((data[i+3] & 192)==128))
                    {
                        i+=4;
                        continue;
                    }

                }
                return false;               
            }
            
            return false;
        }
        return true;
    }
}