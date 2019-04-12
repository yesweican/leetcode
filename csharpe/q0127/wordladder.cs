public class Solution 
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) 
    {
            int theLength = 1;
            int targetindex = -1;

            if (!wordList.Contains(endWord))
                return 0;
            else
            {
                targetindex = wordList.IndexOf(endWord);
                Console.Write("**{0}** ", targetindex); 
            }

            //////////////////////////////////////
            int n = wordList.Count;
            int[,] WordListMatrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                
                Console.Write("\"{0}\", ", wordList[i]);
                for (int j = i+1; j < n; j++)
                {
                    if(LadderUtility.IsDistanceOne(wordList[i], wordList[j]))
                    {
                        WordListMatrix[i, j] = 1;
                        WordListMatrix[j, i] = 1;
                    }
                }
            }

            ArrayList processedQueue = new ArrayList();
            ArrayList processingQueue = new ArrayList();

            if(wordList.Contains(beginWord))
	        {
                int ibegin = wordList.IndexOf(beginWord);
                processingQueue.Add(ibegin);
                //theLength = 0;
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if(LadderUtility.IsDistanceOne(beginWord, wordList[i]))
                    {
                        processingQueue.Add(i);
                        theLength = 2;
                    }
                }

                if (theLength == 1)
                    return 0;
            }

            while (processingQueue.Count>0)
            {
                for (int j = 0; j < processingQueue.Count; j++)
                {
                    int currentWordIndex = (int) processingQueue[j];
                    if (currentWordIndex == targetindex)
                        return theLength;
                    //adding to processedQueue if necessary
                    if (!processedQueue.Contains(currentWordIndex))
                    {
                        processedQueue.Add(currentWordIndex);
                    }
                }
                ArrayList tempQueue = new ArrayList();

                for (int i = 0; i < processingQueue.Count; i++)
                {
                    int i0 = (int) processingQueue[i];

                    for (int j = 0; j < n; j++)
                    {
                        //process each of its children
                        if (WordListMatrix[i0, j] == 1)
                        {   //check processedQueue if necessary
                            if (!processedQueue.Contains(j))
                            {
                                //if add chichen never processed before to the tempQueue
                                tempQueue.Add(j);
                            }
                        }

                    }
                }

                processingQueue = tempQueue;
                theLength++;
            }
            return 0;
        }     
}

    public static class LadderUtility
    {
	    public static bool IsDistanceOne(string word1, string word2)
	    {
	    //distance between two words is one switch
            if (word1.Length != word2.Length)
                return false;
            else
            {
                int diff = 0;
                char[] word1chars = word1.ToCharArray();
                char[] word2chars = word2.ToCharArray();

                for (int i = 0; i < word1.Length; i++)
                {
                    if(word1chars[i]!= word2chars[i])
                        diff++;
                    if (diff > 1) return false;
                }

                if (diff == 0)
                    return false;

                return true;
            }
	    //Is only one character difference?
	    }
    }