using SOLID_Goose_Game.Business.Cases.Interfaces;
using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;
using SOLID_Goose_Game.Logging;

namespace SOLID_Goose_Game.Business.Cases.Classes
{
    public class InnCase : IInnCase
    {
        private ILogger logger;
        public int ID { get; set; }
        public CaseType Type { get; set; }

        public InnCase(int id, CaseType type, ILogger logger)
        {
            ID = id;
            Type = type;
            this.logger = logger;
        }

        public void ResolveCase(Player player)
        {
            ApplyInnCaseEffect(player);
            DisplayInnCaseEffectMessage(player);
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

        public void DisplayInnCaseEffectMessage(Player player)
        {
            if (player.EffectDurationInTurns == 1)
            {
                logger.LogMessage($"{player.PlayerName} landde op de herberg en blijft er {player.EffectDurationInTurns} beurt slapen.");
            } else if (player.EffectDurationInTurns == 0)
            {
                logger.LogMessage($"{player.PlayerName} is nog in de herberg en gaat volgende beurt terug verder.");
            }
        }
    }
}
