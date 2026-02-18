using System;
using System.Collections.Generic;
using System.Text;

namespace UnweightedUndirectedGraphs
{
    public class Graph<T> where T : IComparable<T>
    {
        public List<Vertex<T>> Vertices { get; private set; }

        public Graph()
        {
            Vertices = new List<Vertex<T>>();
        }

        /* Your functions go here */
        public bool AddVertex(Vertex<T> vertex)
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

        public bool RemoveVertex(Vertex<T> vertex)
        {
            if (vertex == null) return false;
            if (!Vertices.Contains(vertex)) return false;
            Vertices.Remove(vertex);
            return true;
        }
        // - Returns true if the removal succeeded, false otherwise
        //
        // - It should only succeed if the vertex exists in your graph
        //   and you remove all edges/connections to it.

        public bool AddEdge(Vertex<T> a, Vertex<T> b)
        {
            if (!(Vertices.Contains(a) && Vertices.Contains(b))) return false;
            a.Neighbors.Add(b);
            b.Neighbors.Add(a);
            return true;
        }
        // - Returns true if the addition succeeded, false otherwise
        //
        // - It should only succeed if both vertices are not null and
        //   exist in the graph. Remember to make the connection mutual.

        public bool RemoveEdge(Vertex<T> a, Vertex<T> b)
        {
            if (!(Vertices.Contains(a) && Vertices.Contains(b))) return false;
            a.Neighbors.Remove(b);
            b.Neighbors.Remove(a);
            return true;
        }
        // - Returns true if the removal succeeded, false otherwise
        //
        // - It should only succeed if both vertices are not null, exist
        //   in the list, and are each other's neighbor.

        public Vertex<T> Search(T value)
        {
            foreach (Vertex<T> v in Vertices)
            {
                if (v.Value.Equals(value)) return v;
            }
            return null;
        }
        // - Returns the vertex with the given value, or null if the
        //   vertex doesn't exist in the graph.

        public bool Contains(T value)
        {
            return Search(value) != null;
        }

        public List<T> DepthFirstTraversal(Vertex<T> curr) => DepthFirstTraversal(curr, []);

        private List<T> DepthFirstTraversal(Vertex<T> curr, List<Vertex<T>> visited)
        {
            List<T> list = new List<T>();
            visited.Add(curr);
            foreach (Vertex<T> v in curr.Neighbors)
            {
                if (!visited.Contains(v))
                {
                    list.AddRange(DepthFirstTraversal(v));
                }
            }
            list.Add(curr.Value);
            return list;
        }

        public List<T> BreadthFirstTraversal(Vertex<T> curr)
        {
            List<T> output = new List<T>();
            List<Vertex<T>> visited = new List<Vertex<T>>();
            Queue<Vertex<T>> movement = new Queue<Vertex<T>>();

            movement.Enqueue(curr);
            visited.Add(curr);

            while (movement.Count > 0)
            {
                curr = movement.Dequeue();
                output.Add(curr.Value);
                foreach (var v in curr.Neighbors)
                {
                    if (!visited.Contains(v))
                    {
                        movement.Enqueue(v);
                    }
                }
            }
            return output;
        }
    }
}
