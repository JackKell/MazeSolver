using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeSolver
{
    class Mouse
    {
        private Maze maze;
        private List<Vertex> openVerticies;
        private List<Vertex> closedVerticies;

        //public Maze Maze { get { return maze; } }

        public Mouse(Maze maze)
        {
            this.maze = maze;
            openVerticies = new List<Vertex>();
            closedVerticies = new List<Vertex>();
        }

        #region Your A Lot of Gets
        private Vertex GetWestVertex(Vertex root)
        {
            Vertex vertex;
            try
            {
                vertex = maze.Map[root.Position.X - 1, root.Position.Y, root.Position.Z];
            }
            catch (IndexOutOfRangeException e) { return null; }
            return vertex;
        }

        private Vertex GetNorthWestVertex(Vertex root)
        {
            Vertex vertex;
            try
            {
                vertex = maze.Map[root.Position.X - 1, root.Position.Y - 1, root.Position.Z];
            }
            catch (IndexOutOfRangeException e) { return null; }
            return vertex;
        }

        private Vertex GetNorthVertex(Vertex root)
        {
            Vertex vertex;
            try
            {
                vertex = maze.Map[root.Position.X, root.Position.Y - 1, root.Position.Z];
            }
            catch (IndexOutOfRangeException e) { return null; }
            return vertex;
        }

        private Vertex GetNorthEastVertex(Vertex root)
        {
            Vertex vertex;

            try
            {
                vertex = maze.Map[root.Position.X + 1, root.Position.Y - 1, root.Position.Z];
            }
            catch (IndexOutOfRangeException e) { return null; }
            return vertex;
        }

        private Vertex GetEastVertex(Vertex root)
        {
            Vertex vertex;
            try
            {
                vertex = maze.Map[root.Position.X + 1, root.Position.Y, root.Position.Z];
            }
            catch (IndexOutOfRangeException e) { return null; }
            return vertex;
        }

        private Vertex GetSouthEastVertex(Vertex root)
        {
            Vertex vertex;
            try
            {
            vertex = maze.Map[root.Position.X + 1, root.Position.Y + 1, root.Position.Z];
            }
            catch (IndexOutOfRangeException e) { return null; }
            return vertex;
        }

        private Vertex GetSouthVertex(Vertex root)
        {
            Vertex vertex;
            try
            {
                vertex = maze.Map[root.Position.X, root.Position.Y + 1, root.Position.Z];
            }
            catch (IndexOutOfRangeException e) { return null; }
            return vertex;
        }

        private Vertex GetSouthWestVertex(Vertex root)
        {
            Vertex vertex;
            try
            {
                vertex = maze.Map[root.Position.X - 1, root.Position.Y + 1, root.Position.Z];
            }
            catch (IndexOutOfRangeException e) { return null; }
            return vertex;
        }

        #endregion

        private List<Vertex> GetSurroundingVerticies(Vertex root)
        {
            Vertex vWest, vNorthWest, vNorth, vNorthEast, vEast,
                vSouthEast, vSouth, vSouthWest;

            vWest = GetWestVertex(root);
            vNorthWest = GetNorthWestVertex(root);
            vNorth = GetNorthVertex(root);
            vNorthEast = GetNorthEastVertex(root);
            vEast = GetEastVertex(root);
            vSouthEast = GetSouthEastVertex(root);
            vSouth = GetSouthVertex(root);
            vSouthWest = GetSouthWestVertex(root);

            List<Vertex> verticies = new List<Vertex>() { vWest, vNorthWest, vNorth,
                vNorthEast, vEast, vSouthEast, vSouth, vSouthWest };

            return verticies;
        }

        private void UpdateVerticies(Vertex root)
        {
            // Adds root to closed list
            if (openVerticies.Contains(root))
                openVerticies.Remove(root);
            closedVerticies.Add(root);

            // Adds verticies to open list
            List<Vertex> verticies = GetSurroundingVerticies(root);
            foreach (Vertex vertex in verticies)
            {
                if (closedVerticies.Contains(vertex))
                    continue;
                if (openVerticies.Contains(vertex))
                    continue;

                openVerticies.Add(vertex);
            }
        }

        public String FindShortestPath()
        {
            Vertex currentVertex = maze.StartVertex;
            currentVertex.MovementCost = 0;

            String path = "There is no possible path to the target. :-(";
            bool pathNotFound = true;
            List<Vertex> surroundingVertexs = new List<Vertex>();

            while (pathNotFound)
            {
                surroundingVertexs = GetSurroundingVerticies(currentVertex);

                foreach (Vertex vertex in surroundingVertexs)
                {
                    if (openVerticies.Contains(vertex))
                        openVerticies.Remove(vertex);
                }

                while(openVerticies.Contains(currentVertex))
                    openVerticies.Remove(currentVertex);

                closedVerticies.Add(currentVertex);

                foreach (Vertex adjacancentVertex in surroundingVertexs)
                {
                    if (adjacancentVertex == null || adjacancentVertex.IsWall || closedVerticies.Contains(adjacancentVertex))
                        continue;

                    double possibleFCost = currentVertex.MovementCost + GetDistance(currentVertex, adjacancentVertex) + adjacancentVertex.GoalDistance;
                    if (possibleFCost < adjacancentVertex.MovementCost)
                    {
                        adjacancentVertex.MovementCost = possibleFCost;

                        if(adjacancentVertex.Parent == null)
                            adjacancentVertex.Parent = currentVertex;

                        if (adjacancentVertex.Parent == maze.EndVertex)
                        {
                            path = GetPath(adjacancentVertex.Parent);
                            pathNotFound = false;
                        }
                    }
                    openVerticies.Add(adjacancentVertex);
                }

                if (openVerticies.Count == 0)
                    return "No Solution";
                currentVertex = GetNodeInOpenListWithTheSmallestCost();
            }
            return path;
        }

        private Vertex GetNodeInOpenListWithTheSmallestCost()
        {
            Vertex smallestVertex = openVerticies[0];
            foreach (Vertex vertex in openVerticies)
            {
                if (vertex.FCost < smallestVertex.FCost)
                {
                    smallestVertex = vertex;
                }
            }
            return smallestVertex;
        }

        public string GetPath(Vertex root)
        {
            List<Point> path = new List<Point>();
            string pathString = "";
            Vertex currentVertex = root;

            //Creates a list of all point from start to end
            do
            {
                path.Add(currentVertex.Position);
                currentVertex = currentVertex.Parent;
            } while (currentVertex.Parent != null);
            path.Add(currentVertex.Position);
            path.Reverse();

            maze.Path = path;

            //Create a string format of the list with formatting
            for (int index = 0; index < path.Count; index++)
            {
                pathString += path[index].ToString();
                if (index != path.Count - 1)
                    pathString += "->" + System.Environment.NewLine;
            }

            return pathString;
        }

        private double GetDistance(Vertex v1, Vertex v2)
        {
            Point p1 = v1.Position;
            Point p2 = v2.Position;
            return Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));
        }
    }
}
