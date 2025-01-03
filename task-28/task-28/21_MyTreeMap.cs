﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static task_28.Program;

namespace task_28
{
    public class MyTreeMap<K, V> : MyNavigableMap<K, V> where K : IComparable<K>
    {
        private class Node
        {
            public K Key { get; set; }
            public V Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(K key, V value)
            {
                Key = key;
                Value = value;
            }
        }

        private IComparer<K> comparator = Comparer<K>.Create((a, b) => a.CompareTo(b));
        //Это лямбда-выражение, которое представляет собой функциональный делегат. 
        //Оно принимает два параметра (a и b) и вызывает метод CompareTo для их сравнения
        private Node root;
        private int size;
        public MyTreeMap() { size = 0; }

        public MyTreeMap(IComparer<K> comparator) { this.comparator = comparator; }

        public void Clear() => size = 0;

        public bool ContainsKey(K key)
        {
            if (Get(key) != null) return true;
            else return false;
        }

        public bool ContainsValue(V value) { return ContainsValue(root, value); }

        private bool ContainsValue(Node node, V value)
        {
            if (node == null) { return false; }

            if (node.Value.Equals(value)) { return true; }

            return ContainsValue(node.Left, value) || ContainsValue(node.Right, value);
        }

        public void EntrySet() { EntrySet(root); }

        private void EntrySet(Node node)
        {
            if (node != null)
            {
                EntrySet(node.Left);
                Console.WriteLine($"Ключ: {node.Key}, Значение: {node.Value}");
                EntrySet(node.Right);
            }
        }
        public V Get(K key)
        {
            Node node = Get(root, key);
            if (node != null) { return node.Value; }

            else { throw new KeyNotFoundException("Key not found in the tree."); }
        }
        private Node Get(Node node, K key)
        {
            if (node == null) { return null; }

            if (key.CompareTo(node.Key) < 0) { return Get(node.Left, key); }

            else if (key.CompareTo(node.Key) > 0) { return Get(node.Right, key); }

            else { return node; }
        }
        public bool IsEmpty() { return size == 0; }

        public void KeySet() { KeySet(root); }

        private void KeySet(Node node)
        {
            if (node != null)
            {
                KeySet(node.Left);
                Console.WriteLine($"Key: {node.Key}");
                KeySet(node.Right);
            }
        }

        public void Put(K key, V value) { root = Put(root, key, value); }

        private Node Put(Node node, K key, V value)
        {
            if (node == null) { return new Node(key, value); }

            if (key.CompareTo(node.Key) < 0) { node.Left = Put(node.Left, key, value); }

            else if (key.CompareTo(node.Key) > 0) { node.Right = Put(node.Right, key, value); }

            else { node.Value = value; }

            return node;
        }

        public void Remove(K key) { root = Remove(root, key); }

        private Node Remove(Node node, K key)
        {
            if (node == null) { return null; }

            if (key.CompareTo(node.Key) < 0) { node.Left = Remove(node.Left, key); }

            else if (key.CompareTo(node.Key) > 0) { node.Right = Remove(node.Right, key); }

            else
            {
                if (node.Left == null) { return node.Right; }

                else if (node.Right == null) { return node.Left; }
                else
                {
                    node.Key = FindMinKey(node.Right);
                    node.Right = Remove(node.Right, node.Key);
                }
            }

            return node;
        }
        private K FindMinKey(Node node)
        {
            while (node.Left != null) { node = node.Left; }
            return node.Key;
        }
        public int Size => size;

        public K FirstKey()
        {
            if (root == null) { throw new InvalidOperationException("Tree is empty."); }

            Node current = root;
            while (current.Left != null) { current = current.Left; }

            return current.Key;
        }

        public K LastKey()
        {
            if (root == null) { throw new InvalidOperationException("Tree is empty."); }

            Node current = root;
            while (current.Right != null) { current = current.Right; }

            return current.Key;
        }
        public void HeapMap(K end) { HeapMap(root, end); }

        private void HeapMap(Node node, K end)
        {
            if (node != null)
            {
                if (node.Key.CompareTo(end) < 0) Console.WriteLine(node.Value);
                HeapMap(node.Left, end);
                HeapMap(node.Right, end);

            }
        }

        public void SubMap(K start, K end) { SubMap(root, start, end); }

        private void SubMap(Node node, K start, K end)
        {
            if (node != null)
            {
                if (node.Key.CompareTo(end) < 0 && node.Key.CompareTo(start) > 0) Console.WriteLine(node.Value);
                SubMap(node.Left, start, end);
                SubMap(node.Right, start, end);
            }
        }
        public void TailMap(K start) { TailMap(root, start); }
        private void TailMap(Node node, K start)
        {
            if (node != null)
            {
                if (node.Key.CompareTo(start) > 0) Console.WriteLine(node.Value);
                TailMap(node.Left, start);
                TailMap(node.Right, start);

            }
        }
        public void LowerEntry(K key) { LowerEntry(root, key); }

        private void LowerEntry(Node node, K key)
        {
            if (node != null)
            {
                if (node.Key.CompareTo(key) < 0) Console.WriteLine("Ключ: " + node.Key + ", Значенние: " + node.Value);
                LowerEntry(node.Left, key);
                LowerEntry(node.Right, key);
            }
        }

        public void FloorEntry(K key) { FloorEntry(root, key); }

        private void FloorEntry(Node node, K key)
        {
            if (node != null)
            {
                if (node.Key.CompareTo(key) <= 0) Console.WriteLine("Ключ: " + node.Key + ", Значенние: " + node.Value);
                FloorEntry(node.Left, key);
                FloorEntry(node.Right, key);
            }
        }

        public void HigherEntry(K key) { HigherEntry(root, key); }

        private void HigherEntry(Node node, K key)
        {
            if (node != null)
            {
                if (node.Key.CompareTo(key) > 0) Console.WriteLine("Ключ: " + node.Key + ", Значенние: " + node.Value);
                HigherEntry(node.Left, key);
                HigherEntry(node.Right, key);
            }
        }

        public void CeilingEntry(K key) { CeilingEntry(root, key); }

        private void CeilingEntry(Node node, K key)
        {
            if (node != null)
            {
                if (node.Key.CompareTo(key) >= 0) Console.WriteLine("Ключ: " + node.Key + ", Значенние: " + node.Value);
                CeilingEntry(node.Left, key);
                CeilingEntry(node.Right, key);
            }
        }
        public void LowerKey(K key) { LowerKey(root, key); }

        private void LowerKey(Node node, K key)
        {
            if (node != null)
            {
                if (node.Key.CompareTo(key) < 0) Console.WriteLine("Ключ: " + node.Key);
                LowerKey(node.Left, key);
                LowerKey(node.Right, key);
            }
        }
        public void FloorKey(K key) { FloorKey(root, key); }

        private void FloorKey(Node node, K key)
        {
            if (node != null)
            {
                if (node.Key.CompareTo(key) <= 0) Console.WriteLine("Ключ: " + node.Key);
                FloorKey(node.Left, key);
                FloorKey(node.Right, key);
            }
        }
        public void HigherKey(K key) { HigherKey(root, key); }

        private void HigherKey(Node node, K key)
        {
            if (node != null)
            {
                if (node.Key.CompareTo(key) > 0) Console.WriteLine("Ключ: " + node.Key);
                HigherKey(node.Left, key);
                HigherKey(node.Right, key);
            }
        }
        public void CeilingKey(K key) { CeilingKey(root, key); }

        private void CeilingKey(Node node, K key)
        {
            if (node != null)
            {
                if (node.Key.CompareTo(key) >= 0) Console.WriteLine("Ключ: " + node.Key);
                CeilingKey(node.Left, key);
                CeilingKey(node.Right, key);
            }
        }
        public V PollFirstEntry()
        {
            if (root == null) { throw new InvalidOperationException("Tree is empty."); }

            Node current = root;
            while (current.Left != null) { current = current.Left; }
            Remove(current.Key);
            return current.Value;
        }
        public V PollLastEntry()
        {
            if (root == null) { throw new InvalidOperationException("Tree is empty."); }

            Node current = root;
            while (current.Right != null) { current = current.Right; }
            Remove(current.Key);
            return current.Value;
        }
        public V FirstEntry()
        {
            if (root == null) { throw new InvalidOperationException("Tree is empty."); }

            Node current = root;
            while (current.Left != null) { current = current.Left; }

            return current.Value;
        }
        public V LastEntry()
        {
            if (root == null) { throw new InvalidOperationException("Tree is empty."); }

            Node current = root;
            while (current.Left != null) { current = current.Left; }

            return current.Value;
        }
    }

}
