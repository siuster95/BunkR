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
    class Weapon
    {
        // fields
        protected int dmg;
        protected bool equipped;
        private List<Bullet> ListofBullet;
        protected Rectangle rect;
        protected Player owner;
        protected int count;
        protected bool active;

        // properties
        public Rectangle Rect
        {
            get { return rect; }
        }

        public int Dmg
        {
            get { return dmg; }
            set { dmg = value; }
        }

        public bool Equipped
        {
            get { return equipped; }
            set { equipped = value; }
        }

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
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

       
        // constructor
        public Weapon(List<Bullet> ListofBullet, Player owner)
        {
            this.equipped = false;
            this.dmg = 0;
            this.ListofBullet = ListofBullet;
            this.owner = owner;
            rect = new Rectangle(owner.X, owner.Y, 20,20);
            count = 0;
        }

        // methods
        /// <summary>
        /// method that fires bullet from current weapon
        /// </summary>
        public Bullet Fire()
        {
            while(ListofBullet.Count>0)
            {
                if (owner.CharacterDirect == "left" || owner.CharacterDirect == "down")
                {
                    if (this is RPG)
                    {
                        ListofBullet[0].Active = true;
                        ListofBullet[0].ValueDirect = 1;
                        ListofBullet[0].X = owner.X;
                        ListofBullet[0].Y = owner.Y + 5;
                        return ListofBullet[0];
                    }
                    ListofBullet[0].Active = true;
                    ListofBullet[0].ValueDirect = 1;
                    ListofBullet[0].X = owner.X;
                    ListofBullet[0].Y = owner.Y + 15;
                    return ListofBullet[0];
                }
                else if (owner.CharacterDirect == "right" || owner.CharacterDirect == "up")
                {
                    if (this is RPG)
                    {
                        ListofBullet[0].Active = true;
                        ListofBullet[0].ValueDirect = 3;
                        ListofBullet[0].X = owner.X + owner.Width - 7;
                        ListofBullet[0].Y = owner.Y + 5;
                        return ListofBullet[0];
                    }
                    ListofBullet[0].Active = true;
                    ListofBullet[0].ValueDirect = 3;
                    ListofBullet[0].X = owner.X + owner.Width - 7;
                    ListofBullet[0].Y = owner.Y + 15;
                    return ListofBullet[0];
                }
                
            }
            return null;
        }

        /// <summary>
        /// method that spawns weapons at random areas on the map
        /// </summary>
        public void Spawn(Rectangle rect)
        {
            this.X = rect.X;
            this.Y = rect.Y;
            Height = rect.Height;
            Width = rect.Width;
            Active = true;
        }

    }
}
