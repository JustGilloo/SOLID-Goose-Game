using SOLID_Goose_Game.Business.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.GameBoard
{
    public interface IGameBoard
    {
        ICase[] Boardsize { get; }
    }
}
