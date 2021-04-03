using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    /// <summary>
    /// Given an array of integers nums and an integer target,
    /// return indices of the two numbers such that they add up to target.
    /// You may assume that each input would have exactly one solution,
    /// and you may not use the same element twice.
    /// You can return the answer in any order.
    /// </summary>
    /// <remarks>
    /// Constraints:
    /// 2 <= nums.length <= 10^3
    /// -10^9 <= nums[i] <= 10^9
    /// -10^9 <= target <= 10^9
    /// Only one valid answer exists.
    /// https://leetcode.com/problems/two-sum
    /// </remarks>
    /// <example>
    /// Input: nums = [2,7,11,15], target = 9
    /// Output: [0,1]
    /// Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
    /// </example>
    internal class TwoSum
    {
        public static int[] TwoSum_(int[] nums, int target)
        {
            if (nums == null)
                throw new ArgumentNullException(nameof(nums));
            if (nums.Length == 0)
                throw new ArgumentException("Array cannot be empty", nameof(nums));

            var indices = new Dictionary<int, int>(nums.Length);

            for (int i = 0; i < nums.Length; i++)
            {
                var diff = target - nums[i];
                if (indices.ContainsKey(diff))
                {
                    return new[] { i, indices[diff] };
                }
                indices.TryAdd(nums[i], i);
            }

            return Array.Empty<int>();
        }
    }
}
