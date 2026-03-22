using Pathfinding;

namespace PathFindingTest
{
    public class UnitTest1
    {
        [Fact]
        public void DijkstraTest1()
        {
            Graph<string> graph = new Graph<string>();
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");
            graph.AddVertex("F");
            graph.AddVertex("G");
            graph.AddVertex("H");

            graph.AddEdge(graph.Search("A"), graph.Search("B"), 1);
            graph.AddEdge(graph.Search("A"), graph.Search("E"), 2);
            graph.AddEdge(graph.Search("A"), graph.Search("G"), 6);
            graph.AddEdge(graph.Search("B"), graph.Search("C"), 1);
            graph.AddEdge(graph.Search("B"), graph.Search("F"), 2);
            graph.AddEdge(graph.Search("C"), graph.Search("D"), 1);
            graph.AddEdge(graph.Search("E"), graph.Search("D"), 2);
            graph.AddEdge(graph.Search("F"), graph.Search("H"), 3);
            graph.AddEdge(graph.Search("F"), graph.Search("D"), 4);
            graph.AddEdge(graph.Search("G"), graph.Search("C"), 2);
            graph.AddEdge(graph.Search("H"), graph.Search("D"), 4);

            // Test the shortest path from A to D(Should be A -> B -> C -> D)

            List<Vertex<string>> path = graph.Dijkstra(graph.Search("A"), graph.Search("D"));
            Assert.Equal(4, path.Count);
            Assert.Equal("A", path[0].Value);
            Assert.Equal("B", path[1].Value);
            Assert.Equal("C", path[2].Value);
            Assert.Equal("D", path[3].Value);
        }

        [Fact]
        public void AStarTest1()
        {
            Graph<string> graph = new Graph<string>();
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");
            graph.AddVertex("F");
            graph.AddVertex("G");
            graph.AddVertex("H");

            graph.AddEdge(graph.Search("A"), graph.Search("B"), 1);
            graph.AddEdge(graph.Search("A"), graph.Search("E"), 2);
            graph.AddEdge(graph.Search("A"), graph.Search("G"), 6);
            graph.AddEdge(graph.Search("B"), graph.Search("C"), 1);
            graph.AddEdge(graph.Search("B"), graph.Search("F"), 2);
            graph.AddEdge(graph.Search("C"), graph.Search("D"), 1);
            graph.AddEdge(graph.Search("E"), graph.Search("D"), 2);
            graph.AddEdge(graph.Search("F"), graph.Search("H"), 3);
            graph.AddEdge(graph.Search("F"), graph.Search("D"), 4);
            graph.AddEdge(graph.Search("G"), graph.Search("C"), 2);
            graph.AddEdge(graph.Search("H"), graph.Search("D"), 4);

            // Test the shortest path from A to D(Should be A -> B -> C -> D)

            List<Vertex<string>> path = graph.Dijkstra(graph.Search("A"), graph.Search("D"));
            Assert.Equal(4, path.Count);
            Assert.Equal("A", path[0].Value);
            Assert.Equal("B", path[1].Value);
            Assert.Equal("C", path[2].Value);
            Assert.Equal("D", path[3].Value);
        }

        [Fact]
        public void BellmanFordTest1()
        {
            Graph<string> graph = new Graph<string>();
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");
            graph.AddVertex("F");
            graph.AddVertex("G");
            graph.AddVertex("H");

            graph.AddEdge(graph.Search("A"), graph.Search("B"), 1);
            graph.AddEdge(graph.Search("A"), graph.Search("E"), 2);
            graph.AddEdge(graph.Search("A"), graph.Search("G"), 6);
            graph.AddEdge(graph.Search("B"), graph.Search("C"), 1);
            graph.AddEdge(graph.Search("B"), graph.Search("F"), 2);
            graph.AddEdge(graph.Search("C"), graph.Search("D"), 1);
            graph.AddEdge(graph.Search("E"), graph.Search("D"), 2);
            graph.AddEdge(graph.Search("F"), graph.Search("H"), 3);
            graph.AddEdge(graph.Search("F"), graph.Search("D"), 4);
            graph.AddEdge(graph.Search("G"), graph.Search("C"), 2);
            graph.AddEdge(graph.Search("H"), graph.Search("D"), 4);

            // Test the shortest path from A to D(Should be A -> B -> C -> D)

           Assert.False(graph.BellmanFord(graph.Search("A")));
           
        }

        [Fact]
        public void BellmanFordTest2()
        {
            Graph<string> graph = new Graph<string>();
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");
            graph.AddVertex("F");
            graph.AddVertex("G");
            graph.AddVertex("H");

            graph.AddEdge(graph.Search("A"), graph.Search("B"), 1);
            graph.AddEdge(graph.Search("B"), graph.Search("A"), 1);
            graph.AddEdge(graph.Search("B"), graph.Search("E"), 1);
            graph.AddEdge(graph.Search("B"), graph.Search("F"), -5);
            graph.AddEdge(graph.Search("E"), graph.Search("B"), 1);
            graph.AddEdge(graph.Search("E"), graph.Search("F"), 1);
            graph.AddEdge(graph.Search("F"), graph.Search("B"), -5);
            graph.AddEdge(graph.Search("F"), graph.Search("E"), 1);
            graph.AddEdge(graph.Search("F"), graph.Search("G"), 1);

            Action action = ()=> graph.BellmanFord(graph.Search("A"));


            // Test the shortest path from A to D(Should be A -> B -> C -> D)
            Assert.True(graph.BellmanFord(graph.Search("A")));
            //Assert.Throws(typeof(Exception),action);
        }
    }
}