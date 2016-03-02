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
    class Bomb
    {
        // fields 
        private Rectangle rectangle;
        private double timer;
        private bool active;

        // properties
        public double Timer
        {
            get { return timer; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
        public int X
        {
            get { return rectangle.X; }
            set { rectangle.X = value; }
        }
        public int Y
        {
            get { return rectangle.Y; }
            set { rectangle.Y = value; }
        }
        public int height
        {
            get { return rectangle.Height; }
            set {rectangle.Height=value;}
        }

        // constructor
        public Bomb(Rectangle rectangle)
        {
            active = false;
            timer = 5;
            this.rectangle = rectangle;
            this.X = rectangle.X;
            this.Y = rectangle.Y;
        }

        // methods
        /// <summary>
        /// Method that clears the map of all character type objects
        /// </summary>
        public void Nuke(Character c)
        {
                c.Health = 0;
        }

    }
}
