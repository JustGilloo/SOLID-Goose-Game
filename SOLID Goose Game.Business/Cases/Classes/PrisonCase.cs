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
    public class PrisonCase : IPrisonCase
    {
        private ILogger logger;
        public int ID { get; set; }
        public CaseType Type { get; set; }

        public PrisonCase(int id, CaseType type, ILogger logger)
        {
            ID = id;
            Type = type;
            this.logger = logger;
        }

        public void ResolveCase(Player player)
        {
            ApplyPrisonCaseEffect(player);
            logger.LogMessage($"{player.PlayerName} landde op de gevangenis en blijft er {player.EffectDurationInTurns} beurten opgesloten.");
        }

        public void ApplyPrisonCaseEffect(Player player)
        {
            switch (player.CanMove)
            {
                case true:
                    player.CanMove = false;
                    player.EffectDurationInTurns = 3;
                    break;
                case false:
                    player.EffectDurationInTurns--;
                    if (player.EffectDurationInTurns == 0)
                    {
                        player.CanMove = true;
                    }
                    break;
            }
        }
    }
}
