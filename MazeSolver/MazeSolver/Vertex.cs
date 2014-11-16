using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeSolver
{
    class Vertex
    {
        private Point position;
        private Vertex parent;
        private double goalDistance;
        private double movementCost;
        private bool isWall;

        public Point Position { get; set; }
        public Vertex Parent { get; set; }
        public double GoalDistance { get; set; }
        public double MovementCost { get; set; }
        public bool IsWall { get; set; }
        public double FCost { get { return goalDistance + movementCost; } }

        public Vertex(Point position, bool isWall)
        {
            this.position = position;
            this.isWall = isWall;
            this.parent = null;
        }

        public Vertex(Point position, int isWall)
        {
            this.position = position;
            this.isWall = isWall == 1;
            this.parent = null;
        }

        public string GetPath()
        {
            List<Point> path = new List<Point>();
            string pathString = "";
            Vertex currentVertex = this;

            //Creates a list of all point from start to end
            do
            {
                path.Add(currentVertex.Position);
                currentVertex = currentVertex.Parent;
            } while (currentVertex != null);
            path.Reverse();

            //Create a string format of the list with formatting
            for (int index = 0; index < path.Count; index++)
            {
                pathString += path[index].ToString();
                if (index != path.Count - 2)
                    pathString += "->";
            }

            return pathString;
        }
        
    }
}
