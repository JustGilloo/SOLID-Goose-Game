using SOLID_Goose_Game.Business.Cases.Interfaces;
using SOLID_Goose_Game.Business.Players;
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
        bool IsFinishReached { get; set; }

        void FillInBoardCases();

        void HandleCaseType(Player player);
    }
}
