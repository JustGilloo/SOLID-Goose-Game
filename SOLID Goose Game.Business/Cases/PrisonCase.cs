using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Cases
{
    public class PrisonCase : IPrisonCase
    {
        IGameState gameState;
        public int ID { get; set; }
        public CaseType Type { get; set; }

        public PrisonCase(int id, CaseType type, IGameState gameState)
        {
            this.ID = id;
            this.Type = type;
            this.gameState = gameState;
        }

        public void ResolveCase(Player player)
        {
            ApplyPrisonCaseEffect(player);
            this.gameState.PrintGameState(this.Type.ToString());
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
