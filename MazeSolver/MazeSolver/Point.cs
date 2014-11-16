#region File Information
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
        public enum Direction
        {
            NORTH = 0, EAST, SOUTH, WEST,
            NORTH_EAST, NORTH_WEST, SOUTH_EAST, SOUTH_WEST,
            TOP, TOP_NORTH, TOP_EAST, TOP_SOUTH, TOP_WEST, TOP_NORTH_EAST, TOP_NORTH_WEST, TOP_SOUTH_EAST, TOP_SOUTH_WEST,
            BOTTOM, BOTTOM_NORTH, BOTTOM_EAST, BOTTOM_SOUTH, BOTTOM_WEST, BOTTOM_NORTH_EAST, BOTTOM_NORTH_WEST, BOTTOM_SOUTH_EAST, BOTTOM_SOUTH_WEST,
            NONE, ERROR
        };
        #region Private Data Members
        private int x;
        private int y;
        private int z;
        #endregion

        #region Getters and Setters
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public int Z { get { return z; } set { z = value; } }
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

        public override string ToString()
        {
            return "(" + x + ", " + y + ", " + z + ")";
        }

        public Direction GetDirection(Point root)
        {
            //NORTH ASPECT
            if (this.Y > root.Y)
            {
                //WEST ASPECT
                if (this.X > root.X)
                {
                    //TOP ASPECT
                    if (this.Z > root.Z)
                        return Direction.TOP_NORTH_WEST;
                    //BOTTOM ASPECT
                    else if (this.Z < root.Z)
                        return Direction.BOTTOM_NORTH_WEST;
                    //SAME Z ASPECT
                    else if (this.Z == root.Z)
                        return Direction.NORTH_WEST;
                    else { return Direction.ERROR; }
                }
                //EAST ASPECT
                else if (this.X < root.X)
                {
                    //TOP ASPECT
                    if (this.Z > root.Z)
                        return Direction.TOP_NORTH_EAST;
                    //BOTTOM ASPECT
                    else if (this.Z < root.Z)
                        return Direction.BOTTOM_NORTH_EAST;
                    //SAME Z ASPECT
                    else if (this.Z == root.Z)
                        return Direction.NORTH_EAST;
                    else { return Direction.ERROR; }
                }
                //SAME X ASPECT
                else if (this.X == root.X)
                {
                    //TOP ASPECT
                    if (this.Z > root.Z)
                        return Direction.TOP_NORTH;
                    //BOTTOM ASPECT
                    else if (this.Z < root.Z)
                        return Direction.BOTTOM_NORTH;
                    //SAME Z ASPECT
                    else if (this.Z == root.Z)
                        return Direction.NORTH;
                    else { return Direction.ERROR; }
                }
                else { return Direction.ERROR; }
            }
            //SOUTH ASPECT
            else if (this.Y < root.Y)
            {
                //WEST ASPECT
                if (this.X > root.X)
                {
                    //TOP ASPECT
                    if (this.Z > root.Z)
                        return Direction.TOP_SOUTH_WEST;
                    //BOTTOM ASPECT
                    else if (this.Z < root.Z)
                        return Direction.BOTTOM_SOUTH_WEST;
                    //SAME Z ASPECT
                    else if (this.Z == root.Z)
                        return Direction.SOUTH_WEST;
                    else { return Direction.ERROR; }
                }
                //EAST ASPECT
                else if (this.X < root.X)
                {
                    //TOP ASPECT
                    if (this.Z > root.Z)
                        return Direction.TOP_SOUTH_EAST;
                    //BOTTOM ASPECT
                    else if (this.Z < root.Z)
                        return Direction.BOTTOM_SOUTH_EAST;
                    //SAME Z ASPECT
                    else if (this.Z == root.Z)
                        return Direction.SOUTH_EAST;
                    else { return Direction.ERROR; }
                }
                //SAME X ASPECT
                else if (this.X == root.X)
                {
                    //TOP ASPECT
                    if (this.Z > root.Z)
                        return Direction.TOP_SOUTH;
                    //BOTTOM ASPECT
                    else if (this.Z < root.Z)
                        return Direction.BOTTOM_SOUTH;
                    //SAME Z ASPECT
                    else if (this.Z == root.Z)
                        return Direction.SOUTH;
                    else { return Direction.ERROR; }
                }
                else { return Direction.ERROR; }
            }
            //SAME Y ASPECT
            else if (this.Y == root.Y)
            {
                //WEST ASPECT
                if (this.X > root.X)
                {
                    //TOP ASPECT
                    if (this.Z > root.Z)
                        return Direction.TOP_WEST;
                    //BOTTOM ASPECT
                    else if (this.Z < root.Z)
                        return Direction.BOTTOM_WEST;
                    //SAME Z ASPECT
                    else if (this.Z == root.Z)
                        return Direction.WEST;
                    else { return Direction.ERROR; }
                }
                //EAST ASPECT
                else if (this.X < root.X)
                {
                    //TOP ASPECT
                    if (this.Z > root.Z)
                        return Direction.TOP_EAST;
                    //BOTTOM ASPECT
                    else if (this.Z < root.Z)
                        return Direction.BOTTOM_EAST;
                    //SAME Z ASPECT
                    else if (this.Z == root.Z)
                        return Direction.EAST;
                    else { return Direction.ERROR; }
                }
                //SAME X ASPECT
                else if (this.X == root.X)
                {
                    //TOP ASPECT
                    if (this.Z > root.Z)
                        return Direction.TOP;
                    //BOTTOM ASPECT
                    else if (this.Z < root.Z)
                        return Direction.BOTTOM;
                    //SAME Z ASPECT
                    else if (this.Z == root.Z)
                        return Direction.NONE;
                    else { return Direction.ERROR; }
                }
                else { return Direction.ERROR; }
            }
            else
                return Direction.ERROR;
        }
    }
}
