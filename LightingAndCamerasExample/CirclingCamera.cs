﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightingAndCamerasExample
{
    public class CirclingCamera : ICamera
    {
        float angle;
        Vector3 position;
        float speed;
        Game1 game;

        Matrix view;
        Matrix projection;

        public Matrix View => view;
        public Matrix Projection => projection;

        /// <summary>
        /// Constructs a new camera that circles the origin
        /// </summary>
        /// <param name="game">The game this camera belongs to</param>
        /// <param name="position">The initial position of the camera</param>
        /// <param name="speed">The speed of the camera</param>
        public CirclingCamera(Game1 game, Vector3 position, float speed)
        {
            this.game = game;
            this.position = position;
            this.speed = speed;
            this.projection = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4,
                game.GraphicsDevice.Viewport.AspectRatio,
                1,
                1000
            );
            this.view = Matrix.CreateLookAt(
                position,
                Vector3.Zero,
                Vector3.Up
            );
        }

        /// <summary>
        /// Updates the camera's positon
        /// </summary>
        /// <param name="gameTime">The GameTime object</param>
        public void Update(GameTime gameTime)
        {
            // update the angle based on the elapsed time and speed
            angle += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Calculate a new view matrix
            this.view =
                Matrix.CreateRotationY(angle) *
                Matrix.CreateLookAt(position, Vector3.Zero, Vector3.Up);
        }
    }
}
