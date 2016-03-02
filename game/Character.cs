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
    abstract class Character
    {
        // fields
        protected double health;
        protected int speed;
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

        public double Health
        {
            get { return health; }
            set { health = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
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

        public string CharacterDirect
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
        public Character()
        {
            health = 100;
            rect = new Rectangle();
        }

        // methods
        public abstract double TakeDamage(double amt);

        public abstract bool IsDead();

        public abstract int Move();

        public abstract void Spawn();
    }
}
