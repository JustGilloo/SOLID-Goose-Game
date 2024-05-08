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
    public class EndCase : IEndCase
    {
        private IGameBoard gameBoard;
        private ILogger logger;
        public int ID { get; set; }
        public CaseType Type { get; set; }
        

        public EndCase(int id, CaseType type, IGameBoard gameboard, ILogger logger)
        {
            ID = id;
            Type = type;
            this.gameBoard = gameboard;
            this.logger = logger;
        }

        public void ResolveCase(Player player)
        {
            CheckPlayerRollExceedsID(player);
            if (gameBoard.IsFinishReached == false)
            {
                this.logger.LogMessage($"{player.PlayerName} gooide hoger dan 63 en werd teruggestuurd naar vakje {player.CurrentPosition}");
                gameBoard.HandleCaseType(player);
            } else
            {
                this.logger.LogMessage($"{player.PlayerName} kwam aan op vakje {player.CurrentPosition}! {player.PlayerName} wint!");
            }
        }
        public void CheckPlayerRollExceedsID(Player player)
        {
            if (player.CurrentPosition > 63) 
            {
                MovePlayerBack(player);
            } else
            {
                gameBoard.IsFinishReached = true;
            }
        }
        public void MovePlayerBack(Player player)
        {
            int spacesToGoBack = player.CurrentPosition - 63;
            player.CurrentPosition = 63 - spacesToGoBack;
        }
    }
}
