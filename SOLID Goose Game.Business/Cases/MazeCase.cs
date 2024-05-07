using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Cases
{
    public class MazeCase : IMazeCase
    {
        IGameState gameState;
        public int ID { get; set; }
        public CaseType Type { get; set; }

        public MazeCase(int id, CaseType type, IGameState gameState)
        {
            this.ID = id;
            this.Type = type;
            this.gameState = gameState;
        }

        public void ResolveCase(Player player)
        {
            ResolveMazeCase(player);
            this.gameState.PrintGameState(this.Type.ToString());
        }
        public void ResolveMazeCase(Player player)
        {
            player.CurrentPosition -= 3;
            player.StartingPosition = player.CurrentPosition;
        }
    }
}
