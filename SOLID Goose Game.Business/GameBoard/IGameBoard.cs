using SOLID_Goose_Game.Business.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.GameBoard
{
    internal interface IGameBoard
    {
        ICase[] Boardsize { get; }
    }
}
