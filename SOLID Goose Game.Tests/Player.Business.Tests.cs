using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLID_Goose_Game.Business.Dice;
using SOLID_Goose_Game.Business.Players;

namespace SOLID_Goose_Game.Tests
{
    internal class PlayerTests
    {
        [Test]
        public void AssertsThatPlayerPositionCorrectlyChanges()
        {
            //Arrange
            Player player = new Player();
            DiceRollerService diceroller = new DiceRollerService();
            int[] dieRolls = new int[2];
            player.StartingPosition = 0;
            player.CurrentPosition = 0;
            dieRolls = [5, 5];
            int expectedResult = dieRolls.Sum();


            //Act
            player.DetermineNewPosition(dieRolls);

            //Assert
            Assert.That(player.CurrentPosition, Is.EqualTo(expectedResult));
        }
    }
}
