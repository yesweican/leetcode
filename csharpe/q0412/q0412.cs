using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q412
    {
        public IList<string> FizzBuzz(int n)
        {
            List<string> results = new List<string>();

            for (int i = 1; i <= n; i++)
            {
                if ((i % 3) == 0)
                {
                    if ((i % 5) == 0)
                    {
                        results.Add("FizzBuzz");
                    }
                    else
                    {
                        results.Add("Fizz");
                    }
                }
                else
                {
                    if ((i % 5) == 0)
                    {
                        results.Add("Buzz");
                    }
                    else
                    {
                        results.Add(i.ToString());
                    }
                }
            }

            return results;
        }

        public IList<string> FizzBuzzBetter(int n)
        {
            List<string> results = new List<string>();

            for (int i = 1; i <= n; i++)
            {
                if ((i % 15) == 0)
                {
                    results.Add("FizzBuzz"); continue;
                }

                if ((i % 5) == 0)
                {
                    results.Add("Buzz"); continue;
                }

                if ((i % 3) == 0)
                {
                    results.Add("Fizz"); continue;
                }

                results.Add(i.ToString());
            }

            return results;
        }

    }
}
