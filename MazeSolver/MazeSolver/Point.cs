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

        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
