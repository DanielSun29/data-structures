using Stacks_and_Queues;

namespace Test1;

public class ABQueue_Test
{
    [Theory]
    [InlineData(1, 2, 3, 4, 5)]
    public void EnqueueTest(params int[] arr)
    {
        ABQueue<int> testQueue = new ABQueue<int>(2);
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
        ABQueue<int> testQueue = new ABQueue<int>(10);
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
    [Fact]
    public void WrapTest()
    {
        ABQueue<int> testQueue = new ABQueue<int>(10);
        Queue<int> refQueue = new Queue<int>();
        for (int i = 0; i < 10; i++)
        {
            testQueue.Enqueue(i);
            refQueue.Enqueue(i);
            Assert.Equal(refQueue.Peek(), testQueue.Peek());
        }
        for (int i = 5; i >= 0; i--)
        {
            Assert.Equal(testQueue.Dequeue(), refQueue.Dequeue());
        }
        for (int i = 0; i < 10; i++)
        {
            testQueue.Enqueue(i);
            refQueue.Enqueue(i);
            Assert.Equal(refQueue.Peek(), testQueue.Peek());
        }
    }
}
