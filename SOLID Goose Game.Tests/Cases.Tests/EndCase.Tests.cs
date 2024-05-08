using Moq;
using SOLID_Goose_Game.Business.Dice;
using SOLID_Goose_Game.Business.Factories;
using SOLID_Goose_Game.Business.GameBoard;
using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;
using SOLID_Goose_Game.Input;
using SOLID_Goose_Game.Logging;
using SOLID_Goose_Game.UserInput;
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
            ILogger logger = new ConsoleLogger();
            IPlayerFactory playerFactory = new PlayerFactory();
            IUserInput userInput = new ConsoleInputter();
            IGameBoard gameBoard = new GameBoard(caseFactory, logger);
            IDiceRollerService diceRoller = new DiceRollerService();
            IGameState gameState = new GameState(logger, userInput, gameBoard, playerFactory, diceRoller);
            Player player = new Player("Speler");
            player.CurrentPosition = 60;
            player.StartingPosition = 60;
            int[] dieRolls = [2, 1];

            bool expectedGameOverState = true;

            //Act
            gameBoard.FillInBoardCases();
            player.DetermineNewPosition(dieRolls);
            gameBoard.HandleCaseType(player);

            //Assert
            Assert.AreEqual(expectedGameOverState, gameBoard.IsFinishReached);
        }
        [Test]
        public void AssertsThatPlayerIsMovedBackEqualToDifferenceIfEndPositionIsHigherThan63()
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
            player.CurrentPosition = 62;
            player.StartingPosition = 62;
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
