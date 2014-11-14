using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeSolver
{
    class Point
    {
        private int x;
        private int y;
        private int z;

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point(int x, int y, int z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
