using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedDirectedGraphs
{
    public class Graph<T>
    {
        private List<Vertex<T>> vertices;

        private List<Edge<T>> GetAllEdges()
        {
            List<Edge<T>> edges = new List<Edge<T>>();
            foreach (Vertex<T> vertex in vertices)
            {
                foreach (Edge<T> edge in vertex.Edges)
                {
                    if (!edges.Contains(edge))
                    {
                        edges.Add(edge);
                    }
                }
            }
            return edges;
        }

        public IReadOnlyList<Vertex<T>> Vertices { get { return vertices; } }
        public IReadOnlyList<Edge<T>> Edges { get { return GetAllEdges(); } }

        public Graph()
        {
            vertices = new List<Vertex<T>>();
        }


        // Functions:

        public bool AddVertex(Vertex<T> vertex)
        {
            if (vertex == null) return false;
            if (Vertices.Contains(vertex)) return false;
            vertices.Add(vertex);
            return true;
        }
        // - Returns true if the addition succeeded, false otherwise
        //
        // - It should only succeed if the vertex is not null and it hasn't already been added to the graph.

        public bool RemoveVertex(Vertex<T> vertex)
        {
            if (vertex == null) return false;
            if (!Vertices.Contains(vertex)) return false;
            vertices.Remove(vertex);
            foreach (Edge<T> edge in Edges)
            {
                if (edge.StartVertex == vertex || edge.EndVertex == vertex)
                {
                    RemoveEdge(edge.StartVertex, edge.EndVertex);
                }
            }
            return true;
        }
        // - Returns true if the removal succeeded, false otherwise
        //
        // - It should only succeed if the vertex exists in your graph and you remove all edges/connections to it.

        public bool AddEdge(Vertex<T> a, Vertex<T> b, float distance)
        {
            if (!(Vertices.Contains(a) && Vertices.Contains(b))) return false;
            Edge<T> edge = new Edge<T>(a, b, distance);
            a.Edges.Add(edge);
            return true;
        }
        // - Returns true if the addition succeeded, false otherwise
        //
        // - It should only succeed if both vertices are not null, exist in the graph, and the edge doesn't
        //   already exist.

        public bool RemoveEdge(Vertex<T> a, Vertex<T> b)
        {
            if (!(Vertices.Contains(a) && Vertices.Contains(b))) return false;
            foreach (Edge<T> edge in a.Edges)
            {
                if (edge.EndVertex == b)
                {
                    a.Edges.Remove(edge);
                    break;
                }
            }
            return true;
        }
        // - Returns true if the removal succeeded, false otherwise
        //
        // - It should only succeed if both vertices are not null, exist in the list, and an edge to remove exists

        public Vertex<T> Search(T value)
        {
            foreach (Vertex<T> vertex in vertices)
            {
                if (vertex.Value.Equals(value))
                {
                    return vertex;
                }
            }
            return null;
        }
        // - Returns the vertex with the given value, or null if the vertex doesn't exist in the graph.

        public Edge<T> GetEdge(Vertex<T> a, Vertex<T> b)
        {
            foreach (Edge<T> edge in a.Edges)
            {
                if (edge.EndVertex == b)
                {
                    return edge;
                }
            }
            return null;
        }
        // - Returns the edge that connects the two given vertices, or null if the vertex doesn't exist in the graph.

        public bool Contains(T value)
        {
            return Search(value) != null;
        }

        public List<T> DepthFirstTraversal(Vertex<T> curr) => DepthFirstTraversal(curr, []);
        private List<T> DepthFirstTraversal(Vertex<T> curr, List<Vertex<T>> visited)
        {
            List<T> list = new List<T>();
            visited.Add(curr);
            foreach (Edge<T> edge in curr.Edges)
            {
                Vertex<T> v = edge.EndVertex;
                if (!visited.Contains(v))
                {
                    list.AddRange(DepthFirstTraversal(v, visited));
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
                foreach (Edge<T> edge in curr.Edges)
                {
                    Vertex<T> v = edge.EndVertex;
                    if (!visited.Contains(v))
                    {
                        movement.Enqueue(v);
                        visited.Add(v);
                    }
                }
            }
            return output;
        }
    }
}
