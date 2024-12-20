using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using task_27;

namespace task_27
{
    public interface MyIterator1<T>
    {
        bool HasNext();
        T Next();
        void Remove();
    }

    public interface MyIterator2<T>
    {
        bool HasNext();
        T Next();
        bool HasPrevious();
        T Previous();
        int NextIndex();
        int PreviousIndex();
        void Remove();
        void Set(T element);
        void Add(T element);
    }
    public class MyItr1<T> : MyIterator1<T> where T : IComparable<T>
    {
        private MyPriorityQueue<T> queue;
        private IEnumerator<T> enumerator;
        private T cursor;
        private bool cursorInitialized;

        public MyItr1(MyPriorityQueue<T> queue)
        {
            this.queue = queue; // Использование this для обращения к полю класса
            enumerator = queue.GetEnumerator();
            cursorInitialized = false; // Флаг для отслеживания состояния cursor
        }

        public bool HasNext()
        {
            return enumerator.MoveNext();
        }

        public T Next()
        {
            if (!HasNext())
                throw new InvalidOperationException("Нет следующего элемента.");

            cursor = enumerator.Current;
            cursorInitialized = true; // Установить флаг, что cursor был инициализирован
            return cursor;
        }

        public void Remove()
        {
            if (!cursorInitialized)
                throw new InvalidOperationException("Метод Next должен быть вызван перед вызовом Remove.");

            queue.Remove(cursor);
            cursorInitialized = false; // Сбрасываем флаг после удаления
        }
    }

    public class MyItr2<T> : MyIterator1<T>
    {
        private MyArrayDeque<T> deque;
        private IEnumerator<T> enumerator;
        private T cursor;
        public MyItr2(MyArrayDeque<T> deque)
        {
            this.deque = deque;
            enumerator = deque.GetEnumerator();
        }

        public bool HasNext()
        {
            return enumerator.MoveNext();
        }

        public T Next()
        {
            cursor = enumerator.Current;
            return cursor;
        }

        public void Remove()
        {
            deque.Remove(cursor);
        }
    }

    public class MyItr3<T> : MyIterator1<T> where T : IComparable<T>
    {
        private MyHashSet<T> set;
        private IEnumerator<T> enumerator;
        private T cursor;
        public MyItr3(MyHashSet<T> kk)
        {
            set = kk;
            enumerator = set.GetEnumerator();
        }
        public bool HasNext()
        {
            return enumerator.MoveNext();
        }

        public T Next()
        {
            cursor = enumerator.Current;
            return cursor;
        }

        public void Remove()
        {
            set.Remove(cursor);
        }
    }

    public class MyItr4<T> : MyIterator1<T> where T : IComparable<T>
    {
        private MyTreeSet<T> root;
        private IEnumerator<T> enumerator;
        private T cursor;
        public MyItr4(MyTreeSet<T> s)
        {
            root = s;
            enumerator = root.GetEnumerator();
        }
        public bool HasNext()
        {
            return enumerator.MoveNext();
        }

        public T Next()
        {
            cursor = enumerator.Current;
            return cursor;
        }

        public void Remove()
        {
            root.Remove(cursor);
        }
    }

    public class MyItr5<T> : MyIterator2<T>
    {
        private MyArrayList<T> array;
        private IEnumerator<T> enumerator;
        private T cursor;
        private int index; // для переммещения назад
        public MyItr5(MyArrayList<T> list)
        {
            array = list;
            enumerator = list.GetEnumerator();

        }
        public bool HasNext()
        {
            return enumerator.MoveNext();
        }
        public T Next()
        {
            cursor = enumerator.Current;
            return cursor;
        }
        public bool HasPrevious()
        {
            return index > 0;

        }
        public T Previous()
        {
            T element = array.Get(index--); return element;
        }
        public int NextIndex()
        {
            int i = array.IndexOf(cursor);
            if (i < array.Size() && i >= 0) return i++;
            else return -1;
        }
        public int PreviousIndex()
        {
            int i = array.IndexOf(cursor);
            if (i < array.Size() && i >= 0) return i--;
            else return -1;
        }
        public void Remove()
        {
            array.Remove(cursor);
        }
        public void Set(T element)
        {
            int i = array.IndexOf(element);
            array.Set(i, element);
        }
        public void Add(T element)
        {
            array.Add(element);
        }
    }

    public class MyItr6<T> : MyIterator2<T>
    {

        private MyVector<T> vector;
        private IEnumerator<T> enumerator;
        private T cursor;
        private int index; 
        public MyItr6(MyVector<T> list)
        {
            vector = list;
            enumerator = list.GetEnumerator();

        }
        public bool HasNext()
        {
            return enumerator.MoveNext();
        }
        public T Next()
        {
            cursor = enumerator.Current;
            return cursor;
        }
        public bool HasPrevious()
        {
            return index > 0;

        }
        public T Previous()
        {
            T element = vector.Get(index--); return element;
        }
        public int NextIndex()
        {
            int i = vector.IndexOf(cursor);
            if (i < vector.Size() && i >= 0) return i++;
            else return -1;
        }
        public int PreviousIndex()
        {
            int i = vector.IndexOf(cursor);
            if (i < vector.Size() && i >= 0) return i--;
            else return -1;
        }
        public void Remove()
        {
            vector.Remove(cursor);
        }
        public void Set(T element)
        {
            int i = vector.IndexOf(element);
            vector.Set(i, element);
        }
        public void Add(T element)
        {
            vector.Add(element);
        }

    }

    public class MyItr7<T> : MyIterator2<T>
    {
        private MyLinkedList<T> list;
        private IEnumerator<T> enumerator;
        private T cursor;
        private int index;
        public MyItr7(MyLinkedList<T> list1)
        {
            list = list1;
            enumerator = list1.GetEnumerator();

        }
        public bool HasNext()
        {
            return enumerator.MoveNext();
        }
        public T Next()
        {
            cursor = enumerator.Current;
            return cursor;
        }
        public bool HasPrevious()
        {
            return index > 0;

        }
        public T Previous()
        {
            T element = list.Get(index--); return element;
        }
        public int NextIndex()
        {
            int i = list.IndexOf(cursor);
            if (i < list.Size() && i >= 0) return i++;
            else return -1;
        }
        public int PreviousIndex()
        {
            int i = list.IndexOf(cursor);
            if (i < list.Size() && i >= 0) return i--;
            else return -1;
        }
        public void Remove()
        {
            list.Remove(cursor);
        }
        public void Set(T element)
        {
            int i = list.IndexOf(element);
            list.Set(i, element);
        }
        public void Add(T element)
        {
            list.Add(element);
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = { 34, 6, 41, 8, 15 };
            MyArrayList<int> list = new MyArrayList<int>(arr);
            MyItr5<int> iterator1 = new MyItr5<int>(list);

            Console.WriteLine("Начальный динамический массив:");
            while (iterator1.HasNext())
            {
                int element = iterator1.Next();
                Console.Write(element + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Динамический массив после добавления элемента 7:");
            list.Add(7);
            MyItr5<int> iterator2 = new MyItr5<int>(list);

            while (iterator2.HasNext())
            {
                int element = iterator2.Next();
                Console.Write(element + " ");
            }
        }
    }
}