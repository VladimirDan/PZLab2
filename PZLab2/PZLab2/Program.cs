using System;

namespace PZLab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class DoublyLinkedListNode
    {
        public char Value { get; set; }
        public DoublyLinkedListNode Next { get; set; }
        public DoublyLinkedListNode Previous { get; set; }

        public DoublyLinkedListNode(char value)
        {
            Value = value;
        }
    }

    class DoublyLinkedList
    {
        private DoublyLinkedListNode _head;
        private DoublyLinkedListNode _tail;
        private int _length;

        public DoublyLinkedList()
        {
            _head = null;
            _tail = null;
            _length = 0;
        }

        public int ListLength()
        {
            return this._length;
        }

        public void Append(char value)
        {
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(value);

            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                newNode.Previous = _tail;
                _tail.Next = newNode;
                _tail = newNode;
            }

            _length++;
        }

        public void Insert(char value, int index)
        {
            if (index < 0 || index > _length)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }

            DoublyLinkedListNode newNode = new DoublyLinkedListNode(value);

            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else if (index == 0)
            {
                newNode.Next = _head;
                _head.Previous = newNode;
                _head = newNode;
            }
            else if (index == _length)
            {
                _tail.Next = newNode;
                newNode.Previous = _tail;
                _tail = newNode;
            }
            else
            {
                DoublyLinkedListNode current = _head;

                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                newNode.Next = current.Next;
                newNode.Previous = current;
                current.Next.Previous = newNode;
                current.Next = newNode;
            }
            _length++;
        }

        public char Delete(int index)
        {
            if (index < 0 || index >= _length)
            {
                throw new IndexOutOfRangeException("Index out of range.");
            }

            char data;

            if (_length == 1)
            {
                data = _head.Value;
                _head = null;
                _tail = null;
            }
            else if (index == 0)
            {
                data = _head.Value;
                _head = _head.Next;
                _head.Previous = null;
            }
            else if (index == _length - 1)
            {
                data = _tail.Value;
                _tail = _tail.Previous;
                _tail.Next = null;
            }
            else
            {
                DoublyLinkedListNode current = _head;

                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                data = current.Value;
                current.Previous.Next = current.Next;
                current.Next.Previous = current.Previous;
            }

            _length--;

            return data;
        }

        public void DeleteAll(char element)
        {
            DoublyLinkedListNode current = _head;
            while (current != null)
            {
                if (current.Value.Equals(element))
                {
                    if (current == _head)
                    {
                        _head = current.Next;
                        if (_head != null)
                        {
                            _head.Previous = null;
                        }
                    }
                    else if (current == _tail)
                    {
                        _tail = current.Previous;
                        _tail.Next = null;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                    }
                }
                current = current.Next;
            }
        }

        public char Get(int index)
        {
            if (index < 0 || index >= this._length) throw new Exception("Error. Index out of range.");
            DoublyLinkedListNode current = this._head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Value;
        }

        public DoublyLinkedList Clone()
        {
            DoublyLinkedList newList = new DoublyLinkedList();
            DoublyLinkedListNode current = this._head;
            for (int i = 0; i < this._length; i++)
            {
                newList.Append(current.Value);
                current = current.Next;
            }
            return newList;
        }

        public void Reverse()
        {
            DoublyLinkedListNode current = this._head;
            DoublyLinkedListNode previous = this._tail;
            for (int i = 0; i < this._length; i++)
            {
                DoublyLinkedListNode next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }
            this._head = previous;
            if (this._length > 0) this._tail = this._head.Next;
        }

        public int FindFirst(char value)
        {
            DoublyLinkedListNode current = this._head;
            for (int i = 0; i < this._length; i++)
            {
                if (current.Value == value) return i;
                current = current.Next;
            }
            return -1;
        }

        public int FindLast(char value)
        {
            DoublyLinkedListNode current = this._tail;
            for (int i = this._length - 1; i <= 0; i--)
            {
                if (current.Value == value) return i;
                current = current.Previous;
            }
            return -1;
        }

        public void Clear()
        {
            this._head = null;
            this._tail = null;
            this._length = 0;
        }

        public void Extend(DoublyLinkedList list)
        {
            DoublyLinkedListNode current = list._head;
            for (int i = 0; i < this._length; i++)
            {
                this.Append(current.Value);
                current = current.Next;
            }
        }
    }
}
