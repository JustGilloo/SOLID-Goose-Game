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
    internal class BridgeCase
    {
        [Test]
        public void CheckIBridgeCaseMovesPlayerTo12()
        {
            //Arrange
            ICaseFactory caseFactory = new CaseFactory();
            Mock<ILogger> logger = new Mock<ILogger>();
            IGameState gameState = new GameState(logger.Object);
            Player player = new Player("Speler");
            player.CurrentPosition = 6;
            player.StartingPosition = 0;
            IGameBoard gameBoard = new GameBoard(caseFactory, gameState);

            int expectedPosition = 12;

            //Act
            gameBoard.FillInBoardCases();
            gameBoard.HandleCaseType(player);

            //Assert
            Assert.AreEqual(expectedPosition, player.CurrentPosition);
        }
    }
}
