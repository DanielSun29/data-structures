using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding
{
    public class Vertex<T>
    {
        public T Value { get; set; }
        public List<Edge<T>> Edges { get; set; }

        public Vertex(T value)
        {
            Value = value;
            Edges = new List<Edge<T>>();
        }
    }
}
