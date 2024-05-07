using SOLID_Goose_Game.Business.Factories;
using SOLID_Goose_Game.Business.GameBoard;
using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;

namespace SOLID_Goose_Game.Tests.Cases.Tests
{
    internal class InnCase
    {
        [Test]
        public void AssertsThatThePlayerCannotMoveFor1Turn()
        {
            //Arrange
            ICaseFactory caseFactory = new CaseFactory();
            IGameState gameState = new GameState();
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
            //following is for MazeCase Resolve
           


            //Assert
            Assert.AreEqual(expectedPosition, player.CurrentPosition);
        }
    }
}
