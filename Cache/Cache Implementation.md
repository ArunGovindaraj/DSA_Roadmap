# 📘 Implement LRU/LFU(Least Recently/Frequently Used) Cache

> **Goal:**  
To implement and compare the performance of LRU (Least Recently Used) and LFU (Least Frequently Used) cache eviction policies.

---

## Definitions
> What is Cache?
    A cache is a hardware or software component that stores data so that future requests for that data can
be served faster. Caches are used to reduce the average time to access data from the main memory or a slower storage device.

Imagine you have:
    A small bag (fast access)
    A big cupboard (slow access)

If you use something often, you keep it in your small bag so you don’t go to the cupboard every time.
That small bag = Cache
But the bag has limited space.
So when it’s full, we must remove something.

👉 Question: Which one should we remove?
    That’s where LRU and LFU come in.

---

## LRU (Least Recently Used) Cache
LRU removes the item that was used long time ago.
👉 “If you haven’t touched it recently, throw it out.”

Example:
> You have space for 3 toys in your table drawer.

You play with:
    - Car
    - Ball
    - Robot

Drawer full now.

Now you bring a Doll.

Which toy do you remove?

👉 Remove the one you didn’t play with recently.

That’s LRU.

🤔 Why LRU?
Because usually:
    If you used something recently, you will probably use it again soon.
    This is called Temporal Locality.

🔧 How to Implement LRU (Efficient Way)
We need:
    O(1) → get(key)
    O(1) → put(key, value)

To achieve this we use:
    🔹 Dictionary (HashMap) → Fast lookup
    🔹 Doubly Linked List → Maintain order of usage

💡 Why Doubly Linked List?
Because we need to:
    - Remove any node in O(1)
    - Move node to front in O(1)

📌 Structure
Head <-> Most Recently Used <-> ... <-> Least Recently Used <-> Tail

Head → Most recent
Tail → Least recent (remove this when full)

---

## LFU (Least Frequently Used) Cache
LFU removes the item that was used least number of times.
👉 “If you rarely use it, throw it out.”

For Example:
You have 3 snacks:
    - Chips (used 5 times)
    - Biscuit (used 2 times)
    - Chocolate (used 7 times)

Now new snack comes.
Remove the one used least.
👉 Biscuit (used 2 times)
That’s LFU.

🤔 Why LFU?
Because:
    Frequently used items are probably important.

🔧 How to Implement LFU
This is harder than LRU.

We need:
    O(1) get
    O(1) put

We use:
    🔹 key → node map
    🔹 frequency → list of nodes
    🔹 Track minimum frequency

📌 Structure
    freq = 1 → [A, B]
    freq = 2 → [C]
    freq = 3 → [D]

We always remove from lowest frequency bucket.

---

Comparing LRU and LFU:
| Feature          | LRU                 | LFU                      |
| ---------------- | ------------------- | ------------------------ |
| Removes          | Least recently used | Least frequently used    |
| Complexity       | O(1)                | O(1)                     |
| Easier?          | ✅ Yes              | ❌ Harder               |
| Real-world usage | Very common         | Used in advanced caching |



