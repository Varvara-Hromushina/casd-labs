﻿public class MyLinkedList<T>
{
    private class MyLLElement<T>
    {
        public T value;
        public MyLLElement<T>? next;
        public MyLLElement<T>? prev;
        public MyLLElement(T element)
        {
            next = null;
            prev = null;
            value = element;
        }
    }

    private MyLLElement<T>? first;
    private MyLLElement<T>? last;
    private int size;

    // 1
    public MyLinkedList()
    {
        first = null;
        last = null;
        size = 0;
    }

    // 2
    public MyLinkedList(T[] array)
    {
        foreach (T item in array) Add(item);
    }

    // 3
    public void Add(T item)
    {
        MyLLElement<T> element = new MyLLElement<T>(item);
        if (size == 0)
        {
            first = element;
            last = element;
        }
        else
        {
            last.next = element;
            element.prev = last;
            last = element;
        }
        size++;
    }

    // 4
    public void AddAll(T[] array)
    {
        foreach(T item in array)
            Add(item);
    }

    // 5
    public void Clear()
    {
        first = null;
        last = null;
        size = 0;
    }

    // 6
    public bool Contains(object item)
    {
        MyLLElement<T> step = first;
        while (step != null)
        {
            if (step.value.Equals(item))
                return true;
            step = step.next;
        }
        return false;

        
    }

    // 7
    public bool ContainsAll(T[] array)
    {
        bool[] newArray = new bool[array.Length];
        MyLLElement<T> step = first;
        while(step != null)
        {
            int cnt = 0;
            if (step.Equals(array[cnt]))
                newArray[cnt] = true;
            cnt++;
            step = step.next;
        }
        for (int i = 0; i < newArray.Length; i++)
            if (!newArray[i])
                return false;
        return true;
    }
    // 8
    public bool IsEmpty() => size == 0;

    // 9
    public void Remove(object item)
    {
        if (Contains(item))
        {
            if (first.value.Equals(item))
            {
                first = first.next;
                size--;
                return;
            }
            MyLLElement<T>? step = first;
            while(step != null)
            {
                if (step.next.value.Equals(item))
                {
                    step = step.next;
                    size--;
                    return;
                }
                else
                    step = step.next;
            }
        }
    }

    // 10
    public void RemoveAll(T[] array)
    {
        foreach(T item in array)
            Remove(item);
    }

    // 11
    public void RetainAll(T[] array)
    {
        T[] newArray = new T[array.Length];
        for (int i = 0; i < size; i++)
        {
            int fl = 0;
            for (int j = 0; j < array.Length; j++)
            {
                if (Get(i).Equals(array[j]))
                {
                    fl = 0;
                    break;
                }
                else
                    fl = 1;
            }
            if (fl == 1)
                Remove(Get(i));
        }
    }

    // 12
    public int Size() => size;

    // 13
    public T[] ToArray()
    {
        T[] newArray = new T[size];
        for (int i = 0; i < size; i++)
            newArray[i] = Get(i);
        return newArray;
    }

    // 14
    public T[] ToArray(T[] array)
    {
        if (array == null)
            return ToArray();
        else
        {
            T[] newArray = new T[array.Length + size];
            for (int i = 0; i < array.Length; i++)
                newArray[i] = array[i];
            for (int i = array.Length; i < newArray.Length; i++)
                newArray[i] = Get(i);
            return newArray;
        }
    }

    // 15
    public void Add(int index, T item)
    {
        if(index == 0)
        {
            MyLLElement<T> step = new MyLLElement<T>(item);
            step.next = first;
            first.prev = step;
            first = step;
            return;
        }
        else if (index == size - 1)
        {
            MyLLElement<T> step = new MyLLElement<T> (item);
            step.prev = last;
            last.next = step;
            last = step;
            return;
        }
        else
        {
            MyLLElement<T> step = new MyLLElement<T>(item);
            step = first;
            int cnt = 0;
            while(cnt != index)
            {
                step = step.next;
                cnt++;
            }
            if (cnt == index)
            {
                MyLLElement<T> element = new MyLLElement<T> (item);
                element.next = step;
                element.prev = step.prev;
                step.prev.next = element;
                step.prev = element;
            }
        }
    }

    // 16
    public void AddAll(int index, T[] array)
    {
        foreach (T item in array)
            Add(index, item);
    }
    
    // 17
    public T Get(int index)
    {
        int current = 0;
        if (index >= size) throw new IndexOutOfRangeException();
        if (index == size - 1) return last.value;
        if (index == 0) return first.value;
        MyLLElement<T>? step = first;
        while(current != index)
        {
            step = step.next;
            current++;
        }
        return step.value;
    }

    // 18
    public int IndexOf(T item)
    {
        int i = 0;
        MyLLElement<T> step = new MyLLElement<T>(item);
        step = first;
        while (step != null)
        {
            if (step.value.Equals(item))
                return i;
            i++;
            step = step.next;
        }
        return -1;
    }

    // 19
    public int LastIndexOf(T item) 
    {
        int i = 0;
        int retI = -1;
        MyLLElement<T> step = new MyLLElement<T>(item);
        step = first;
        while(step != null)
        {
            if (step.value.Equals(item))
                retI = i;
            i++;
            step = step.next;
        }
        return retI;
    }

    // 20
    public T Remove(int index)
    {
        T item = Get(index);
        Remove(item);
        return item;
    }

    // 21
    public void Set(int index, T item)
    {
        MyLLElement<T> step = new MyLLElement<T>(item);
        step = first;
        int ind = 0;
        while(ind != index)
        {
            ind++;
            step = step.next;
        }
        step.value = item;
    }

    // 22
    public T[] SubList(int fromIndex, int toIndex)
    {
        T[] array = new T[toIndex - fromIndex + 1];
        int index1 = 0;
        int index2 = 0;
        MyLLElement<T> step = new MyLLElement<T>(first.value);
        step = first;
        while (index1 != fromIndex)
        {
            step = step.next;
            index1++;
        }
        while (index1 <= toIndex)
        {
            index1++;
            index2++;
            array[index2] = step.value;
            step = step.next;
        }
        return array;
    }

    // 23
    public T Element() => first.value;


    // 24
    public bool Offer(T item)
    {
        Add(item);
        if (Contains(item))
            return true;
        return false;
    }

    // 25
    public T Peek()
    {
        if (first == null) throw new NullReferenceException();
        return first.value;
    }

    // 26
    public T Poll()
    {
        T item = first.value;
        Remove(item);
        return item;
    }
    // 27
    public void AddFirst(T item) => Add(0, item);

    // 28
    public void AddLast(T item) => Add(size - 1, item);

    // 29
    public T GetFirst()
    {
        if (first == null)
            throw new NullReferenceException();
        return first.value;
    } 

    // 30
    public T GetLast()
    {
        if (first == null)
            throw new NullReferenceException();
        return last.value;
    }

    // 31
    public bool OfferFirst(T item)
    {
        AddFirst(item);
        if (Contains(item))
            return true;
        return false;
    }

    // 32
    public bool OfferLast(T item)
    {
        AddLast(item);
        if (Contains(item))
            return true;
        return false;
    }

    // 33
    public T Pop()
    {
        T item = first.value;
        Remove(item);
        return item;
    }

    // 34
    public void Push(T obj)
    {
        AddFirst(obj);
    }

    // 35
    public T PeekFirst()
    {
        if (size == 0)
            throw new Exception();
        return first.value;
    }

    // 36
    public T PeekLast()
    {
        if (size == 0)
            throw new Exception();
        return last.value;
    }

    // 37
    public T PollFirst()
    {
        T item = first.value;
        Remove(item);
        return item;
    }
    
    // 38
    public T PollLast()
    {
        T item = last.value;
        Remove(item);
        return item;
    }

    // 39
    public T RemoveLast()
    {
        T item = last.value;
        Remove(item);
        return item;
    }

    // 40
    public T RemoveFirst()
    {
        T item = first.value;
        Remove(item);
        return item;
    }

    // 41
    public bool RemoveLastOccurence(T item)
    {
        int index = LastIndexOf(item);
        if (index != -1)
        {
            Remove(index);
            return true;
        }
        return false;
    }

    // 42
    public bool RemoveFirstOccurence(T item)
    {
        int index = IndexOf(item);
        if (index != -1)
        {
            Remove(index);
            return true;
        }
        return false;
    }

    public void Print()
    {
        MyLLElement<T> step = new MyLLElement<T>(first.value);
        step = first;
        while (step != null)
        {
            Console.Write($"{step.value} ");
            step = step.next;
        }
        Console.WriteLine();
    }
} 
public class Program
{
    static void Main()
    {
        int[] array = { 1, 4, 5, -5, 80, -87, 63, 23, 7 };
        MyLinkedList<int> list = new MyLinkedList<int>(array);
        Console.WriteLine("Начальный двунаправленный список: ");
        list.Print();
        Console.WriteLine();
        Console.WriteLine("Удаляем и возвращаем элемент из головы двунаправленного списка: " + list.Poll());
        list.Print();
    }
}