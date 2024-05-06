using SOLID_Goose_Game.Business.Factories;
using SOLID_Goose_Game.Business.GameBoard;
using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Tests.Cases.Tests
{
    public class DeathCase
    {
        [Test] 
        public void CheckIfDeathCaseResetsPlayerTo0()
        {
            //Arrange
            ICaseFactory caseFactory = new CaseFactory();
            IGameState gameState = new GameState();
            Player player = new Player();
            player.CurrentPosition = 58;
            player.StartingPosition = 55;
            IGameBoard gameBoard = new GameBoard(caseFactory, gameState);

            int expectedPosition = 0;

            //Act
            gameBoard.FillInBoardCases();
            gameBoard.HandleCaseType(player);

            //Assert
            Assert.AreEqual(expectedPosition, player.CurrentPosition);
        }
    }
}
