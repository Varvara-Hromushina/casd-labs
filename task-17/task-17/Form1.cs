using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using ZedGraph;

namespace task_17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeGraph();
        }


        private void InitializeGraph()
        {
            zedGraphControl1.GraphPane.Title.Text = "Зависимость времени от количества элементов в массиве";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "Размер массива, шт";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Время выполнения, мс";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            GraphPane pane = zedGraphControl1.GraphPane; 
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    MyArrayList<int> list = new MyArrayList<int>(10);
                    MyLinkedList<int> linkedlist = new MyLinkedList<int>();
                    int size;
                    for (size = 100; size <= 100000; size *= 10)
                    {
                        double sum = 0;
                        double sum1 = 0;
                        for (int j = 0; j < 20; j++)
                        {
                            Stopwatch timer = new Stopwatch();
                            timer.Start();
                            for (int i = 0; i < size; i++) list.Add(i);
                            timer.Stop();
                            sum += timer.ElapsedMilliseconds;

                            Stopwatch timer1= new Stopwatch();
                            timer1.Start();
                            for (int i = 0; i < size; i++) linkedlist.Add(i);
                            timer1.Stop();
                            sum1 += timer1.ElapsedMilliseconds;
                        }
                        double rez = sum / 20; // 20 операций => делим на 20
                        double rez2= sum1 / 20;
                        list1.Add(size, rez);
                        list2.Add(size, rez2);
                        list.Clear();
                        linkedlist.Clear();
                    }
                    break;
                case 1:
                    list = new MyArrayList<int>(10);
                    linkedlist = new MyLinkedList<int>();
                    for (size = 100; size <= 1000; size *= 10)
                    {
                        double sum = 0;
                        double sum1 = 0;
                        for (int j = 0; j < 20; j++)
                        {
                            for (int i = 0; i < size; i++) list.Add(i);
                            for (int i = 0; i < size; i++) linkedlist.Add(i);

                            Random rand = new Random();
                            int w = rand.Next(0, size - 1);

                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            for (int i = 0; i < size; i++)
                            {
                                int index = rand.Next(0, list.Size() - 1);
                                int number = rand.Next(0, 100000); list.Add(index, number);
                            }
                            stopwatch.Stop();
                            sum += stopwatch.ElapsedMilliseconds;

                            Stopwatch stopwatch1 = new Stopwatch();
                            stopwatch1.Start();
                            for (int i = 0; i < size; i++)
                            {
                                int index = rand.Next(0, linkedlist.Size() - 1);
                                int number = rand.Next(0, 100000); linkedlist.Set(index, number);
                            }
                            stopwatch1.Stop();
                            sum1 += stopwatch1.ElapsedMilliseconds;
                        }
                        double rez = sum / 20;
                        double rez2 = sum1 / 20;
                        list1.Add(size, rez);
                        list2.Add(size, rez2);
                        list.Clear();
                        linkedlist.Clear();
                    }
                    break;
                case 2:
                    list = new MyArrayList<int>(10);
                    linkedlist = new MyLinkedList<int>();
                    for (size = 100; size <= 1000; size *= 10)
                    {
                        double sum = 0;
                        double sum1 = 0;
                        for (int j = 0; j < 20; j++)
                        {
                            for (int i = 0; i < size; i++) list.Add(i);
                            for (int i = 0; i < size; i++) linkedlist.Add(i);

                            Random rand = new Random();
                            int w=rand.Next(0,size-1);

                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            for(int i=0;i<size;i++) list.Get(w);
                            stopwatch.Stop();
                            sum += stopwatch.ElapsedMilliseconds;

                            Stopwatch stopwatch1 = new Stopwatch();
                            stopwatch1.Start();
                            for(int i=0;i<size;i++) linkedlist.Get(w);
                            stopwatch1.Stop();
                            sum1 += stopwatch1.ElapsedMilliseconds;
                        }
                        double rez = sum / 20;
                        double rez2 = sum1 / 20;
                        list1.Add(size, rez);
                        list2.Add(size, rez2);
                        list.Clear();
                        linkedlist.Clear();
                    }
                        break;
                    
                case 3:
                    

                    list = new MyArrayList<int>(10);
                    linkedlist = new MyLinkedList<int>();
                    for (size = 100; size <= 1000; size *= 10)
                    {
                        double sum = 0;
                        double sum1 = 0;
                        for (int j = 0; j < 20; j++)
                        {
                            for (int i = 0; i < size; i++) list.Add(i);
                            for (int i = 0; i < size; i++) linkedlist.Add(i);

                            Random random = new Random();
                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            for (int i = 0; i < size; i++)
                            {
                                int index = random.Next(0, list.Size() - 1);
                                int number = random.Next(0, 100000); list.Set(index, number);
                            }
                            stopwatch.Stop();
                            sum += stopwatch.ElapsedMilliseconds;

                            Stopwatch stopwatch1 = new Stopwatch();
                            stopwatch1.Start();
                            for (int i = 0; i < size; i++) {
                                int index = random.Next(0, linkedlist.Size() - 1);
                                int number = random.Next(0, 100000); linkedlist.Set(index, number);
                            }
                            stopwatch1.Stop();
                            sum1 += stopwatch1.ElapsedMilliseconds;
                        }
                        double rez = sum / 20;
                        double rez2 = sum1 / 20;
                        list1.Add(size, rez);
                        list2.Add(size, rez2);
                        list.Clear();
                        linkedlist.Clear();
                    }
                    break;

                   
                case 4:
                    list = new MyArrayList<int>(10);
                    linkedlist = new MyLinkedList<int>();
                    for (size = 100; size <= 10000; size *= 10)
                    {
                        double sum = 0;
                        double sum1 = 0;
                        for (int j = 0; j < 20; j++)
                        {
                            for (int i = 0; i < size; i++) list.Add(i);
                            for (int i = 0; i < size; i++) linkedlist.Add(i);

                            Random rand = new Random();
                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            for (int i = 0; i < size; i++)
                            {
                                int index = rand.Next(0, list.Size() - 1); list.Remove(index);
                            }
                            stopwatch.Stop();
                            sum += stopwatch.ElapsedMilliseconds;

                            Stopwatch stopwatch1 = new Stopwatch();
                            stopwatch1.Start();
                            for (int i = 0; i < size; i++)
                            {
                                int index = rand.Next(0, linkedlist.Size()-1); linkedlist.Remove(index);
                            }
                            stopwatch1.Stop();
                            sum1 += stopwatch1.ElapsedMilliseconds;
                        }
                        double rez = sum / 20;
                        double rez2 = sum1 / 20;
                        list1.Add(size, rez);
                        list2.Add(size, rez2);
                        list.Clear();
                        linkedlist.Clear();
                    }
                    break;
            }
            pane.CurveList.Clear();
            pane.AddCurve("MyArrayList", list1, Color.HotPink, SymbolType.None);
            ((LineItem)pane.CurveList[0]).Line.Width = 2.0f;

            pane.AddCurve("MyLinkedList", list2, Color.Purple, SymbolType.None);
            ((LineItem)pane.CurveList[1]).Line.Width = 2.0f;

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
