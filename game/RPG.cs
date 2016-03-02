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
    class RPG : Weapon
    {
        // constructor 
        public RPG(List<Bullet> ListofBullets, Rectangle rect, Player owner)
            : base(ListofBullets, owner)
        {
            X = rect.X;
            Y = rect.Y;
            Height = rect.Height;
            Width = rect.Width;
            this.dmg = 100;
            this.equipped = false;
        }

    }
}
