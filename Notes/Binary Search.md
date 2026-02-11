# 📘 Binary Search 

> **Goal:**  
To learn about Binary Search and where are the places we can use it.

---

## How it works?
Binary search works by repeatedly dividing the search interval in half.
1. Start with two pointers: `left` at the beginning and `right` at the end of the sorted array.
2. Calculate the `mid` index: `mid = left + (right - left) / 2`.
3. Compare the target value with the middle element:
   - If they are equal, return the `mid` index.
   - If the target is less than the middle element, move the `right` pointer to `mid - 1`.
   - If the target is greater than the middle element, move the `left` pointer to `mid + 1`.
4. Repeat steps 2-4 until the target is found or the `left` pointer exceeds the `right` pointer.
5. If the target is not found, return -1 or an indication that the target is not present.

## Key Points to Remember
6. Time Complexity: O(log n)
7. Space Complexity: O(1) for iterative, O(log n) for recursive due to call stack.
8. Binary search is efficient for large datasets due to its logarithmic time complexity.
9. It requires the input data to be sorted beforehand, which may involve additional time if the data is not already sorted.
10. Binary search can be implemented both iteratively and recursively, with the iterative approach being more space-efficient.
11. It is commonly used in various applications, including searching in databases, finding elements in sorted arrays, and solving optimization problems.

--- 

## 🔍 When Can We Use Binary Search?
Binary search can be used when the data or the search space is **sorted or follows a monotonic pattern**, 
allowing us to discard half of the possibilities at each step.

---

### ✅ Scenario 1: Sorted Array / List (Most Common)
You can use binary search to:
    Find a number
    Find insert position
    Find first / last occurrence

📌 Why?
Because you can safely throw away half the data each time.

### ✅ Scenario 2: Answer Lies in a Range (Search Space Is Sorted)
Example:
Find the minimum speed needed to finish a task in h hours.

Here:
    Speed range = 1 → 10⁹
    As speed increases → time required only decreases
    This creates a monotonic relationship.

📌 This is called Binary Search on Answer.

### ✅ Scenario 3: First / Last True or False (Monotonic Condition)
false false false true true true

You can binary search to find:
    First true
    Last false

📌 Used in:
    Lower bound
    Upper bound
    Capacity problems

### ✅ Scenario 4: Search Insert Position / Lower Bound
When you want:
    First element ≥ target
    First element > target
    Binary search gives the answer in O(log n).

### ✅ Scenario 5: Rotated Sorted Array (Special Case)
[4,5,6,7,0,1,2]

Still usable because:
    One half is always sorted

Binary search logic adapts.