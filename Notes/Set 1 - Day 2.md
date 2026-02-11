# 📘 Day 2 Notes – Strings & Character Arrays (Deep Understanding)

> **Goal of Day 2:**  
Understand **how strings actually work under the hood**, why they feel slower than arrays, and **when to convert strings into character arrays** for optimal solutions.

---

## 1️ What Is a String? (Beyond Definition)

A **string** is a sequence of characters, but **how it behaves depends on the language**.

### Key Reality
- In most languages (Java, C#, Python):
  - **Strings are immutable**
  - Any modification creates a **new string**
- Internally, strings are often backed by a **character array**

📌 This is the root reason for performance differences.

---

## 2️ String Immutability (CRITICAL CONCEPT)

### What does immutable mean?
Once a string is created, **it cannot be changed**.

Example:
s = "abc"
s[0] = 'z'   ❌ Not allowed

- What happens when you "modify" a string?
  s = s + "d"
    - Internally:
        - New memory is allocated
        - Old characters are copied
        - New string is created
        - ⏱️ Time cost: O(n)
        - 🧠 Hidden cost: Repeated string operations become expensive

## 3 String vs Character Array (When to Use Which)

| Aspect               | String    | char[]       |
| -------------------- | --------- | ------------ |
| Mutability           | Immutable | Mutable      |
| Modification cost    | O(n)      | O(1)         |
| Memory usage         | Higher    | Lower        |
| Safety               | High      | Lower        |
| Interview preference | Good      | Often better |

- When char[] is better?
    - Frequent modifications
    - In-place algorithms
    - Two-pointer problems

- 📌 Interview Tip:
    - If the problem requires modifying characters, convert string → char[].