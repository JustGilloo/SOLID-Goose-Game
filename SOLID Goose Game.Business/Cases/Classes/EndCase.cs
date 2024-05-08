using SOLID_Goose_Game.Business.Cases.Interfaces;
using SOLID_Goose_Game.Business.GameBoard;
using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Cases.Classes
{
    public class EndCase : IEndCase
    {
        private IGameState gameState;
        private IGameBoard gameBoard;
        public int ID { get; set; }
        public CaseType Type { get; set; }
        

        public EndCase(int id, CaseType type, IGameState gameState, IGameBoard gameboard)
        {
            ID = id;
            Type = type;
            this.gameState = gameState;
            this.gameBoard = gameboard;
        }

        public void ResolveCase(Player player)
        {
            CheckPlayerRollExceedsID(player);
            if (gameState.IsGameOver == false)
            {
                gameState.PrintGameState($"{player.PlayerName} gooide hoger dan 63 en werd teruggestuurd naar vakje {player.CurrentPosition}");
                gameBoard.HandleCaseType(player);
            } else
            {
                gameState.PrintGameState($"{player.PlayerName} kwam aan op vakje {player.CurrentPosition}! {player.PlayerName} wint!");
            }
        }
        public void CheckPlayerRollExceedsID(Player player)
        {
            if (player.CurrentPosition > 63) 
            {
                MovePlayerBack(player);
            } else
            {
                gameState.IsGameOver = true;
            }
        }
        public void MovePlayerBack(Player player)
        {
            int spacesToGoBack = player.CurrentPosition - 63;
            player.CurrentPosition = 63 - spacesToGoBack;
        }
    }
}
