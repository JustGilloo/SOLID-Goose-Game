using SOLID_Goose_Game.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.GameState
{
    public class GameState : IGameState
    {
        public ILogger logger;
        public GameState(ILogger logger) 
        {
            this.logger = logger;
        }
        public bool IsGameOver { get; set; } = false;

        public void PrintGameState(string message)
        {
            logger.LogMessage(message);
        }
    }
}
