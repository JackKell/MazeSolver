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
        private Point dimenstions;
        private List<List<List<Vertex>>> map;
        #endregion

        #region Getters and Setters
        public Point Start { get; set; }
        public Point End { get; set; }
        public Point Dimenstions { get; set; }
        #endregion

        #region Contructor(s)
        public Maze(String fileName)
        {
            /* NOTE: Sorry Kyle the top left of the maze needs to be (0,0) 
             * much much much easier. I will just change the point values
             * so that they point to the correct locations.
             */

            //Also Note: This code will need alot of cleanning up after this.
            start = new Point();
            end = new Point();
            dimenstions = new Point();
            map = new List<List<List<Vertex>>>();

            StreamReader sr = new StreamReader(fileName);

            string currentLine = "";
            int currentLineNum = 1;

            while ((currentLine = sr.ReadLine()) != null && currentLine != "")
            {
                switch (currentLineNum)
                {
                    case 1:
                        List<String> values = new List<String>(currentLine.Split(' '));
                        dimenstions.X = int.Parse(values[0]);
                        dimenstions.Y = int.Parse(values[1]);
                        if (values.Count > 2)
                            dimenstions.Z = int.Parse(values[2]);
                        else
                            dimenstions.Z = 1;
                        break;
                    case 2:
                        values = new List<String>(currentLine.Split(' '));
                        start.X = (int.Parse(values[0]) - 1);
                        start.Y = dimenstions.Y - int.Parse(values[1]);
                        if (values.Count > 2)
                            start.Z = int.Parse(values[2]) - 1;
                        break;
                    case 3:
                        values = new List<String>(currentLine.Split(' '));
                        end.X = int.Parse(values[0]) - 1;
                        end.Y = dimenstions.Y - int.Parse(values[1]);
                        if (values.Count > 2)
                            end.Z = int.Parse(values[2]) - 1;
                        break;
                    default:
                        values = new List<String>(currentLine.Split(' '));
                        int yIndex = currentLineNum - 3;
                        int zIndex = yIndex / Dimenstions.Y;
                        for (int xIndex = 0; xIndex < Dimenstions.X; xIndex++)
                        {
                            map[xIndex][yIndex][zIndex] = new Vertex(new Point(xIndex, yIndex, zIndex), int.Parse(values[xIndex]));
                        }
                        break;
                }
                currentLineNum++;
            }
        }
        #endregion
    }
}
