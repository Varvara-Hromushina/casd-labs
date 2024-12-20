using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyTreeSet<int> myTreeSet = new MyTreeSet<int>();
            Console.WriteLine("Начальное множество:");
            for(int i = 1; i <= 5; i++)
            {
                myTreeSet.Add(i, i * 6);
            }
            myTreeSet.Print();
            Console.WriteLine();

            Console.WriteLine("Множество после удаления элемента с ключом 2:");
            myTreeSet.Remove(2);
            myTreeSet.Print();
            Console.WriteLine();

            Console.WriteLine("Значение первого элемента множества: " + myTreeSet.First()); 
            Console.WriteLine();

            Console.WriteLine("Наименьший элемент е, для которого истинно е >= 21: e = " + myTreeSet.Ceiling(21));
        }
    }
}
