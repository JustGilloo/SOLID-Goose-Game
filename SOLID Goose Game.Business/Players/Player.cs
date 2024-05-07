using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Players
{
    public class Player : IPlayer
    {
        public string PlayerName { get; set; }
        public int StartingPosition { get; set; }
        public int CurrentPosition { get; set; }

        public void DetermineNewPosition(int[] dieRolls)
        {
            CurrentPosition += dieRolls.Sum();
            StartingPosition = CurrentPosition;
        }
    }
}
