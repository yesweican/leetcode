using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution {
    public int LargestUniqueNumber(int[] A) 
	{

		Dictionary<int, int> dict = new Dictionary<int, int>();
		for(int i=0; i<A.Length; i++)
		{
		if(!dict.ContainsKey(A[i]))
   			{  dict.Add(A[i], 1);  
    		}
		else
		{ 
			dict[A[i]]=-1;
		}
	}
 
 	int max=-1;  
	foreach(var pair in dict)
   	{
       		if(pair.Value==1)
       		{
           		if(pair.Key>max)
           		{
               			max=pair.Key;
           		}
       		}
   
   	}
 	return max;
    }
}