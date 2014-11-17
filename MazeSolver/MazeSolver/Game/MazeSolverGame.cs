#region File Info
/*
 * Authors: Kyle Hunstman & Brandon Olson
 * File Name: MazeSolverGame.cs
 * File Discription: It holds the information for the solving maze game.
 */
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MazeSolver.Screens;
#endregion

namespace MazeSolver
{
    public class MazeSolverGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameScreen currentScreen;
        MazeScreen mazeScreen;
        Maze maze;

        public MazeSolverGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            maze = new Maze(@"Mazes/maze_50.txt");
            mazeScreen = new MazeScreen(this, spriteBatch, maze);
        }

        protected override void Initialize()
        {
            base.Initialize();
            currentScreen = mazeScreen;
            currentScreen.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent() {}

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            currentScreen.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
