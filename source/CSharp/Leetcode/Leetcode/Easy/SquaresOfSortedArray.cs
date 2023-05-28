using System;

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
        var length = nums.Length;

        if (length == 0)
        {
            return Array.Empty<int>();
        }
        else if (length == 1)
        {
            return new[] { nums[0] * nums[0] };
        }

        var result = new int[length];
        var left = 0;
        var right = length - 1;
        var index = right;
        var leftValue = nums[left] * nums[left];
        var rightValue = nums[right] * nums[right];

        while (left < right)
        {
            if (leftValue < rightValue)
            {
                result[index--] = rightValue;
                right--;
                rightValue = nums[right] * nums[right];
            }
            else if (leftValue > rightValue)
            {
                result[index--] = leftValue;
                left++;
                leftValue = nums[left] * nums[left];
            }
            else
            {
                result[index--] = leftValue;
                result[index--] = rightValue;
                left++;
                right--;
                leftValue = nums[left] * nums[left];
                rightValue = nums[right] * nums[right];
            }
        }

        if (left == right)
        {
            result[index] = leftValue;
        }

        return result;
    }
}