using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Dice
{
    internal interface IDiceRoller
    {
        int RollTotal { get; set; }
        int AmountOfDice { get; set; }
        int[] RollResults { get; set; }
    }
}
