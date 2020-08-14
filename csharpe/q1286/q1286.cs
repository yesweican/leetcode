using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge05
{
    public class q1286
    {
        List<string> _data;
        //Dictionary<string, int> dict;
        int currentIndex;

        public q1286(string characters, int combinationLength)
        {
            _data = new List<string>();
            //dict = new Dictionary<string, int>();

            recursiveProcess(characters, "", combinationLength);
            currentIndex = 0;
        }

        private void recursiveProcess(string s, string prefix, int remaining)
        {
            if(remaining==0)
            {
                _data.Add(prefix);
                //dict.Add(prefix, _data.Count);
                return;
            }

            if (s.Length < remaining)
                return;

            string newPrefix = prefix + s[0];
            string newStr = s.Substring(1);
            recursiveProcess(newStr, newPrefix, remaining - 1);
            recursiveProcess(newStr, prefix, remaining);

        }

        public string Next()
        {
            string temp = _data[currentIndex];
            currentIndex++;
            return temp;
        }

        public bool HasNext()
        {
            if (currentIndex < _data.Count)
                return true;
            else
                return false;
        }
    }
}
