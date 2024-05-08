using SOLID_Goose_Game.Business.Cases.Interfaces;
using SOLID_Goose_Game.Business.GameBoard;
using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;
using SOLID_Goose_Game.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Cases.Classes
{
    public class GooseCase : IGooseCase
    {
        private ILogger logger;
        private IGameBoard gameBoard;

        public int ID { get; set; }
        public CaseType Type { get; set; }

        public GooseCase(int id, CaseType type, IGameBoard gameBoard, ILogger logger)
        {
            ID = id;
            Type = type;
            this.logger = logger;
            this.gameBoard = gameBoard;
        }

        public void ResolveCase(Player player)
        {
            if (player.StartingPosition == 0 && this.ID == 9)
            {
                HandleGooseCaseException(player);
            }
            else
            {
                DeterminePlayerMovementDirection(player);
            }
            logger.LogMessage($"{player.PlayerName} kwam terecht op een Ganzenvakje en werd gestuurd naar vakje {player.CurrentPosition}.");
            gameBoard.HandleCaseType(player);
        }
        public void DeterminePlayerMovementDirection(Player player)
        {
            if (ID > player.StartingPosition)
            {
                MovePlayerForwards(player);
            }
            else
            {
                MovePlayerBackwards(player);
            }
        }
        public void HandleGooseCaseException(Player player)
        {
            if (player.DiceResultArray == (int[])[4, 5] && player.DiceResultArray == (int[])[5, 4])
            {
                player.CurrentPosition = 26;
            } else
            {
                player.CurrentPosition = 53;
            }
        }
        public void MovePlayerForwards(Player player)
        {
            player.DetermineNewPosition(player.DiceResultArray);
        }
        public void MovePlayerBackwards(Player player)
        {
            player.CurrentPosition -= player.DiceResultArray.Sum();
        }
    }
}
