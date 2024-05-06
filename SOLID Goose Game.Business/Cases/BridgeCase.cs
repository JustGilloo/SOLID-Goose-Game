using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Cases
{
    public class BridgeCase : IBridgeCase
    {
        private IGameState gameState;
        public int ID { get; set; }
        public CaseType Type { get; set; }

        public BridgeCase(int id, CaseType type, IGameState gameState)
        {
            this.ID = id;
            this.Type = type;
            this.gameState = gameState;
        }

        public void ResolveCase(Player player)
        {
            ResolveBridgeCase(player);
            this.gameState.PrintGameState($"{player.PlayerName} landde op een brug en sprong meteen naar vakje {player.CurrentPosition}.");
        }

        public void ResolveBridgeCase(Player player)
        {
            player.CurrentPosition *= 2;
            player.StartingPosition = player.CurrentPosition;
        }
    }
}
