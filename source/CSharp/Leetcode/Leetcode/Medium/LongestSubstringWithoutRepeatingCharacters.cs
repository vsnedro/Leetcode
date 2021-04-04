using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Medium
{
    /// <summary>
    /// Given a string s, find the length of the longest substring without repeating characters.
    /// </summary>
    /// <remarks>
    /// Constraints:
    /// 0 <= s.length <= 5 * 10^4
    /// s consists of English letters, digits, symbols and spaces.
    /// https://leetcode.com/problems/longest-substring-without-repeating-characters/
    /// </remarks>
    /// <example>
    /// Input: s = "pwwkew"
    /// Output: 3
    /// Explanation: The answer is "wke", with the length of 3.
    /// Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
    /// </example>
    internal class LongestSubstringWithoutRepeatingCharacters
    {
        public static int LengthOfLongestSubstring(string s)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            if (s.Length <= 1)
                return s.Length;

            var maxLength = 1;

            for (int l = 0; l < s.Length - 1; l++)
            {
                var r = l + 1;
                if (!s[r].Equals(s[l]))
                {
                    var curLength = 2;
                    r++;
                    while ((r < s.Length) && (s.IndexOf(s[r], l) == r))
                    {
                        r++;
                        curLength++;
                    }

                    if (curLength > maxLength)
                        maxLength = curLength;
                }

                if (s.Length - l <= maxLength)
                    break;
            }

            return maxLength;
        }
    }
}
