using System;
using System.Collections.Generic;
using System.Text;

namespace UnweightedUndirectedGraphs
{
    internal class Vertex<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public List<Vertex<T>> Neighbors { get; set; }

        public Vertex(T value)
        {
            this.Value = value; 
        }
    }
}
