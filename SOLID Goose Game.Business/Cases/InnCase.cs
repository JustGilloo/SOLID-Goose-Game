using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;

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
            ResolveInnCase(player);
            this.gameState.PrintGameState(this.Type.ToString());
        }
        public void ResolveInnCase(Player player)
        {
            switch (player.CanMove)
            {
                case true:
                    player.CanMove = false;
                    player.EffectDurationInTurns = 1;
                    break;
                case false:
                    player.CanMove = true;
                    player.EffectDurationInTurns--;
                    break;
            }

        }
    }
}
