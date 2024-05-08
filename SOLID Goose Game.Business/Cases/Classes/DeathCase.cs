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
    public class DeathCase : IDeathCase
    {
        private ILogger logger;
        public int ID { get; set; }
        public CaseType Type { get; set; }

        public DeathCase(int id, CaseType type, ILogger logger)
        {
            ID = id;
            this.logger = logger;
        }

        public void ResolveCase(Player player)
        {
            ApplyDeathCaseEffect(player);
            logger.LogMessage($"{player.PlayerName} landde op de guillotine! U bent dood, uw nieuw leven begint op vakje {player.CurrentPosition}.");
        }
        public void ApplyDeathCaseEffect(Player player)
        {
            player.CurrentPosition = 0;
            player.StartingPosition = 0;
        }
    }
}
