using Moq;
using SOLID_Goose_Game.Business.Dice;
using SOLID_Goose_Game.Business.Factories;
using SOLID_Goose_Game.Business.GameBoard;
using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;
using SOLID_Goose_Game.Input;
using SOLID_Goose_Game.Logging;
using SOLID_Goose_Game.UserInput;

namespace SOLID_Goose_Game.Tests.Cases.Tests
{
    internal class InnCase
    {
        [Test]
        public void AssertsThatThePlayerCannotMoveFor1Turn()
        {
            //Arrange
            ICaseFactory caseFactory = new CaseFactory();
            ILogger logger = new ConsoleLogger();
            IPlayerFactory playerFactory = new PlayerFactory();
            IUserInput userInput = new ConsoleInputter();
            IGameBoard gameBoard = new GameBoard(caseFactory, logger);
            IDiceRollerService diceRoller = new DiceRollerService();
            IGameState gameState = new GameState(logger, userInput, gameBoard, playerFactory, diceRoller);
            Player player = new Player("Speler");
            player.StartingPosition = 17;
            player.CurrentPosition = 17;
            int[] dieRolls = new int[2];
            dieRolls = [1, 1];

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
