namespace Test1;
using Stacks_and_Queues;

public class LLBQueue_Test
{
    [Theory]
    [InlineData(1, 2, 3, 4, 5)]
    public void EnqueueTest(params int[] arr)
    {
        LLBQueue<int> testQueue = new LLBQueue<int>();
        Queue<int> refQueue = new Queue<int>();
        for (int i = 0; i < arr.Length; i++)
        {
            testQueue.Enqueue(arr[i]);
            refQueue.Enqueue(arr[i]);
            Assert.Equal(refQueue.Peek(), testQueue.Peek());
        }
    }

    [Theory]
    [InlineData(1, 2, 3, 4, 5)]
    public void DequeueTest(params int[] arr)
    {
        LLBQueue<int> testQueue = new LLBQueue<int>();
        Queue<int> refQueue = new Queue<int>();
        for (int i = 0; i < arr.Length; i++)
        {
            testQueue.Enqueue(arr[i]);
            refQueue.Enqueue(arr[i]);
            Assert.Equal(refQueue.Peek(), testQueue.Peek());
        }
        for (int i = arr.Length - 1; i >= 0; i--)
        {           
            Assert.Equal(testQueue.Dequeue(), refQueue.Dequeue());
        }
    }
}
