using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Medium
{
    /// <summary>
    /// Given a string s, return the longest palindromic substring in s.
    /// </summary>
    /// <remarks>
    /// Constraints:
    /// 1 <= s.length <= 1000
    /// s consist of only digits and English letters(lower-case and/or upper-case)
    /// https://leetcode.com/problems/longest-palindromic-substring
    /// </remarks>
    /// <example>
    /// Input: s = "babad"
    /// Output: "bab"
    /// Note: "aba" is also a valid answer.
    /// </example>
    class LongestPalindromicSubstring
    {
        public static string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException(nameof(s));

            // создаём псевдостроку с границами в виде символа '#'
            var s2 = new char[s.Length * 2 + 1];
            Array.Fill(s2, '#');
            for (int i = 0; i < s.Length; ++i)
                s2[i * 2 + 1] = s[i];

            var p = new int[s2.Length];
            int r = 0, c = 0, index = 0, i_mir = 0;
            int maxLen = 1;

            for (int i = 0; i < s2.Length; ++i)
            {
                i_mir = 2 * c - i;

                // Если мы попадаем в пределы радиуса прошлого результата,
                // то начальное значение текущего радиуса можно взять из зеркального результата
                p[i] = r > i ? Math.Min(p[i_mir], r - i) : 0;

                while ((i > p[i]) && ((i + p[i] + 1) < s2.Length) && (s2[i - p[i] - 1] == s2[i + p[i] + 1]))
                    ++p[i];

                if (p[i] + i > r)
                {
                    c = i;
                    r = i + p[i];
                }

                if (maxLen < p[i])
                {
                    maxLen = p[i];
                    index = i;
                }
            }

            // Отображаем найденные позиции на оригинальную строку
            return s.Substring((index - maxLen) / 2, maxLen);
        }
    }
}
