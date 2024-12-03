using System.Collections;
using System.Reflection.Metadata.Ecma335;

public class MyHashMap<K, V>
{
    private class Node
    {
        public K Key { get; set; }
        public V Value { get; set; }
        public Node Next { get; set; }

        public Node(K key, V value)
        {
            Key = key;
            Value = value;
        }
    }

    private Node[] table;
    private int size;
    private double loadFactor;
    public MyHashMap()
    {
        table  = new Node[16];
        size = 16;
        loadFactor = 0.75;
    }
    public MyHashMap(int initialCapacity)
    {
        table = new Node[initialCapacity];
        size = initialCapacity;
        loadFactor = 0.75;
    }
    public MyHashMap(int initialCapacity, double loadFactorr)
    {
        table = new Node[initialCapacity];
        size = initialCapacity;
        loadFactor = loadFactorr;
    } 
    private int GetHashCode(K key)
    {
        return Math.Abs(key.GetHashCode()) % size; //чтобы ограничить хэш-код в диапазоне допустимых индексов массива от 0 до size - 1
    }
    private int GetHashCode(V key) { return Math.Abs(key.GetHashCode()) % size; }
    public void Clear() {  size = 0; }
    public bool ContainsKey(K key)
    {
        int index = GetHashCode(key);
        Node current = table[index];
        while (current != null)
        {
            if (current.Key.Equals(key)) { return true; }
            current = current.Next;
        }
        return false;
    }
    public bool ContainsValue(V value)
    {
        int index = GetHashCode(value);
        Node current = table[index];
        while (current != null)
        {
            if (current.Key.Equals(value)) { return true; }
            current = current.Next;
        }
        return false;
    }
    /*реализует итератор, который возвращает все пары ключ-значение из хэш-таблицы
    IEnumerable<KeyValuePair<K, V>>:
    Метод возвращает интерфейс IEnumerable, который позволяет итерироваться по коллекции пар ключ-значение.KeyValuePair<K, V>
    — это структура, представляющая пару ключ-значение, где K — тип ключа, а V — тип значения.*/
     public IEnumerable<KeyValuePair<K, V>> EntrySet()
    {
        for (int i = 0; i < size; i++)
        {
            Node current = table[i];
            while (current != null)
            {
                yield return new KeyValuePair<K, V>(current.Key, current.Value);
                current = current.Next;
            }
        }
    }
    public V Get(K key)
    {
        int index = GetHashCode(key);
        Node current = table[index];
        while (current != null)
        {
            if (current.Key.Equals(key)) { return current.Value; }
            current = current.Next;
        }

        throw new KeyNotFoundException("Ключ не найден.");
    }
    public bool IsEmpty() { return size == 0; }
    public void KeySet()
    {
        K[] t = new K[size];
        for (int i = 0; i < size; i++)
        {
            Node current = table[i];
            while (current != null)
            {
                t[i] = current.Key;
                current = current.Next;
            }
        }
    }
    public void Put(K key, V value)
    {
        int index = GetHashCode(key);
        Node newNode = new Node(key, value);

        if (table[index] == null)
        {
            table[index] = newNode;
        }
        else
        {
            Node current = table[index];
            while (true)
            {
                if (current.Key.Equals(key))
                {
                    current.Value = value;
                    return;
                }
                if (current.Next == null)
                {
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }
        }
    }
    public void Remove(K key)
    {
        int index = GetHashCode(key);

        // Если в индексе нет значения, ничего не делаем
        if (table[index] == null) { return; }

        // Если удаляемый ключ - первый в списке
        if (table[index].Key.Equals(key))
        {
            table[index] = table[index].Next;
            size--;
            return;
        }

        // Ищем ключ в списке
        Node current = table[index];
        Node? previous = null;
        while (current != null)
        {
            if (current.Key.Equals(key))
            {
                previous.Next = current.Next;
                size--;
                return;
            }
            previous = current;
            current = current.Next;
        }
    }
    public int Size() { return size; }
}
