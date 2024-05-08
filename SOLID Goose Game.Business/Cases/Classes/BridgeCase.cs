using SOLID_Goose_Game.Business.Cases.Interfaces;
using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Cases.Classes
{
    public class BridgeCase : IBridgeCase
    {
        private IGameState gameState;
        public int ID { get; set; }
        public CaseType Type { get; set; }

        public BridgeCase(int id, CaseType type, IGameState gameState)
        {
            ID = id;
            Type = type;
            this.gameState = gameState;
        }

        public void ResolveCase(Player player)
        {
            ApplyBridgeCaseEffect(player);
            gameState.PrintGameState($"{player.PlayerName} landde op een brug en sprong meteen naar vakje {player.CurrentPosition}.");
        }

        public void ApplyBridgeCaseEffect(Player player)
        {
            player.CurrentPosition *= 2;
            player.StartingPosition = player.CurrentPosition;
        }
    }
}
