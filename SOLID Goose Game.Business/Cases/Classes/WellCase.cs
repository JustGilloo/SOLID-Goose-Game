using SOLID_Goose_Game.Business.Cases.Interfaces;
using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;
using SOLID_Goose_Game.Logging;

namespace SOLID_Goose_Game.Business.Cases.Classes
{
    public class WellCase : IWellCase
    {
        private ILogger logger;
        public int ID { get; set; }
        public CaseType Type { get; set; }
        public Player[] TrappedPlayerArray { get; set; }

        public WellCase(int id, CaseType type, ILogger logger)
        {
            ID = id;
            Type = type;
            this.logger = logger;
            TrappedPlayerArray = new Player[1];
        }

        public void ResolveCase(Player player)
        {
            if (CheckIfWellContainsPlayer())
            {
                EmptyWell();
            }
            TrapPlayerInWell(player);
            logger.LogMessage($"{player.PlayerName} landde op vakje {player.CurrentPosition} en viel in de waterput! Hopelijk kan iemand je redden door op de waterput te landen!");
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
