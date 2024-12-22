using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_28
{
    public class MyHeap<T> where T : IComparable<T>
    {
        private MyArrayList<T> heap = new MyArrayList<T>(10);
        private Comparer<T> comparer;

        private int size;

        public MyHeap(T[] array)
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
                right = 2 * i + 2;

                if (right < size && comparer.Compare(heap.Get(right), heap.Get(parents)) > 0)
                    parents = right;

                if (left < size && comparer.Compare(heap.Get(left), heap.Get(parents)) > 0)
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

        public T Get(int index)
        {
            return heap.Get(index);
        }

        public void HeapMerge(MyHeap<T> newHeap)
        {
            while (newHeap.size > 0)
            {
                T element = newHeap.DeleteMaximum();
                AddElement(element);
            }
            for (int i = size / 2; i >= 0; i--)
                Heapify(i);
        }

        public void Print()
        {
            for (int i = 0; i < size; i++) Console.Write(heap.Get(i) + " ");
            Console.WriteLine();
        }
    }
}
