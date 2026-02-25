using WeightedDirectedGraphs;

namespace WeightedDirectedGraphsTest
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
                Assert.True(graph.Contains(arr[i]));
            }

            graph.AddEdge(vertices[0], vertices[2], 1);
            Assert.Equal(graph.Vertices[0].Edges[0].EndVertex, vertices[2]);

            graph.AddEdge(vertices[1], vertices[2], 1);
            Assert.Equal(graph.Vertices[1].Edges[0].EndVertex, vertices[2]);

            graph.AddEdge(vertices[3], vertices[5], 1);
            Assert.Equal(graph.Vertices[3].Edges[0].EndVertex, vertices[5]);

            graph.AddEdge(vertices[3], vertices[7], 1);
            Assert.Equal(graph.Vertices[3].Edges[1].EndVertex, vertices[7]);

            graph.AddEdge(vertices[6], vertices[5], 1);
            Assert.Equal(graph.Vertices[6].Edges[0].EndVertex, vertices[5]);

            graph.AddEdge(vertices[6], vertices[7], 1);
            Assert.Equal(graph.Vertices[6].Edges[1].EndVertex, vertices[7]);
        }

        [Fact]
        public void ContainsTest()
        {
            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7 };
            Graph<int> graph = new Graph<int>();
            Vertex<int>[] vertices = new Vertex<int>[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                vertices[i] = new Vertex<int>(arr[i]);
                graph.AddVertex(vertices[i]);
                Assert.True(graph.Contains(arr[i]));
            }
        }

        [Fact]
        public void AddEdgeTest()
        {
            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7 };
            Graph<int> graph = new Graph<int>();
            Vertex<int>[] vertices = new Vertex<int>[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                vertices[i] = new Vertex<int>(arr[i]);
                graph.AddVertex(vertices[i]);
                Assert.True(graph.Contains(arr[i]));
            }
            graph.AddEdge(vertices[0], vertices[2], 1);
            Assert.Equal(graph.Vertices[0].Edges[0].EndVertex, vertices[2]);
        }

        [Fact]
        public void RemoveTest()
        {
            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7 };
            Graph<int> graph = new Graph<int>();
            Vertex<int>[] vertices = new Vertex<int>[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                vertices[i] = new Vertex<int>(arr[i]);
                graph.AddVertex(vertices[i]);
                Assert.True(graph.Contains(arr[i]));
            }
            graph.AddEdge(vertices[0], vertices[2], 1);
            graph.AddEdge(vertices[1], vertices[2], 1);
            graph.AddEdge(vertices[3], vertices[5], 1);
            graph.AddEdge(vertices[3], vertices[7], 1);
            graph.AddEdge(vertices[6], vertices[5], 1);
            graph.AddEdge(vertices[6], vertices[7], 1);

            graph.RemoveVertex(vertices[3]);
            Assert.False(graph.Contains(3));
            Assert.DoesNotContain(graph.GetEdge(vertices[3], vertices[5]), graph.Edges);
            Assert.DoesNotContain(graph.GetEdge(vertices[3], vertices[7]), graph.Edges);
        }

        [Fact]
        public void RemoveEdgeTest()
        {
            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7 };
            Graph<int> graph = new Graph<int>();
            Vertex<int>[] vertices = new Vertex<int>[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                vertices[i] = new Vertex<int>(arr[i]);
                graph.AddVertex(vertices[i]);
                Assert.True(graph.Contains(arr[i]));
            }
            graph.AddEdge(vertices[0], vertices[2], 1);
            graph.AddEdge(vertices[1], vertices[2], 1);
            graph.AddEdge(vertices[3], vertices[5], 1);
            graph.AddEdge(vertices[3], vertices[7], 1);
            graph.AddEdge(vertices[6], vertices[5], 1);
            graph.AddEdge(vertices[6], vertices[7], 1);
            graph.RemoveEdge(vertices[3], vertices[5]);
            Assert.DoesNotContain(graph.GetEdge(vertices[3], vertices[5]), graph.Edges);
            graph.RemoveEdge(vertices[6], vertices[7]);
            Assert.DoesNotContain(graph.GetEdge(vertices[6], vertices[7]), graph.Edges);
        }

        [Fact]
        public void DepthFirstTraversalTest()
        {
            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7 };
            Graph<int> graph = new Graph<int>();
            Vertex<int>[] vertices = new Vertex<int>[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                vertices[i] = new Vertex<int>(arr[i]);
                graph.AddVertex(vertices[i]);
                Assert.True(graph.Contains(arr[i]));
            }
            graph.AddEdge(vertices[0], vertices[2], 1);
            graph.AddEdge(vertices[1], vertices[2], 1);
            graph.AddEdge(vertices[3], vertices[5], 1);
            graph.AddEdge(vertices[3], vertices[7], 1);
            graph.AddEdge(vertices[6], vertices[5], 1);
            graph.AddEdge(vertices[6], vertices[7], 1);

            // Testing
            Assert.Equal(new List<int> {
                vertices[2].Value,
                vertices[0].Value
            }, graph.DepthFirstTraversal(vertices[0]));

            Assert.Equal(new List<int> {
                vertices[5].Value,
                vertices[7].Value,
                vertices[3].Value
            }, graph.DepthFirstTraversal(vertices[3]));
        }

        [Fact]
        public void BreadthFirstTraversalTest()
        {
            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7 };
            Graph<int> graph = new Graph<int>();
            Vertex<int>[] vertices = new Vertex<int>[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                vertices[i] = new Vertex<int>(arr[i]);
                graph.AddVertex(vertices[i]);
                Assert.True(graph.Contains(arr[i]));
            }
            graph.AddEdge(vertices[0], vertices[2], 1);
            graph.AddEdge(vertices[1], vertices[2], 1);
            graph.AddEdge(vertices[3], vertices[5], 1);
            graph.AddEdge(vertices[3], vertices[7], 1);
            graph.AddEdge(vertices[6], vertices[5], 1);
            graph.AddEdge(vertices[6], vertices[7], 1);

            // Testing
            Assert.Equal(new List<int> {
                vertices[0].Value,
                vertices[2].Value,
            }, graph.BreadthFirstTraversal(vertices[0]));

            Assert.Equal(new List<int> {
                vertices[3].Value,
                vertices[5].Value,
                vertices[7].Value
            }, graph.BreadthFirstTraversal(vertices[3]));
        }
    }
}
