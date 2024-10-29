using System.Collections;

public class Heap<T> where T: IComparable<T>
{
    private MyArrayList<T> heap = new MyArrayList<T>(10);
    private Comparer<T> comparer;

    private int size;
    
    public Heap(T[] array)
    {
        size = array.Length;
        for (int i = 0; i < size; i++) heap.Add(array[i]);

        comparer = Comparer<T>.Default;    
        for (int i = size / 2 - 1; i >= 0; i--) Heapify(i);
    }

    public Comparer<T> ComparatorGet()
    {
        return comparer;
    }

    public void ComparatorSet(Comparer<T> comparator)
    {
        this.comparer = comparator;
    }
    
    public T SearchMaximum() => heap.Get(0);
    public T DeleteMaximum()
    {
        T maximum = heap.Get(0);
        heap.Remove(0);
        size--;
        Heapify(0);
        return maximum;
    }

  // восстанавливаем порядок
    public void Heapify(int i)
    {
        int left;
        int right;
        int parents = i;
        while (true)
        {
            left = 2 * i + 1;
            right  = 2 * i + 2;

            if(right < size && comparer.Compare(heap.Get(right),heap.Get(parents)) > 0)
                parents = right;

            if (left < size && comparer.Compare(heap.Get(left),heap.Get(parents)) > 0)
                parents = left;

            if (parents == i)
                break;

            Swap(parents, i);
            i = parents;
        }
    }

    
    private void Swap(int i, int j) 
    {
        T temp1 = heap.Get(i);
        T temp2 = heap.Get(j);
        heap.Set(j, temp1);
        heap.Set(i, temp2);
    }
    

    public void KeyIncr(int index, T e)
    {
        if (index > heap.Size() - 1) throw new IndexOutOfRangeException();

        heap.Set(index, e);
        for (int i = size / 2; i >= 0; i--) Heapify(i);
    }

    public void AddElement(T element)
    {
        heap.Set(size, element);
        size++;
        for (int i = size / 2; i >= 0; i--) Heapify(i);
    }

    public void HeapMerge(Heap<T> newHeap)
    {
        while(newHeap.size > 0)
        {
            T element = newHeap.DeleteMaximum();
            AddElement(element);
        }
        for(int i = size / 2; i >= 0; i--)
            Heapify(i);
    }

    public void Print()
    {
        for (int i = 0; i < size; i++) Console.Write(heap.Get(i) + " ");
        Console.WriteLine();
    }
}
class Project
{
    static void Main(string[] args)
    {
        int[] mas = { 7, 44, 2, 25, 8, 3, 31, 4};
        int[] mas1 = { 12, 23, 15 };

        Heap<int> hp = new Heap<int>(mas);
        Console.WriteLine("Первая 'куча': ");
        hp.Print();

        Heap<int>hp1 = new Heap<int>(mas1);
        Console.WriteLine("Вторая 'куча': ");
        hp1.Print();
        Console.WriteLine();

        Console.WriteLine("Первая 'куча' после удаления максимума: ");
        hp.DeleteMaximum();
        hp.Print();

        Console.WriteLine("Вторая 'куча' после удаления максимума: ");
        hp1.DeleteMaximum();
        hp1.Print();
        Console.WriteLine();

        Console.WriteLine("Слияние двух 'куч': ");
        hp.HeapMerge(hp1);
        hp.Print();
    }
}