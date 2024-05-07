using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Cases
{
    public class DeathCase : IDeathCase
    {
        IGameState gameState;
        public int ID { get; set; }
        public CaseType Type { get; set; }

        public DeathCase(int id, CaseType type, IGameState gameState)
        {
            this.ID = id;
            this.Type = type;
            this.gameState = gameState;
        }

        public void ResolveCase(Player player)
        {
            ApplyDeathCaseEffect(player);
            this.gameState.PrintGameState($"{player.PlayerName} landde op de guillotine! U bent dood, uw nieuw leven begint op vakje {player.CurrentPosition}.");
        }
        public void ApplyDeathCaseEffect(Player player)
        {
            player.CurrentPosition = 0;
            player.StartingPosition = 0;
        }
    }
}
