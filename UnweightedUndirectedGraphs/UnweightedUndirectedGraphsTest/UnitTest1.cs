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
                Assert.True(graph.Contains(arr[i]));
            }

            graph.AddEdge(vertices[0], vertices[2]);
            Assert.Equal(graph.Vertices[0].Neighbors[0], vertices[2]);
            Assert.Equal(graph.Vertices[2].Neighbors[0], vertices[0]);

            graph.AddEdge(vertices[1], vertices[2]);
            Assert.Equal(graph.Vertices[1].Neighbors[0], vertices[2]);
            Assert.Equal(graph.Vertices[2].Neighbors[1], vertices[1]);

            graph.AddEdge(vertices[3], vertices[5]);
            Assert.Equal(graph.Vertices[3].Neighbors[0], vertices[5]);
            Assert.Equal(graph.Vertices[5].Neighbors[0], vertices[3]);

            graph.AddEdge(vertices[3], vertices[7]);
            Assert.Equal(graph.Vertices[3].Neighbors[1], vertices[7]);
            Assert.Equal(graph.Vertices[7].Neighbors[0], vertices[3]);

            graph.AddEdge(vertices[6], vertices[5]);
            Assert.Equal(graph.Vertices[6].Neighbors[0], vertices[5]);
            Assert.Equal(graph.Vertices[5].Neighbors[1], vertices[6]);

            graph.AddEdge(vertices[6], vertices[7]);
            Assert.Equal(graph.Vertices[6].Neighbors[1], vertices[7]);
            Assert.Equal(graph.Vertices[7].Neighbors[1], vertices[6]);
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
            graph.AddEdge(vertices[0], vertices[2]);
            graph.AddEdge(vertices[1], vertices[2]);
            graph.AddEdge(vertices[3], vertices[5]);
            graph.AddEdge(vertices[3], vertices[7]);
            graph.AddEdge(vertices[6], vertices[5]);
            graph.AddEdge(vertices[6], vertices[7]);

            for (int i = 0; i < graph.Vertices.Count; i++)
            {
                Vertex<int> vertex = graph.Vertices[i];
                graph.RemoveVertex(vertex);
                Assert.False(graph.Contains(vertex.Value));
                foreach (Vertex<int> v in graph.Vertices)
                {
                    Assert.False(v.Neighbors.Contains(vertex));
                }
            }
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
            graph.AddEdge(vertices[0], vertices[2]);
            graph.AddEdge(vertices[1], vertices[2]);
            graph.AddEdge(vertices[3], vertices[5]);
            graph.AddEdge(vertices[3], vertices[7]);
            graph.AddEdge(vertices[6], vertices[5]);
            graph.AddEdge(vertices[6], vertices[7]);

            // Start testing

            Assert.Equal(
                graph.DepthFirstTraversal(vertices[0]),
                new List<int> { 1, 2, 0 }
            );

            Assert.Equal(
                graph.DepthFirstTraversal(vertices[5]),
                new List<int> { 6, 7, 3, 5 }
            );

            /*
             Graph used:
            https://visualgo.net/en/dfsbfs?create=%7B%22vl%22%3A%7B%220%22%3A%7B%22x%22%3A422.28061968490647%2C%22y%22%3A282.40904931211685%7D%2C%221%22%3A%7B%22x%22%3A50%2C%22y%22%3A431.198379294138%7D%2C%222%22%3A%7B%22x%22%3A218.3301385197513%2C%22y%22%3A368.9854211812574%7D%2C%223%22%3A%7B%22x%22%3A662.5744706341209%2C%22y%22%3A351.5558852823516%7D%2C%224%22%3A%7B%22x%22%3A382.4897785997576%2C%22y%22%3A98.0067303983368%7D%2C%225%22%3A%7B%22x%22%3A853.0713303620362%2C%22y%22%3A290.07720079703654%7D%2C%226%22%3A%7B%22x%22%3A950%2C%22y%22%3A431.1983792941381%7D%2C%227%22%3A%7B%22x%22%3A793.8415440767872%2C%22y%22%3A501.9932696016632%7D%7D%2C%22el%22%3A%7B%220%22%3A%7B%22u%22%3A0%2C%22v%22%3A2%2C%22w%22%3A1%7D%2C%221%22%3A%7B%22u%22%3A1%2C%22v%22%3A2%2C%22w%22%3A1%7D%2C%222%22%3A%7B%22v%22%3A0%2C%22u%22%3A2%2C%22w%22%3A1%7D%2C%223%22%3A%7B%22v%22%3A1%2C%22u%22%3A2%2C%22w%22%3A1%7D%2C%224%22%3A%7B%22u%22%3A3%2C%22v%22%3A5%2C%22w%22%3A1%7D%2C%225%22%3A%7B%22u%22%3A3%2C%22v%22%3A7%2C%22w%22%3A1%7D%2C%226%22%3A%7B%22v%22%3A3%2C%22u%22%3A5%2C%22w%22%3A1%7D%2C%227%22%3A%7B%22u%22%3A5%2C%22v%22%3A6%2C%22w%22%3A1%7D%2C%228%22%3A%7B%22v%22%3A5%2C%22u%22%3A6%2C%22w%22%3A1%7D%2C%229%22%3A%7B%22u%22%3A6%2C%22v%22%3A7%2C%22w%22%3A1%7D%2C%2210%22%3A%7B%22v%22%3A3%2C%22u%22%3A7%2C%22w%22%3A1%7D%2C%2211%22%3A%7B%22v%22%3A6%2C%22u%22%3A7%2C%22w%22%3A1%7D%7D%7D&directed=1
             */
        }

        [Fact]
        public void DepthFirstTraversalTest2()
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

            graph.AddEdge(vertices[0], vertices[1]);
            graph.AddEdge(vertices[0], vertices[2]);
            graph.AddEdge(vertices[1], vertices[3]);
            graph.AddEdge(vertices[1], vertices[4]);
            graph.AddEdge(vertices[2], vertices[5]);
            graph.AddEdge(vertices[5], vertices[6]);
            graph.AddEdge(vertices[5], vertices[7]);


            // Start testing

            Assert.Equal(
                graph.DepthFirstTraversal(vertices[0]),
                new List<int> { 3, 4, 1, 6, 7, 5, 2, 0 }
            );

            /*
             Tree used:
            https://visualgo.net/en/dfsbfs?create=%7B%22vl%22%3A%7B%220%22%3A%7B%22x%22%3A400%2C%22y%22%3A80%7D%2C%221%22%3A%7B%22x%22%3A300%2C%22y%22%3A180%7D%2C%222%22%3A%7B%22x%22%3A500%2C%22y%22%3A180%7D%2C%223%22%3A%7B%22x%22%3A200%2C%22y%22%3A280%7D%2C%224%22%3A%7B%22x%22%3A320%2C%22y%22%3A280%7D%2C%225%22%3A%7B%22x%22%3A520%2C%22y%22%3A280%7D%2C%226%22%3A%7B%22x%22%3A440%2C%22y%22%3A380%7D%2C%227%22%3A%7B%22x%22%3A560%2C%22y%22%3A360%7D%7D%2C%22el%22%3A%7B%220%22%3A%7B%22u%22%3A0%2C%22v%22%3A1%2C%22w%22%3A1%7D%2C%221%22%3A%7B%22v%22%3A0%2C%22u%22%3A1%2C%22w%22%3A1%7D%2C%222%22%3A%7B%22u%22%3A1%2C%22v%22%3A3%2C%22w%22%3A1%7D%2C%223%22%3A%7B%22v%22%3A1%2C%22u%22%3A3%2C%22w%22%3A1%7D%2C%224%22%3A%7B%22u%22%3A1%2C%22v%22%3A4%2C%22w%22%3A1%7D%2C%225%22%3A%7B%22v%22%3A1%2C%22u%22%3A4%2C%22w%22%3A1%7D%2C%226%22%3A%7B%22u%22%3A0%2C%22v%22%3A2%2C%22w%22%3A1%7D%2C%227%22%3A%7B%22v%22%3A0%2C%22u%22%3A2%2C%22w%22%3A1%7D%2C%228%22%3A%7B%22u%22%3A2%2C%22v%22%3A5%2C%22w%22%3A1%7D%2C%229%22%3A%7B%22v%22%3A2%2C%22u%22%3A5%2C%22w%22%3A1%7D%2C%2210%22%3A%7B%22u%22%3A5%2C%22v%22%3A6%2C%22w%22%3A1%7D%2C%2211%22%3A%7B%22v%22%3A5%2C%22u%22%3A6%2C%22w%22%3A1%7D%2C%2212%22%3A%7B%22u%22%3A5%2C%22v%22%3A7%2C%22w%22%3A1%7D%2C%2213%22%3A%7B%22v%22%3A5%2C%22u%22%3A7%2C%22w%22%3A1%7D%7D%7D&directed=1
             */
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
            graph.AddEdge(vertices[0], vertices[2]);
            graph.AddEdge(vertices[1], vertices[2]);
            graph.AddEdge(vertices[3], vertices[5]);
            graph.AddEdge(vertices[3], vertices[7]);
            graph.AddEdge(vertices[6], vertices[5]);
            graph.AddEdge(vertices[6], vertices[7]);
            // Start testing
            Assert.Equal(
                graph.BreadthFirstTraversal(vertices[0]),
                new List<int> { 0, 2, 1 }
            );
            Assert.Equal(
                graph.BreadthFirstTraversal(vertices[5]),
                new List<int> { 5, 3, 6, 7 }
            );
            /*
            Graph used:
            https://visualgo.net/en/dfsbfs?create=%7B%22vl%22%3A%7B%220%22%3A%7B%22x%22%3A422.28061968490647%2C%22y%22%3A282.40904931211685%7D%2C%221%22%3A%7B%22x%22%3A50%2C%22y%22%3A431.198379294138%7D%2C%222%22%3A%7B%22x%22%3A218.3301385197513%2C%22y%22%3A368.9854211812574%7D%2C%223%22%3A%7B%22x%22%3A662.5744706341209%2C%22y%22%3A351.5558852823516%7D%2C%224%22%3A%7B%22x%22%3A382.4897785997576%2C%22y%22%3A98.0067303983368%7D%2C%225%22%3A%7B%22x%22%3A853.0713303620362%2C%22y%22%3A290.07720079703654%7D%2C%226%22%3A%7B%22x%22%3A950%2C%22y%22%3A431.1983792941381%7D%2C%227%22%3A%7B%22x%22%3A793.8415440767872%2C%22y%22%3A501.9932696016632%7D%7D%2C%22el%22%3A%7B%220%22%3A%7B%22u%22%3A0%2C%22v%22%3A2%2C%22w%22%3A1%7D%2C%221%22%3A%7B%22u%22%3A1%2C%22v%22%3A2%2C%22w%22%3A1%7D%2C%222%22%3A%7B%22v%22%3A0%2C%22u%22%3A2%2C%22w%22%3A1%7D%2C%223%22%3A%7B%22v%22%3A1%2C%22u%22%3A2%2C%22w%22%3A1%7D%2C%224%22%3A%7B%22u%22%3A3%2C%22v%22%3A5%2C%22w%22%3A1%7D%2C%225%22%3A%7B%22u%22%3A3%2C%22v%22%3A7%2C%22w%22%3A1%7D%2C%226%22%3A%7B%22v%22%3A3%2C%22u%22%3A5%2C%22w%22%3A1%7D%2C%227%22%3A%7B%22u%22%3A5%2C%22v%22%3A6%2C%22w%22%3A1%7D%2C%228%22%3A%7B%22v%22%3A5%2C%22u%22%3A6%2C%22w%22%3A1%7D%2C%229%22%3A%7B%22u%22%3A6%2C%22v%22%3A7%2C%22w%22%3A1%7D%2C%2210%22%3A%7B%22v%22%3A3%2C%22u%22%3A7%2C%22w%22%3A1%7D%2C%2211%22%3A%7B%22v%22%3A6%2C%22u%22%3A7%2C%22w%22%3A1%7D%7D%7D&directed=1
            */
        }

        [Fact]
        public void BreadthFirstTraversalTest2()
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

            graph.AddEdge(vertices[0], vertices[1]);
            graph.AddEdge(vertices[0], vertices[2]);
            graph.AddEdge(vertices[1], vertices[3]);
            graph.AddEdge(vertices[1], vertices[4]);
            graph.AddEdge(vertices[2], vertices[5]);
            graph.AddEdge(vertices[5], vertices[6]);
            graph.AddEdge(vertices[5], vertices[7]);


            // Start testing

            Assert.Equal(
                graph.BreadthFirstTraversal(vertices[0]),
                new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 }
            );

            /*
             Tree used:
            https://visualgo.net/en/dfsbfs?create=%7B%22vl%22%3A%7B%220%22%3A%7B%22x%22%3A400%2C%22y%22%3A80%7D%2C%221%22%3A%7B%22x%22%3A300%2C%22y%22%3A180%7D%2C%222%22%3A%7B%22x%22%3A500%2C%22y%22%3A180%7D%2C%223%22%3A%7B%22x%22%3A200%2C%22y%22%3A280%7D%2C%224%22%3A%7B%22x%22%3A320%2C%22y%22%3A280%7D%2C%225%22%3A%7B%22x%22%3A520%2C%22y%22%3A280%7D%2C%226%22%3A%7B%22x%22%3A440%2C%22y%22%3A380%7D%2C%227%22%3A%7B%22x%22%3A560%2C%22y%22%3A360%7D%7D%2C%22el%22%3A%7B%220%22%3A%7B%22u%22%3A0%2C%22v%22%3A1%2C%22w%22%3A1%7D%2C%221%22%3A%7B%22v%22%3A0%2C%22u%22%3A1%2C%22w%22%3A1%7D%2C%222%22%3A%7B%22u%22%3A1%2C%22v%22%3A3%2C%22w%22%3A1%7D%2C%223%22%3A%7B%22v%22%3A1%2C%22u%22%3A3%2C%22w%22%3A1%7D%2C%224%22%3A%7B%22u%22%3A1%2C%22v%22%3A4%2C%22w%22%3A1%7D%2C%225%22%3A%7B%22v%22%3A1%2C%22u%22%3A4%2C%22w%22%3A1%7D%2C%226%22%3A%7B%22u%22%3A0%2C%22v%22%3A2%2C%22w%22%3A1%7D%2C%227%22%3A%7B%22v%22%3A0%2C%22u%22%3A2%2C%22w%22%3A1%7D%2C%228%22%3A%7B%22u%22%3A2%2C%22v%22%3A5%2C%22w%22%3A1%7D%2C%229%22%3A%7B%22v%22%3A2%2C%22u%22%3A5%2C%22w%22%3A1%7D%2C%2210%22%3A%7B%22u%22%3A5%2C%22v%22%3A6%2C%22w%22%3A1%7D%2C%2211%22%3A%7B%22v%22%3A5%2C%22u%22%3A6%2C%22w%22%3A1%7D%2C%2212%22%3A%7B%22u%22%3A5%2C%22v%22%3A7%2C%22w%22%3A1%7D%2C%2213%22%3A%7B%22v%22%3A5%2C%22u%22%3A7%2C%22w%22%3A1%7D%7D%7D&directed=1
             */
        }
    }
}
