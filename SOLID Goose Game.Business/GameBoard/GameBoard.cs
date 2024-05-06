using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.GameBoard
{
    internal class GameBoard : IGameBoard
    {
        public int[] Boardsize { get; private set; } = new int[63];
    }
}
