using SOLID_Goose_Game.Business.GameBoard;
using SOLID_Goose_Game.Business.Dice;
using SOLID_Goose_Game.Business.Factories;
using SOLID_Goose_Game.Business.Cases;
using System.Diagnostics;
namespace SOLID_Goose_Game.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AssertsThatBoardIsFilledWithCases()
        {
            //Arrange
            ICaseFactory caseFactory = new CaseFactory();
            GameBoard gameboard = new GameBoard(caseFactory);

            //Act
            gameboard.FillInBoardCases();

            //Assert
            Assert.That(gameboard.Boardsize != null, Is.True);
        }

        [Test]
        public void AssertThatIDsAreSetInArrayOfCases()
        {
            //Arrange
            ICaseFactory caseFactory = new CaseFactory();
            GameBoard gameboard = new GameBoard(caseFactory);

            //Act & Assert
            gameboard.FillInBoardCases();
            foreach (var i in gameboard.Boardsize)
            {
                Assert.That(i.ID, Is.Not.EqualTo(null));
            }
        }
    }
}