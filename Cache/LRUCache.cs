using System;
using System.Collections.Generic;
using System.Text;

namespace DSARoadmap.Cache
{
    public class LRUCache
    {
        /// <summary>
        /// Represents a node in a doubly linked list, containing a key-value pair and references to adjacent nodes.
        /// </summary>
        /// Time Complexity: O(1) for insertion, deletion, and access operations on the node, as it maintains direct references to its previous and next nodes.
        /// Space Complexity: O(1) for each node, as it only stores a fixed amount of data (key, value, and references to adjacent nodes) regardless of the size of the cache.
        /// <remarks>Typically used as an internal data structure for collections that require efficient
        /// insertion, removal, and traversal, such as an LRU cache or custom linked list implementations. Each node
        /// maintains references to its previous and next nodes, enabling bidirectional navigation.</remarks>
        private class Node
        {            
            public int Key; // The key associated with the cache entry, used for identification and retrieval.            
            public int Value; // The value associated with the cache entry, representing the data stored in the cache.
            public Node Prev; // A reference to the previous node in the doubly linked list, allowing backward traversal through the list.
            public Node Next; // A reference to the next node in the doubly linked list, allowing forward traversal through the list.

            /// <summary>
            /// Initializes a new instance of the Node class with the specified key and value.
            /// </summary>
            /// <param name="key">The key associated with the node. Typically used to identify or index the node within a collection.</param>
            /// <param name="value">The value stored in the node. Represents the data or payload associated with the key.</param>
            public Node(int key, int value)
            {
                Key = key; // Initialize the Key property with the provided key parameter, allowing the node to be identified within a collection or cache.
                Value = value; // Initialize the Value property with the provided value parameter, representing the data stored in the node. This value can be retrieved or updated as needed when managing the cache or linked list.
            }
        }

        private readonly int _capacity; // The maximum number of entries that the LRU cache can hold. Once the cache reaches this capacity, it will evict the least recently used entry to make room for new entries.
        private Dictionary<int, Node> _cache; // A dictionary that maps keys to their corresponding nodes in the doubly linked list. This allows for O(1) access to cache entries based on their keys, enabling efficient retrieval and updates of cache values.
        private Node _head, _tail; // References to the head and tail nodes of the doubly linked list. The head node represents the most recently used entry in the cache, while the tail node represents the least recently used entry. These references are crucial for maintaining the order of entries in the cache and facilitating efficient eviction of the least recently used entry when necessary.

        /// <summary>
        /// Initializes a new instance of the LRUCache class with the specified capacity.
        /// </summary>
        /// <remarks>If the number of items added exceeds the specified capacity, the least recently used
        /// items will be removed to make room for new entries.</remarks>
        /// <param name="capacity">The maximum number of items that the cache can hold. Must be a positive integer.</param>
        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _cache = new Dictionary<int, Node>();
        }

        /// <summary>
        /// Retrieves the value associated with the specified key from the cache.
        /// </summary>
        /// <remarks>If the key is found, the corresponding item is moved to the front of the cache,
        /// indicating recent access. This method does not throw an exception if the key is not present; instead, it
        /// returns -1.</remarks>
        /// <param name="key">The key of the item to retrieve from the cache.</param>
        /// <returns>The value associated with the specified key if it exists in the cache; otherwise, -1.</returns>
        public int Get(int key)
        {
            if (!_cache.ContainsKey(key))
                return -1;

            Node node = _cache[key];
            MoveToFront(node);
            return node.Value;
        }

        /// <summary>
        /// Adds a key-value pair to the cache or updates the value for an existing key. If the cache has reached its
        /// capacity, the least recently used item is removed to make space.
        /// </summary>
        /// <remarks>If the specified key already exists in the cache, its value is updated and it is
        /// marked as the most recently used. If the cache is full and a new key is added, the least recently used item
        /// is evicted to maintain the cache size.</remarks>
        /// <param name="key">The key associated with the value to add or update in the cache.</param>
        /// <param name="value">The value to store for the specified key.</param>
        public void Put(int key, int value)
        {
            if (_cache.ContainsKey(key))
            {
                Node node = _cache[key];
                node.Value = value;
                MoveToFront(node);
            }
            else
            {
                if (_cache.Count == _capacity)
                {
                    _cache.Remove(_tail.Key);
                    RemoveNode(_tail);
                }

                Node newNode = new Node(key, value);
                AddToFront(newNode);
                _cache[key] = newNode;
            }
        }

        /// <summary>
        /// Adds the specified node to the front of the linked list, updating head and tail references as necessary.
        /// </summary>
        /// <remarks>If the list is empty, the node becomes both the head and tail. The method does not
        /// check for duplicate nodes or whether the node is already part of another list; callers should ensure the
        /// node is not already linked elsewhere.</remarks>
        /// <param name="node">The node to add to the front of the list. Cannot be null.</param>
        private void AddToFront(Node node)
        {
            node.Next = _head;
            node.Prev = null;

            if (_head != null)
                _head.Prev = node;

            _head = node;

            if (_tail == null)
                _tail = node;
        }

        /// <summary>
        /// Removes the specified node from the linked list.
        /// </summary>
        /// <remarks>After removal, the node is detached from the list and the list's head or tail
        /// references are updated if necessary. Removing a node that is not part of the list may result in inconsistent
        /// state.</remarks>
        /// <param name="node">The node to remove from the list. Must be a valid node currently contained in the list.</param>
        private void RemoveNode(Node node)
        {
            if (node.Prev != null)
                node.Prev.Next = node.Next;
            else
                _head = node.Next;

            if (node.Next != null)
                node.Next.Prev = node.Prev;
            else
                _tail = node.Prev;
        }

        /// <summary>
        /// Moves the specified node to the front of the linked list.
        /// </summary>
        /// <remarks>This method is typically used to update the position of a node after it has been
        /// accessed, such as in a least recently used (LRU) cache implementation. The node must already be part of the
        /// list.</remarks>
        /// <param name="node">The node to move to the front. Cannot be null.</param>
        private void MoveToFront(Node node)
        {
            RemoveNode(node);
            AddToFront(node);
        }

        /// <summary>
        /// Displays the current contents of the LRU cache to the console in order from most recently used to least
        /// recently used.
        /// </summary>
        /// <remarks>This method writes the cache state to the standard output. It is intended for
        /// debugging or diagnostic purposes and does not modify the cache.</remarks>
        public void PrintCache()
        {
            Console.WriteLine("\nCurrent LRU Cache State:");

            Node current = _head;

            while (current != null)
            {
                Console.Write($"[{current.Key}:{current.Value}] ");
                current = current.Next;
            }

            Console.WriteLine();
        }
    }
}
