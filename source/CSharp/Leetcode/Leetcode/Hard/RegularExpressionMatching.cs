using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Hard
{
    /// <summary>
    /// Given an input string (s) and a pattern (p), implement regular expression matching with support for '.' and '*' where: 
    /// '.' Matches any single character.​​​​
    /// '*' Matches zero or more of the preceding element.
    /// The matching should cover the entire input string (not partial).
    /// </summary>
    /// <remarks>
    /// Constraints:
    /// 0 <= s.length <= 20
    /// 0 <= p.length <= 30
    /// s contains only lowercase English letters.
    /// p contains only lowercase English letters, '.', and '*'.
    /// It is guaranteed for each appearance of the character '*', there will be a previous valid character to match.
    /// https://leetcode.com/problems/regular-expression-matching/
    /// </remarks>
    /// <example>
    /// Input: s = "aa", p = "a"
    /// Output: false
    /// Explanation: "a" does not match the entire string "aa".
    /// Input: s = "aa", p = "a*"
    /// Output: true
    /// Explanation: '*' means zero or more of the preceding element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".
    /// Input: s = "ab", p = ".*"
    /// Output: true
    /// Explanation: ".*" means "zero or more (*) of any character (.)".
    /// Input: s = "aab", p = "c*a*b"
    /// Output: true
    /// Explanation: c can be repeated 0 times, a can be repeated 1 time. Therefore, it matches "aab".
    /// </example>
    class RegularExpressionMatching
    {
        public static bool IsMatch(string s, string p)
        {
            if (string.IsNullOrEmpty(p))
                return string.IsNullOrEmpty(s);
            if (p == ".*")
                return true;

            var sIndex = s.Length - 1;
            var pIndex = p.Length - 1;

            while ((sIndex > 0) && (pIndex > 0))
            {
                var sChar = s[sIndex];

                switch (p[pIndex])
                {
                    case '*':
                        var pChar = p[pIndex - 1];
                        switch (pChar)
                        {
                            case '.':
                                // TODO
                                break;

                            default:
                                if (sChar != pChar)
                                {
                                    pIndex -= 2;
                                }
                                else
                                {
                                    var sCharPos = sIndex;
                                    while ((sCharPos >= 0) && (s[sCharPos] == pChar))
                                        sCharPos--;
                                    var pCharPos = pIndex - 1;
                                    while ((pCharPos >= 0) && (p[pCharPos] == pChar))
                                        pCharPos--;
                                    var sCharNum = sIndex - sCharPos;
                                    var pCharNum = pIndex - pCharPos;

                                    s = "baaa"  !=  p = "baaaaa*"
                                    s = "baaa"      p = "baa*aa*aa*"
                                    s = "baaa"      p = "baaa*a*aa*"
                                    s = "baaa"      p = "baaa*a*a*a*"
                                    s = "baaa"      p = "baaa*a*a*a*.*a*"
                                    s = "baaa"      p = "baa*a*"
                                    s = "baaa"      p = "baaa*a*"
                                    s = "baaa"      p = "baaaa*a*"
                                    s = "baaa"      p = "ba*a*a*a*"
                                    s = "baaa"      p = "ba*a*aa*"
                                    s = "baaa"      p = "ba*aaa*"
                                    s = "baaa"      p = "baaaa*"
                                    s = "baaa"      p = "baaa*"
                                    s = "baaa"      p = "baa*"
                                    s = "baaa"      p = "ba*"
                                    s = "baaa"      p = "ba*a"
                                    s = "baaa"      p = "ba*aa"
                                    s = "baaa"      p = "ba*aaa"
                                    s = "baaa"      p = "ba*a*a*aaa"
                                }
                                break;
                        }
                        break;

                    case '.':
                        --sIndex;
                        --pIndex;
                        break;

                    default:
                        if (sChar != p[pIndex])
                            return false;
                        --sIndex;
                        --pIndex;
                        break;
                }
            }

            return (sIndex == -1) && (pIndex == -1);
        }
    }
}
