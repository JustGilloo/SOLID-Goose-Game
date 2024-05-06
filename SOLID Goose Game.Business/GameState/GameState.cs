using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLID_Goose_Game.Logging;

namespace SOLID_Goose_Game.Business.GameState
{
    public class GameState : IGameState
    {
        public bool IsGameOver { get; set; } = false;

        public void PrintGameState(string message)
        {
            ILogger logger = new ConsoleLogger();

            logger.LogMessage($"Player moved!");
        }
    }
}
