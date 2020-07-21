using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{

    /**
 * The Read4 API is defined in the parent class Reader4.
 *     int Read4(char[] buf);
 */

    public class q157
    {
        /**
         * @param buf Destination buffer
         * @param n   Number of characters to read
         * @return    The number of actual characters read
         */
        private int Read4(char[] buf)
        {
            return 0;
        }

        public int Read(char[] buf, int n)
        {
            int remainder = n % 4;
            int calls = (n - remainder) / 4;
            int count = 0;

            for (int i = 0; i < ((remainder == 0) ? calls : (calls + 1)); i++)
            {
                char[] chunk = new char[4];
                int m = Read4(chunk);

                for (int j = 0; j < m; j++)
                {
                    if (i < calls)
                    {
                        buf[i*4+j] = chunk[j];
                        count++;
                    }
                    else
                    {
                        if ((i == calls) && (j < remainder))
                        {
                            buf[i * 4 + j] = chunk[j];
                            count++;
                        }
                    }

                }

                //if reaching the File End Early, break out.
                if (m < 4)
                {
                    break;
                }


            }

            return count;    

        }
    }
}
