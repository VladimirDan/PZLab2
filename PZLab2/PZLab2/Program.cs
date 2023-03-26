using System;
using System.Collections.Generic;

namespace PZLab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    /*public class DoublyLinkedListNode
    {
        public char Value { get; set; }
        public DoublyLinkedListNode Next { get; set; }
        public DoublyLinkedListNode Previous { get; set; }

        public DoublyLinkedListNode(char value)
        {
            Value = value;
        }
    }*/

    public class DoublyLinkedList
    {
        private LinkedList<char> list;

        public DoublyLinkedList()
        {
            list = new LinkedList<char>();
        }

        public int ListLength()
        {
            return list.Count;
        }

        public void Append(char value)
        {
            LinkedListNode<char> newNode = new LinkedListNode<char>(value);
            list.AddLast(newNode);
        }

        public void Insert(char value, int index)
        {
            if (index < 0 || index > list.Count)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }

            LinkedListNode<char> newNode = new LinkedListNode<char>(value);

            if (index == 0)
            {
                list.AddFirst(newNode);
            }
            else if (index == list.Count)
            {
                list.AddLast(newNode);
            }
            else
            {
                LinkedListNode<char> current = list.First;
                for (int i = 0; i < index - 2; i++)
                {
                    current = current.Next;
                }
                list.AddAfter(current, newNode);
            }
        }

        public char Delete(int index)
        {
            if (index < 0 || index >= list.Count)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }

            LinkedListNode<char> current = list.First;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            char data = current.Value;
            list.Remove(current);
            return data;
        }

        public void DeleteAll(char element)
        {
            LinkedListNode<char> current = list.First;
            while (current != null)
            {
                if (current.Value.Equals(element))
                {
                    current = current.Next;
                    list.Remove(current.Previous);
                    continue;
                }
                current = current.Next;
            }
        }

        public char Get(int index)
        {
            if (index < 0 || index >= list.Count)
                throw new Exception("Error. Index out of range.");

            LinkedListNode<char> current = list.First;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Value;
        }

        public DoublyLinkedList Clone()
        {
            DoublyLinkedList newList = new DoublyLinkedList();
            LinkedListNode<char> current = list.First;
            for (int i = 0; i < list.Count; i++)
            {
                newList.Append(current.Value);
                current = current.Next;
            }
            return newList;
        }

        public void Reverse()
        {
            LinkedList<char> newList = new LinkedList<char>();
            while (list.Count != 0)
            {
                newList.AddLast(new LinkedListNode<char>(list.Last.Value));
                list.RemoveLast();
            }
            list = newList;
        }

        public int FindFirst(char value)
        {
            LinkedListNode<char> current = list.First;
            for (int i = 0; i < list.Count; i++)
            {
                if (current.Value == value) return i;
                current = current.Next;
            }
            return -1;
        }

        public int FindLast(char value)
        {
            LinkedListNode<char> current = list.Last;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (current.Value == value) return i;
                current = current.Previous;
            }
            return -1;
        }

        public void Clear()
        {
            list.Clear();
        }

        public void Extend(DoublyLinkedList doublyLinkedList)
        {
            LinkedListNode<char> current = doublyLinkedList.list.First;
            for (int i = 0; i < doublyLinkedList.list.Count; i++)
            {
                this.Append(current.Value);
                current = current.Next;
            }
        }
    }
}
