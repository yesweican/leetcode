public class Solution {
    public int RomanToInt(string s) {
             int total=0;
            char[] chars = s.ToCharArray(); 
            //chars.Reverse();
            Array.Reverse(chars);

            bool LastCharWasV = false;
            bool LastCharWasX = false;
            bool LastCharWasL = false;
            bool LastCharWasC = false;
            bool LastCharWasD = false;
            bool LastCharWasM = false;
            for (int i = 0; i < chars.Length; i++)
            {
                switch (chars[i])
                {
                    case 'I':
                        if (LastCharWasV || LastCharWasX)
                        {
                            total -= 1;
                        }
                        else
                            total += 1;
                        LastCharWasV = false;
                        LastCharWasX = false;
                        LastCharWasL = false;
                        LastCharWasC = false;
                        LastCharWasD = false;
                        LastCharWasM = false;
                        break;
                    case 'V':
                        total += 5;
                        LastCharWasV = true;
                        LastCharWasX = false;
                        LastCharWasL = false;
                        LastCharWasC = false;
                        LastCharWasD = false;
                        LastCharWasM = false;
                        break;
                    case 'X':
                        if (LastCharWasL || LastCharWasC)
                        {
                            total -= 10;
                        }
                        else
                            total += 10;
                        LastCharWasV = false;
                        LastCharWasX = true;
                        LastCharWasL = false;
                        LastCharWasC = false;
                        LastCharWasD = false;
                        LastCharWasM = false;
                        break;
                    case 'L':
                        total += 50;
                        LastCharWasV = false;
                        LastCharWasX = false;
                        LastCharWasL = true;
                        LastCharWasC = false;
                        LastCharWasD = false;
                        LastCharWasM = false;
                        break;
                    case 'C':
                        if (LastCharWasD || LastCharWasM)
                        {
                            total -= 100;

                        }
                        else
                            total += 100;
                        LastCharWasV = false;
                        LastCharWasX = false;
                        LastCharWasL = false;
                        LastCharWasC = true;
                        LastCharWasD = false;
                        LastCharWasM = false;
                        break;
                    case 'D':
                        total += 500;
                        LastCharWasV = false;
                        LastCharWasX = false;
                        LastCharWasL = false;
                        LastCharWasC = false;
                        LastCharWasD = true;
                        LastCharWasM = false;
                        break;
                    case 'M':
                        total += 1000;
                        LastCharWasV = false;
                        LastCharWasX = false;
                        LastCharWasL = false;
                        LastCharWasC = false;
                        LastCharWasD = false;
                        LastCharWasM = true;
                        break;
                }
            }

            return total;       
    }
}