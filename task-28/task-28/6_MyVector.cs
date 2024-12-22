using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static task_28.Program;

namespace task_28
{
    public class MyVector<T> : MyList<T>
    {
        protected T[] elementData;
        protected int elementCount;
        protected int capacityIncrement;

        private MyVector<T> vector;
        public MyVector(MyVector<T> v)
        {
            vector = v;
        }
        public void ListIterator() { vector.ListIterator(); }
        public void ListIterator(int index) { vector.ListIterator(index); }

        public IEnumerator<T> GetEnumerator()
        {
            T[] arr = ToArray();
            foreach (T i in arr)
            {
                yield return i;
            }
        }

        public MyVector(int initialCapacity, int initialCapacityIncrement)
        {
            elementData = new T[initialCapacity];
            elementCount = initialCapacity;
            capacityIncrement = initialCapacityIncrement;
        }

        public MyVector(int initialCapacity)
        {
            elementData = new T[initialCapacity];
            elementCount = 0;
            capacityIncrement = 0;
        }

        public MyVector()
        {
            elementData = null;
            elementCount = 10;
            capacityIncrement = 0;
        }

        public MyVector(T[] arr)
        {
            elementData = new T[arr.Length];
            elementCount = arr.Length;
            for (int i = 0; i < elementCount; i++)
            {
                elementData[i] = arr[i];
            }
            capacityIncrement = 0;
        }


        public void Add(T element)
        {
            if (elementCount == elementData.Length) Resize();
            elementData[elementCount] = element;
            elementCount++;
        }

        public void Resize()
        {
            T[] newElementData;
            if (capacityIncrement != 0) newElementData = new T[(int)(elementData.Length * capacityIncrement)];
            else newElementData = new T[(int)(elementData.Length * 2)];

            for (int i = 0; i < elementCount; i++)
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
            elementCount = 0;
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
            if (elementCount == 0) return true;
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
                    elementCount--;
                    Array.Resize(ref elementData, elementCount);
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
            return elementCount;
        }

        public T[] ToArray()
        {
            T[] newArray = new T[elementCount];
            for (int i = 0; i < elementCount; i++)
            {
                newArray[i] = elementData[i];
            }
            return newArray;
        }

        public T[] ToArray(T[] arr)
        {

            if (arr != null && arr.Length < elementCount)
            {
                Console.WriteLine("В массиве недостаточно места для хранения динамического массива");
                return arr;
            }

            else if (arr == null) arr = new T[elementCount];
            for (int i = 0; i < arr.Length; i++) arr[i] = elementData[i];
            return arr;
        }

        public void Add(int index, T element)
        {
            if ((index < 0) || (index > elementCount)) throw new ArgumentOutOfRangeException("index");
            if (elementCount == elementData.Length) Resize();
            for (int j = elementCount; j > index; j--) elementData[j] = elementData[j - 1];
            elementData[index] = element;
            elementCount++;
        }

        public void AddAll(int index, T[] arr)
        {
            T[] newArray = new T[elementCount + arr.Length];
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
            for (int i = index + arr.Length; i < elementCount + arr.Length; i++)
            {
                newArray[i] = elementData[k]; k++;
            }
            elementData = newArray;
            elementCount = newArray.Length;
        }

        public T Get(int index)
        {
            if ((index < 0) || (index > elementCount)) throw new ArgumentOutOfRangeException("index");
            else return elementData[index];
        }

        public int IndexOf(object obj)
        {
            for (int i = 0; i < elementCount; i++) if (obj.Equals(elementData[i])) return i;
            return -1;
        }

        public int LastIndexOf(object obj)
        {
            for (int i = elementCount - 1; i > 0; i--) if (obj.Equals(elementData[i])) return i;
            return -1;
        }

        public T Remove(int index)
        {
            if ((index < 0) || (index > elementCount)) throw new ArgumentOutOfRangeException("index");
            T element = elementData[index];
            Remove(element);
            return element;
        }

        public void Set(int index, T element)
        {
            if ((index < 0) || (index > elementCount)) throw new ArgumentOutOfRangeException("index");
            elementData[index] = element;
        }

        public T[] SubList(int fromIndex, int toIndex)
        {
            if ((fromIndex < 0) || (fromIndex > elementCount)) throw new ArgumentOutOfRangeException("fromIndex");
            if ((toIndex < 0) || (toIndex > elementCount)) throw new ArgumentOutOfRangeException("toIndex");
            int k = 0;
            T[] newArray = new T[toIndex - fromIndex];
            for (int i = fromIndex; i < toIndex; i++)
            {
                newArray[k] = elementData[i]; k++;
            }
            return newArray;
        }

        public T FirstElement()
        {
            return elementData[0];
        }

        public T LastElement()
        {
            return elementData[elementCount - 1];
        }

        public void RemoveElementAt(int pos)
        {
            Remove(pos);
        }

        public void RemoveRange(int begin, int end)
        {
            if ((begin < 0) || (begin >= elementCount)) throw new ArgumentOutOfRangeException("begin out of range");
            if ((end < 0) || (end >= elementCount)) throw new ArgumentOutOfRangeException("end out of range");
            T[] newArray = new T[elementCount - (end - begin)];
            int index = 0;
            for (int i = begin; i < end; i++)
            {
                newArray[index++] = elementData[i];
            }
            this.RemoveAll(newArray);
        }

        public void Print()
        {
            if (elementCount != 0) { for (int i = 0; i < elementCount; i++) Console.Write(elementData[i] + " "); }
            Console.WriteLine();
        }
    }

}
