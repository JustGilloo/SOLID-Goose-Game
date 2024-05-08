using SOLID_Goose_Game.Business.Cases.Interfaces;
using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;
using SOLID_Goose_Game.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Cases.Classes
{
    public class MazeCase : IMazeCase
    {
        private ILogger logger;
        public int ID { get; set; }
        public CaseType Type { get; set; }

        public MazeCase(int id, CaseType type, ILogger logger)
        {
            ID = id;
            Type = type;
            this.logger = logger;
        }

        public void ResolveCase(Player player)
        {
            ApplyMazeCase(player);
            logger.LogMessage(this.Type.ToString());
        }
        public void ApplyMazeCase(Player player)
        {
            player.CurrentPosition -= 3;
            player.StartingPosition = player.CurrentPosition;
        }
    }
}
