namespace QuickSort
{
    public class TheQuickSort <T> where T : IComparable<T>
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
            if (end - start < 1)
            {
                return;
            }
            int left = start - 1;
            int right = end + 1;
            var pivot = arr[start];
            while (left < right)
            {
                do
                {
                    left++;
                } while (arr[left].CompareTo(pivot) < 0 && left < right);

                do
                {
                    right--;
                } while (arr[right].CompareTo(pivot) > 0 && left < right);
                if (left < right)
                {
                    Swap(arr, left, right);
                }
            }
            HoareSort(arr, start, right);
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
