using SortedSet;
namespace SortedSetTest
{
    public class UnitTest1
    {
        [Fact]
        public void AddTest()
        {
            TheSortedSet<int> set = new TheSortedSet<int>();
            for (int i = 0; i < 10; i++)
            {
                set.Add(i);
                Assert.True(set.Contains(i));
            }
            Assert.Equal(10, set.Count);
            Assert.False(set.Contains(10));
        }

        [Fact]
        public void AddRangeTest()
        {
            TheSortedSet<int> set = new TheSortedSet<int>();
            set.AddRange(new List<int> { 1, 2, 3, 4, 5 });
            Assert.Equal(5, set.Count);
            for (int i = 1; i <= 5; i++)
            {
                Assert.True(set.Contains(i));
            }
            Assert.Equal(5, set.Count);
            Assert.False(set.Contains(6));
        }

        [Fact]
        public void RemoveTest()
        {
            var set = new TheSortedSet<int>();
            set.AddRange(new List<int> { 1, 2, 3, 4, 5 });
            Assert.True(set.Remove(3));
            Assert.False(set.Contains(3));
            Assert.Equal(4, set.Count);
            Assert.False(set.Remove(6));
        }

        [Fact]
        public void CeilingTest()
        {
            var set = new TheSortedSet<int>();
            set.AddRange(new List<int> { 1, 2, 3, 5, 6 });
            int ceiling = set.Ceiling(4);
            Assert.Equal(5, ceiling);
            Assert.Equal(6, set.Ceiling(6));
        }
        [Fact]
        public void FloorTest()
        {
            var set = new TheSortedSet<int>();
            set.AddRange(new List<int> { 1, 2, 3, 5, 6 });
            int floor = set.Floor(4);
            Assert.Equal(3, floor);
        }

        [Fact]
        public void ClearTest()
        {
            var set = new TheSortedSet<int> { 1, 2, 3, 4, 5 };
            set.Clear();
            Assert.Equal(0, set.Count);
            Assert.False(set.Contains(1));
        }

        [Fact]
        public void IntersectTest()
        {
            var set = new TheSortedSet<int> { 1, 2, 3, 4, 5, 6 };
            var set2 = new TheSortedSet<int> { 4, 5, 6, 7, 8, 9 };
            var intersect = set.Intersection(set2);
            Assert.Equal(3, intersect.Count);
            Assert.True(intersect.Contains(4));
            Assert.True(intersect.Contains(5));
            Assert.True(intersect.Contains(6));
        }

        [Fact]
        public void UnionTest()
        {
            var set = new TheSortedSet<int> { 1, 2, 3, 4, 5, 6 };
            var set2 = new TheSortedSet<int> { 4, 5, 6, 7, 8, 9 };
            var union = set.Union(set2);
            Assert.Equal(9, union.Count);
            for (int i = 1; i <= 9; i++)
            {
                Assert.True(union.Contains(i));
            }
        }

        [Fact]
        public void MinMaxTest()
        {
            var set = new TheSortedSet<int> { 1, 2, 3, 4, 5 };
            Assert.Equal(1, set.Min());
            Assert.Equal(5, set.Max());
        }
    }
}
