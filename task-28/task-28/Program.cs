using System;
using System.Collections.Generic;

namespace task_28
{
    public class Program
    {
        public interface MyCollection<T>
        {
            void Add(T e);
            void AddAll(int index,T[] a);
            void Clear();
            bool Contains(object o);
            bool ContainsAll(T[] a);
            bool IsEmpty();
            void Remove(object o);
            void RemoveAll(T[] a);
            void RetainAll(T[] a);
            int Size();
            T[] ToArray();
            T[] ToArray(T[] a);
        }
        public interface MyList<T> : MyCollection<T>
        {
            void Add(int index, T e);
            void AddAll(int index, T[] a);
            T Get(int index);
            int IndexOf(object o);
            int LastIndexOf(object o);
            void ListIterator();
            void ListIterator(int index);
            T Remove(int index);
            void Set(int index, T e);
            T[] SubList(int fromIndex, int toIndex);
        }
        public interface MyQueue<T> : MyCollection<T>
        {
            T Element();
            bool Offer(T obj);
            T Peek();
            T Poll();
        }
        public interface MyDeque<T> : MyCollection<T>
        {
            void AddFirst(T obj);
            void AddLast(T obj);
            T GetFirst();
            T GetLast();
            bool OfferFirst(T obj);
            bool OfferLast(T obj);
            T Pop();
            void Push(T obj);
            T PeekFirst();
            T PeekLast();
            T PollFirst();
            T PollLast();
            T RemoveLast();
            T RemoveFirst();
            bool RemoveLastOccurrence(T obj);
            bool RemoveFirstOccurrence(T obj);
        }
        public interface MySet<T> : MyCollection<T>
        {
            T First();
            T Last();
            void SubSet(T FromElement, T ToElement);
            void HeadSet(T toElement);
            void TailSet(T fromElement);
        }


        public interface MyNavigableSet<T> : MySet<T>
        {
            void LowerEntry(T key);
            void FloorEntry(T key);
            void HigherEntry(T key);
            void CeilingEntry(T key);
            void LowerKey(T key);
            void FloorKey(T key);
            void HigherKey(T key);
            void CeilingKey(T key);
            void PollFirstEntry();
            void PollLastEntry();
            void FirstEntry();
            void LastEntry();

        }

        public interface MyMap<K, V>
        {
            void Clear();
            bool ContainsKey(K key);
            bool ContainsValue(V value);
            IEnumerable<KeyValuePair<K, V>> EntrySet();
            V Get(K key);
            bool IsEmpty();
            K[] KeySet();
            void Put(K key, V value);
            void Remove(K key);
            int Size();
        }
        public interface MySortedMap<K, V>
        {
            K FirstKey();
            K LastKey();
            void HeapMap(K end);
            void SubMap(K start, K end);
            void TailMap(K start);
        }
        public interface MyNavigableMap<K, V> : MySortedMap<K, V>
        {
            void LowerEntry(K key);
            void FloorEntry(K key);
            void HigherEntry(K key);
            void CeilingEntry(K key);
            void LowerKey(K key);
            void FloorKey(K key);
            void HigherKey(K key);
            void CeilingKey(K key);
            V PollFirstEntry();
            V PollLastEntry();
            V FirstEntry();
            V LastEntry();
        }
        static void Main(string[] args)
        {
            
        }
    }
}