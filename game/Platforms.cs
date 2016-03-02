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
    class Platforms
    {
        // fields
        private Rectangle rect;
        private Player player;
        private int DC;
        private bool dropbool;
        private bool onbool;
        private int number;

        // properties
        public int X
        {
            get { return rect.X; }
            set {rect.X=value;}
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
     
       
        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        public Rectangle Rectangle
        {
            get { return rect; }
            
        }
        public bool PDB
        {
            get { return dropbool; }
            set { dropbool = value; }
        }
        public bool Onbool
        {
            get { return onbool; }
            set { onbool = value; }
        }
       public int Number
        {
            get { return number; }
            set { number = value; }
        }

        // constructor
        public Platforms(int x, int y,Player player,int number)
        {
            this.X = x;
            this.Y = y;
            this.Height = 30;
            this.Width = 250;
            this.Player = player;
            DC = 0;
            dropbool = false;
            onbool = false;
            this.number = number;
        }

        //methods
        // Method that keeps player on platform
        public bool IsPlayerOnPlatform(bool dropping,bool jumpingoff,bool dropfromothers)
        {
            if (this.Player.X + this.Player.Width / 2 > this.X && this.Player.X + this.Player.Width / 2 < this.X + this.Width && this.Player.Y + this.Player.Height < this.Y && dropping == true && this.Player.Y + this.Player.Height > this.Y - 20 && jumpingoff == false || this.Player.X + this.Player.Width / 2 > this.X && this.Player.X + this.Player.Width / 2 < this.X + this.Width && this.Player.Y + this.Player.Height < this.Y && this.Player.Y + this.Player.Height > this.Y - 20 && dropfromothers == true)
            {
                this.Player.Y = this.Y - 57;
                return onbool = true;
               
            }
            if (onbool == true && this.Player.X + this.Player.Width / 2 < this.X || this.Player.X + this.Player.Width / 2 > this.X + this.Width && onbool == true )
            {
                dropbool = true;
                return onbool=false;
                

            }
            if(this.Onbool==true&&this.Player.Y+this.Player.Height<this.Y-20)
            {
                return Onbool = false;
            }
            return false;
        }
        
        // Method that drops player from platform
        public void Drop(int number,bool landed)
        {
            if (dropbool == true&&landed == false)
            {
                if (number == 1)
                {
                    if (DC <= 35)
                    {
                        player.Y += 2;
                        DC = DC + 1;
                        
                    }
                    if (DC >= 35)
                    {
                        dropbool = false;
                        DC = 0;
                        
                    }
                }
                else if(number == 2)
                {
                    if (DC <= 35)
                    {
                        player.Y += 2;
                        DC = DC + 1;
                        
                    }
                    if (DC >= 35)
                    {
                        dropbool = false;
                        DC = 0;
                        
                    }
                }
                else if( number == 3)
                {
                    if (DC <= 70)
                    {
                        player.Y += 2;
                        DC = DC + 1;
                        
                    }
                    if (DC >= 70)
                    {
                        dropbool = false;
                        DC = 0;
                        
                    }
                }
                else if(number == 4)
                {
                    if (DC <= 105)
                    {
                        player.Y += 2;
                        DC = DC + 1;
                        
                    }
                    if (DC >= 105)
                    {
                        dropbool = false;
                        DC = 0;
                        
                    }
                }
                else if(number == 5)
                {
                    if (DC <= 140)
                    {
                        player.Y += 2;
                        DC = DC + 1;
                       
                    }
                    if (DC >= 140)
                    {
                        dropbool = false;
                        DC = 0;
                        
                    }
                }
                else if(number == 6)
                {
                    if (DC <= 120)
                    {
                        player.Y += 2;
                        DC = DC + 1;
                        
                    }
                    if (DC >= 120)
                    {
                        dropbool = false;
                        DC = 0;
                        
                    }
                }
            }
                else if(landed == true)
                {
                    this.PDB = false;
                    this.DC = 0;
                }
                
            }
           
        }

    }

