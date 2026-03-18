using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using Pathfinding;
using System;
using System.Runtime.Intrinsics.X86;

namespace PathfindingVisualizer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        const int GRIDSIZE = 10;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        Rectangle[,] rectangles; // Drawing only, not for logic
        Graph<Point> graph;
        Square<Point>[,] squares;
        Square<Point> startSquare;
        Square<Point> endSquare;

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 1000;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            int screenWidth = GraphicsDevice.Viewport.Width;
            int screenHeight = GraphicsDevice.Viewport.Height;
            spriteBatch = new SpriteBatch(GraphicsDevice);

            rectangles = new Rectangle[GRIDSIZE, GRIDSIZE];
            squares = new Square<Point>[GRIDSIZE, GRIDSIZE];

            graph = new Graph<Point>();
            for (int i = 0; i < GRIDSIZE; i++)
            {
                for (int j = 0; j < GRIDSIZE; j++)
                {
                    rectangles[i, j] = new Rectangle(i * (screenWidth / GRIDSIZE), j * (screenWidth / GRIDSIZE), screenWidth / GRIDSIZE, screenHeight / GRIDSIZE);
                    graph.AddVertex(new Point(i, j));
                    squares[i, j] = new Square<Point>(graph.Search(new Point(i, j)), rectangles[i, j]);
                }
            }
            for (int i = 0; i < GRIDSIZE; i++)
            {
                for (int j = 0; j < GRIDSIZE; j++)
                {
                    if (graph.Search(new Point(i + 1, j)) != null)
                    {
                        graph.AddEdge(graph.Search(new Point(i, j)), graph.Search(new Point(i + 1, j)), 1);
                    }
                    if (graph.Search(new Point(i, j + 1)) != null)
                    {
                        graph.AddEdge(graph.Search(new Point(i, j)), graph.Search(new Point(i, j + 1)), 1);
                    }
                    if (graph.Search(new Point(i - 1, j)) != null)
                    {
                        graph.AddEdge(graph.Search(new Point(i, j)), graph.Search(new Point(i - 1, j)), 1);
                    }
                    if (graph.Search(new Point(i, j - 1)) != null)
                    {
                        graph.AddEdge(graph.Search(new Point(i, j)), graph.Search(new Point(i, j - 1)), 1);
                    }
                }
            }
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            MouseState mouseState = Mouse.GetState();
            for (int i = 0; i < GRIDSIZE; i++)
            {
                for (int j = 0; j < GRIDSIZE; j++)
                {
                    if (rectangles[i,j].Contains(mouseState.Position) && mouseState.RightButton == ButtonState.Pressed)
                    {
                        squares[i, j].State = SquareState.Wall;
                        squares[i, j].Vertex.Edges.Clear();
                        graph.RemoveVertex(squares[i, j].Vertex);
                    }
                    if (rectangles[i, j].Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
                    {
                        if (startSquare == null)
                        {
                            startSquare = squares[i, j];
                            startSquare.State = SquareState.End;
                        }
                        else if (endSquare == null && squares[i, j] != startSquare)
                        {
                            endSquare = squares[i, j];
                            endSquare.State = SquareState.End;
                        }
                    }
                }
            }

            if (startSquare != null && endSquare != null)
            {
                var path = graph.AStar(startSquare.Vertex, endSquare.Vertex, Manhattan);

                foreach (var vertex in path)
                {
                    var square = squares[vertex.Value.X, vertex.Value.Y];
                    if (square != startSquare && square != endSquare)
                    {
                        square.State = SquareState.Path;
                    }
                }
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            for (int i = 0; i < GRIDSIZE; i++)
            {
                for (int j = 0; j < GRIDSIZE; j++)
                {
                    if (squares[i, j].State == SquareState.Wall)
                    {
                        spriteBatch.FillRectangle(rectangles[i, j], Color.Gray);
                    }
                    if (squares[i, j].State == SquareState.Path)
                    {
                        spriteBatch.FillRectangle(rectangles[i, j], Color.Green);
                    }
                    if (squares[i,j].State == SquareState.End)
                    {
                        spriteBatch.FillRectangle(rectangles[i,j], Color.Red);
                    }
                }
            }
            foreach (var rect in rectangles)
            {
                spriteBatch.DrawRectangle(rect, Color.White);
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        // Heuristic function for A* (Manhattan distance)
        float Manhattan(Vertex<Point> a, Vertex<Point> b)
        {
            return Math.Abs(a.Value.X - b.Value.X) + Math.Abs(a.Value.Y - b.Value.Y);
        }
    }
}
