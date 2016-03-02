using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace game
{
    class SafeSpot
    {
        // fields
        private double timer;
        private bool active;
        protected Rectangle rect;

        // properties
        public int X
        {
            get { return rect.X; }
            set { rect.X = value; }
        }

        public int Y
        {
            get { return rect.Y; }
            set { rect.Y = value; }
        }

        public int Height
        {
            get { return rect.Height; }
            set { rect.Height = value; }
        }
        public int Width
        {
            get { return rect.Width; }
            set { rect.Width = value; }
        }

        public Rectangle Rect
        {
            get { return rect; }
        }

        public double Timer
        {
            get { return timer; }
            set { timer = value; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        // constructor
        public SafeSpot(Rectangle rect)
        {
            active = false;
            timer = 5;
            X = rect.X;
            Y = rect.Y;
            Height = rect.Height;
            Width = rect.Width;
        }

        // methods
        /// <summary>
        /// method that spawns safespot 
        /// </summary>
        public void Spawn(Rectangle rect)
        {
           active = true;
           this.X = rect.X;
           this.Y = rect.Y;
           Height = rect.Height;
           Width = rect.Width;
        }

        /// <summary>
        /// method that determines if player is inside of safespot
        /// </summary>
        public bool IsSafe(Player P)
        {
            // if this.rect intersects with player.rect, return true (player is safe from bomb & enemies)
            if (this.rect.Intersects(P.Rect) == true)
            {
                return true;
            }
            return false;
        }

    }
}
