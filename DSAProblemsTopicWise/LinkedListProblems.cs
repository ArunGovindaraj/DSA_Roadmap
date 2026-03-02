using DSARoadmap.Common.CommonServices;
using DSARoadmap.LinkedList;

namespace DSARoadmap.DSAProblemsTopicWise
{
    public class LinkedListProblems
    {
        #region Variables
        private readonly CommonServices commonServices;
        #endregion

        #region Constructor
        public LinkedListProblems(CommonServices _commonServices)
        {
            commonServices = _commonServices;

            int[] input = { 1, 2, 3, 4, 5 };

            #region Reverse Linked List
            var head = CommonServices.CreateList(input);

            Console.WriteLine("Original List:");
            CommonServices.PrintList(head);

            var reversed = ReverseList(head);

            Console.WriteLine("Reversed List:");
            CommonServices.PrintList(reversed);
            #endregion




        }
        #endregion

        #region Private Methods

        #endregion

        #region Public Methods
        #region Reverse Linked List
        /// <summary>
        /// Reverses the order of the nodes in a singly linked list.
        /// </summary>
        /// Time Complexity: O(n), where n is the number of nodes in the linked list, since we need to traverse the entire list once.
        /// Space Complexity: O(1), since we are using only a constant amount of extra space for the pointers (prev, current, nextTemp) regardless of the size of the input list.
        /// Algorithm used: Iterative approach to reverse the linked list by maintaining three pointers (prev, current, nextTemp) to keep track of the nodes while reversing the links.
        /// <remarks>The method does not modify the values of the nodes, only their order. The original
        /// list is reversed in place; no new nodes are created.</remarks>
        /// <typeparam name="T">The type of the elements stored in the linked list nodes.</typeparam>
        /// <param name="head">The head node of the singly linked list to reverse. Can be null to indicate an empty list.</param>
        /// <returns>The new head node of the reversed linked list, or null if the input list is empty.</returns>
        public static ListNode<T> ReverseList<T>(ListNode<T> head)
        {
            // For Example: Input: 1 -> 2 -> 3 -> 4 -> 5 -> null
            // Expected Output: 5 -> 4 -> 3 -> 2 -> 1 -> null
            // Explanation: We initialize three pointers: prev (initially null), current (initially head), and nextTemp (used to temporarily store the next node). We iterate through the list, reversing the links by setting current.Next to prev, then moving prev and current one step forward until we reach the end of the list. Finally, we return prev as the new head of the reversed list.
            // Edge Cases: If the input list is empty (head is null), the method will return null. If the list has only one node, it will simply return that node as the new head without any changes.
            // Step-by-Step Solution:
            // 1. Initialize three pointers: prev (set to null), current (set to head), and nextTemp (used for temporary storage).
            // 2. Iterate through the linked list until current is null:
            //   a. Store the next node (current.Next) in nextTemp.
            //   b. Reverse the current node's pointer by setting current.Next to prev.
            //   c. Move prev to the current node.
            //   d. Move current to the next node (nextTemp).
            // 3. After the loop, prev will be pointing to the new head of the reversed list, so return prev.
            // Code Implementation:
            // The method takes the head of the linked list as input and returns the new head of the reversed list. It uses an iterative approach to reverse the links between the nodes in place, ensuring that the original list is modified without creating new nodes.
            
            ListNode<T> prev = null;
            ListNode<T> current = head;

            while (current != null)
            {
                ListNode<T> nextTemp = current.Next;
                current.Next = prev;
                prev = current;
                current = nextTemp;
            }

            return prev;
        }
        #endregion


        #endregion
    }
}
