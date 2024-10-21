using System.ComponentModel;
using System.Runtime.InteropServices;

class MyStack<T> : MyVector<T>
{
    private int currentIndex;
    public MyStack()
    {
        elementCount++; 
        currentIndex = elementCount;      
        elementData = new T[elementCount]; 
        capacityIncrement = 0;
    }
    
     public void Push(T item)
    {
        Add(currentIndex, item); 
    }

    public void Pop()
    {
        Remove(currentIndex);
        elementCount--;
    }

    public T Peek()
    {
        if(elementCount == 0) throw new Exception("Стек пуст");
        else return Get(currentIndex);
    }

    public bool Empty()
    {
        return Size() == 0;
    }

    public int Search(T item)
    {
        if(IndexOf(item) == -1) return -1;
        else return IndexOf(item);
    }

    public void Print()
    {
        for(int i = currentIndex; i <= elementCount; i++) {Console.Write($"{Get(i)} ");}
        Console.WriteLine();
    }

}

class Program
{
    static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            Console.WriteLine("Стек: ");
            stack.Print();

            stack.Pop();
            Console.WriteLine("Стек после извлечения верхнего элемента из стека: ");
            stack.Print();

            Console.WriteLine("Возвращение верхнего элемента стека без его извлечения: ");
            Console.WriteLine(stack.Peek());

            Console.WriteLine("Проверка стека на пустоту: ");
            Console.WriteLine(stack.Empty());

            Console.WriteLine("Поиск «глубины» объекта в стеке: ");
            Console.WriteLine(stack.Search(3));

        }
}
