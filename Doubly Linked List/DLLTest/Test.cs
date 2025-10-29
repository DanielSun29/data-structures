using Doubly_Linked_List;
using System.Globalization;
namespace DLLTest
{
    public class Test
    {

        [Fact]
        public void MathTest()
        {
            Assert.True(1 + 1 == 2);
        }

        [Theory]
        [InlineData(1)]
        public void MathTest2(int number)
        {
            Assert.InRange(number, 0, 2);
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 5)]
        public void AddFirstTest(params int[] arr)
        {
            Doubly_Linked_List.DoublyLinked<int> list = new DoublyLinked<int>();
            Assert.Null(list.Head);
            for (int i = 0; i < arr.Length; i++)
            {
                list.AddFirst(arr[i]);
                Assert.Equal(arr[i], list.Head.Value);
            }
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 5)]
        [InlineData(7)]
        public void AddBeforeTest(params int[] arr)
        {
            int number = 7;
            Doubly_Linked_List.DoublyLinked<int> list = new DoublyLinked<int>();
            Assert.Null(list.Head);
            for (int i = 0; i < arr.Length; i++)
            {
                list.AddFirst(arr[i]);
            }
            list.AddBefore(list.Head.Next, number);
            Assert.Equal(list.Head.Next.Value, number);
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 5)]
        public void AddLastTest(params int[] arr)
        {
            int number = 7;
            Doubly_Linked_List.DoublyLinked<int> list = new DoublyLinked<int>();
            Assert.Null(list.Head);
            for (int i = 0; i < arr.Length; i++)
            {
                list.AddFirst(arr[i]);
            }
            list.AddLast(number);
            Assert.Equal(list.Head.Previous.Value, number);
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 5)]
        [InlineData(2,3,4,5,6,7,8,9,0,1,2,3,4,5)]
        [InlineData(7)]
        
        public void AddAfterTest(params int[] arr)
        {
            int number = 7;
            Doubly_Linked_List.DoublyLinked<int> list = new DoublyLinked<int>();
            Assert.Null(list.Head);
            list.AddFirst(0);
            for (int i = 0; i < arr.Length; i++)
            {
                var curr = list.Head;
                list.AddAfter(curr,arr[i]);
                Assert.Equal(curr.Next.Value, arr[i]);
                curr = curr.Next;
            }
            list.AddAfter(list.Head.Next, number);
            Assert.Equal(list.Head.Next.Next.Value, number);
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 5)]
        [InlineData(7)]
        public void RemoveFirstTest(params int[] arr)
        {
            Doubly_Linked_List.DoublyLinked<int> list = new DoublyLinked<int>();
            Assert.Null(list.Head);
            for (int i = 0; i < arr.Length; i++)
            {
                list.AddFirst(arr[i]);
            }
            Node<int> temp = list.Head.Next;
            list.RemoveFirst();
            Assert.Equal(list.Head, temp);
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 5)]
        [InlineData(7)]
        public void RemoveLastTest(params int[] arr)
        {
            Doubly_Linked_List.DoublyLinked<int> list = new DoublyLinked<int>();
            Assert.Null(list.Head);
            for (int i = 0; i < arr.Length; i++)
            {
                list.AddFirst(arr[i]);
            }
            Node<int> temp = list.Head.Previous.Previous;
            list.RemoveLast();
            Assert.Equal(list.Head.Previous, temp);
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 5)]
        [InlineData(2)]
        public void RemoveTest(params int[] arr)
        {
            int number = 2;
            Doubly_Linked_List.DoublyLinked<int> list = new DoublyLinked<int>();
            Assert.Null(list.Head);
            for (int i = 0; i < arr.Length; i++)
            {
                list.AddLast(arr[i]);
            }
            Node<int> temp = list.Head.Next.Next;
            list.Remove(number);
            Assert.Equal(list.Head.Next, temp);
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 5)]
        [InlineData(2)]
        public void ClearTest(params int[] arr)
        {
            Doubly_Linked_List.DoublyLinked<int> list = new DoublyLinked<int>();
            Assert.Null(list.Head);
            for (int i = 0; i < arr.Length; i++)
            {
                list.AddLast(arr[i]);
            }
            list.Clear();
            Assert.Null(list.Head);
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 5)]
        [InlineData(2)]
        public void SearchTest(params int[] arr)
        {
            int number = 2;
            Doubly_Linked_List.DoublyLinked<int> list = new DoublyLinked<int>();
            Assert.Null(list.Head);
            for (int i = 0; i < arr.Length; i++)
            {
                list.AddLast(arr[i]);
            }
            Node<int> temp = list.Search(number);
            Assert.Equal(list.Head.Next, temp);
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 5)]
        [InlineData(2)]
        public void ContainsTest(params int[] arr)
        {
            int number = 2;
            Doubly_Linked_List.DoublyLinked<int> list = new DoublyLinked<int>();
            Assert.Null(list.Head);
            for (int i = 0; i < arr.Length; i++)
            {
                list.AddLast(arr[i]);
            }
            Node<int> temp = list.Search(number);
            Assert.True(list.Contains(number) && list.Contains(temp) && temp.Value.Equals(number));
        }
    }
}