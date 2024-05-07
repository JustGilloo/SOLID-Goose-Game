using SOLID_Goose_Game.Business.Factories;
using SOLID_Goose_Game.Business.GameBoard;
using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;
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
            IGameState gameState = new GameState();
            Player player = new Player();
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
