using System;
using System.Linq;

public static class Sorting
{
    public static int[] BubbleSort(int[] array)
    {
        int varStorage;
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    varStorage = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = varStorage;
                }
            }
        }
        return array;
    }

    public static int[] ShakerSort(int[] array)
    {
        for (var i = 0; i < array.Length / 2; i++)
        {
            var noSwap = true;
            //проход слева направо
            for (var j = i; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    (array[j + 1], array[j]) = (array[j], array[j + 1]);
                    noSwap = false;
                }
            }
            //проход справа налево
            for (var j = array.Length - 2 - i; j > i; j--)
            {
                if (array[j - 1] > array[j])
                {
                    (array[j], array[j - 1]) = (array[j - 1], array[j]);
                    noSwap = false;
                }
            }
            //если обменов не было выходим
            if (noSwap) break;
        }
        return array;
    }

    public static int[] CombSort(int[] array)
    {
        int varStorage;
        var arrayLength = array.Length;
        var currentStep = arrayLength - 1;

        while (currentStep > 1)
        {
            for (int i = 0; i + currentStep < array.Length; i++)
            {
                if (array[i] > array[i + currentStep])
                {
                    varStorage = array[i];
                    array[i] = array[i + currentStep];
                    array[i + currentStep] = varStorage;
                }
            }

            currentStep = GetNextStep(currentStep);
        }

        //сортировка пузырьком
        for (var i = 1; i < arrayLength; i++)
        {
            var noSwap = true;
            for (var j = 0; j < arrayLength - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    varStorage = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = varStorage;
                    noSwap = false;
                }
            }

            if (noSwap) break;
        }
        return array;
    }
    static int GetNextStep(int s)
    {
        s = s * 1000 / 1247;
        return s > 1 ? s : 1;
    }

    public static int[] InsertionSort(int[] array)
    {
        for (var i = 1; i < array.Length; i++)
        {
            var key = array[i];
            var j = i;
            while ((j > 1) && (array[j - 1] > key))
            {
                (array[j], array[j - 1]) = (array[j - 1], array[j]);
                j--;
            }
            array[j] = key;
        }
        return array;
    }

    public static int[] ShellSort(int[] array)
    {
        //расстояние между элементами, которые сравниваются
        var d = array.Length / 2;
        while (d >= 1)
        {
            for (var i = d; i < array.Length; i++)
            {
                var j = i;
                while ((j >= d) && (array[j - d] > array[j]))
                {
                    (array[j - d], array[j]) = (array[j], array[j - d]);
                    j -= d;
                }
            }

            d /= 2;
        }
        return array;
    }

    public static int[] TreeSort(int[] array)
    {
        var treeNode = new TreeNode(array[0]);
        for (int i = 1; i < array.Length; i++)
        {
            treeNode.Insert(new TreeNode(array[i]));
        }

        return treeNode.Transform();
    }

    public static int[] GnomeSort(int[] array)
    {
        var index = 1;
        var nextIndex = index + 1;

        while (index < array.Length)
        {
            if (array[index - 1] < array[index])
            {
                index = nextIndex;
                nextIndex++;
            }
            else
            {
                (array[index], array[index - 1]) = (array[index - 1], array[index]);
                index--;
                if (index == 0)
                {
                    index = nextIndex;
                    nextIndex++;
                }
            }
        }
        return array;
    }

    public static int[] SelectionSort(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int extremum = array[i];
            int indexOfExtremum = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] > extremum || array[j] < extremum)
                {
                    indexOfExtremum = j;
                    extremum = array[j];
                }
            }

            array[indexOfExtremum] = array[i];
            array[i] = extremum;
        }

        return array;
    }

    public static int[] HeapSort(int[] array)
    {
        int N = array.Length;
        for (int i = N / 2 - 1; i >= 0; i--)
            Heapify(array, N, i);
        for (int i = N - 1; i > 0; i--)
        {
            (array[i], array[0]) = (array[0], array[i]);
            Heapify(array, i, 0);
        }
        return array;
    }
    static void Heapify(int[] array, int N, int i)
    {
        int largest = i;
        int l = 2 * i + 1;
        int r = 2 * i + 2;
        if (l < N && array[l] > array[largest])
            largest = l;
        if (r < N && array[r] > array[largest])
            largest = r;
        if (largest != i)
        {
            (array[largest], array[i]) = (array[i], array[largest]);
            Heapify(array, N, largest);
        }
    }

    public static void QuickSort(int[] array, int left, int right)
    {
        while (left < right)
        {
            int pivotIndex = Partition(array, left, right);

            if (pivotIndex - left < right - pivotIndex)
            {
                QuickSort(array, left, pivotIndex - 1);
                left = pivotIndex + 1;
            }
            else
            {
                QuickSort(array, pivotIndex + 1, right);
                right = pivotIndex - 1;
            }
        }
    }
    public static int[] QuickSort(int[] array)
    {
        QuickSort(array, 0, array.Length - 1);
        return array;
    }
    static int Partition(int[] array, int left, int right)
    {
        int pivot = array[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (array[j] <= pivot)
            {
                i++;
                (array[j], array[i]) = (array[i], array[j]);
            }
        }

        (array[right], array[i + 1]) = (array[i + 1], array[right]);
        return i + 1;
    }


    static void Merge(int[] array, int l, int m, int r)
    {
        int n1 = m - l + 1;
        int n2 = r - m;
        int[] L = new int[n1];
        int[] R = new int[n2];
        int i, j;
        for (i = 0; i < n1; ++i)
            L[i] = array[l + i];
        for (j = 0; j < n2; ++j)
            R[j] = array[m + 1 + j];
        i = 0;
        j = 0;
        int k = l;
        while (i < n1 && j < n2)
        {
            if (L[i] <= R[j])
            {
                array[k] = L[i];
                i++;
            }
            else
            {
                array[k] = R[j];
                j++;
            }
            k++;
        }
        while (i < n1)
        {
            array[k] = L[i];
            i++;
            k++;
        }
        while (j < n2)
        {
            array[k] = R[j];
            j++;
            k++;
        }
    }
    public static void MergeSort(int[] array, int l, int r)
    {
        if (l < r)
        {
            int m = l + (r - l) / 2;
            MergeSort(array, l, m);
            MergeSort(array, m + 1, r);
            Merge(array, l, m, r);
        }
    }
    public static int[] MergeSort(int[] array)
    {
        MergeSort(array, 0, array.Length - 1);
        return array;
    }

    static int FindMaxValue(int[] arr)
    {
        int maxValue = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > maxValue)
            {
                maxValue = arr[i];
            }
        }
        return maxValue;
    }
    static int FindMinValue(int[] arr)
    {
        int minValue = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < minValue)
            {
                minValue = arr[i];
            }
        }
        return minValue;
    }
    public static int[] CountingSort(int[] array)
    {

        int max = FindMaxValue(array);
        int min = FindMinValue(array);

        int range = max - min + 1;
        var count = new int[range];

        for (var i = 0; i < array.Length; i++) count[array[i] - min]++;

        var index = 0;
        for (var i = 0; i < count.Length; i++)
        {
            for (var j = 0; j < count[i]; j++)
            {
                array[index] = i + min;
                index++;
            }
        }
        return array;
    }

    public static int[] RadixSort(int[] array)
    {
        int i, j;
        int[] tempArray = new int[array.Length];
        for (int shift = 31; shift > -1; --shift)
        {
            j = 0;
            for (i = 0; i < array.Length; ++i)
            {
                bool move = (array[i] << shift) >= 0;
                if (shift == 0 ? !move : move)
                    array[i - j] = array[i];
                else
                    tempArray[j++] = array[i];
            }
            Array.Copy(tempArray, 0, array, array.Length - j, j);
        }
        return array;
    }

    static void BitSeqSort(int[] array, int left, int right, bool inv)
    {
        if (right - left <= 1) return;
        int mid = left + (right - left) / 2;

        for (int i = left, j = mid; i < mid && j < right; i++, j++)
        {
            if (inv ^ (array[i] > array[j]))
            {
                (array[j], array[i]) = (array[i], array[j]);
            }
        }

        BitSeqSort(array, left, mid, inv);
        BitSeqSort(array, mid, right, inv);
    }
    static void MakeBitonic(int[] arr, int left, int right)
    {
        if (right - left <= 1) return;
        int mid = left + (right - left) / 2;

        MakeBitonic(arr, left, mid);
        BitSeqSort(arr, left, mid, false);
        MakeBitonic(arr, mid, right);
        BitSeqSort(arr, mid, right, true);
    }
    public static int[] BitonicSort(int[] array)
    {
        int n = 1;
        int inf = array.Max() + 1;
        int length = array.Length;

        while (n < length) n *= 2;

        int[] temp = new int[n];
        Array.Copy(array, temp, length);

        for (int i = length; i < n; i++)
        {
            temp[i] = inf;
        }

        MakeBitonic(temp, 0, n);
        BitSeqSort(temp, 0, n, false);

        Array.Copy(temp, array, length);
        return array;
    }
}
