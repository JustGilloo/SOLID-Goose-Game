using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.GameState
{
    internal interface IGameState
    {
        bool IsGameOver { get; set; }
    }
}
