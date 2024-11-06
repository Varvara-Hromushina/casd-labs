using System;

public static class Sorting<T> where T : IComparable<T>
{
    public static T[] BubbleSort(T[] array)
    {
        T varStorage;
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (array[j].CompareTo(array[j + 1]) > 0)
                {
                    varStorage = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = varStorage;
                }
            }
        }
        return array;
    }

    public static T[] ShakerSort(T[] array)
    {
        for (int i = 0; i < array.Length / 2; i++)
        {
            bool noSwap = true;
            //проход слева направо
            for (int j = i; j < array.Length - i - 1; j++)
            {
                if (array[j].CompareTo(array[j + 1]) > 0)
                {
                    (array[j + 1], array[j]) = (array[j], array[j + 1]);
                    noSwap = false;
                }
            }
            //проход справа налево
            for (int j = array.Length - 2 - i; j > i; j--)
            {
                if (array[j - 1].CompareTo(array[j]) > 0)
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

    public static T[] CombSort(T[] array)
    {
        T varStorage;
        int arrayLength = array.Length;
        int currentStep = arrayLength - 1;

        while (currentStep > 1)
        {
            for (int i = 0; i + currentStep < array.Length; i++)
            {
                if (array[i].CompareTo(array[i + currentStep]) > 0)
                {
                    varStorage = array[i];
                    array[i] = array[i + currentStep];
                    array[i + currentStep] = varStorage;
                }
            }

            currentStep = GetNextStep(currentStep);
        }

        //сортировка пузырьком
        for (int i = 1; i < arrayLength; i++)
        {
            bool noSwap = true;
            for (int j = 0; j < arrayLength - i; j++)
            {
                if (array[j].CompareTo(array[j + 1]) > 0)
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
    private static int GetNextStep(int s)
    {
        s = s * 1000 / 1247;
        return s > 1 ? s : 1;
    }

    public static T[] InsertionSort(T[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            T key = array[i];
            int j = i;

            while ((j > 1) && (array[j - 1].CompareTo(key) > 0))
            {
                (array[j], array[j - 1]) = (array[j - 1], array[j]);
                j--;
            }
            array[j] = key;
        }
        return array;
    }

    public static T[] ShellSort(T[] array)
    {
        //расстояние между элементами, которые сравниваются
        int d = array.Length / 2;
        while (d >= 1)
        {
            for (int i = d; i < array.Length; i++)
            {
                int j = i;
                while ((j >= d) && (array[j - d].CompareTo(array[j]) > 0))
                {
                    (array[j - d], array[j]) = (array[j], array[j - d]);
                    j -= d;
                }
            }

            d /= 2;
        }
        return array;
    }

    public static T[] TreeSort(T[] array)
    {
        TreeNode<T> treeNode = new TreeNode<T>(array[0]);
        for (int i = 1; i < array.Length; i++)
        {
            treeNode.Insert(new TreeNode<T>(array[i]));
        }

        return treeNode.Transform();
    }

    public static T[] GnomeSort(T[] array)
    {
        int index = 1;
        int nextIndex = index + 1;

        while (index < array.Length)
        {
            if (array[index].CompareTo(array[index - 1]) > 0)
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

    public static T[] SelectionSort(T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            T extremum = array[i];
            int indexOfExtremum = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if ((array[j].CompareTo(extremum) > 0) || extremum.CompareTo(array[j]) > 0)
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

    public static T[] HeapSort(T[] array)
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
    private static void Heapify(T[] array, int N, int i)
    {
        int largest = i;
        int l = 2 * i + 1;
        int r = 2 * i + 2;
        if (l < N && array[l].CompareTo(array[largest]) > 0)
            largest = l;
        if (r < N && array[r].CompareTo(array[largest]) > 0)
            largest = r;
        if (largest != i)
        {
            (array[largest], array[i]) = (array[i], array[largest]);
            Heapify(array, N, largest);
        }
    }

    private static int Partition(T[] array, int left, int right)
    {
        T pivot = array[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (pivot.CompareTo(array[j]) >= 0)
            {
                i++;
                (array[j], array[i]) = (array[i], array[j]);
            }
        }

        (array[right], array[i + 1]) = (array[i + 1], array[right]);
        return i + 1;
    }
    private static void QuickSortRecursive(T[] array, int left, int right)
    {
        while (left < right)
        {
            int pivotIndex = Partition(array, left, right);

            if (pivotIndex - left < right - pivotIndex)
            {
                QuickSortRecursive(array, left, pivotIndex - 1);
                left = pivotIndex + 1;
            }
            else
            {
                QuickSortRecursive(array, pivotIndex + 1, right);
                right = pivotIndex - 1;
            }
        }
    }

    public static T[] QuickSort(T[] array)
    {
        QuickSortRecursive(array, 0, array.Length - 1);
        return array;
    }

    private static void Merge(T[] array, int l, int m, int r)
    {
        int n1 = m - l + 1;
        int n2 = r - m;
        T[] L = new T[n1];
        T[] R = new T[n2];
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
            if (R[j].CompareTo(L[i]) >= 0)
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
    private static void MergeSortRecursive(T[] array, int l, int r)
    {
        if (l < r)
        {
            int m = l + (r - l) / 2;
            MergeSortRecursive(array, l, m);
            MergeSortRecursive(array, m + 1, r);
            Merge(array, l, m, r);
        }
    }
    public static T[] MergeSort(T[] array)
    {
        MergeSortRecursive(array, 0, array.Length - 1);
        return array;
    }

    private static void BitSeqSortRecursive(T[] array, int left, int right, bool inv)
    {
        if (right - left <= 1) return;
        int mid = left + (right - left) / 2;

        for (int i = left, j = mid; i < mid && j < right; i++, j++)
        {
            if (inv ^ (array[i]?.CompareTo(array[j]) >= 0))
            {
                (array[j], array[i]) = (array[i], array[j]);
            }
        }

        BitSeqSortRecursive(array, left, mid, inv);
        BitSeqSortRecursive(array, mid, right, inv);
    }
    private static void MakeBitonic(T[] arr, int left, int right)
    {
        if (right - left <= 1) return;
        int mid = left + (right - left) / 2;

        MakeBitonic(arr, left, mid);
        BitSeqSortRecursive(arr, left, mid, false);
        MakeBitonic(arr, mid, right);
        BitSeqSortRecursive(arr, mid, right, true);
    }
    public static T[] BitonicSort(T[] array)
    {
        int n = 1;
        int length = array.Length;

        while (n < length) n *= 2;

        T[] temp = new T[n];
        Array.Copy(array, temp, length);

        for (int i = length; i < n; i++)
        {
            temp[i] = default;
        }

        MakeBitonic(temp, 0, n);
        BitSeqSortRecursive(temp, 0, n, false);

        Array.ConstrainedCopy(temp, n - length, array, 0, length);
        return array;
    }
}
