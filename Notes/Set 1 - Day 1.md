# 📘 Day 1 Notes – Arrays Fundamentals (Deep Understanding)

> **Goal of Day 1:**  
Build a **rock-solid mental model of arrays**, so you don’t just “use arrays”, but **reason with them** during interviews and real problem-solving.

---

## 1️ What Is an Array? (Not Just Definition)

An **array** is a collection of elements stored in **contiguous memory locations**.

### Why contiguous memory matters
- Each element sits **right next to the previous one**
- Index-based access becomes **very fast (O(1))**
- CPU cache-friendly → performance boost

Index: 0 1 2 3 4
Memory: [10] [20] [30] [40] [50]


👉 This is why arrays are fast.

---

## 2️ Time Complexity – Think in Operations

| Operation                     | Time          | Why                           |
|-------------------------------|---------------|-------------------------------|
| Access by index               | O(1)          | Direct address calculation    |
| Traverse                      | O(n)          | Visit each element once       |
| Insert at end                 | O(1)*         | Only if space exists          |
| Insert/delete at start/middle | O(n)          | Elements must shift           |
| Search (unsorted)             | O(n)          | No ordering info              |

\* Amortized O(1) in dynamic arrays

---

## 3️ Static vs Dynamic Arrays (Important Concept)

### Static Array
- Fixed size
- Memory allocated once
- Very fast, but inflexible

### Dynamic Array (ArrayList / List / Vector)
- Resizable
- Internally uses static array
- Resizing causes **copying**

#### Amortized Time (Interview Favorite)
- Resize doesn’t happen often
- Average insertion → O(1)

---

## 4️ Subarray vs Subsequence (CRITICAL DIFFERENCE)

### Subarray
- **Continuous**
- Uses indices
- Sliding window applies

#### Example:
Array: [1, 2, 3, 4]
Subarrays:
[1], [2], [3], [4]
[1,2], [2,3], [3,4]
[1,2,3], [2,3,4]
[1,2,3,4]


### Subsequence
- **Order preserved**
- Elements may be skipped
- Often exponential combinations

#### Example:
Subsequences of [1,2,3]:
[ ], [1], [2], [3], [1,2], [1,3], [2,3], [1,2,3]


👉 **If the problem says “continuous” → subarray**

---

## 5️ Core Array Traversal Patterns

### Single Pass
for i = 0 to n-1
Used when:
 - Counting
 - Finding max/min
 - Simple checks

### Reverse Pass
for i = n-1 to 0
Used when:
 - Reverse operations
 - Compare from back

### Two Indices
i moves forward
j moves backward
Used in:
 - Reverse array
 - Palindrome checks

---

## 6 In-Place vs Extra Space

### In-Place
 - No extra array
 - Space O(1)
 - Mutates original array

#### Example:
 - Reverse array using swapping

### Extra Space
 - Uses new array
 - Space O(n)
 - Easier but less optimal

---

## 7 Common Beginner Mistakes (Avoid These)

❌ Confusing subarray with subsequence
❌ Using nested loops without checking constraints
❌ Ignoring space complexity
❌ Modifying array when not allowed

---

## 8 How to Approach Array Problems (Mental Checklist)
 - Is order important?
 - Is array sorted?
 - Is subarray or subsequence involved?
 - Can I do it in one pass?
 - Can I optimize space?

---

## 9️ Sample Brute → Optimal Thought Process
### Problem: Reverse an Array

👉 Brute Approach
    Create new array
    Copy elements in reverse
    Time: O(n), Space: O(n)

👉 Optimal Approach
    Swap start & end
    Move inward
    Time: O(n), Space: O(1)

👉 Key Insight
    If only order changes, try two pointers

---

## 🔑 Final Takeaways (Memorize These)
   Arrays = fast access, slow modification
   Contiguous memory = power
   Subarray ≠ Subsequence
   In-place > extra space
   Always think: Can I do better?

---

## 🧩 Practice Problems – Day 1 (IMPORTANT)

### ✅ Problem 1: Find Maximum & Minimum Element
**Purpose:** Learn traversal and comparison

- Think in one pass
- Track current min/max

👉 Observe:
- How many variables you really need

---

### ✅ Problem 2: Reverse an Array
**Purpose:** Understand in-place logic

**Brute:**
- Create new array

**Optimal:**
- Two pointers (start, end)
- Swap until they meet

👉 Observe:
- How space drops from O(n) → O(1)

---

### ✅ Problem 3: Check If Array Is Sorted
**Purpose:** Validation logic

- Compare `arr[i]` and `arr[i+1]`
- Early exit optimization

👉 Observe:
- Why early return saves time

---

### ✅ Problem 4 (Optional Easy Medium): Move All Zeros to End
**Purpose:** Prepare for two-pointer thinking

**Brute:**
- Extra array

**Optimal:**
- Pointer for non-zero index

👉 Observe:
- Stability of elements
- In-place rearrangement

---

## 🧠 Brute → Optimal Thinking Template (Write This)

For **each problem**, write:

### Brute Approach: 
 - Logic
 - Time complexity
 - Space complexity
 - Why it’s inefficient

### Optimal Approach:
 - Pattern used
 - Key idea
 - Time & space

### Key Insight:
 - 1 sentence takeaway

---

## 📝 Notes Focus for Day 1 (WRITE THESE)

After solving problems, your notes **must contain**:

- Why array access is O(1)
- Why insert/delete is O(n)
- Difference between subarray & subsequence
- When in-place is possible
- How two-pointer reduces space

If your notes don’t include these → rewrite them.

---

