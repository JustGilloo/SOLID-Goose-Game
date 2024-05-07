using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Cases
{
    public class InnCase : IInnCase
    {
        IGameState gameState;
        public int ID { get; set; }
        public CaseType Type { get; set; }

        public InnCase(int id, CaseType type, IGameState gameState)
        {
            this.ID = id;
            this.Type = type;
            this.gameState = gameState;
        }

        public void ResolveCase(Player player)
        {
            this.gameState.PrintGameState(this.Type.ToString());
        }
        public void ResolveInnCase(Player player)
        {
            player.EffectDurationInTurns = 1;
            player.CanMove = false;
            while (player.EffectDurationInTurns > 0)
            {
                player.EffectDurationInTurns--;
            }
            if (player.EffectDurationInTurns == 0)
            {
                player.CanMove = true;
            }
        }
    }
}
