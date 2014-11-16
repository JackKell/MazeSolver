using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MazeSolver.Screens
{
    class MazeScreen : GameScreen
    {
        private Maze maze;
        private Mouse mouse;

        public MazeScreen(MazeSolverGame game, SpriteBatch spriteBatch, Maze maze)
            : base(game, spriteBatch)
        {
            this.maze = maze;
            this.mouse = new Mouse(maze);
        }

        public override void Initialize()
        {
            Console.WriteLine(mouse.FindShortestPath());
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
