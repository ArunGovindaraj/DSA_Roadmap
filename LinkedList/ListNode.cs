using System;
using System.Collections.Generic;
using System.Text;

namespace DSARoadmap.LinkedList
{
    public class ListNode<T>
    {
        public T Data;
        public ListNode<T> Next;

        public ListNode(T data)
        {
            Data = data;
            Next = null;
        }
    }
}
