using Moq;
using SOLID_Goose_Game.Business.Cases;
using SOLID_Goose_Game.Business.Cases.Interfaces;
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
    public class DeathCase
    {
        [Test] 
        public void CheckIfDeathCaseResetsPlayerTo0()
        {
            //Arrange
            ICaseFactory caseFactory = new CaseFactory();
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            GameState gameState = new GameState(mockLogger.Object);
            Player player = new Player("Speler");
            player.CurrentPosition = 58;
            player.StartingPosition = 55;
            IGameBoard gameBoard = new GameBoard(caseFactory, gameState);

            int expectedPosition = 0;

            //Act
            gameBoard.FillInBoardCases();
            gameBoard.HandleCaseType(player);

            //Assert
            Assert.AreEqual(expectedPosition, player.CurrentPosition);
            //int expectedSpace = 0;
            //Mock<IGameState> gameState = new Mock<IGameState>();
            //IPlayer player = new Player("Speler");
            //IDeathCase deathCase = new DeathCase(5, gameState.Object);
            //deathCase.ResolveCase(player);
            //Assert.AreEqual(expectedSpace, player.CurrentPosition);
        }
    }
}
