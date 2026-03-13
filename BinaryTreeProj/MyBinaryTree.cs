using System;
using System.Collections;
using System.Collections.Generic;
using BinaryTreeProj;

namespace MyBinaryTreeProj
{
    public class MyBinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private MyBinaryTreeNode<T> _head;
        private int _count;

        public int Count => _count;

        public void Add(T value)
        {
            if (_head == null)
            {
                _head = new MyBinaryTreeNode<T>(value);
            }
            else
            {
                AddTo(_head, value);
            }
            _count++;
        }

        private void AddTo(MyBinaryTreeNode<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null) node.Left = new MyBinaryTreeNode<T>(value);
                else AddTo(node.Left, value);
            }
            else
            {
                if (node.Right == null) node.Right = new MyBinaryTreeNode<T>(value);
                else AddTo(node.Right, value);
            }
        }

        public bool Remove(T value)
        {
            MyBinaryTreeNode<T> current, parent;
            current = FindWithParent(value, out parent);

            if (current == null) return false;

            _count--;

            if (current.Right == null)
            {
                if (parent == null) _head = current.Left;
                else
                {
                    if (parent.Left == current) parent.Left = current.Left;
                    else parent.Right = current.Left;
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (parent == null) _head = current.Right;
                else
                {
                    if (parent.Left == current) parent.Left = current.Right;
                    else parent.Right = current.Right;
                }
            }
            else
            {
                MyBinaryTreeNode<T> leftmost = current.Right.Left;
                MyBinaryTreeNode<T> leftmostParent = current.Right;

                while (leftmost.Left != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }

                leftmostParent.Left = leftmost.Right;
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if (parent == null) _head = leftmost;
                else
                {
                    if (parent.Left == current) parent.Left = leftmost;
                    else parent.Right = leftmost;
                }
            }
            return true;
        }

        private MyBinaryTreeNode<T> FindWithParent(T value, out MyBinaryTreeNode<T> parent)
        {
            MyBinaryTreeNode<T> current = _head;
            parent = null;

            while (current != null)
            {
                int result = value.CompareTo(current.Value);
                if (result == 0) return current;

                parent = current;
                if (result < 0) current = current.Left;
                else current = current.Right;
            }
            return null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrder(_head).GetEnumerator();
        }

        private IEnumerable<T> InOrder(MyBinaryTreeNode<T> node)
        {
            if (node == null) yield break;
            foreach (var n in InOrder(node.Left)) yield return n;
            yield return node.Value;
            foreach (var n in InOrder(node.Right)) yield return n;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}