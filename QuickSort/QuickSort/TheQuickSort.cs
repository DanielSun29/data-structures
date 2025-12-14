namespace QuickSort
{
    public class TheQuickSort<T> where T : IComparable<T>
    {
        public static void LomutoSort(T[] arr, int start, int end) // end is inclusive
        {
            if (end - start < 1)
            {
                return;
            }

            var pivot = arr[end];
            int wall = start;
            int curr = start;
            while (curr < end)
            {
                if (wall >= arr.Length)
                {
                    return;
                }
                if (arr[curr].CompareTo(pivot) < 0)
                {
                    Swap(arr, curr, wall);
                    wall++;
                    curr++;
                }
                else
                {
                    curr++;
                }
            }

            Swap(arr, end, wall);

            LomutoSort(arr, start, wall - 1);
            LomutoSort(arr, wall + 1, end);
        }

        public static void HoareSort(T[] arr, int start, int end)
        {
            if (end - start <= 1)
            {
                return;
            }
            int left = start;
            int right = end;
            var pivot = arr[start];
            //while (left < right)
            //{
            //    while (arr[left].CompareTo(pivot) < 0 && left < right)
            //    {
            //        left++;
            //    }

            //    while (arr[right].CompareTo(pivot) > 0 && left < right)
            //    {
            //        right--;
            //    }

            //    if (left < right)
            //    {
            //        Swap(arr, left, right);
            //        left++;
            //    }
            //}
            //if (right == end)
            //{
            //    HoareSort(arr, start, right - 1);
            //}
            //else
            //{
            //    HoareSort(arr, start, right);
            //}
            //HoareSort(arr, right + 1, end);
            //// The problem here to fix is that, if we don't increase left, its gonna be forever stuck when encountering multiple same values, 
            //// if we do increase left, there is a probability to skip thru data that still needs to be sorted. Same with decreasing right.
            //// This problem is not solved yet, and for now the commented out code is the same as the code that are not(cuz i dont know what to do yet)
            while (left < right)
            {
                while (arr[left].CompareTo(pivot) < 0 && left < right)
                {
                    left++;
                }

                while (arr[right].CompareTo(pivot) > 0 && left < right)
                {
                    right--;
                }

                if (left < right)
                {
                    Swap(arr, left, right);
                    left++;
                }
            }
            if (right == end)
            {
                HoareSort(arr, start, right - 1);
            }
            else
            {
                HoareSort(arr, start, right);
            }
            HoareSort(arr, right + 1, end);
        }

        private static void Swap(T[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
