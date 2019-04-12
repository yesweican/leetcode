using System;
using System.Collections;
using System.Collections.Generic;
public class Solution {
    public int itemCount { get; set; }
    public List<int> originalArray { get; set; }
    public List<IList<int>> arrayPermutations { get; set; }   
    
    public IList<IList<int>> Permute(int[] nums) {
        itemCount=nums.Length; 
        originalArray=new List<int>();
        for (int i=0; i<itemCount;i++)
        {
            originalArray.Add(nums[i]);
        }    

        arrayPermutations = new List<IList<int>>();

        GeneratePermuatation(originalArray, new List<int>(), 0);
        return (IList<IList<int>>)arrayPermutations;      
        
    }
    
   private  void GeneratePermuatation(List<int> remainingItems, List<int> prefixItems, int currentDepth)
    {
        if (remainingItems.Count() == 0)
            arrayPermutations.Add(prefixItems);

        for (int i = 0; i < remainingItems.Count; i++)
        {
            List<int> newRemaining = new List<int>(remainingItems);
            List<int> newPrefixs = new List<int>(prefixItems);

            newPrefixs.Add(remainingItems[i]);
            newRemaining.RemoveAt(i);

            GeneratePermuatation(newRemaining, newPrefixs, currentDepth + 1);

        }
    }    
}