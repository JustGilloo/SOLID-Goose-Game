using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;

namespace SOLID_Goose_Game.Business.Cases
{
    public class WellCase : IWellCase
    {
        IGameState gameState;
        public int ID { get; set; }
        public CaseType Type { get; set; }
        public Player[] StuckPlayerArray { get; set; }

        public WellCase(int id, CaseType type, IGameState gameState)
        {
            this.ID = id;
            this.Type = type;
            this.gameState = gameState;
            this.StuckPlayerArray = new Player[1];
        }

        public void ResolveCase(Player player)
        {
            if (CheckIfWellContainsPlayer())
            {
                EmptyWell();
            }
            TrapPlayerInWell(player);
            this.gameState.PrintGameState(this.Type.ToString());
        }
        public bool CheckIfWellContainsPlayer()
        {
            return (this.StuckPlayerArray[0] != null);
        }
        public void TrapPlayerInWell(Player player)
        {
            player.CanMove = false;
            this.StuckPlayerArray[0] = player;
        }
        public void EmptyWell()
        {
            this.StuckPlayerArray[0].CanMove = true;
            this.StuckPlayerArray = null;
        }
    }
}
