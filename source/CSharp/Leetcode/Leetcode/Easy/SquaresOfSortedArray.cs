using System.Linq;
using System.Collections.Generic;

namespace Leetcode.Easy.SquaresOfSortedArray;

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
        var result = new LinkedList<int>();
        var index = default(int);

        for (index = 0; index < nums.Length; index++)
        {
            if (nums[index] <= 0)
            {
                result.AddFirst(nums[index] * nums[index]);
            }
            else
            {
                break;
            }
        }

        if (index == nums.Length)
        {
            return result.ToArray();
        }

        if (result.Count == 0)
        {
            return nums.Select(x => x * x).ToArray();
        }

        if (nums[index] * nums[index] < result.First.Value)
        {
            result.AddFirst(nums[index] * nums[index]);
            index++;
        }

        var node = result.First;
        for (var i = index; i < nums.Length; i++)
        {
            var value = nums[i] * nums[i];

            while (node.Next != null && node.Next.Value <= value)
            {
                node = node.Next;
            }

            node = result.AddAfter(node, value);
        }

        return result.ToArray();
    }
}