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
            Random random = new Random();
            int[] dieRolls = new int[2];
            player.StartingPosition = 0;
            player.CurrentPosition = 0;

            dieRolls[0] = random.Next(1, 7);
            dieRolls[1] = random.Next(1, 7); 
            int expectedResult = dieRolls[0] + dieRolls[1];

            //Act
            player.DetermineNewPosition(dieRolls);

            //Assert
            Assert.That(player.CurrentPosition, Is.EqualTo(expectedResult));
        }
    }
}
