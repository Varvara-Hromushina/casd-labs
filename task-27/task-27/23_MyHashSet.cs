using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_27
{
    public class MyHashSet<T> where T : IComparable<T>
    {
        MyHashMap<T, object> map;

        public IEnumerator<T> GetEnumerator()
        {
            T[] arr = ToArray();
            foreach (T i in arr)
            {
                yield return i;
            }
        }
        public MyHashSet()
        {
            map = new MyHashMap<T, object>();
        }
        public MyHashSet(T[] a)
        {
            map = new MyHashMap<T, object>();
            foreach (T obj in a)
                map.Put(obj, true);
        }
        public MyHashSet(int initialCapacity, float loadFactor)
        {
            map = new MyHashMap<T, object>(initialCapacity, loadFactor);
        }
        public MyHashSet(int initialCapacity)
        {
            map = new MyHashMap<T, object>(initialCapacity);
        }
        public void Add(T obj)
        {
            map.Put(obj, true);
        }
        public void addAll(T[] a)
        {
            foreach (T obj in a) map.Put(obj, true);
        }
        public void Clear() => map.Clear();
        public bool Contains(T obj) => map.ContainsKey(obj);
        public bool ContainsAll(T[] a)
        {
            foreach (T obj in a)
            { if (!map.ContainsKey(obj)) return false; }
            return true;
        }
        public bool IsEmpty() => map.IsEmpty();
        public void Remove(T obj) => map.Remove(obj);
        public void Remove(T[] a)
        {
            foreach (T obj in a) map.Remove(obj);
        }
        public void RetainAll(T[] a)
        {
            T[] g = map.KeySet();
            foreach (T obj in g)
                if (!a.Contains<T>(obj)) map.Remove(obj);
        }
        public void Size() => map.Size();

        public T[] ToArray()
        {
            T[] el = map.KeySet();
            return el;
        }

        public T[] ToArray(T[] a)
        {
            if (a == null)
                return ToArray();

            var count = map.Size();
            T[] el = new T[count];
            int i = 0;
            foreach (T obj in map.KeySet())
            {
                el[i++] = obj;
            }
            return el;
        }
    }


}
