# 📘 Convert Sorted Array Into Binary Search Tree

> **Goal:**  
To convert a sorted array into a height-balanced binary search tree (BST).

---

## Definitions
BST(Height-balanced means) - For every node, the height difference between left and right subtrees is at most 1.

---

## Problem Statement (Core Idea)
Given a sorted array (ascending order), convert it into a height-balanced Binary Search Tree (BST).

---

## Key Observations (MOST IMPORTANT)
1️. Why BST is possible?
In a BST:
    Left subtree values < root
    Right subtree values > root
    The array is already sorted
    So we can directly use indices to split left & right parts
2. Why choose the middle element as root?
If you pick:
    First element → skewed tree
    Last element → skewed tree
    Middle element → balanced tree ✅
    📌 Balance is the entire point of this problem.

---

## 🧩 Core Insight (One-Liner)

Pick the middle element as root, recursively build left subtree from left half and right subtree from right half.

---

## 🧠 Recursive Thinking (Step-by-Step)
Given array: `[-10, -3, 0, 5, 9]`
Step 1: Pick middle element as root
    Middle index = (0 + 4) / 2 = 2 → Value = 0
    Root = TreeNode(0)
Step 2: Build left subtree from left half `[-10, -3]`
Step 3: Build right subtree from right half `[5, 9]`

## 🧠 Recursion Mental Model (VERY IMPORTANT)
Think in terms of ranges, not arrays:
buildBST(leftIndex, rightIndex)

Base Case: if left > right → return null

Recursive Case:
    mid = (left + right) / 2
    Create node with nums[mid]
    node.left = build(left, mid - 1)
    node.right = build(mid + 1, right)

## ⏱️ Complexity Analysis (Interview MUST)
Time Complexity:
    Every element used once
    ✅ O(n)

Space Complexity
    Recursion stack height = log n
    ✅ O(log n) (balanced tree)