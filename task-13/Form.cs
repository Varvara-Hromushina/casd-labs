using System;
using System.Collections.Generic;
using System.Linq;
using ZedGraph;

namespace KASDLab13
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            InitializeGraph();
        }

        private readonly string[, ] names =  { 
            { "сортировка пузырьком", "шейкерная сортировка", "ортировка вставками", "гномья сортировка", "сортировка выбором" }, 
            { "сортировка Шелла", "сортировка деревом", "битонная сортировка", "", "" },
            { "сортировка расчёской", "пирамидальная сортировка", "быстрая сортировка", "сортировка слиянием", "" } 
        };

        List<double[]> list;

        readonly System.Drawing.Color[] colors = new System.Drawing.Color[6] { System.Drawing.Color.Red, System.Drawing.Color.Olive, System.Drawing.Color.Purple, System.Drawing.Color.Green, System.Drawing.Color.Blue, System.Drawing.Color.Aqua };

        private void VisGraph(object sender, EventArgs e)
        {
            int iterations = 3;
            list = new List<double[]>();

            switch (ArrayTypeCombobox.SelectedIndex)
            {
                case 0:
                    switch (GroupCombobox.SelectedIndex)
                    {
                        case 0:
                            for (int index = 1; index <= iterations; index++)
                                list.Add(Speed.SpeedOfSortingInt((int)Math.Pow(10, index), Sorting<int>.BubbleSort, Sorting<int>.ShakerSort, Sorting<int>.InsertionSort, Sorting<int>.GnomeSort, Sorting<int>.SelectionSort));
                            break;
                        case 1:
                            for (int index = 1; index <= iterations; index++)
                                list.Add(Speed.SpeedOfSortingInt((int)Math.Pow(10, index), Sorting<int>.ShellSort, Sorting<int>.TreeSort, Sorting<int>.BitonicSort));
                            break;
                        case 2:
                            for (int index = 1; index <= iterations; index++)
                                list.Add(Speed.SpeedOfSortingInt((int)Math.Pow(10, index), Sorting<int>.CombSort, Sorting<int>.HeapSort, Sorting<int>.QuickSort, Sorting<int>.MergeSort));
                            break;
                    }
                    break;
                case 1:
                    switch (GroupCombobox.SelectedIndex)
                    {
                        case 0:
                            for (int index = 1; index <= iterations; index++)
                                list.Add(Speed.SpeedOfSortingDouble((int)Math.Pow(10, index), Sorting<double>.BubbleSort, Sorting<double>.ShakerSort, Sorting<double>.InsertionSort, Sorting<double>.GnomeSort, Sorting<double>.SelectionSort));
                            break;
                        case 1:
                            for (int index = 1; index <= iterations; index++)
                                list.Add(Speed.SpeedOfSortingDouble((int)Math.Pow(10, index), Sorting<double>.ShellSort, Sorting<double>.TreeSort, Sorting<double>.BitonicSort));
                            break;
                        case 2:
                            for (int index = 1; index <= iterations; index++)
                                list.Add(Speed.SpeedOfSortingDouble((int)Math.Pow(10, index), Sorting<double>.CombSort, Sorting<double>.HeapSort, Sorting<double>.QuickSort, Sorting<double>.MergeSort));
                            break;
                    }
                    break;
                case 2:
                    switch (GroupCombobox.SelectedIndex)
                    {
                        case 0:
                            for (int index = 1; index <= iterations; index++)
                                list.Add(Speed.SpeedOfSortingChar((int)Math.Pow(10, index), Sorting<char>.BubbleSort, Sorting<char>.ShakerSort, Sorting<char>.InsertionSort, Sorting<char>.GnomeSort, Sorting<char>.SelectionSort));
                            break;
                        case 1:
                            for (int index = 1; index <= iterations; index++)
                                list.Add(Speed.SpeedOfSortingChar((int)Math.Pow(10, index), Sorting<char>.ShellSort, Sorting<char>.TreeSort, Sorting<char>.BitonicSort));
                            break;
                        case 2:
                            for (int index = 1; index <= iterations; index++)
                                list.Add(Speed.SpeedOfSortingChar((int)Math.Pow(10, index), Sorting<char>.CombSort, Sorting<char>.HeapSort, Sorting<char>.QuickSort, Sorting<char>.MergeSort));
                            break;
                    }
                    break;
                case 3:
                    switch (GroupCombobox.SelectedIndex)
                    {
                        case 0:
                            for (int index = 1; index <= iterations; index++)
                                list.Add(Speed.SpeedOfSortingString((int)Math.Pow(10, index), Sorting<string>.BubbleSort, Sorting<string>.ShakerSort, Sorting<string>.InsertionSort, Sorting<string>.GnomeSort, Sorting<string>.SelectionSort));
                            break;
                        case 1:
                            for (int index = 1; index <= iterations; index++)
                                list.Add(Speed.SpeedOfSortingString((int)Math.Pow(10, index), Sorting<string>.ShellSort, Sorting<string>.TreeSort, Sorting<string>.BitonicSort));
                            break;
                        case 2:
                            for (int index = 1; index <= iterations; index++)
                                list.Add(Speed.SpeedOfSortingString((int)Math.Pow(10, index), Sorting<string>.CombSort, Sorting<string>.HeapSort, Sorting<string>.QuickSort, Sorting<string>.MergeSort));
                            break;
                    }
                    break;
            }

            PaintGraph(list);
        }

        private void PaintGraph(List<double[]> list)
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();

            int countOfSorts = list[0].Length;

            List<PointPairList> arrayOfLists = new List<PointPairList>();
            for (int index = 0; index < countOfSorts; index++)
            {
                arrayOfLists.Add(new PointPairList());
            }

            for (int i = 0; i < list.Count(); i++)
            {
                for (int index = 0; index < countOfSorts; index++)
                {
                    arrayOfLists[index].Add(Math.Pow(10, i + 1), list[i][index]);
                }
            }

            for (int index = 0; index < countOfSorts; index++)
            {
                pane.AddCurve(names[GroupCombobox.SelectedIndex, index], arrayOfLists[index], colors[index], SymbolType.None);
            }

            pane.XAxis.Scale.Max = Math.Pow(10, list.Count());

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void InitializeGraph()
        {
            zedGraphControl1.GraphPane.Title.Text = "ЗАВИСИМОСТЬ ВРЕМЕНИ ВЫПОЛНЕНИЯ ОТ РАЗМЕРА МАССИВА";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "РАЗМЕР МАССИВА, шт";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "ВРЕМЯ ВЫПОЛНЕНИЯ, мс";
        }
    }
}