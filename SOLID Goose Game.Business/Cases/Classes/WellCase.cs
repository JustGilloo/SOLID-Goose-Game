using SOLID_Goose_Game.Business.Cases.Interfaces;
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
            DisplayWellEffectMesage(player);
        }
        public bool CheckIfWellContainsPlayer()
        {
            return TrappedPlayerArray[0] != null;
        }
        public void TrapPlayerInWell(Player player)
        {
            player.CanMove = false;
            player.EffectDurationInTurns = -1;
            TrappedPlayerArray[0] = player;
        }
        public void EmptyWell()
        {
            TrappedPlayerArray[0].CanMove = true;
            TrappedPlayerArray[0].EffectDurationInTurns = 0;
            TrappedPlayerArray[0] = null;
        }

        public void DisplayWellEffectMesage(Player player)
        {
            if (player.StartingPosition < this.ID)
            {
                logger.LogMessage($"{player.PlayerName} landde op vakje {player.CurrentPosition} en viel in de waterput! Hopelijk kan iemand je redden door op de waterput te landen!");
            }
            else if (player.EffectDurationInTurns == -1)
            {
                logger.LogMessage($"{player.PlayerName} zit vast in de waterput! Hopelijk kan iemand je redden door op de waterput te landen!");
            }
        }
    }
}
