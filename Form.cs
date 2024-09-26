using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using ZedGraph;

namespace KASDLab03
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            InitializeGraph();
        }

        int selectedArrayTypeIndex = -1;
        int selectedGroupIndex = -1;

        readonly static string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        readonly static string pathToTime = directory + @"\time.txt";
        readonly static string pathToResult = directory + @"\result.txt";

        string[] names;
        List<double[]> list;
        List<int[]> data = new List<int[]>();
        List<int[]> result = new List<int[]>();

        readonly System.Drawing.Color[] colors = new System.Drawing.Color[6] { System.Drawing.Color.Red, System.Drawing.Color.Olive, System.Drawing.Color.Purple, System.Drawing.Color.Green, System.Drawing.Color.Blue, System.Drawing.Color.Aqua };

        private void SelectArrayType(object sender, EventArgs e)
        {
            selectedArrayTypeIndex = ArrayTypeCombobox.SelectedIndex;
        }

        private void SelectGroup(object sender, EventArgs e)
        {
            selectedGroupIndex = GroupCombobox.SelectedIndex;
        }

        private double[] SpeedOfSorting(Func<int, int[]> Generate, int length, params Func<int[], int[]>[] SortMethods)
        {
            double[] sum = new double[SortMethods.Length];
            for (int i = 0; i < 20; i++)
            {
                int[] array = Generate(length);
                try
                {
                    int[] sortedArray = null;
                    int index = 0;
                    foreach (Func<int[], int[]> Method in SortMethods)
                    {
                        Stopwatch timer = new Stopwatch();
                        timer.Start();
                        sortedArray = Method((int[])array.Clone());
                        timer.Stop();
                        sum[index] += timer.ElapsedMilliseconds;
                        index++;
                    }
                    data.Add(array);
                    result.Add(sortedArray);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                };
            }

            return sum;
        }

        private void VisGraph(object sender, EventArgs e)
        {
            var arrayType = new Func<int, int[]>[] { Generate.Random, Generate.ArrayOfArrays, Generate.ArraySwap, n => Generate.ArrayRepeat(n, 50) };

            list = new List<double[]>();

            switch (selectedGroupIndex)
            {
                case 0:
                    names = new string[5] { "сортировка пузырьком", "шейкерная сортировка", "ортировка вставками", "гномья сортировка", "сортировка выбором" };
                    for (int index = 1; index <= 4; index++)
                        list.Add(SpeedOfSorting(arrayType[selectedArrayTypeIndex], (int)Math.Pow(10, index), Sorting.BubbleSort, Sorting.ShakerSort, Sorting.InsertionSort, Sorting.GnomeSort, Sorting.SelectionSort));
                    break;
                case 1:
                    names = new string[3] { "сортировка Шелла", "сортировка деревом", "битонная сортировка" };
                    for (int index = 1; index <= 4; index++)
                        list.Add(SpeedOfSorting(arrayType[selectedArrayTypeIndex], (int)Math.Pow(10, index), Sorting.ShellSort, Sorting.TreeSort, Sorting.BitonicSort));
                    break;
                case 2:
                    names = new string[6] { "сортировка расчёской", "пирамидальная сортировка", "быстрая сортировка", "сортировка слиянием", "сортировка подсчётом", "поразрядная сортировка" };
                    for (int index = 1; index <= 4; index++)
                        list.Add(SpeedOfSorting(arrayType[selectedArrayTypeIndex], (int)Math.Pow(10, index), Sorting.CombSort, Sorting.HeapSort, Sorting.QuickSort, Sorting.MergeSort, Sorting.CountingSort, Sorting.RadixSort));
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
                pane.AddCurve(names[index], arrayOfLists[index], colors[index], SymbolType.None);
            }

            pane.XAxis.Scale.Max = Math.Pow(10, list.Count());

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void Export(object sender, EventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter(pathToTime);
            list.ForEach(x => streamWriter.WriteLine(string.Join(" ", x)));
            streamWriter.Close();
            streamWriter = new StreamWriter(pathToResult);
            data.ForEach(x => {
                streamWriter.WriteLine("Array:");
                streamWriter.WriteLine(string.Join(" ", x));
            });
            result.ForEach(x => {
                streamWriter.WriteLine("Result:");
                streamWriter.WriteLine(string.Join(" ", x));
            });

            streamWriter.Close();
        }

        private void InitializeGraph()
        {
            zedGraphControl1.GraphPane.Title.Text = "ЗАВИСИМОСТЬ ВРЕМЕНИ ВЫПОЛНЕНИЯ ОТ РАЗМЕРА МАССИВА";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "РАЗМЕР МАССИВА, шт";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "ВРЕМЯ ВЫПОЛНЕНИЯ, мс";
        }
    }
}