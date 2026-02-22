using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedDirectedGraphs
{
    public class Graph<T>
    {
        private List<Vertex<T>> vertices;

        private List<Edge<T>> edges;

        public IReadOnlyList<Vertex<T>> Vertices { get { return vertices; } }
        public IReadOnlyList<Edge<T>> Edges { get { return edges; } }

        public Graph()
        {
            vertices = new List<Vertex<T>>();
            edges = new List<Edge<T>>();
        }


        // Functions:

        public void AddVertex(Vertex<T> vertex)
        {
            vertices.Add(vertex);

        }
        // - Returns true if the addition succeeded, false otherwise
        //
        // - It should only succeed if the vertex is not null and it hasn't already been added to the graph.

        public bool RemoveVertex(Vertex<T> vertex)
        {
            vertices.Remove(vertex);
            return true;
        }
        // - Returns true if the removal succeeded, false otherwise
        //
        // - It should only succeed if the vertex exists in your graph and you remove all edges/connections to it.

        public bool AddEdge(Vertex<T> a, Vertex<T> b, float distance)
        {
            return true;
        }
        // - Returns true if the addition succeeded, false otherwise
        //
        // - It should only succeed if both vertices are not null, exist in the graph, and the edge doesn't
        //   already exist.

        public bool RemoveEdge(Vertex<T> a, Vertex<T> b)
        {
            return true;
        }
        // - Returns true if the removal succeeded, false otherwise
        //
        // - It should only succeed if both vertices are not null, exist in the list, and an edge to remove exists

        public Vertex<T> Search(T value)
        {
            return null;

        }
        // - Returns the vertex with the given value, or null if the vertex doesn't exist in the graph.

        public Edge<T> GetEdge(Vertex<T> a, Vertex<T> b)
        {
            return null;
        }
        // - Returns the edge that connects the two given vertices, or null if the vertex doesn't exist in the graph.
    }
}
