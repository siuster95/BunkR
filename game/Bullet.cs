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
    class Bullet
    {
        // fields
        protected bool active;
        protected int valueDirect;
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

        public string PlayerDirect
        {
            get
            {
                if (valueDirect == 0)
                {
                    return "up";
                }
                else if (valueDirect == 1)
                {
                    return "left";
                }
                else if (valueDirect == 2)
                {
                    return "down";
                }
                else if (valueDirect == 3)
                {
                    return "right";
                }
                else
                { return "Error"; }
            }
        }

        public int ValueDirect
        {
            get { return valueDirect; }
            set { valueDirect = value; }
        }

        public Rectangle Rect
        {
            get { return rect; }
        }

        // constructor 
        public Bullet(Rectangle rect, int valueDirect)
        {
            active = false;
            this.X = rect.X;
            this.Y = rect.Y;
            Height = rect.Height;
            Width = rect.Width;
            this.valueDirect = valueDirect;
        }

        // methods
        /// <summary>
        /// method that allows the bullet to move after fired (or when active)
        /// </summary>
        public int Move()
        {
            if (active == true)
            {
                // moves the bullets
                if (valueDirect == 0)
                {
                    this.Y -= 1;
                }
                else if (valueDirect == 1)
                {
                    this.X -= 3;
                }
                else if (valueDirect == 2)
                {
                    this.Y += 1;
                }
                else if (valueDirect == 3)
                {
                    this.X += 3;
                }

            }
            return this.X + this.Y;
        }

        /// <summary>
        /// method that detects collision between bullet and zombie
        /// </summary>
        public bool IsColliding(Enemy zombie)
        {
            if (this.rect.Intersects(zombie.Rect) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}