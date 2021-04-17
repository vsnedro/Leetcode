using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    /// <summary>
    /// Given a signed 32-bit integer x, return x with its digits reversed.
    /// If reversing x causes the value to go outside the signed 32-bit integer range [-2^31, 2^31 - 1], then return 0.
    /// Assume the environment does not allow you to store 64-bit integers(signed or unsigned).
    /// </summary>
    /// <remarks>
    /// Constraints:
    /// -2^31 <= x <= 2^31 - 1
    /// https://leetcode.com/problems/reverse-integer/
    /// </remarks>
    /// <example>
    /// Input: x = -1230
    /// Output: -321
    /// </example>
    class ReverseInteger
    {
        public static int Reverse(int x)
        {
            if (x == 0)
                return 0;

            var limitInt = int.MaxValue / 10;
            var limitFrac = int.MaxValue % 10;

            var source = (x > int.MinValue) ? Math.Abs(x) : int.MaxValue;
            var reversed = 0;
            while (source > 0)
            {
                var fractional = source % 10;
                if ((reversed > limitInt) || ((reversed == limitInt) && (fractional > limitFrac)))
                    return 0;
                reversed *= 10;
                reversed += fractional;
                source /= 10;
            }

            return x > 0 ? reversed : -reversed;
        }
    }
}
