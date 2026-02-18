using UnweightedUndirectedGraphs;
namespace UnweightedUndirectedGraphsTest
{
    public class UnitTest1
    {
        [Fact]
        public void AddTest()
        {
            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7 };
            Graph<int> graph = new Graph<int>();
            Vertex<int>[] vertices = new Vertex<int>[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                vertices[i] = new Vertex<int>(arr[i]);
                graph.AddVertex(vertices[i]);
                Assert.True(graph.Sea)
            }

            graph.AddEdge(vertices[0], vertices[2]);
            graph.AddEdge(vertices[1], vertices[2]);

            graph.AddEdge(vertices[3], vertices[5]);
            graph.AddEdge(vertices[3], vertices[7]);
            graph.AddEdge(vertices[6], vertices[5]);
            graph.AddEdge(vertices[6], vertices[7]);
        }
    }
}
