using System;
using System.Text;
public class Solution {
    public string ReverseWords(String s) {

	    String s2=reverseString(s);
	    var chars2=s2.ToCharArray();

        var words=s2.Split(null);

	    StringBuilder wordBuffer=new StringBuilder();
        foreach(String word in words)
        {
             if(!String.IsNullOrEmpty(word))
             {
                  wordBuffer.Append(reverseString(word));  
                  wordBuffer.Append(" ");
             }

        }
        return wordBuffer.ToString().Trim();
    }

    private String reverseString(String original)
    {
        var chars=original.ToCharArray();
	StringBuilder builder=new StringBuilder();
	for (int i=chars.Length; i>0; i--)
	{
		builder.Append(chars[i-1]);
	}
        return builder.ToString();
    }
}