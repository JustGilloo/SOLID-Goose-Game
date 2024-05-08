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
    public class MazeCase
    {
        [Test]
        public void AssertsIfMazeCorrectlySetsPlayerPositionTo39()
        {
            //Arrange
            ICaseFactory caseFactory = new CaseFactory();
            Mock<ILogger> logger = new Mock<ILogger>();
            IGameState gameState = new GameState((ILogger)logger);
            Player player = new Player("Speler");
            player.CurrentPosition = 37;
            player.StartingPosition = 37;
            int[] dieRolls = new int[2];
            dieRolls = [2, 3];
            IGameBoard gameBoard = new GameBoard(caseFactory, gameState);

            int expectedPosition = 39;

            //Act
            gameBoard.FillInBoardCases();
            player.DetermineNewPosition(dieRolls);
            gameBoard.HandleCaseType(player);

            //Assert
            Assert.AreEqual(expectedPosition, player.CurrentPosition);
        }
    }
}
