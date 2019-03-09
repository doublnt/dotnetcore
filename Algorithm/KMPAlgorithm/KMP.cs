using System;

namespace KMPAlgorithm
{
    public class KMP
    {
        public void KMPSearch(string pattern, string content)
        {
            int patternLength = pattern.Length;
            int contentLength = content.Length;

            int[] lps = new int[patternLength];
            int j = 0;

            ComputeLPSArray(pattern, patternLength, lps);

            int i = 0;
            while (i < contentLength)
            {
                if (pattern[j] == content[i])
                {
                    j++;
                    i++;
                }
                if (j == patternLength)
                {
                    Console.Write("Found Pattern at index" + (i - j));
                    j = lps[j - 1];
                }
                else if (i < contentLength && pattern[j] != content[i])
                {
                    if (j != 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }
            }

        }

        public void ComputeLPSArray(string pattern, int patternLength, int[] lps)
        {
            int len = 0;
            int i = 1;
            lps[0] = 0;

            while (i < patternLength)
            {
                if (pattern[i] == pattern[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else
                {
                    if (len != 0)
                    {
                        len = lps[len - 1];
                    }
                    else
                    {
                        lps[i] = len;
                        i++;
                    }
                }
            }
        }
    }
}
