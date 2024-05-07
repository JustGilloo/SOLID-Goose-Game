using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Players
{
    public interface IPlayer
    {
        string PlayerName { get; }
        int StartingPosition { get; set; }
        int CurrentPosition { get; set; }
        int EffectDurationInTurns { get; set; }
        bool CanMove { get; set; }
        int[] DiceResultArray { get; set; } 

        void DetermineNewPosition(int[] dieRolls);
        void SetStartOfTurnPosition();
    }
}
