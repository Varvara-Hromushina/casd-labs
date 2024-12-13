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

namespace task_22
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

       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            GraphPane pane = zedGraphControl1.GraphPane;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    MyHashMap<int, int> listHashMap = new MyHashMap<int, int>(10);
                    MyTreeMap<int, int> listTreeMap = new MyTreeMap<int, int>();
                    int size;
                    for (size = 10; size <= 1000; size *= 10)
                    {
                        double sum = 0;
                        double sum1 = 0;
                        for (int j = 0; j < 20; j++)
                        {

                            Stopwatch timer = new Stopwatch();
                            timer.Start();
                            for (int i = 1; i < size; i++) listHashMap.Put(i, i * 2);
                            timer.Stop();
                            sum += timer.ElapsedMilliseconds;

                            Stopwatch timer1 = new Stopwatch();
                            timer1.Start();
                            for (int i = 1; i < size; i++) listTreeMap.Put(i, i * 3);
                            timer1.Stop();
                            sum1 += timer1.ElapsedMilliseconds;
                        }
                        double rez = sum / 20; // 20 операций => делим на 20
                        double rez2 = sum1 / 20;
                        list1.Add(size, rez);
                        list2.Add(size, rez2);
                        listHashMap.Clear();
                        listTreeMap.Clear();
                    }
                    break;
                case 1:
                    listHashMap = new MyHashMap<int, int>(10);
                    listTreeMap = new MyTreeMap<int, int>();
                    for (size = 10; size <= 1000; size *= 10)
                    {
                        double sum = 0;
                        double sum1 = 0;
                        for (int j = 0; j < 20; j++)
                        {
                            for (int i = 1; i < size; i++) listHashMap.Put(i, i * 2);
                            for (int i = 1; i < size; i++) listTreeMap.Put(i, i * 3);

                            Random rand = new Random();
                            int w = rand.Next(0, size - 1);

                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            for (int i = 0; i < size; i++) listHashMap.Get(w);
                            stopwatch.Stop();
                            sum += stopwatch.ElapsedMilliseconds;

                            Stopwatch stopwatch1 = new Stopwatch();
                            stopwatch1.Start();
                            for (int i = 0; i < size; i++) listTreeMap.Get(w);
                            stopwatch1.Stop();
                            sum1 += stopwatch1.ElapsedMilliseconds;
                        }
                        double rez = sum / 20;
                        double rez2 = sum1 / 20;
                        list1.Add(size, rez);
                        list2.Add(size, rez2);
                        listHashMap.Clear();
                        listTreeMap.Clear();
                    }
                    break;


                case 2:
                    listHashMap = new MyHashMap<int, int>(10);
                    listTreeMap = new MyTreeMap<int, int>();
                    for (size = 10; size <= 1000; size *= 10)
                    {
                        double sum = 0;
                        double sum1 = 0;
                        for (int j = 0; j < 20; j++)
                        {
                            for (int i = 1; i < size; i++) listHashMap.Put(i, i * 2);
                            for (int i = 1; i < size; i++) listTreeMap.Put(i, i * 3);
                            Random rand = new Random();
                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            for (int i = 0; i < size; i++)
                            {
                                int index = rand.Next(0, size - 1); listHashMap.Remove(index);
                            }
                            stopwatch.Stop();
                            sum += stopwatch.ElapsedMilliseconds;

                            Stopwatch stopwatch1 = new Stopwatch();
                            stopwatch1.Start();
                            for (int i = 0; i < size; i++)
                            {
                                int index = rand.Next(0, size - 1); listTreeMap.Remove(index);
                            }
                            stopwatch1.Stop();
                            sum1 += stopwatch1.ElapsedMilliseconds;
                        }
                        double rez = sum / 20;
                        double rez2 = sum1 / 20;
                        list1.Add(size, rez);
                        list2.Add(size, rez2);
                        listHashMap.Clear();
                        listTreeMap.Clear();
                    }
                    break;
            }

            pane.CurveList.Clear();
            pane.AddCurve("MyHashMap", list1, Color.HotPink, SymbolType.None);
            ((LineItem)pane.CurveList[0]).Line.Width = 2.0f;

            pane.AddCurve("MyTreeMap", list2, Color.Purple, SymbolType.None);
            ((LineItem)pane.CurveList[1]).Line.Width = 2.0f;

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
    }
}
