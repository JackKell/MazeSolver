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

        public Vertex(Point position, bool isWall)
        {
            this.position = position;
            this.isWall = isWall;
        }
    }
}
