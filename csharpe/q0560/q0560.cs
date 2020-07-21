using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class q560
{
    public int SubarraySumBadSlow(int[] nums, int k)
    {
        int count = 0;
        int[,] buffer = new int[nums.Length, nums.Length];

        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            buffer[0, i] = sum;
            if (sum == k)
                count++;
        }

        for (int i = 1; i < nums.Length; i++)
            for (int j = i; j < nums.Length; j++)
            {
                if (i == j)
                {
                    buffer[i, i] = nums[i];
                    if (nums[i] == k)
                        count++;
                }
                else
                {
                    buffer[i, j] = buffer[0, j] - buffer[0, i - 1];
                    if (buffer[i, j] == k)
                        count++;
                }
            }

        return count;
    }

    public int SubarraySum(int[] nums, int k)
    {
        int count = 0;
        int[] buffer = new int[nums.Length];

        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            buffer[i] = sum;
            if (sum == k)
                count++;
        }

        for (int i = 1; i < nums.Length; i++)
            for (int j = i; j < nums.Length; j++)
            {
                if (i == j)
                {
                    if (nums[i] == k)
                        count++;
                }
                else
                {
                    if (buffer[j] - buffer[i - 1] == k)
                        count++;
                }
            }

        return count;
    }
}

