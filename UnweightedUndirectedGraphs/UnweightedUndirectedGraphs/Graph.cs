using System;
using System.Collections.Generic;
using System.Text;

namespace UnweightedUndirectedGraphs
{
    internal class Graph<T> where T : IComparable<T>
    {
        public List<Vertex<T>> Vertices { get; private set; }

        public Graph()
        {
            Vertices = new List<Vertex<T>>();
        }

        /* Your functions go here */
        bool AddVertex(Vertex<T> vertex)
        {
            if (vertex == null) return false;
            if (Vertices.Contains(vertex)) return false;
            Vertices.Add(vertex);
            return true;
        }
        // - Returns true if the addition succeeded, false otherwise
        //
        // - It should only succeed if the vertex is not null and it
        //   hasn't already been added to the graph.

        bool RemoveVertex(Vertex<T> vertex)
        {

        }
        // - Returns true if the removal succeeded, false otherwise
        //
        // - It should only succeed if the vertex exists in your graph
        //   and you remove all edges/connections to it.

        bool AddEdge(Vertex<T> a, Vertex<T> b)
        {

        }
        // - Returns true if the addition succeeded, false otherwise
        //
        // - It should only succeed if both vertices are not null and
        //   exist in the graph. Remember to make the connection mutual.

        bool RemoveEdge(Vertex<T> a, Vertex<T> b)
        {


        }
        // - Returns true if the removal succeeded, false otherwise
        //
        // - It should only succeed if both vertices are not null, exist
        //   in the list, and are each other's neighbor.

        Vertex<T> Search(T value)
        {

        }
        // - Returns the vertex with the given value, or null if the
        //   vertex doesn't exist in the graph.
    }
}
