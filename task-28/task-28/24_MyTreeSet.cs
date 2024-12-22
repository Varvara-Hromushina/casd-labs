using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static task_28.Program;

namespace task_28
{
    public class MyTreeSet<T> where T : IComparable<T>, MyNavigableSet<T>
    {
        private RedBlackTree<T> _tree;

        IComparer<T> _comparer = Comparer<T>.Default;

        private int Size => _tree.Size();

        public MyTreeSet()
        {
            _tree = new RedBlackTree<T>();
        }

        public MyTreeSet(RedBlackTreeNode<T> m)
        {
            _tree = new RedBlackTree<T>();
            Add(m.Key, m.Value);
        }

        public MyTreeSet(Comparer<T> comparer)
        {
            _tree = new RedBlackTree<T>(comparer);
            _comparer = comparer;
        }

        public MyTreeSet(T[] arrayKeys, T[] arrayValues)
        {
            _tree = new RedBlackTree<T>();
            AddAll(arrayKeys, arrayValues);
        }

        public void Add(T key, T value)
        {
            if (!_tree.Contains(key))
            {
                _tree.Insert(key, value);
            }
        }

        public void AddAll(T[] arrayKeys, T[] arrayValues)
        {
            for(int i = 0; i < arrayKeys.Length; i++) 
            {
                Add(arrayKeys[i], arrayValues[i]);
            }
        }

        public void Clear()
        {
            foreach (var node in _tree)
            {
                node.Left = null;
                node.Right = null;
            }
            _tree = new RedBlackTree<T>();
        }

        public bool Contains(T item)
        {
            return _tree.Contains(item);
        }

        public bool ContainsAll(T[] array)
        {
            foreach (T item in array)
            {
                if (!Contains(item)) return false;
            }
            return true;
        }

        public bool IsEmpty() { return _tree.IsEmpty(); }

        public void Remove(T key)
        {
            _tree.Remove(key);
        }

        public void RemoveAll(T[] array)
        {
            if (ContainsAll(array))
            {
                foreach (T item in array)
                {
                    _tree.Remove(item);
                }
            }
        }

        public void RetainAll(T[] array)
        {
            if (ContainsAll(array))
            {
                foreach (var node in _tree)
                {
                    if (!array.Contains(node.Value)) Remove(node.Value);
                }
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[Size];
            int i = 0;
            foreach (var node in _tree)
            {
                array[i++] = node.Value;
            }
            return array;
        }

        public T[] ToArray(T[] array)
        {
            array = new T[Size];
            int i = 0;
            foreach (var node in _tree)
            {
                array[i++] = node.Value;
            }
            return array;
        }

        public T First()
        {
            foreach (var node in _tree)
            {
                return node.Value;
            }
            return default(T);
        }

        public T Last()
        {
            var last = default(T);
            foreach (var node in _tree)
            {
                last = node.Value;
            }
            return last;
        }

        public MyTreeSet<T> SubSet(T from, T to)
        {
            MyTreeSet<T> newTreeSet = new MyTreeSet<T>();
            foreach (var node in _tree)
            {
                if (node.Value.CompareTo(from) >= 0 && node.Value.CompareTo(to) < 0) newTreeSet.Add(node.Key,node.Value);
            }
            return newTreeSet;
        }

        public MyTreeSet<T> HeadSet(T to)
        {
            MyTreeSet<T> newTreeSet = new MyTreeSet<T>();
            foreach (var node in _tree)
            {
                if (node.Value.CompareTo(to) < 0) newTreeSet.Add(node.Key, node.Value);
            }
            return newTreeSet;
        }

        public MyTreeSet<T> TailSet(T from)
        {
            MyTreeSet<T> newTreeSet = new MyTreeSet<T>();
            foreach (var node in _tree)
            {
                if (node.Value.CompareTo(from) >= 0) newTreeSet.Add(node.Key, node.Value);
            }
            return newTreeSet;
        }

        public T Ceiling(T item)
        {
            foreach (var node in _tree)
            {
                if (node.Value.CompareTo(item) >= 0) return node.Value;
            }
            return default(T);
        }

        public T Floor(T item)
        {
            T res = default(T);
            foreach (var node in _tree)
            {
                if (node.Value.CompareTo(item) <= 0) res = node.Value;
            }
            return res;
        }

        public T Higher(T item)
        {
            foreach (var node in _tree)
            {
                if (node.Value.CompareTo(item) > 0) return node.Value;
            }
            return default(T);
        }

        public T Lower(T item)
        {
            T res = default(T);
            foreach (var node in _tree)
            {
                if (node.Value.CompareTo(item) < 0) res = node.Value;
            }
            return res;
        }

        public MyTreeSet<T> HeadSet(T upperBound, bool include)
        {
            MyTreeSet<T> newTreeSet = new MyTreeSet<T>();
            foreach (var node in _tree)
            {
                if (include)
                {
                    if (node.Value.CompareTo(upperBound) <= 0) newTreeSet.Add(node.Key, node.Value);
                }
                else if (node.Value.CompareTo(upperBound) < 0) newTreeSet.Add(node.Key, node.Value);
            }
            return newTreeSet;
        }

        public MyTreeSet<T> SubSet(T upperBound, T lowerBound, bool lowInclude, bool highInclude)
        {
            MyTreeSet<T> newTreeSet = new MyTreeSet<T>();
            foreach (var node in _tree)
            {
                if (lowInclude)
                {
                    if (highInclude)
                    {
                        if (node.Value.CompareTo(upperBound) <= 0 && node.Value.CompareTo(lowerBound) >= 0) newTreeSet.Add(node.Key, node.Value);
                    }
                    else
                    {
                        if (node.Value.CompareTo(upperBound) <= 0 && node.Value.CompareTo(lowerBound) > 0) newTreeSet.Add(node.Key, node.Value);
                    }
                }
                else
                {
                    if (highInclude)
                    {
                        if (node.Value.CompareTo(upperBound) <= 0 && node.Value.CompareTo(lowerBound) >= 0) newTreeSet.Add(node.Key, node.Value);
                    }
                    else
                    {
                        if (node.Value.CompareTo(upperBound) <= 0 && node.Value.CompareTo(lowerBound) > 0) newTreeSet.Add(node.Key, node.Value);
                    }
                }
            }
            return newTreeSet;
        }

        public MyTreeSet<T> TailSet(T lowerBound, bool include)
        {
            MyTreeSet<T> newTreeSet = new MyTreeSet<T>();
            foreach (var node in _tree)
            {
                if (include)
                {
                    if (node.Value.CompareTo(lowerBound) >= 0) newTreeSet.Add(node.Key, node.Value);
                }
                else if (node.Value.CompareTo(lowerBound) < 0) newTreeSet.Add(node.Key, node.Value);
            }
            return newTreeSet;
        }

        public T PollLast()
        {
            T elem = Last();
            if (elem != null) Remove(elem);
            return elem;

        }

        public T PollFirst()
        {
            T elem = First();
            if (elem != null) Remove(elem);
            return elem;

        }

        public IEnumerator<RedBlackTreeNode<T>> DescendingIterator()
        {
            return _tree.ReverseInOrder(_tree.root).GetEnumerator();
        }

        public MyTreeSet<T> DescendingSet()
        {
            MyTreeSet<T> newTreeSet = new MyTreeSet<T>();
            var it = DescendingIterator();
            while (it.MoveNext()) newTreeSet.Add(it.Current.Key, it.Current.Value);
            return newTreeSet;
        }

        public IEnumerator<T> GetEnumerator()
        {
            T[] arr = ToArray();
            foreach (T i in arr)
            {
                yield return i;
            }
        }

        public void Print()
        {
            _tree.InOrderTraversal();
        }
    }
}
