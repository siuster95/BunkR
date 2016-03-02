using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game
{
    class PlayerStat
    {
        // fields
        private int playerScore;
        private Player p1;

        // properties

        public int PlayerScore
        {
            get { return playerScore; }
            set { playerScore = value; }
        }


        // constructor
        public PlayerStat(Player p1)
        {
            playerScore = 0;
            this.p1 = p1;
        }

        // methods
        public void LostGame()
        {
            if (p1.IsDead() == true)
            {
                Console.WriteLine("Game Over!");
                Console.WriteLine("Your score: " + this.playerScore);
            }
        }
    }
}
