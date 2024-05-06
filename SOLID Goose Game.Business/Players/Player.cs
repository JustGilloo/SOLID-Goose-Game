using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Players
{
    internal class Player : IPlayer
    {
        public string PlayerNumber { get; set; }
        public int StartingPosition { get; set; }
        public int EndingPosition { get; set; }
    }
}
