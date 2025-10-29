using Stacks_and_Queues;

namespace Test1
{
    public class ABStackTest
    {
        [Fact]
       
        public void PushTest()
        {
            ABStack<int> testStack = new ABStack<int>(10);
            testStack.Push(1);
            Assert.Equal(1, testStack.Peek());
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 5)]
        public void PopTest(params int[] arr)
        {
            Stack<int> refStack = new Stack<int>(10);
            ABStack<int> testStack = new ABStack<int>(10);
            for (int i = 0; i < arr.Length; i++)
            {
                refStack.Push(arr[i]);
                testStack.Push(arr[i]);
                Assert.Equal(testStack.Peek(), refStack.Peek());
            }
            for (int i = 0; i < arr.Length-1; i++)
            {
                refStack.Pop();
                testStack.Pop();
                Assert.Equal(testStack.Peek(), refStack.Peek());
            }
            
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 5)]
        public void PeekTest(params int[] arr)
        {
            Stack<int> refStack = new Stack<int>(10);
            ABStack<int> testStack = new ABStack<int>(10);
            for (int i = 0; i < arr.Length; i++)
            {
                refStack.Push(arr[i]);
                testStack.Push(arr[i]);
                Assert.Equal(testStack.Peek(), refStack.Peek());
            }
            Assert.Equal(testStack.Peek(), refStack.Peek());
        }
    }
}