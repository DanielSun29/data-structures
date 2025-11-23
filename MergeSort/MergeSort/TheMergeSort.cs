namespace MergeSort
{
    public class TheMergeSort<T> where T : IComparable<T>
    {

        public static List<T> Sort(List<T> list)
        {
            //This is the only function with recursion, the other 2 are helper functions
            if (list.Count <= 1)
            {
                return list;
            }

            (List<T> Left, List<T> Right) result = Split(list);
            result.Left = Sort(result.Left);
            result.Right = Sort(result.Right);
            return Merge(result.Left, result.Right);
        }

        public static List<T> Merge(List<T> left, List<T> right)
        {
            List<T> result = new List<T>();
            int j = 0;
            for (int i = 0; i < right.Count; i++)
            {
                while (j < left.Count && left[j].CompareTo(right[i]) < 0)
                {
                    result.Add(left[j]);
                    j++;
                }
                result.Add(right[i]);
            }
            while (j < left.Count)
            {
                result.Add(left[j]);
                j++;
            }
            return result;
        }

        public static (List<T> Left, List<T> Right) Split(List<T> list)
        {
            // Right is >= left
            var left = new List<T>();
            var right = new List<T>();
            for (int i = 0; i < list.Count; i++)
            {
                if(i<list.Count/2)
                {
                    left.Add(list[i]);
                }
                else
                {
                    right.Add(list[i]);
                }
            }
            //if (list.Count % 2 == 0)
            //{
            //    for (int i = 0; i < list.Count / 2; i++)
            //    {
            //        left.Add(list[i]);
            //        right.Add(list[i + (list.Count / 2)]);
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < 1 + (list.Count / 2); i++)
            //    {
            //        left.Add(list[i]);
            //        if (list[i + (list.Count / 2)] == null)
            //        {
            //            break;
            //        }
            //        right.Add(list[i + (list.Count / 2)]);
            //    }
            //}
            return (left, right);
        }
    }
}