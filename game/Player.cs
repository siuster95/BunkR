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
 class Player : Character
    {
        // fields
        private Weapon currentlyEquipped;
        private PlayerStat p1Stat;
        private bool pickedUpNewWep;
        private int jumpcount;
        private bool jumpbool;
        private int dropcount;
        private bool dropbool;
        KeyboardState currentKey;
        KeyboardState previousKey;
        

        // properties
        public PlayerStat P1Stat
        {
            get { return p1Stat; }
        }

        public Weapon CurrentlyEquipped
        {
            get { return currentlyEquipped; }
            set { currentlyEquipped = value; }
        }

        public bool PickedUpNewWep
        {
            get { return pickedUpNewWep; }
            set { pickedUpNewWep = value; }
        }

        public int Jumpcount
        {
            get { return jumpcount; }
            set { jumpcount = value; }
        }

        public bool Jumpbool
        {
            get { return jumpbool; }
            set { jumpbool = value; }
        }

        public int Dropcount
        {
            get { return dropcount; }
            set { dropcount = value; }
        }

        public bool Dropbool
        {
            get { return dropbool; }
            set { dropbool = value; }
        }

        // constructor
        public Player(Rectangle rectangle, PlayerStat p1Stat)
        {
            X = rectangle.X;
            Y = rectangle.Y;
            Height = rectangle.Height;
            Width = rectangle.Width;
            pickedUpNewWep = false;
            this.speed = 5;
            this.p1Stat = p1Stat;
            ValueDirect = 0;
            this.Dropbool = false;
            this.Dropcount = 0;
            this.Jumpbool = false;
            this.Jumpcount = 0;
        }

        // methods
        /// <summary>
        /// method that allows player to take damage
        /// </summary>
        /// <param name="amt">how much damager taken (input zombie's attack)</param>
        /// <returns>returns remaining health</returns>
        public override double TakeDamage(double amt)
        {
            this.health -= amt;
            return this.health;
        }
     
        /// <summary>
        /// method that determines if player is dead
        /// </summary>
        public override bool IsDead()
        {
            if (this.health <= 0)
                return true;
            return false;
        }

        /// <summary>
        /// method that allows player to move
        /// </summary>
        public override int Move()
        {
            previousKey = currentKey;
            currentKey = Keyboard.GetState();
            if (currentKey.IsKeyDown(Keys.W))
            {
                // look up with weapon
                //this.Y -= this.speed;
            }
            else if (currentKey.IsKeyDown(Keys.D))
            {
                ValueDirect = 3;
                this.X += this.speed;
            }
            else if (currentKey.IsKeyDown(Keys.S))
            {
                this.Y += this.speed;
                
            }
            else if (currentKey.IsKeyDown(Keys.A))
            {
                this.X -= this.speed;
                ValueDirect = 1;
            }
            else if (currentKey.IsKeyDown(Keys.A) == true && previousKey.IsKeyUp(Keys.A) == true)
            {
                ValueDirect = 2;
            }
            else if (currentKey.IsKeyUp(Keys.D) == true && previousKey.IsKeyDown(Keys.D) == true)
            {
                ValueDirect = 3;
            }
            return this.X + this.Y;
        }

        
        /// <summary>
        /// method that allows player to jump
        /// </summary>
        public void Jump()
        {
           if(this.jumpbool ==true)
           {
               this.Y = this.Y-2;
               this.jumpcount++;
           }
            
            if(this.Jumpcount==50)
            {
                this.Jumpcount = 0;
                this.Jumpbool = false;
                this.Dropbool = true;
            }
        }

        // Method that allows player to drop after jumping
        public bool Drop()
        {
             if (this.dropbool == true)
            {
                this.Y = this.Y+2;
            }
             
            if (this.Y+this.Height>430)
            {
                this.Dropbool = false;
            }
            return dropbool;
        }

        /// <summary>
        /// checks if player collides with another unit
        /// </summary>
        /// <returns></returns>
        public bool IsColliding(Enemy zombie)
        {
            if (this.Rect.Intersects(zombie.Rect) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        // Method that checks if player is colliding with weapon 
        public bool IsColliding(Weapon W)
        {
            if (this.Rect.Intersects(W.Rect) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// method that picks up weapon when player collides with a weapon on the ground
        /// </summary>
        public void PickUpWeapon(Weapon groundWeapon)
        {
            if (this.rect.Intersects(groundWeapon.Rect) == true)
            {
                this.currentlyEquipped = groundWeapon;
                pickedUpNewWep = true;
            }
        }

        /// <summary>
        /// method that spawns the player
        /// </summary>
        public override void Spawn()
        {
            // x and y coordinates might change according to finalized map
            this.X = 200;
            this.Y = 200; 
        }
    }
}
