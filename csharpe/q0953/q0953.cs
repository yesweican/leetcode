using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class q953
    {
        public Dictionary<char, char> dict;
        public bool IsAlienSorted(string[] words, string order)
        {
            char[] characters = order.ToCharArray();
            dict = new Dictionary<char, char>();
            for (int i = 0; i < characters.Length; i++)
            {
                char temp = 'a';
                temp += (char)i;//special operator;

                dict.Add(order[i], temp);
            }

            string start = translate(words[0]);

            for (int i = 1; i < words.Length ; i++)
            {
                string temp = translate(words[i]);
                if (String.Compare(start,temp)>0)
                    return false;
                start = temp;
            }

            return true;
        }

        private string translate(string alienstr)
        {
            char[] buffer = alienstr.ToCharArray();
            char[] result = new char[buffer.Length];


            for (int i=0; i<buffer.Length;i++)
            {
                char c = buffer[i];
                result[i] = dict[c];
            }

            return new string(result);
        }
    }
}
