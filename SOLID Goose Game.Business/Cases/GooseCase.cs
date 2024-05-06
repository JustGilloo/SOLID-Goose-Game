using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Cases
{
    public class GooseCase : IGooseCase
    {
        IGameState gameState;
        public int ID { get; set; }
        public CaseType Type { get; set; }

        public GooseCase(int id, CaseType type, IGameState gameState)
        {
            this.ID = id;
            this.Type = type;
            this.gameState = gameState;
        }

        public void ResolveCase(Player player)
        {
            this.gameState.PrintGameState();
        }
    }
}
