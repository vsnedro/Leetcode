using System.Linq;
using System;
using System.Diagnostics.Metrics;
using System.Collections.Generic;

namespace Leetcode.Easy;

/// <summary>
/// Given an integer array nums sorted in non-decreasing order,
/// return an array of the squares of each number sorted in non-decreasing order.
/// </summary>
/// <remarks>
/// https://leetcode.com/problems/squares-of-a-sorted-array/description/
/// </remarks>
/// <example>
/// Example 1:
/// Input: nums = [-4,-1,0,3,10]
/// Output: [0,1,9,16,100]
/// Explanation: After squaring, the array becomes[16, 1, 0, 9, 100].
/// After sorting, it becomes[0, 1, 9, 16, 100].
/// Example 2:
/// Input: nums = [-7,-3,2,3,11]
/// Output: [4,9,9,49,121]
/// </example>
public class Solution
{
    public int[] SortedSquares(int[] nums)
    {
        var result = new List<int>(nums.Length);
        var n = new List<int>(nums.Length);
        var p = new List<int>(nums.Length);

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] < 0)
            {
                n.Insert(0, nums[i] * nums[i]);
            }
            else
            {
                p.Add(nums[i] * nums[i]);
            }
        }

        var indexN = 0;
        var indexP = 0;

        while (indexN < n.Count && indexP < p.Count)
        {
            if (n[indexN] < p[indexP])
            {
                result.Add(n[indexN++]);
            }
            else if (n[indexN] == p[indexP])
            {
                result.Add(n[indexN++]);
                result.Add(p[indexP++]);
            }
            else
            {
                result.Add(p[indexP++]);
            }
        }

        if (indexN < n.Count)
        {
            result.AddRange(n.Skip(indexN));
        }
        else if (indexP < p.Count)
        {
            result.AddRange(p.Skip(indexP));
        }

        return result.ToArray();
    }
}