using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Medium
{
    /// <summary>
    /// Definition for singly-linked list.
    /// </summary>
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    /// <summary>
    /// You are given two non-empty linked lists representing two non-negative integers.
    /// The digits are stored in reverse order, and each of their nodes contains a single digit.
    /// Add the two numbers and return the sum as a linked list.
    /// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
    /// </summary>
    /// <remarks>
    /// Constraints:
    /// The number of nodes in each linked list is in the range[1, 100].
    /// 0 <= Node.val <= 9
    /// It is guaranteed that the list represents a number that does not have leading zeros.
    /// https://leetcode.com/problems/add-two-numbers
    /// </remarks>
    /// <example>
    /// Example 1:
    /// Input: l1 = [2,4,3], l2 = [5,6,4]
    /// Output: [7,0,8]
    /// Explanation: 342 + 465 = 807.
    /// </example>
    internal class AddTwoNumbers
    {
        public static ListNode AddTwoNumbers_(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                throw new ArgumentNullException(nameof(l1));
            if (l2 == null)
                throw new ArgumentNullException(nameof(l2));

            var headNode = new ListNode();
            var currNode = headNode;
            var carry = 0;

            while ((l1 != null) || (l2 != null))
            {
                var sum = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;
                if (sum >= 10)
                {
                    sum %= 10;
                    carry = 1;
                }
                else
                {
                    carry = 0;
                }
                currNode.next = new ListNode(sum);
                currNode = currNode.next;

                l1 = l1?.next;
                l2 = l2?.next;
            };

            if (carry > 0)
                currNode.next = new ListNode(carry);

            return headNode.next;
        }
    }
}
