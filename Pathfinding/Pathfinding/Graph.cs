using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Pathfinding
{
    public class Graph<T>
    {
        Dictionary<Vertex<T>, VertexInfo<T>> vertices;

        public int Count { get { return vertices.Count; } }

        private List<Edge<T>> GetAllEdges()
        {
            List<Edge<T>> edges = new List<Edge<T>>();
            foreach (Vertex<T> vertex in vertices.Keys)
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

        public IReadOnlyDictionary<Vertex<T>, VertexInfo<T>> Vertices { get { return vertices; } }
        public IReadOnlyList<Edge<T>> Edges { get { return GetAllEdges(); } }

        public PriorityQueue<Vertex<T>, float> Queue { get; private set; }

        public Graph()
        {
            vertices = new Dictionary<Vertex<T>, VertexInfo<T>>();

        }

        public bool AddVertex(Vertex<T> vertex)
        {
            if (vertex == null) return false;
            if (Vertices.Keys.Contains(vertex)) return false;
            vertices.Add(vertex, new VertexInfo<T>() { Vertex = vertex });
            return true;
        }

        public bool AddVertex(T value)
        {
            return AddVertex(new Vertex<T>(value));
        }


        public bool RemoveVertex(Vertex<T> vertex)
        {
            if (vertex == null) return false;
            if (!Vertices.Keys.Contains(vertex)) return false;
            foreach (Edge<T> edge in Edges)
            {
                if (edge.StartVertex == vertex || edge.EndVertex == vertex)
                {
                    RemoveEdge(edge.StartVertex, edge.EndVertex);
                }
            }
            vertices.Remove(vertex);
            return true;
        }


        public bool RemoveVertex(T value)
        {
            return RemoveVertex(Search(value));
        }


        public bool AddEdge(Vertex<T> a, Vertex<T> b, float distance)
        {
            if (!(Vertices.Keys.Contains(a) && Vertices.Keys.Contains(b))) return false;
            Edge<T> edge = new Edge<T>(a, b, distance);
            a.Edges.Add(edge);
            return true;
        }


        public bool RemoveEdge(Vertex<T> a, Vertex<T> b)
        {
            if (!(Vertices.Keys.Contains(a) && Vertices.Keys.Contains(b))) return false;
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


        public Vertex<T> Search(T value)
        {
            foreach (Vertex<T> vertex in vertices.Keys)
            {
                if (vertex.Value.Equals(value))
                {
                    return vertex;
                }
            }
            return null;
        }


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


        public bool Contains(T value)
        {
            return Search(value) != null;
        }


        public List<Vertex<T>> Dijkstra(Vertex<T> start, Vertex<T> end)
        {
            if (start == null || end == null) return null;
            if (!Vertices.Keys.Contains(start) || !Vertices.Keys.Contains(end)) return null;

            Queue = new PriorityQueue<Vertex<T>, float>();

            List<Vertex<T>> visited = new List<Vertex<T>>();

            foreach (Vertex<T> vertex in vertices.Keys)
            {
                vertices[vertex].TotalCost = float.PositiveInfinity;
            }
            vertices[start].TotalCost = 0;

            visited.Add(start);
            Queue.Enqueue(start, 0);
            while (Queue.Count > 0)
            {
                Vertex<T> curr = Queue.Dequeue();
                foreach (Edge<T> edge in curr.Edges)
                {
                    if (!visited.Contains(edge.EndVertex))
                    {
                        Queue.Enqueue(edge.EndVertex, vertices[edge.EndVertex].TotalCost);
                    }
                }

                if (curr == end)
                {
                    Stack<Vertex<T>> path = new Stack<Vertex<T>>();
                    while (curr != null)
                    {
                        path.Push(curr);
                        if (curr == start) break;
                        curr = vertices[curr].FoundingEdge.StartVertex;
                    }
                    return path.ToList();
                }
                foreach (Edge<T> edge in curr.Edges)
                {
                    float altCost = vertices[curr].TotalCost + edge.Cost;
                    if (altCost < vertices[edge.EndVertex].TotalCost)
                    {
                        vertices[edge.EndVertex].TotalCost = altCost;
                        vertices[edge.EndVertex].FoundingEdge = edge;
                        Queue.Enqueue(edge.EndVertex, altCost);
                    }
                }
            }
            return null; // No path found
        }

        public List<Vertex<T>> AStar(Vertex<T> start, Vertex<T> end, Func<Vertex<T>, Vertex<T>, float> heuristic)
        {
            if (start == null || end == null) return null;
            if (!Vertices.Keys.Contains(start) || !Vertices.Keys.Contains(end)) return null;

            Queue = new PriorityQueue<Vertex<T>, float>();

            List<Vertex<T>> visited = new List<Vertex<T>>();

            foreach (Vertex<T> vertex in vertices.Keys)
            {
                vertices[vertex].TotalCost = float.PositiveInfinity;
            }
            vertices[start].TotalCost = 0;

            visited.Add(start);
            Queue.Enqueue(start, 0);
            while (!visited.Contains(end))
            {
                if (Queue.Count == 0) return null; // No path found
                Vertex<T> curr = Queue.Dequeue();
                foreach (Edge<T> edge in curr.Edges)
                {
                    float altCost = vertices[curr].TotalCost + edge.Cost;
                    if (altCost < vertices[edge.EndVertex].TotalCost)
                    {
                        vertices[edge.EndVertex].TotalCost = altCost;
                        vertices[edge.EndVertex].FoundingEdge = edge;
                        if (!Queue.Contains(edge.EndVertex))
                        {
                            Queue.Enqueue(edge.EndVertex, altCost + heuristic(edge.EndVertex, end));
                        }
                    }
                }
                visited.Add(curr);
            }

            Stack<Vertex<T>> path = new Stack<Vertex<T>>();
            var temp = end;
            while (temp != null)
            {
                path.Push(temp);
                if (temp == start) break;
                temp = vertices[temp].FoundingEdge.StartVertex;
            }
            return path.ToList();
        }


        public bool BellmanFord(Vertex<T> start)
        {
            if (start == null) return false;
            if (!Vertices.Keys.Contains(start)) return false;
            foreach (Vertex<T> vertex in vertices.Keys)
            {
                vertices[vertex].TotalCost = float.PositiveInfinity;
            }
            vertices[start].TotalCost = 0;
            for (int i = 0; i < vertices.Count - 1; i++)
            {
                foreach (Edge<T> edge in Edges)
                {
                    float altCost = vertices[edge.StartVertex].TotalCost + edge.Cost;
                    if (altCost < vertices[edge.EndVertex].TotalCost)
                    {
                        vertices[edge.EndVertex].TotalCost = altCost;
                        vertices[edge.EndVertex].FoundingEdge = edge;
                    }
                }
            }
            // Check for negative weight cycles
            foreach (Edge<T> edge in Edges)
            {
                float altCost = vertices[edge.StartVertex].TotalCost + edge.Cost;
                if (altCost < vertices[edge.EndVertex].TotalCost)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
