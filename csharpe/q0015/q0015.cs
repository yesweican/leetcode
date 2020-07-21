using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class q015
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            HashSet<string> set = new HashSet<string>();
            List<IList<int>> results = new List<IList<int>>(); 
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                for (int j = i+1; j < nums.Length - 1; j++)
                {
                    for (int k = j+1; k < nums.Length; k++)
                    {
                        //string s = nums[i].ToString() + "," + nums[j].ToString() + "," + nums[k].ToString();
                        //Console.WriteLine(s);
                        if ((nums[i]+nums[j]+nums[k])==0)
                        {
                            string s = nums[i].ToString() + "," + nums[j].ToString() + "," + nums[k].ToString();
                            Console.WriteLine(s);
                            if (!set.Contains(s))
                            {
                                set.Add(s);
                                List<int> a = new List<int>();
                                a.Add(nums[i]);
                                a.Add(nums[j]);
                                a.Add(nums[k]);
                                results.Add(a);
                            }
                        }
                    }//end of for
                }//end of for
            }//end of for
            return results;
        }


        public IList<IList<int>> ThreeSumBetter(int[] nums)
        {
            List<IList<int>> results = new List<IList<int>>();
            if (nums == null || nums.Length < 3)
                return results;

            Array.Sort(nums);

            if ((nums[0] + nums[1] + nums[2]) > 0) return results;
            if((nums[nums.Length-1]+nums[nums.Length-1]+nums[nums.Length-1])<0) return results;

            for (int i = 0; i < nums.Length - 2; i++)
            {
                //variable i needs to skip too to avoid duplicates
                if ((i > 0) && (nums[i - 1] == nums[i]))
                    continue;

                int j=i+1, k=nums.Length-1;
                while (j < k)
                {
                    int temp = nums[i] + nums[j] + nums[k];

                    if (temp == 0)
                    {
                        string s = nums[i].ToString() + "," + nums[j].ToString() + "," + nums[k].ToString();
                        Console.WriteLine(s);
                        List<int> a = new List<int>() { nums[i], nums[j], nums[k] };
                        results.Add(a);
                        ////skipping to avoid duplicates
                        while (((j + 1) < k) && (nums[j] == nums[j + 1]))
                            j++;
                        j++;
                        while ((j < (k-1)) && (nums[k] == nums[k- 1]))
                            k--;
                        k--;

                    }
                    else
                    {
                        if (temp < 0)
                            j++;
                        else
                            k--;
                    }
                }//end of while

            }//end of for
            return results;
        }

    }
}
