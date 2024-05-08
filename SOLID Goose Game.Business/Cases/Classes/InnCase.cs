using SOLID_Goose_Game.Business.Cases.Interfaces;
using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;

namespace SOLID_Goose_Game.Business.Cases.Classes
{
    public class InnCase : IInnCase
    {
        IGameState gameState;
        public int ID { get; set; }
        public CaseType Type { get; set; }

        public InnCase(int id, CaseType type, IGameState gameState)
        {
            ID = id;
            Type = type;
            this.gameState = gameState;
        }

        public void ResolveCase(Player player)
        {
            ApplyInnCaseEffect(player);
            gameState.PrintGameState(Type.ToString());
        }
        public void ApplyInnCaseEffect(Player player)
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
