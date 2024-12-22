using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_28
{
    public class MyStack<T> : MyVector<T>
    {
        private int currentIndex;

        public MyStack()
        {
            elementCount = 0; // Количество элементов в стеке
            currentIndex = -1; // Индекс текущего элемента
            capacityIncrement = 1; // Начальная емкость стека
            elementData = new T[capacityIncrement]; // Инициализация массива
        }

        

        public void Push(T item)
        {
            // Проверка на необходимость увеличения емкости
            if (currentIndex + 1 >= elementData.Length)
            {
                Array.Resize(ref elementData, elementData.Length + capacityIncrement);
            }
            currentIndex++;
            elementData[currentIndex] = item;
            elementCount++;
        }

        public T Pop()
        {
            if (Empty())
                throw new InvalidOperationException("Стек пуст");

            T result = elementData[currentIndex]; // Получаем верхний элемент
            currentIndex--;
            elementCount--;
            return result;
        }

        public T Peek()
        {
            if (Empty())
                throw new InvalidOperationException("Стек пуст");

            return elementData[currentIndex]; // Возвращаем верхний элемент без удаления
        }

        public bool Empty()
        {
            return elementCount == 0; // Проверка на пустоту
        }

        public int Search(T item)
        {
            for (int i = 0; i <= currentIndex; i++)
            {
                if (EqualityComparer<T>.Default.Equals(elementData[i], item))
                {
                    return i; // Возвращаем индекс первого найденного элемента
                }
            }
            return -1; // Если элемент не найден
        }

        public void Print()
        {
            for (int i = 0; i <= currentIndex; i++)
            {
                Console.Write($"{elementData[i]} ");
            }
            Console.WriteLine();
        }
    }
}
