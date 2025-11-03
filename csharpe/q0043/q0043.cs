public class Solution {
    string finalresult;

    public string Multiply(string num1, string num2)
    {
        finalresult = "0";

        char[] num2chars = num2.ToCharArray();
        Array.Reverse(num2chars);

        for(int pos = 0; pos < num2chars.Length; pos++)
        {
            string buffer = Multiply2(num1, num2chars[pos], pos);
            Console.WriteLine(buffer);
            finalresult = Addition(buffer, finalresult);
        }

        return finalresult;
    }

    private string Multiply2(string num1, char c, int pos)
    {
        if (c == '0')
            return "0";   
            
        char[] num1chars = num1.ToCharArray();
        Array.Reverse(num1chars);
            
        List<char> result = new List<char>();
        int carry = 0; int v0 = c - '0';
        //multiply here
        for (int i=0; i<num1chars.Length; i++)
        {
            int v1 = num1chars[i] - '0';
            int temp = v1 * v0 + carry;
            if (temp >= 10)
            {
                carry = temp / 10;
            }
            else
            {
                carry = 0;
            }

            temp = temp % 10;
            result.Add((char)(temp + '0'));
        }
        if(carry>0)
        {
            result.Add((char)(carry + '0'));
        }
        result.Reverse();
        String strResult = new String(result.ToArray());
        //append pos zeros at the end...
        StringBuilder builder = new StringBuilder();
        if(result.Count > 0 && result[0] != '0')
        {
            for (int j = 0; j < pos; j++)
            {
                builder.Append('0');
            }
        }

        return strResult + builder.ToString();
    }

    private string Addition(string num1, string num2)
    {
        char[] num1chars = num1.ToCharArray();
        Array.Reverse(num1chars);
        char[] num2chars = num2.ToCharArray();
        Array.Reverse(num2chars);
        List<char> result = new List<char>();
        int carry = 0;

        int l1 = num1chars.Length;
        int l2 = num2chars.Length;
        int current = 0;

        while (current <= (l1 - 1) || current <= (l2 - 1))
        {
            int temp = 0;
            if (current <= (l1 - 1))
            {
                int digit1 = num1chars[current] - '0';
                temp += digit1;
            }

            if (current <= (l2 - 1))
            {
                int digit2 = num2chars[current] - '0';
                temp += digit2;
            }

            if (carry > 0)
            {
                temp += carry;
                carry = 0;
            }
            else
            {
                carry = 0;
            }

            if (temp >= 10)
            {
                carry = 1;//9+9+1<20
                temp -= 10;
            }

            result.Add((char)('0' + temp));

            current++;
        }

        if (carry > 0)
        {
            result.Add((char)('0' + carry));
        }

        result.Reverse();

        string strResult = new string(result.ToArray());

        return strResult;
    }
}