using System.Linq;
using System;

public class MyHashSet<T> where T : IComparable
{
    MyHashMap<T, object> map;
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

class Program
{
    public static void Main(string[] args)
    {
        MyHashSet<int> set = new MyHashSet<int>();

        Console.WriteLine("Начальное множество: ");
        for (int i = 1; i <= 5; i++) set.Add(i * 7);
        int[] arr1 = set.ToArray();
        foreach (int i in arr1) { Console.Write(i + " "); }
        Console.WriteLine();

        Console.WriteLine("Множество после удаления элемента 7: ");
        set.Remove(7);
        int[] arr2 = set.ToArray();
        foreach (int i in arr2) { Console.Write(i + " "); }
        Console.WriteLine();

        Console.WriteLine("Проверка, содержит ли множество элемент 14: " + set.Contains(14));

        set.Add(156);
        Console.WriteLine("Множество после добавления элемента 156: ");
        int[] arr3 = set.ToArray();
        foreach (int i in arr3) { Console.Write(i + " "); }
        Console.WriteLine();
        Console.ReadKey();
    }
}