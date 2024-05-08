using SOLID_Goose_Game.Business.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.GameState
{
    public interface IGameState
    {
        bool IsGameOver { get; set; }
        void PrintGameState(string message);
        void SetupGame();
        void CreatePlayer(string playerName);
        bool ResolvePlayerTurn(Player player);
        void GameLoop();
    }
}
