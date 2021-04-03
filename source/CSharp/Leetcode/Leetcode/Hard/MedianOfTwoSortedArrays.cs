using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Hard
{
    /// <summary>
    /// Given two sorted arrays nums1 and nums2 of size m and n respectively,
    /// return the median of the two sorted arrays.
    /// </summary>
    /// <remarks>
    /// Constraints:
    /// nums1.length == m
    /// nums2.length == n
    /// 0 <= m <= 1000
    /// 0 <= n <= 1000
    /// 1 <= m + n <= 2000
    /// -10^6 <= nums1[i], nums2[i] <= 10^6
    /// https://leetcode.com/problems/median-of-two-sorted-arrays
    /// </remarks>
    /// <example>
    /// Input: nums1 = [1,3], nums2 = [2]
    /// Output: 2.00000
    /// Explanation: merged array = [1, 2, 3] and median is 2.
    /// Input: nums1 = [1,2], nums2 = [3,4]
    /// Output: 2.50000
    /// Explanation: merged array = [1, 2, 3, 4] and median is (2 + 3) / 2 = 2.5.
    /// </example>
    internal class MedianOfTwoSortedArrays
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1 == null)
                throw new ArgumentNullException(nameof(nums1));
            if (nums2 == null)
                throw new ArgumentNullException(nameof(nums2));
            if ((nums1.Length <= 0) && (nums2.Length <= 0))
                throw new ArgumentException("Both arrays cannot be empty.");

            var nums = new List<int>(nums1.Length + nums2.Length);
            nums.AddRange(nums1);
            nums.AddRange(nums2);
            nums.Sort();

            var mid = nums.Count / 2;
            return nums.Count % 2 == 1 ? nums[mid] : (nums[mid] + nums[mid - 1]) / 2d;
        }

        public static double FindMedianSortedArrays_v2(int[] nums1, int[] nums2)
        {
            if (nums1 == null)
                throw new ArgumentNullException(nameof(nums1));
            if (nums2 == null)
                throw new ArgumentNullException(nameof(nums2));
            if ((nums1.Length <= 0) && (nums2.Length <= 0))
                throw new ArgumentException("Both arrays cannot be empty.");

            var nums = new int[nums1.Length + nums2.Length];
            nums1.CopyTo(nums, 0);
            nums2.CopyTo(nums, nums1.Length);
            Array.Sort(nums);

            var mid = nums.Length / 2;
            return nums.Length % 2 == 1 ? nums[mid] : (nums[mid] + nums[mid - 1]) / 2d;
        }

        public static double FindMedianSortedArrays_v3(int[] nums1, int[] nums2)
        {
            if (nums1 == null)
                throw new ArgumentNullException(nameof(nums1));
            if (nums2 == null)
                throw new ArgumentNullException(nameof(nums2));
            if ((nums1.Length <= 0) && (nums2.Length <= 0))
                throw new ArgumentException("Both arrays cannot be empty.");

            var nums = new int[nums1.Length + nums2.Length];
            var index1 = 0;
            var index2 = 0;
            var index = 0;

            // merge two arrays
            while ((index1 < nums1.Length) && (index2 < nums2.Length))
            {
                if (nums1[index1] < nums2[index2])
                {
                    nums[index++] = nums1[index1++];
                }
                else if (nums1[index1] > nums2[index2])
                {
                    nums[index++] = nums2[index2++];
                }
                else if (nums1[index1] == nums2[index2])
                {
                    nums[index++] = nums1[index1++];
                    nums[index++] = nums2[index2++];
                }
            }

            // copy the rest of the elements
            while (index1 < nums1.Length)
            {
                nums[index++] = nums1[index1++];
            }
            while (index2 < nums2.Length)
            {
                nums[index++] = nums2[index2++];
            }

            var mid = nums.Length / 2;
            return nums.Length % 2 == 1 ? nums[mid] : (nums[mid] + nums[mid - 1]) / 2d;
        }

        public static void Test()
        {
            const int tries = 10;
            const int numCountMax = 1000;
            const int numValueMin = -1_000_000;
            const int numValueMax = 1_000_000;

            var timer = new Stopwatch();
            var rnd = new Random();

            for (int i = 0; i < tries; i++)
            {
                var m = rnd.Next(numCountMax + 1);
                var n = rnd.Next(numCountMax + 1);
                if (m + n == 0)
                    n++;

                var nums1 = new int[n];
                var nums2 = new int[m];

                // fill and sort arrays
                for (int i1 = 0; i1 < n; i1++)
                    nums1[i1] = rnd.Next(-numValueMin, numValueMax + 1);
                for (int i2 = 0; i2 < m; i2++)
                    nums2[i2] = rnd.Next(-numValueMin, numValueMax + 1);
                Array.Sort(nums1);
                Array.Sort(nums2);

                timer.Start();
                var median = FindMedianSortedArrays(nums1, nums2);
                timer.Stop();
                var ticks = timer.ElapsedTicks;

                timer.Start();
                var median_v2 = FindMedianSortedArrays_v2(nums1, nums2);
                timer.Stop();
                var ticks_v2 = timer.ElapsedTicks;

                timer.Start();
                var median_v3 = FindMedianSortedArrays_v3(nums1, nums2);
                timer.Stop();
                var ticks_v3 = timer.ElapsedTicks;

                Console.WriteLine($"n = {n}");
                Console.WriteLine($"m = {m}");
                Console.WriteLine($"FindMedianSortedArrays = {median}");
                Console.WriteLine($"FindMedianSortedArrays_v2 = {median_v2}");
                Console.WriteLine($"FindMedianSortedArrays_v3 = {median_v3}");
                Console.WriteLine($"ticks = {ticks}");
                Console.WriteLine($"ticks_v2 = {ticks_v2}");
                Console.WriteLine($"ticks_v3 = {ticks_v3}");
                Console.WriteLine();
            }
        }
    }
}
