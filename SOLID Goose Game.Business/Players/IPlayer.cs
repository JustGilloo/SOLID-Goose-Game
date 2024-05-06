using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Players
{
    internal interface IPlayer
    {
        string PlayerNumber { get; }
        int StartingPosition { get; set; }
        int EndingPosition { get; set; }
    }
}
