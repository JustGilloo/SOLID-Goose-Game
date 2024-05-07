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
    internal class GooseCaseTests
    {
        [Test]
        public void AssertsIfPlayerMovementDirectionNeedsToBeForwardWhenGooseCaseIsTriggered()
        {
            //Arrange
            ICaseFactory caseFactory = new CaseFactory();
            IGameState gameState = new GameState();
            Player player = new Player("Speler");
            player.CurrentPosition = 0;
            player.StartingPosition = 0;
            int[] dieRolls = [2, 3];
            IGameBoard gameBoard = new GameBoard(caseFactory, gameState);

            int expectedPosition = 10;

            //Act
            player.DetermineNewPosition(dieRolls);
            gameBoard.HandleCaseType(player);


            //Assert
            Assert.AreEqual(expectedPosition, player.CurrentPosition);
        }
        [Test]
        public void AssertsIfPlayerMovementDirectionNeedsToBeBackwardsWhenGooseCaseIsTriggered()
        {

        }
    }
}
