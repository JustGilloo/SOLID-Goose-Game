using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Players
{
    public class Player : IPlayer
    {
        public Player(string name) 
        {
            this.PlayerName = name;
            this.StartingPosition = 0;
            this.CurrentPosition = 0;
            this.EffectDurationInTurns = 0;
            this.CanMove = true;
            this.DiceResultArray = new int[2];
        }
        public string PlayerName { get; set; }
        public int StartingPosition { get; set; }
        public int CurrentPosition { get; set; }
        public int EffectDurationInTurns { get; set; }
        public bool CanMove { get; set; } 
        public int[] DiceResultArray { get; set; } 

        public void DetermineNewPosition(int[] dieRolls)
        {
            if (this.CanMove == true)
            {
                this.DiceResultArray = dieRolls;
                CurrentPosition += dieRolls.Sum();
            }
        }
        public void SetStartOfTurnPosition()
        {
            StartingPosition = CurrentPosition;
        }
    }
}
