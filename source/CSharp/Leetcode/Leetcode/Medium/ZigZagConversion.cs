using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Medium
{
    /// <summary>
    /// The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)
    /// P   A   H   N
    /// A P L S I I G
    /// Y   I   R
    /// And then read line by line: "PAHNAPLSIIGYIR"
    /// Write the code that will take a string and make this conversion given a number of rows:
    /// string convert(string s, int numRows);
    /// </summary>
    /// <remarks>
    /// Constraints:
    /// 1 <= s.length <= 1000
    /// s consists of English letters(lower-case and upper-case), ',' and '.'.
    /// 1 <= numRows <= 1000
    /// https://leetcode.com/problems/zigzag-conversion/
    /// </remarks>
    /// <example>
    /// Input: s = "PAYPALISHIRING", numRows = 4
    /// Output: "PINALSIGYAHRPI"
    /// Explanation:
    /// P     I    N
    /// A   L S  I G
    /// Y A   H R
    /// P     I
    /// </example>
    class ZigZagConversion
    {
        public static string Convert(string s, int numRows)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException(nameof(s));
            if (numRows <= 0)
                throw new ArgumentOutOfRangeException(nameof(numRows));

            if ((numRows == 1) || (s.Length <= numRows))
                return s;

            var words = new StringBuilder[numRows];
            for (int i = 0; i < words.Length; ++i)
                words[i] = new StringBuilder((int)Math.Round(s.Length / (float)(numRows - 1)));

            var index = 0;
            while (index < s.Length)
            {
                // vertical row
                for (int i = index; (i < index + numRows) && (i < s.Length); ++i)
                    words[i - index].Append(s[i]);
                index += numRows;
                // zigzag
                for (int i = index; (i < index + numRows - 2) && (i < s.Length); ++i)
                    words[numRows - 2 - (i - index)].Append(s[i]);
                index += numRows - 2;
            }

            var convertedString = new StringBuilder(s.Length);
            foreach (var word in words)
                convertedString.Append(word);

            return convertedString.ToString();
        }
    }
}
