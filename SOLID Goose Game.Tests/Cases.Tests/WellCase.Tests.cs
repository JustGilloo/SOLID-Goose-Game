using SOLID_Goose_Game.Business.Cases.Classes;
using SOLID_Goose_Game.Business.Factories;
using SOLID_Goose_Game.Business.GameBoard;
using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;
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
            IGameState gameState = new GameState();
            Player player = new Player("Speler");
            int[] dieRolls = new int[2];
            dieRolls = [4, 2];
            player.CurrentPosition = 25;
            player.StartingPosition = 25;
            IGameBoard gameBoard = new GameBoard(caseFactory, gameState);

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
            IGameState gameState = new GameState();
            Player player1 = new Player("Speler 1");
            Player player2 = new Player("Speler 2");
            int[] dieRolls = new int[2];
            dieRolls = [4, 2];
            player1.CurrentPosition = 25;
            player1.StartingPosition = 25;
            player2.CurrentPosition = 25;
            player2.StartingPosition = 25;
            IGameBoard gameBoard = new GameBoard(caseFactory, gameState);

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
            Assert.IsTrue(player1.CanMove);
            Assert.IsFalse(player2.CanMove);
        }
    }
}
