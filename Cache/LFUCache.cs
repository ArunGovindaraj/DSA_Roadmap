using System;
using System.Collections.Generic;
using System.Text;

namespace DSARoadmap.Cache
{
    public class LFUCache
    {
        /// <summary>
        /// Represents a key-value pair with an associated access frequency, typically used in cache implementations to
        /// track usage patterns.
        /// </summary>
        /// Time Complexity: O(1) for accessing and updating the key, value, and frequency properties of the node, as they are stored as direct fields within the class. The frequency is updated in constant time when accessed or modified.
        /// Space Complexity: O(1) for each node, as it only stores a fixed amount of data (key, value, and frequency) regardless of the size of the cache. The overall space complexity of the LFUCache class will depend on the number of nodes stored in the cache, which is determined by the capacity and usage patterns.
        /// <remarks>The Node class is commonly used in data structures such as LFU (Least Frequently
        /// Used) caches, where both the value and the frequency of access are important for eviction policies. The
        /// Frequency field is initialized to 1 to indicate the first insertion or access.</remarks>
        private class Node
        {
            public int Key;
            public int Value;
            public int Frequency = 1;
        }

        private int _capacity; // The maximum number of entries that the LFU cache can hold. Once the cache reaches this capacity, it will evict the least frequently used entry to make room for new entries.
        private int _minFreq; // The minimum frequency of access among the entries currently stored in the cache. This value is used to identify which entries are the least frequently used and should be evicted when the cache reaches its capacity. It is updated whenever entries are accessed or added to ensure that it accurately reflects the current state of the cache.
        private Dictionary<int, Node> _keyMap; // A dictionary that maps keys to their corresponding nodes in the cache. This allows for O(1) access to cache entries based on their keys, enabling efficient retrieval and updates of cache values and frequencies.
        private Dictionary<int, LinkedList<Node>> _freqMap; // A dictionary that maps access frequencies to linked lists of nodes that share the same frequency. This structure allows for efficient tracking and management of entries based on their access frequency, enabling quick identification and eviction of the least frequently used entries when necessary.

        /// <summary>
        /// Initializes a new instance of the LFUCache class with the specified capacity.
        /// </summary>
        /// <remarks>If the number of items in the cache exceeds the specified capacity, the least
        /// frequently used item is removed to make space for new entries.</remarks>
        /// <param name="capacity">The maximum number of items that the cache can hold. Must be greater than zero.</param>
        public LFUCache(int capacity)
        {
            _capacity = capacity;
            _keyMap = new Dictionary<int, Node>();
            _freqMap = new Dictionary<int, LinkedList<Node>>();
        }

        /// <summary>
        /// Retrieves the value associated with the specified key, if it exists in the cache.
        /// </summary>
        /// <remarks>Accessing a key updates its usage frequency in the cache. This method does not add a
        /// new entry if the key is not found.</remarks>
        /// <param name="key">The key whose associated value is to be returned.</param>
        /// <returns>The value associated with the specified key if the key exists in the cache; otherwise, -1.</returns>
        public int Get(int key)
        {
            if (!_keyMap.ContainsKey(key))
                return -1;

            Node node = _keyMap[key];
            UpdateFrequency(node);
            return node.Value;
        }

        /// <summary>
        /// Inserts a key-value pair into the cache or updates the value if the key already exists.
        /// </summary>
        /// <remarks>If the cache has reached its capacity, the least frequently used item is removed to
        /// make space for the new entry. If multiple items have the same frequency, the least recently used among them
        /// is evicted first. If the cache capacity is zero, this method performs no operation.</remarks>
        /// <param name="key">The key to add or update in the cache.</param>
        /// <param name="value">The value to associate with the specified key.</param>
        public void Put(int key, int value)
        {
            if (_capacity == 0)
                return;

            if (_keyMap.ContainsKey(key))
            {
                Node node = _keyMap[key];
                node.Value = value;
                UpdateFrequency(node);
            }
            else
            {
                if (_keyMap.Count == _capacity)
                {
                    var list = _freqMap[_minFreq];
                    var nodeToRemove = list.First.Value;
                    list.RemoveFirst();
                    _keyMap.Remove(nodeToRemove.Key);
                }

                Node newNode = new Node { Key = key, Value = value };
                _minFreq = 1;

                if (!_freqMap.ContainsKey(1))
                    _freqMap[1] = new LinkedList<Node>();

                _freqMap[1].AddLast(newNode);
                _keyMap[key] = newNode;
            }
        }

        /// <summary>
        /// Updates the frequency count of the specified node and moves it to the appropriate frequency list.
        /// </summary>
        /// <remarks>This method is typically used in frequency-based cache implementations, such as LFU
        /// (Least Frequently Used) caches, to maintain accurate frequency tracking and efficient node repositioning.
        /// The method also updates the minimum frequency tracker if necessary.</remarks>
        /// <param name="node">The node whose frequency is to be incremented and repositioned within the frequency map. Cannot be null.</param>
        private void UpdateFrequency(Node node)
        {
            int freq = node.Frequency;
            _freqMap[freq].Remove(node);

            if (_freqMap[freq].Count == 0 && freq == _minFreq)
                _minFreq++;

            node.Frequency++;

            if (!_freqMap.ContainsKey(node.Frequency))
                _freqMap[node.Frequency] = new LinkedList<Node>();

            _freqMap[node.Frequency].AddLast(node);
        }

        /// <summary>
        /// Displays the current state of the LFU cache, including the frequency lists and their contents, to the
        /// console.
        /// </summary>
        /// <remarks>Use this method for debugging or diagnostic purposes to visualize the cache's
        /// internal structure and frequency distribution. The output includes each frequency and the associated cache
        /// entries, as well as the current minimum frequency.</remarks>
        public void PrintCache()
        {
            Console.WriteLine("\nCurrent LFU Cache State:");

            foreach (var freq in _freqMap.Keys.OrderBy(f => f))
            {
                Console.Write($"Freq {freq} : ");

                foreach (var node in _freqMap[freq])
                {
                    Console.Write($"[{node.Key}:{node.Value}] ");
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Minimum Frequency: {_minFreq}");
        }
    }
}
