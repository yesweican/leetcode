public class Solution {
    public string IntToRoman(int num) {
             StringBuilder buffer = new StringBuilder();
            int[] digits = new int[4];
            digits[3] = num % 10;
            num = (num - digits[3]) / 10;
            digits[2] = num % 10;
            num = (num - digits[2]) / 10;
            digits[1] = num % 10;
            num = (num - digits[1]) / 10;
            digits[0] = num;

            for (int j=0; j < digits[0]; j++)
            {
                buffer.Append("M");
            }
            switch (digits[1])
            {
                case 9: buffer.Append("CM"); break;
                case 8: buffer.Append("DCCC"); break;
                case 7: buffer.Append("DCC"); break;
                case 6: buffer.Append("DC"); break;
                case 5: buffer.Append("D"); break;
                case 4: buffer.Append("CD"); break;
                case 3: buffer.Append("CCC"); break;
                case 2: buffer.Append("CC"); break;
                case 1: buffer.Append("C"); break;
                case 0: break;
            }
            switch (digits[2])
            {
                case 9: buffer.Append("XC"); break;
                case 8: buffer.Append("LXXX"); break;
                case 7: buffer.Append("LXX"); break;
                case 6: buffer.Append("LX"); break;
                case 5: buffer.Append("L"); break;
                case 4: buffer.Append("XL"); break;
                case 3: buffer.Append("XXX"); break;
                case 2: buffer.Append("XX"); break;
                case 1: buffer.Append("X"); break;
                case 0: break;
            }

            switch (digits[3])
            {
                case 9: buffer.Append("IX"); break;
                case 8: buffer.Append("VIII"); break;
                case 7: buffer.Append("VII"); break;
                case 6: buffer.Append("VI"); break;
                case 5: buffer.Append("V"); break;
                case 4: buffer.Append("IV"); break;
                case 3: buffer.Append("III"); break;
                case 2: buffer.Append("II"); break;
                case 1: buffer.Append("I"); break;
                case 0: break;
            }

            return buffer.ToString();       
    }
}