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

        public Point Position { get { return position; } set { position = value; } }
        public Vertex Parent { get { return parent; } set { parent = value; } }
        public double GoalDistance { get { return goalDistance; } set { goalDistance = value; } }
        public double MovementCost { get {return movementCost; } set { movementCost = value; } }
        public bool IsWall { get { return isWall; } set { isWall = value; } }
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
                Console.WriteLine(currentVertex.Position.ToString());
                currentVertex = currentVertex.Parent;
            } while (currentVertex.Parent != null);
            path.Add(currentVertex.Position);
            path.Reverse();

            //Create a string format of the list with formatting
            for (int index = 0; index < path.Count; index++)
            {
                pathString += path[index].ToString();
                if (index != path.Count - 1)
                    pathString += "->";
            }

            return pathString;
        }
        
    }
}
