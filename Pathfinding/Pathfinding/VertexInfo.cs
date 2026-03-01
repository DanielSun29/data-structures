using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding
{
    public class VertexInfo<T>
    {
        public Vertex<T> Vertex { get; set; } // This is the original vertex

        public float TotalCost { get; set; }
        public bool IsVisited { get; set; }
        public Edge<T> FoundingEdge { get; set; }

        public T Value
        {
            get
            {
                return Vertex.Value;
            }
            set
            {
                Vertex.Value = value;
            }
        }

        public List<Edge<T>> Edges
        {
            get
            {
                return Vertex.Edges;
            }
            set
            {
                Vertex.Edges = value;
            }
        }   
    }
}
