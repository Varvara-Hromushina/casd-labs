using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static task_28.Program;

namespace task_28
{
    public class MyArrayList<T> : MyList<T>
    {
        private T[] elementData;
        private int size;

        private MyArrayList<T> list;
        public MyArrayList(MyArrayList<T> listt)
        {
            list = listt;
        }

        public void ListIterator() { list.ListIterator(); }
        public void ListIterator(int index) { list.ListIterator(index); }

        public IEnumerator<T> GetEnumerator()
        {
            T[] arr = ToArray();
            foreach (T i in arr)
            {
                yield return i;
            }
        }


        public MyArrayList() { size = 0; }

        public MyArrayList(T[] arr)
        {
            elementData = new T[arr.Length];
            size = arr.Length;
            for (int i = 0; i < size; i++)
            {
                elementData[i] = arr[i];
            }
        }

        public MyArrayList(int capacity)
        {
            elementData = new T[capacity];
            size = 0;
        }

        public void Add(T element)
        {
            if (size == elementData.Length) Resize();
            elementData[size] = element;
            size++;
        }

        public void Resize()
        {
            int newSize = (int)(elementData.Length * 1.5) + 1;
            T[] newElementData = new T[newSize];
            for (int i = 0; i < size; i++)
            {
                newElementData[i] = elementData[i];
            }
            elementData = newElementData;
        }

        public void Add(T[] arr)
        {
            foreach (T element in arr) Add(element);
        }

        public void Clear()
        {
            elementData = null;
            size = 0;
        }

        public bool Contains(object obj)
        {
            foreach (T element in elementData)
            {
                if (element.Equals(obj)) return true;
            }
            return false;
        }

        public bool ContainsAll(T[] arr)
        {
            bool flag = true;
            foreach (T element in arr)
            {
                if (flag)
                {
                    flag = false;
                    foreach (T elems in elementData)
                    {
                        if (element.Equals(elems))
                        {
                            flag = true;
                            break;
                        }
                    }
                }
                else break;
            }
            return flag;
        }

        public bool IsEmpty()
        {
            if (size == 0) return true;
            else return false;
        }

        public void Remove(object obj)
        {
            for (int i = 0; i < elementData.Length; i++)
            {
                if (elementData[i].Equals(obj))
                {
                    for (int j = i; j < elementData.Length - 1; j++)
                    {
                        elementData[j] = elementData[j + 1];
                    }
                    size--;
                    Array.Resize(ref elementData, size);
                    return;
                }
            }
        }

        public void RemoveAll(T[] arr)
        {
            foreach (T element in arr) Remove(element);
        }

        public void RetainAll(T[] arr)
        {

            T[] arrCopy = new T[elementData.Length];
            for (int i = 0; i < elementData.Length; i++) arrCopy[i] = elementData[i];
            if (ContainsAll(arr) != true)
            {
                Console.WriteLine("Некоторые элементы отсутствуют в массиве");
                return;
            }
            bool flag = true;
            foreach (T element in arrCopy)
            {
                foreach (T elems in arr)
                {
                    if (element.Equals(elems))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag == true) Remove(element);
                flag = true;
            }
        }

        public int Size()
        {
            return size;
        }

        public T[] ToArray()
        {
            T[] newArray = new T[size];
            for (int i = 0; i < size; i++)
            {
                newArray[i] = elementData[i];
            }
            return newArray;
        }

        public T[] ToArray(T[] arr)
        {

            if (arr != null && arr.Length < size)
            {
                Console.WriteLine("В массиве недостаточно места для хранения динамического массива");
                return arr;
            }

            else if (arr == null) arr = new T[size];
            for (int i = 0; i < arr.Length; i++) arr[i] = elementData[i];
            return arr;
        }

        public void Add(int index, T element)
        {
            if ((index < 0) || (index > size)) throw new ArgumentOutOfRangeException("index");
            if (size == elementData.Length) Resize();
            for (int j = size; j > index; j--) elementData[j] = elementData[j - 1];
            elementData[index] = element;
            size++;
        }

        public void AddAll(int index, T[] arr)
        {
            T[] newArray = new T[size + arr.Length];
            for (int i = 0; i < index; i++)
            {
                newArray[i] = elementData[i];
            }
            int j = 0;
            for (int i = index; i < index + arr.Length; i++)
            {
                newArray[i] = arr[j]; j++;
            }
            int k = index;
            for (int i = index + arr.Length; i < size + arr.Length; i++)
            {
                newArray[i] = elementData[k]; k++;
            }
            elementData = newArray;
            size = newArray.Length;
        }

        public T Get(int index)
        {
            if ((index < 0) || (index > size)) throw new ArgumentOutOfRangeException("index");
            else return elementData[index];
        }

        public int IndexOf(object obj)
        {
            for (int i = 0; i < size; i++) if (obj.Equals(elementData[i])) return i;
            return -1;
        }

        public int LastIndexOf(object obj)
        {
            for (int i = size - 1; i > 0; i--) if (obj.Equals(elementData[i])) return i;
            return -1;
        }

        public T Remove(int index)
        {
            if ((index < 0) || (index > size)) throw new ArgumentOutOfRangeException("index");
            T element = elementData[index];
            Remove(element);
            return element;
        }

        public void Set(int index, T element)
        {
            if ((index < 0) || (index > size)) throw new ArgumentOutOfRangeException("index");
            elementData[index] = element;
        }

        public T[] SubList(int fromIndex, int toIndex)
        {
            if ((fromIndex < 0) || (fromIndex > size)) throw new ArgumentOutOfRangeException("fromIndex");
            if ((toIndex < 0) || (toIndex > size)) throw new ArgumentOutOfRangeException("toIndex");
            int k = 0;
            T[] newArray = new T[toIndex - fromIndex];
            for (int i = fromIndex; i < toIndex; i++)
            {
                newArray[k] = elementData[i]; k++;
            }
            return newArray;
        }

        public void Print()
        {
            if (size != 0) { for (int i = 0; i < size; i++) Console.Write(elementData[i] + " "); }
            Console.WriteLine();
        }
    }

}
