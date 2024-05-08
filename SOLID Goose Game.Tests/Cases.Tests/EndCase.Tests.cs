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
    internal class EndCaseTests
    {
        [Test]
        public void AssertsIfPlayerMovedOntoCase63ExactlyAndChangesGameOverBoolean()
        {
            //Arrange
            ICaseFactory caseFactory = new CaseFactory();
            IGameState gameState = new GameState();
            Player player = new Player("Speler");
            player.CurrentPosition = 60;
            player.StartingPosition = 60;
            IGameBoard gameBoard = new GameBoard(caseFactory, gameState);
            int[] dieRolls = [2, 1];

            bool expectedGameOverState = true;

            //Act
            gameBoard.FillInBoardCases();
            player.DetermineNewPosition(dieRolls);
            gameBoard.HandleCaseType(player);

            //Assert
            Assert.AreEqual(expectedGameOverState, gameState.IsGameOver);
        }
        [Test]
        public void AssertsThatPlayerIsMovedBackEqualToDifferenceIfEndPositionIsHigherThan63()
        {
            //Arrange
            ICaseFactory caseFactory = new CaseFactory();
            IGameState gameState = new GameState();
            Player player = new Player("Speler");
            player.CurrentPosition = 62;
            player.StartingPosition = 62;
            IGameBoard gameBoard = new GameBoard(caseFactory, gameState);
            int[] dieRolls = [2, 3];

            int expectedPosition = 49;

            //Act
            gameBoard.FillInBoardCases();
            player.DetermineNewPosition(dieRolls);
            gameBoard.HandleCaseType(player);

            //Assert
            Assert.AreEqual(expectedPosition, player.CurrentPosition);
        }
    }
}
