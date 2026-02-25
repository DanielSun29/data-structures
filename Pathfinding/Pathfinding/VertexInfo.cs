using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding
{
    public class VertexInfo<T>
    {
        Vertex<T> Vertex { get; set; } // This is the original vertex

        float TotalCost { get; set; }
        bool IsVisited { get; set; }
        Edge<T> FoundingEdge { get; set; }
            
        T Value
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
    }
}
