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
    class HealthPack
    {
        // fields
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

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public Rectangle Rect
        {
            get { return rect; }
        }

        // constructor
        public HealthPack(Rectangle rect)
        {
            active = false;
            X = rect.X;
            Y = rect.Y;
            Height = rect.Height;
            Width = rect.Width;
        }

        // methods
        /// <summary>
        /// method that determines if player has collided with healthpack
        /// </summary>
        public bool IsColliding(Player p)
        {
            // if this.rect intersects with player.rect, return true
            if (this.rect.Intersects(p.Rect) == true)
            {
                
                return true;
            }
            return false;
        }

        /// <summary>
        /// method that spawns healthpacks
        /// </summary>
        public void Spawn(Rectangle rect)
        {
            this.X = rect.X;
            this.Y = rect.Y;
            Height = rect.Height;
            Width = rect.Width;
            active = true;
        }


    }
}
