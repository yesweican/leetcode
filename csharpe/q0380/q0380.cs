using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// RandomSet
    /// </summary>
    public class q380
    {
        int[] data;
        int dataCount;
        Dictionary<int, int> dict;


        /** Initialize your data structure here. */
        public q380()
        {
            data = new int[10000];
            dataCount = 0;
            dict = new Dictionary<int, int>();
        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            if (dict.ContainsKey(val))
                return false;

            data[dataCount] = val;
            dict.Add(val, dataCount);
            dataCount++;

            return true;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            if (!dict.ContainsKey(val))
                return false;

            int i = dict[val];
            int temp = data[dataCount - 1];
            data[i] = temp;

            dict[temp] = i;
            dict.Remove(val);
            dataCount--;

            return true;

        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            Random r= new Random();

            double d = r.NextDouble();
            int j = Convert.ToInt32((dataCount-1) * d);

            return data[j];
        }
    }
}
