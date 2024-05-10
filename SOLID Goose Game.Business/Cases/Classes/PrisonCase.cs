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
            DisplayPrisonEffectTurnMessage(player);
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

        public void DisplayPrisonEffectTurnMessage(Player player)
        {
            if (player.EffectDurationInTurns == 3)
            {
                logger.LogMessage($"{player.PlayerName} landde op de gevangenis en blijft er {player.EffectDurationInTurns} beurten opgesloten.");
            } else if (player.CanMove == false)
            {
                logger.LogMessage($"{player.PlayerName} staat nog op de gevangenis en blijft er nog {player.EffectDurationInTurns} beurt(en) opgesloten.");
            } else if (player.EffectDurationInTurns == 0)
            {
                logger.LogMessage($"{player.PlayerName} staat nog op de gevangenis en komt volgende beurt vrij!.");
            }
        }
    }
}
