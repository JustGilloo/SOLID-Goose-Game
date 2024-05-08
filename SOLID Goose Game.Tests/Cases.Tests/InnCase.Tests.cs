using Moq;
using SOLID_Goose_Game.Business.Factories;
using SOLID_Goose_Game.Business.GameBoard;
using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;
using SOLID_Goose_Game.Logging;

namespace SOLID_Goose_Game.Tests.Cases.Tests
{
    internal class InnCase
    {
        [Test]
        public void AssertsThatThePlayerCannotMoveFor1Turn()
        {
            //Arrange
            ICaseFactory caseFactory = new CaseFactory();
            Mock<ILogger> logger = new Mock<ILogger>();
            IGameState gameState = new GameState((ILogger)logger);
            Player player = new Player("Speler");
            player.StartingPosition = 17;
            player.CurrentPosition = 17;
            int[] dieRolls = new int[2];
            dieRolls = [1, 1];
            IGameBoard gameBoard = new GameBoard(caseFactory, gameState);

            int expectedPosition = 19;

            //Act
            gameBoard.FillInBoardCases();
            player.DetermineNewPosition(dieRolls);
            gameBoard.HandleCaseType(player);

            //Assert
            Assert.AreEqual(expectedPosition, player.CurrentPosition);
        }
    }
}
