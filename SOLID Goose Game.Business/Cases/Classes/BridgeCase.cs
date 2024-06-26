﻿using SOLID_Goose_Game.Business.Cases.Interfaces;
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
    public class BridgeCase : IBridgeCase
    {
        private ILogger logger;
        public int ID { get; set; }
        public CaseType Type { get; set; }

        public BridgeCase(int id, CaseType type, ILogger logger)
        {
            ID = id;
            Type = type;
            this.logger = logger;
        }

        public void ResolveCase(Player player)
        {
            ApplyBridgeCaseEffect(player);
            logger.LogMessage($"{player.PlayerName} landde op een brug en sprong meteen naar vakje {player.CurrentPosition}.");
        }

        public void ApplyBridgeCaseEffect(Player player)
        {
            player.CurrentPosition *= 2;
            player.StartingPosition = player.CurrentPosition;
        }
    }
}
