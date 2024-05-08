﻿using SOLID_Goose_Game.Business.Cases.Interfaces;
using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;
using SOLID_Goose_Game.Logging;

namespace SOLID_Goose_Game.Business.Cases.Classes
{
    public class InnCase : IInnCase
    {
        private ILogger logger;
        public int ID { get; set; }
        public CaseType Type { get; set; }

        public InnCase(int id, CaseType type, ILogger logger)
        {
            ID = id;
            Type = type;
            this.logger = logger;
        }

        public void ResolveCase(Player player)
        {
            ApplyInnCaseEffect(player);
            logger.LogMessage(this.Type.ToString());
        }
        public void ApplyInnCaseEffect(Player player)
        {
            switch (player.CanMove)
            {
                case true:
                    player.CanMove = false;
                    player.EffectDurationInTurns = 1;
                    break;
                case false:
                    player.CanMove = true;
                    player.EffectDurationInTurns--;
                    break;
            }

        }
    }
}
