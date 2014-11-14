﻿#region File Information
/*
 * Authors: Kyle Huntsman and Brandon Olson
 * File Name: Point.cs
 * File Description: 
 */
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace MazeSolver
{
    class Point
    {
        #region Private Data Members
        private int x;
        private int y;
        private int z;
        #endregion

        #region Getters and Setters
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        #endregion

        #region Constructor(s)
        public Point() {}

        public Point(int x, int y) : this(x, y, 0) {}

        public Point(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        #endregion
    }
}
