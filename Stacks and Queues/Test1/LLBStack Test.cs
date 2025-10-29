using Stacks_and_Queues;

namespace Test1
{
    public class LLBStackTest
    {
        [Theory]
        [InlineData(1, 2, 3, 4, 5)]
        public void PushTest(params int[] arr)
        {
            LLBStack<int> testStack = new LLBStack<int>();
            testStack.Push(1);
            Assert.Equal(1, testStack.Peek());
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 5)]
        public void PopTest(params int[] arr)
        {
            Stack<int> refStack = new Stack<int>();
            LLBStack<int> testStack = new LLBStack<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                refStack.Push(arr[i]);
                testStack.Push(arr[i]);
            }

            refStack.Pop();
            testStack.Pop();
            Assert.Equal(testStack.Peek(), refStack.Peek());
        }

        [Theory]
        [InlineData(1, 2, 3, 4, 5)]
        public void PeekTest(params int[] arr)
        {
            Stack<int> refStack = new Stack<int>();
            LLBStack<int> testStack = new LLBStack<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                refStack.Push(arr[i]);
                testStack.Push(arr[i]);
            }
            Assert.Equal(testStack.Peek(), refStack.Peek());
        }
    }
}