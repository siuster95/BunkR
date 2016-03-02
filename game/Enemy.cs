using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.IO;

namespace game
{
    class Enemy : Character
    {
        // enemy class represents a basic zombie enemy 

        // fields
        protected int attack;
        protected Player player;
        protected int numberofline;

        // properties
        public int Attack
        {
            get { return attack; }
            set{attack = value;}
        }
        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        // constructor
        public Enemy(Player player,Rectangle rectangle)
        {
            Random RNG = new Random();
            numberofline = 1;
            //float speedVal = RNG.Next(1/100,1);
            StreamReader reader = null;
            try
            {
                reader = new StreamReader("ZombieEditor/ZombieEditor/bin/Debug/ZombieEditor.txt");

                string line = null;

                while((line = reader.ReadLine())!= null)
                {   
                    if(numberofline==1)
                    {
                    this.Health = int.Parse(line);
                    numberofline++;
                    }
                    else if(numberofline==2)
                    {
                    this.Attack = int.Parse(line);
                    numberofline++;
                    }
                    else if(numberofline==3)
                    {
                    this.Speed = int.Parse(line);
                    
                    }
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine("Error:" + e.Message);
            }
            finally
            {
                if(reader != null)
                    reader.Close();
            }

            //attack = 1;
            //speed = 1;
            this.Player = player;
            X = rectangle.X;
            Y = rectangle.Y;
            Height = rectangle.Height;
            Width = rectangle.Width;
        }

        // methods
        /// <summary>
        /// method that allows zombie to take damage
        /// </summary>
        /// <param name="amt">how much damage to take (input weapon's damage)</param>
        /// <returns>returns remaining health</returns>
        public override double TakeDamage(double amt)
        {
            this.health -= amt;
            return this.health;
        }

        /// <summary>
        /// method that returns true if zombie is dead, false if not
        /// </summary>
        public override bool IsDead()
        {
            if (this.health <= 0)
                return true;
            return false;
        }

        /// <summary>
        /// method that moves the zombie
        /// </summary>
        /// <returns>returns zombie updated position</returns>
        public override int Move()
        {
            if (CharacterDirect == "right")
            {
                this.X += this.speed;
            }
            else if (CharacterDirect == "left")
            {
                this.X -= this.speed;
            }
            return this.X;
        }

        /// <summary>
        /// Spawn method for zombie
        /// </summary>
        public override void Spawn()
        {
            Random RNG = new Random();
            int randomSpawnSide = RNG.Next(0, 2);

            // spawns zombie on left side of map
            if (randomSpawnSide == 0)
                this.X = -1;

            // spawns zombie on right side of map
            else if (randomSpawnSide == 1)
                this.X = Console.BufferWidth + 1;

            this.Y = 200; // change according to y coordinate for ground level
        }

        /// <summary>
        /// Method that makes zombie follow player around the map
        /// </summary>
        public void Follow()
        {
            if(this.X > player.X)
            {
                ValueDirect = 1;
            }
            else if (this.X<player.X)
            {
                ValueDirect = 3;
            }
            this.Move();
        }
    }
}
