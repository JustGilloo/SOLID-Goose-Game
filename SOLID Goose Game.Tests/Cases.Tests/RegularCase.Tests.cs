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
    internal class RegularCase
    {
        [Test]
        public void AssertsThatPlayerCorrectlyLandsOnRegularCase30WithCorrectStandardOutput()
        {
            //Arrange
            ICaseFactory caseFactory = new CaseFactory();
            ILogger logger = new ConsoleLogger();
            IPlayerFactory playerFactory = new PlayerFactory();
            IUserInput userInput = new ConsoleInputter();
            IGameBoard gameBoard = new GameBoard(caseFactory, logger);
            IDiceRollerService diceRoller = new DiceRollerService();
            IGameState gameState = new GameState(logger, userInput, gameBoard, playerFactory, diceRoller);
            Player player = new Player("Speler 1");
            int[] dieRolls = new int[2];
            dieRolls = [3, 2];

            player.CurrentPosition = 25;
            player.StartingPosition = 25;

            int expectedPosition = 30;

            //Act
            gameBoard.FillInBoardCases();
            player.DetermineNewPosition(dieRolls);
            gameBoard.HandleCaseType(player);

            //Assert
            Assert.AreEqual(expectedPosition, player.CurrentPosition);
        }
    }
}
