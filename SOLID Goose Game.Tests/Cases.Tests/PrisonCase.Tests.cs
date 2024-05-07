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
    internal class PrisonCase
    {
        [Test]
        public void AssertsIfPlayerCannotMoveFor3Turns()
        {
            //Arrange
            ICaseFactory caseFactory = new CaseFactory();
            IGameState gameState = new GameState();
            Player player = new Player("Speler");
            player.CurrentPosition = 48;
            player.StartingPosition = 48;
            int[] dieRolls = new int[2];
            dieRolls = [2, 2];
            IGameBoard gameBoard = new GameBoard(caseFactory, gameState);

            int expectedPosition = 52;

            //Act
            gameBoard.FillInBoardCases();
            for (int i = 0; i < 3; i++) 
            {
                player.DetermineNewPosition(dieRolls);
                gameBoard.HandleCaseType(player);
            }

            //Assert
            Assert.AreEqual(expectedPosition, player.CurrentPosition);
        }
    }
}
