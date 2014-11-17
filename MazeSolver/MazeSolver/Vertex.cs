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
    }
}
