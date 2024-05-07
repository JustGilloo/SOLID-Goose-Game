using SOLID_Goose_Game.Business.Cases;
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
    internal class WellCaseTests
    {
        [Test]
        public void AssertsThatTheWellCaseCorrectlyTakesInAPlayer()
        {
            //Arrange
            ICaseFactory caseFactory = new CaseFactory();
            IGameState gameState = new GameState();
            Player player = new Player("Speler");
            int[] dieRolls = new int[2];
            dieRolls = [4, 2];
            player.CurrentPosition = 25;
            player.StartingPosition = 25;
            IGameBoard gameBoard = new GameBoard(caseFactory, gameState);

            Player[] trappedPlayer = [player];

            //Act
            gameBoard.FillInBoardCases();
            WellCase wellCase = (WellCase)gameBoard.Boardsize[31];
            player.DetermineNewPosition(dieRolls);
            gameBoard.HandleCaseType(player);

            //Assert
            Assert.AreEqual(trappedPlayer[0], wellCase.StuckPlayerArray[0]);
        }
        [Test]
        public void AssertsThatAPlayerArrivingOnWellCaseAsItIsOccupiedSuccesfullyGetsTrapped()
        {

        }
    }
}
