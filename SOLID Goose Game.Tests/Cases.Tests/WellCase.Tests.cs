using Moq;
using SOLID_Goose_Game.Business.Cases.Classes;
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
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Tests.Cases.Tests
{
    internal class WellCaseTests
    {
        [Test]
        public void AssertsThatTheWellCaseCorrectlyTakesInAPlayer()
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
            int[] dieRolls = new int[2];
            dieRolls = [4, 2];
            player.CurrentPosition = 25;
            player.StartingPosition = 25;

            Player[] expectedTrappedPlayer = [player];

            //Act
            gameBoard.FillInBoardCases();
            WellCase wellCase = (WellCase)gameBoard.Boardsize[31];
            player.DetermineNewPosition(dieRolls);
            gameBoard.HandleCaseType(player);

            //Assert
            Assert.AreEqual(expectedTrappedPlayer[0], wellCase.TrappedPlayerArray[0]);
        }
        [Test]
        public void AssertsThatAPlayerArrivingOnWellCaseAsItIsOccupiedSuccesfullyGetsTrapped()
        {
            //Arrange
            ICaseFactory caseFactory = new CaseFactory();
            ILogger logger = new ConsoleLogger();
            IPlayerFactory playerFactory = new PlayerFactory();
            IUserInput userInput = new ConsoleInputter();
            IGameBoard gameBoard = new GameBoard(caseFactory, logger);
            IDiceRollerService diceRoller = new DiceRollerService();
            IGameState gameState = new GameState(logger, userInput, gameBoard, playerFactory, diceRoller);
            Player player1 = new Player("Speler 1");
            Player player2 = new Player("Speler 2");
            int[] dieRolls = new int[2];
            dieRolls = [4, 2];

            player1.CurrentPosition = 25;
            player1.StartingPosition = 25;
            player2.CurrentPosition = 25;
            player2.StartingPosition = 25;

            Player[] expectedTrappedPlayer = [player2];

            //Act
            gameBoard.FillInBoardCases();
            WellCase wellCase = (WellCase)gameBoard.Boardsize[31];
            player1.DetermineNewPosition(dieRolls);
            gameBoard.HandleCaseType(player1);
            player2.DetermineNewPosition(dieRolls);
            gameBoard.HandleCaseType(player2);

            //Assert
            Assert.AreEqual(expectedTrappedPlayer[0], wellCase.TrappedPlayerArray[0]);
            Assert.IsFalse(player2.CanMove);
        }
        [Test]
        public void AssertsThatAPlayerWhoGotFreedByAnotherPlayerCanMove()
        {
            //Arrange
            ICaseFactory caseFactory = new CaseFactory();
            ILogger logger = new ConsoleLogger();
            IPlayerFactory playerFactory = new PlayerFactory();
            IUserInput userInput = new ConsoleInputter();
            IGameBoard gameBoard = new GameBoard(caseFactory, logger);
            IDiceRollerService diceRoller = new DiceRollerService();
            IGameState gameState = new GameState(logger, userInput, gameBoard, playerFactory, diceRoller);
            Player player1 = new Player("Speler 1");
            Player player2 = new Player("Speler 2");
            int[] dieRolls = new int[2];
            dieRolls = [4, 2];

            player1.CurrentPosition = 25;
            player1.StartingPosition = 25;
            player2.CurrentPosition = 25;
            player2.StartingPosition = 25;

            Player[] expectedTrappedPlayer = [player2];

            //Act
            gameBoard.FillInBoardCases();
            WellCase wellCase = (WellCase)gameBoard.Boardsize[31];
            player1.DetermineNewPosition(dieRolls);
            gameBoard.HandleCaseType(player1);
            player2.DetermineNewPosition(dieRolls);
            gameBoard.HandleCaseType(player2);

            //Assert
            Assert.IsTrue(player1.CanMove);
        }
    }
}
