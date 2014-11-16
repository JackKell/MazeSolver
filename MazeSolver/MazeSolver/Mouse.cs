using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeSolver
{
    class Mouse
    {
        private Maze maze;
        private List<Vertex> openVerticies;
        private List<Vertex> closedVerticies;

        public Mouse(Maze maze)
        {
            this.maze = maze;
        }

        public String FindShortestPath()
        {
            Vertex currVertex = maze.StartVertex;

            return "";
        }
    }
}
