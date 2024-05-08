using Moq;
using SOLID_Goose_Game.Business.Factories;
using SOLID_Goose_Game.Business.GameBoard;
using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;
using SOLID_Goose_Game.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Tests.Cases.Tests
{
    internal class GooseCaseTests
    {
        [Test]
        public void AssertsIfPlayerMovementDirectionNeedsToBeForwardWhenGooseCaseIsTriggered()
        {
            //Arrange
            ICaseFactory caseFactory = new CaseFactory();
            Mock<ILogger> logger = new Mock<ILogger>();
            IGameState gameState = new GameState((ILogger)logger);
            Player player = new Player("Speler");
            player.CurrentPosition = 0;
            player.StartingPosition = 0;
            int[] dieRolls = [2, 3];
            IGameBoard gameBoard = new GameBoard(caseFactory, gameState);

            int expectedPosition = 10;

            //Act
            gameBoard.FillInBoardCases();
            player.DetermineNewPosition(dieRolls);
            gameBoard.HandleCaseType(player);


            //Assert
            Assert.AreEqual(expectedPosition, player.CurrentPosition);
        }
        [Test]
        public void AssertsIfPlayerMovementDirectionNeedsToBeBackwardsWhenGooseCaseIsTriggered()
        {
            //Arrange
            ICaseFactory caseFactory = new CaseFactory();
            Mock<ILogger> logger = new Mock<ILogger>();
            IGameState gameState = new GameState((ILogger)logger);
            Player player = new Player("Speler");
            player.CurrentPosition = 62;
            player.StartingPosition = 62;
            int[] dieRolls = [2, 3];
            IGameBoard gameBoard = new GameBoard(caseFactory, gameState);

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
