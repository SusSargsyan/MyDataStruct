using System;

namespace MyLinkedListLibrary
{
    public class MyLinkedList<T>
    {
        private MyLinkedListNode<T> head;
        public int Count { get; private set; }


        public void AddFirst(T value)
        {
            var newNode = new MyLinkedListNode<T>(value);
            newNode.Next = head;
            head = newNode;
            Count++;
        }


        public void AddLast(T value)
        {
            var newNode = new MyLinkedListNode<T>(value);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                var current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            Count++;
        }


        public void RemoveFirst()
        {
            if (head == null) return;
            head = head.Next;
            Count--;
        }


        public void RemoveLast()
        {
            if (head == null) return;
            if (head.Next == null)
            {
                head = null;
            }
            else
            {
                var current = head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
            }
            Count--;
        }


        public void Clear()
        {
            head = null;
            Count = 0;
        }


        public bool Contains(T value)
        {
            var current = head;
            while (current != null)
            {
                if (current.Value.Equals(value)) return true;
                current = current.Next;
            }
            return false;
        }


        public override bool Equals(object obj)
        {
            if (obj is MyLinkedList<T> other)
            {
                if (this.Count != other.Count) return false;

                var currentThis = this.head;
                var currentOther = other.head;

                while (currentThis != null)
                {
                    if (!currentThis.Value.Equals(currentOther.Value)) return false;
                    currentThis = currentThis.Next;
                    currentOther = currentOther.Next;
                }
                return true;
            }
            return false;
        }


        public T GetFirst() => head != null ? head.Value : throw new Exception("List is empty");
    }
}

