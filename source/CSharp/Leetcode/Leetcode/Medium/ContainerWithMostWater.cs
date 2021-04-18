using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Medium
{
    /// <summary>
    /// Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai).
    /// n vertical lines are drawn such that the two endpoints of the line i is at (i, ai) and (i, 0).
    /// Find two lines, which, together with the x-axis forms a container, such that the container contains the most water.
    /// Notice that you may not slant the container.
    /// </summary>
    /// <remarks>
    /// Constraints:
    /// n == height.length
    /// 2 <= n <= 10^5
    /// 0 <= height[i] <= 10^4
    /// https://leetcode.com/problems/container-with-most-water/
    /// </remarks>
    /// <example>
    /// Input: height = [1,8,6,2,5,4,8,3,7]
    /// Output: 49
    /// Input: height = [1,1]
    /// Output: 1
    /// Input: height = [4,3,2,1,4]
    /// Output: 16
    /// </example>
    class ContainerWithMostWater
    {
        public static int MaxArea(int[] height)
        {
            var maxArea = Math.Min(height[0], height[^1]) * (height.Length - 1);

            for (int i = 0; i < height.Length - 1; ++i)
            {
                if (height[i] <= 0) continue;
                var index = maxArea / height[i] + 1;
                for (int j = index; j < height.Length; j++)
                {
                    var area = Math.Min(height[i], height[j]) * (j - i);
                    if (area > maxArea)
                        maxArea = area;
                }
            }

            return maxArea;
        }

        public static int MaxArea_v2(int[] height)
        {
            var maxArea = 0;

            var l = 0;
            var r = height.Length - 1;
            while (l < r)
            {
                var area = Math.Min(height[l], height[r]) * (r - l);
                if (area > maxArea)
                    maxArea = area;
                if (height[l] <= height[r])
                    ++l;
                else
                    --r;
            }

            return maxArea;
        }
    }
}
