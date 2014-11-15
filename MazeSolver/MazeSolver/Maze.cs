#region File Information
/*
 * Authors: Kyle Huntsman and Brandon Olson
 * File Name: Maze.cs
 * File Description: 
 */
#endregion

#region Using Statments
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
#endregion

namespace MazeSolver
{
    class Maze
    {
        #region Private Data Members
        private Point start;
        private Point end;
        private Point dimensions;
        private List<List<List<Vertex>>> map;
        #endregion

        #region Getters and Setters
        public Point Start { get; set; }
        public Point End { get; set; }
        public Point Dimensions { get; set; }
        public List<List<List<Vertex>>> Map { get; }
        #endregion

        #region Contructor(s)
        public Maze(String fileName)
        {
            start = new Point();
            end = new Point();
            dimensions = new Point();
            map = new List<List<List<Vertex>>>();

            StreamReader sr = new StreamReader(fileName);

            string currentLine = "";
            int currentLineNum = 1;

            while ((currentLine = sr.ReadLine()) != null && currentLine != "")
            {
                List<String> values = new List<String>(currentLine.Split(' '));

                switch (currentLineNum)
                {
                    case 1:
                        // Reads the dimensions of the maze on line 1
                        dimensions.X = int.Parse(values[0]);
                        dimensions.Y = int.Parse(values[1]);
                        dimensions.Z = values.Count > 2 ? int.Parse(values[2]) : 1;
                        break;
                    case 2:
                        /* The start point given in the maze file is
                         * already 0 based, so no need to subtract 1
                         */
                        // Reads the start point of the maze on line 2
                        start.X = int.Parse(values[0]);
                        start.Y = dimensions.Y - int.Parse(values[1]); // Reverses the y-axis
                        start.Z = values.Count > 2 ? int.Parse(values[2]) : 0;
                        break;
                    case 3:
                        /* The end point given in the maze file is
                         * already 0 based, so no need to subtract 1
                         */
                        // Reads the end point of the maze on line 3
                        end.X = int.Parse(values[0]);
                        end.Y = dimensions.Y - int.Parse(values[1]); // Reverses the y-axis
                        end.Z = values.Count > 2 ? int.Parse(values[2]) : 0;
                        break;
                    default:
                        // The maze definition starts on line 4
                        int yIndex = currentLineNum - 4;
                        int zIndex = yIndex / dimensions.Y;
                        for (int xIndex = 0; xIndex < dimensions.X; xIndex++)
                        {
                            Point point = new Point(xIndex, yIndex, zIndex);
                            Vertex vertex = new Vertex(point, int.Parse(values[xIndex]));
                            vertex.GoalDistance = GetDistance(point, end);
                            map[xIndex][yIndex][zIndex] = vertex;
                        }
                        break;
                }
                currentLineNum++;
            }
        }
        #endregion

        #region Private Method(s)
        private double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt(
                ((p2.X - p1.X) * (p2.X - p1.X)) + 
                ((p2.Y - p1.Y) * (p2.Y - p1.Y)) + 
                ((p2.Z - p1.Z) * (p2.Z - p1.Z)));
        }
        #endregion

        #region Public Method(s)
        //Draw itself
        //Update maybe
        //I don't know
        #endregion
    }
}
