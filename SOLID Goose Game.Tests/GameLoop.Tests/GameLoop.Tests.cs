using SOLID_Goose_Game.Business.Dice;
using SOLID_Goose_Game.Business.Factories;
using SOLID_Goose_Game.Business.GameBoard;
using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Input;
using SOLID_Goose_Game.Logging;
using SOLID_Goose_Game.UserInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Tests.GameLoop.Tests
{
    internal class GameLoopTests
    {
        [Ignore("Unfinished due to lacking console input capabilities")]
        [Test]
        public void AssertsThatGameSuccesfullySetsUpAndPlaysUntilAPlayerReachesTheFinish()
        {
            //Arrange
            ICaseFactory caseFactory = new CaseFactory();
            ILogger logger = new ConsoleLogger();
            IPlayerFactory playerFactory = new PlayerFactory();
            IUserInput userInput = new ConsoleInputter();
            IGameBoard gameBoard = new GameBoard(caseFactory, logger);
            IDiceRollerService diceRoller = new DiceRollerService();
            IGameState gameState = new GameState(logger, userInput, gameBoard, playerFactory, diceRoller);

            bool expectedResult = false;

            //Act
            gameState.SetupGame();
            gameState.GameLoop();

            //Assert
            Assert.AreEqual(expectedResult, gameBoard.IsFinishReached);
        }
    }
}
