
using System.Drawing;
using System.Runtime.CompilerServices;

class MyPriorityQueue<T>  where T : IComparable<T>
{
    private T[] queue;
    private int size;
    private Comparer<T> comparator;
    public Comparer<T> ComparatorGet()
    {
        return comparator;
    }
    public void ComparatorSet(Comparer<T> comparator)
    {
        this.comparator = comparator;
    }

    public MyPriorityQueue() { queue = null; size = 11; comparator = Comparer<T>.Default; }
    public MyPriorityQueue(T[] arr) 
    { 
        queue = new T[arr.Length];
        size = arr.Length;
        for(int i = 0; i < arr.Length; i++) { queue[i] = arr[i]; }
        comparator = Comparer<T>.Default;
        Heapify();
    }

    public MyPriorityQueue(int initialCapacity) 
    { 
        queue = null; 
        size = initialCapacity; 
        comparator = Comparer<T>.Default;
    }
    
    public MyPriorityQueue(int initialCapacity, Comparer<T> comparator1)
    {
        if (initialCapacity < 0) throw new ArgumentOutOfRangeException();
        queue = null;
        size = initialCapacity;
        comparator = comparator1;
    }

    public MyPriorityQueue(MyPriorityQueue<T> Q)
    {
        queue = Q.ToArray();
        size = Q.Size();
        comparator = Q.ComparatorGet();
    }

    public void Add(T element)
    {
        if (size >= queue.Length)
        {
            int newCapacity = size < 64 ? (size * 2) + 1 : (int)(size * 1.5) + 1;
            T[] newArray = new T[newCapacity];

            for (int index = 0; index < size; index++) { newArray[index] = queue[index]; }
            queue = newArray;
        }
        
        queue[size] = element;
        size++;
        Heapify();
    
    }
    

    public void AddAll(T[] arr)
    {
        for(int i = 0; i < arr.Length; i++) Add(arr[i]);
    }

    public void Clear() { size = 0; }

    public bool Contains(object o)
    {
        bool k = false;
        for (int i = 0; i < size; i++)
        {
            foreach (T t in queue)
            {
                if (Equals(t, o)) k = true;
            }
        }
        return k;
    }

    public bool ContainsAll(T[] arr)
    {
        bool k = false;
        for (int i = 0; i < arr.Length; i++)
        {
            if (Contains(arr[i])) k = true;
        }
        return k;
    }

    public bool IsEmpty()
    {
        if(size == 0) return true;
        else return false;
    }
     private int FindIndex(object o)
    {
        for (int i = 0; i < size; i++)
        {
            if (o.Equals(queue[i]))
            {
                return i;
            }
        }
        return -1;
    }

    public void Remove(object o)
    {
        if (Contains(o))
        {
            int index = FindIndex(o);
            size--;
            queue[index] = queue[size];
        } 
        Heapify(); 
    }

    
    public void RemoveAll(T[] arr)
    {
        for (int i = 0; i < arr.Length; i++) { Remove(arr[i]); }
    }

    public void RetainAll(T[] arr)
    {
        
        T[] arrCopy = new T[queue.Length];
        for (int i = 0; i < queue.Length; i++) arrCopy[i] = queue[i];
        if(ContainsAll(arr) != true) 
        {
            Console.WriteLine("Некоторые элементы отсутствуют в массиве");
            return;
        }
        bool flag = true;
        foreach(T element in arrCopy)
        {
            foreach(T elems in arr)
            {
                if (element.Equals(elems)) 
                {   
                    flag = false;
                    break;
                }
            }
            if(flag == true) Remove(element);
            flag = true;
        }
        Array.Clear(arrCopy);
    }

    public int Size() { return size; }

    public T[] ToArray()
    {
        T[] newArray = new T[size];
        for(int i = 0; i < size; i++)
        {
            newArray[i] = queue[i];
        }
        return newArray;
    }

    public T[] ToArray(T[]? arr)
    {

        if (arr!= null && arr.Length < size) 
        {
            Console.WriteLine("В массиве недостаточно места для хранения массива");
            return arr;
        }

        else if(arr == null) arr = new T[size];
        for(int i = 0; i < arr.Length; i++) arr[i] = queue[i];
        return arr;
    }

    public T Element() { return queue[0]; }

    public bool Offer(T obj)
    {
        Add(obj);
        if (Contains(obj)) return true;
        else return false;
    }

    public T? Peek()
    {
        if (size == 0) return default(T);
        else return queue[0];
    }

    public T? Poll()
    {
        if (size == 0) return default;
        T element = queue[0];
        for (int i = 0; i < size - 1; i++) queue[i] = queue[i + 1];
        size--;
        Heapify();
        return element;
    }

    private void Heapify()
    {
        MyHeap<T> myHeap = new MyHeap<T>(queue);
        myHeap.ComparatorSet(comparator);
        for (int i = 0; i < size; i++) queue[i] = myHeap.Get(i); 
    }
    private void Swap(int index1, int index2)
    {
        T temp1 = queue[index1];
        queue[index1] = queue[index2];
        queue[index2] = temp1;
    }

    public void Print()
    {
        for (int i = 0; i < size; i++) Console.Write(queue[i] + " ");
        Console.WriteLine();
    }

}

class Project
{
    static void Main(string[] args)
    {
        int[] mas = { 44, 2, 8, 3, 31, 9, 7 };

        MyPriorityQueue<int> q = new MyPriorityQueue<int>(mas);
        Console.WriteLine("Начальная 'куча': ");
        q.Print();
        Console.WriteLine();

        Console.WriteLine("'Куча' после добаления нового элемента: ");
        q.Add(4);
        q.Print();
        Console.WriteLine();

        Console.WriteLine("Извлекаем первый элемент: ");
        Console.WriteLine(q.Poll());
        Console.WriteLine();

        Console.WriteLine("'Куча' после извлечения первого элемента: ");
        q.Print();
        
    }
}
