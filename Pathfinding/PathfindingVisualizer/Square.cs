using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Pathfinding;

namespace PathfindingVisualizer
{
    public enum SquareState
    {
        Unvisited,
        Open,
        Wall,
        End,
        Path
    }

    public class Square<T>
    {
        public Vertex<T> Vertex;
        public Rectangle Rectangle;
        public SquareState State;

        public Square(Vertex<T> vertex, Rectangle rectangle)
        {
            Vertex = vertex;
            Rectangle = rectangle;
            State = SquareState.Open;
        }
    }
}
