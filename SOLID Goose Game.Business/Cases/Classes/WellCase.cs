using SOLID_Goose_Game.Business.Cases.Interfaces;
using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;

namespace SOLID_Goose_Game.Business.Cases.Classes
{
    public class WellCase : IWellCase
    {
        IGameState gameState;
        public int ID { get; set; }
        public CaseType Type { get; set; }
        public Player[] TrappedPlayerArray { get; set; }

        public WellCase(int id, CaseType type, IGameState gameState)
        {
            ID = id;
            Type = type;
            this.gameState = gameState;
            TrappedPlayerArray = new Player[1];
        }

        public void ResolveCase(Player player)
        {
            if (CheckIfWellContainsPlayer())
            {
                EmptyWell();
            }
            TrapPlayerInWell(player);
            gameState.PrintGameState(Type.ToString());
        }
        public bool CheckIfWellContainsPlayer()
        {
            return TrappedPlayerArray[0] != null;
        }
        public void TrapPlayerInWell(Player player)
        {
            player.CanMove = false;
            TrappedPlayerArray[0] = player;
        }
        public void EmptyWell()
        {
            TrappedPlayerArray[0].CanMove = true;
            TrappedPlayerArray[0] = null;
        }
    }
}
