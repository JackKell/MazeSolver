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
            if (root.Position.X == 0)
                return root;

            vertex = maze.Map[root.Position.X - 1][root.Position.Y][root.Position.Z];
            vertex.Parent = root;
            return vertex;
        }

        private Vertex GetNorthWestVertex(Vertex root)
        {
            return GetNorthVertex(GetWestVertex(root));
        }

        private Vertex GetNorthVertex(Vertex root)
        {
            Vertex vertex;
            if (root.Position.Y == 0)
                return root;

            vertex = maze.Map[root.Position.X][root.Position.Y - 1][root.Position.Z];
            vertex.Parent = root;
            return vertex;
        }

        private Vertex GetNorthEastVertex(Vertex root)
        {
            return GetNorthVertex(GetEastVertex(root));
        }

        private Vertex GetEastVertex(Vertex root)
        {
            Vertex vertex;
            if (root.Position.X == maze.Dimensions.X)
                return root;

            vertex = maze.Map[root.Position.X + 1][root.Position.Y][root.Position.Z];
            vertex.Parent = root;
            return vertex;
        }

        private Vertex GetSouthEastVertex(Vertex root)
        {
            return GetSouthVertex(GetEastVertex(root));
        }

        private Vertex GetSouthVertex(Vertex root)
        {
            Vertex vertex;
            if (root.Position.Y == maze.Dimensions.Y)
                return root;

            vertex = maze.Map[root.Position.X][root.Position.Y + 1][root.Position.Z];
            vertex.Parent = root;
            return vertex;
        }

        private Vertex GetSouthWestVertex(Vertex root)
        {
            return GetSouthVertex(GetWestVertex(root));
        }

        #endregion

        private List<Vertex> GetSurroundingVerticies(Vertex root)
        {
            Vertex vWest, vNorthWest, vNorth, vNorthEast, vEast,
                vSouthEast, vSouth, vSouthWest;

            vWest = GetWestVertex(root);
            vNorthWest = GetWestVertex(root);
            vNorth = GetWestVertex(root);
            vNorthEast = GetWestVertex(root);
            vEast = GetWestVertex(root);
            vSouthEast = GetWestVertex(root);
            vSouth = GetWestVertex(root);
            vSouthWest = GetWestVertex(root);

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
            String path = "There is no possible path to the target. :-(";
            bool pathNotFound = true;
            List<Vertex> surroundingVertexs = new List<Vertex>();

            while (pathNotFound)
            {
                closedVerticies.Add(currentVertex);
                surroundingVertexs = GetSurroundingVerticies(currentVertex);
                foreach (Vertex adjacancentVertex in surroundingVertexs)
                {
                    double possibleFCost = currentVertex.MovementCost + 1 + adjacancentVertex.GoalDistance;
                    if (possibleFCost < adjacancentVertex.MovementCost)
                    {
                        adjacancentVertex.MovementCost = possibleFCost;
                        adjacancentVertex.Parent = currentVertex;
                        if (adjacancentVertex.Parent == maze.EndVertex)
                        {
                            path = adjacancentVertex.GetPath();
                            pathNotFound = false;
                        }
                    }
                }
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
    }
}
