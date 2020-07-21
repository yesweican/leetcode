using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    //
    public class q422
    {
        public bool ValidWordSquareBasic(IList<string> words)
        {
            int length = words[0].Length;
            int counter = 0;
            char[,] data = new char[length, length];
            foreach (var w in words)
            {
                if (w.Length != length)
                    return false;
                char[] temp = w.ToCharArray();
                for (int i = 0; i < length; i++)
                {
                    data[counter, i] = temp[i];
                }
                int j = 0;
                while (j < counter)
                {
                    if (data[counter, j] != data[j, counter])
                        return false;
                    j++;
                }

                counter++;
                if (counter > length)
                    return false;
            }
            return true;
        }

        public bool ValidWordSquare2(IList<string> words)
        {
            int length = 0;
            int rowcount = 0;
            ///Step One
            foreach (var w in words)
            {
                rowcount++;
                if (w.Length > length)
                    length = w.Length;
            }

            if (words[0].Length != length)
                return false;
            if (rowcount != length)
                return false;

            char[,] data = new char[length, length];
            //Step Two
            for(int row = 0; row<rowcount; row++)
            {
                char[] temp = words[row].ToCharArray();
                //if the words were not the same length
                for (int i = 0; i < length; i++)
                {
                    if (i < temp.Length)
                        data[row, i] = temp[i];
                    else
                        data[row, i] = '$';

                }
            }

            //Step Three
            int counter = 1;
            while(counter<length)
            {
                //valdate until the center or the length of the current string
                for(int j=0; j<counter; j++)
                {
                    if (data[counter, j] != data[j, counter])
                        return false;
                }

                counter++;
            }
            return true;
        }

        public bool ValidWordSquare(IList<string> words)
        {
            int length = 0;
            int rowcount = 0;

            //Step One Preprocess
            foreach (var w in words)
            {
                rowcount++;
                if (w.Length > length)
                    length = w.Length;
            }

            if (words[0].Length != length)
                return false;
            if (rowcount != length)
                return false;

            char[,] data = new char[length, length];

            //Step Two=Combining loading and validation
            for (int row = 0; row < rowcount; row++)
            {
                char[] temp = words[row].ToCharArray();
                //if the words were not the same length
                for (int i = 0; i < length; i++)
                {
                    if (i < temp.Length)
                        data[row, i] = temp[i];
                    else
                        data[row, i] = '$';

                    if (i < row)
                    {
                        if (data[row, i] != data[i, row])
                            return false;
                    }

                }
            }

            return true;
        }

    }
}
