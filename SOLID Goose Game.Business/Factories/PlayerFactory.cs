using SOLID_Goose_Game.Business.Players;

namespace SOLID_Goose_Game.Business.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer Create(PlayerType playerType, string name)
        {
            switch (playerType)
            {
                case PlayerType.Regular:
                    return new Player(name);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
