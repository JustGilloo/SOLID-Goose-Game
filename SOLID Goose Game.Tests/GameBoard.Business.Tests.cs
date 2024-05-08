using SOLID_Goose_Game.Business.GameBoard;
using SOLID_Goose_Game.Business.Dice;
using SOLID_Goose_Game.Business.Factories;
using SOLID_Goose_Game.Business.Cases;
using System.Diagnostics;
using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;
using System.Threading.Tasks;
using Moq;
using SOLID_Goose_Game.Logging;
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
            Mock<ILogger> logger = new Mock<ILogger>();
            IGameState gameState = new GameState((ILogger)logger);
            IGameBoard gameboard = new GameBoard(caseFactory, gameState);

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
            Mock<ILogger> logger = new Mock<ILogger>();
            IGameState gameState = new GameState((ILogger)logger);
            IGameBoard gameboard = new GameBoard(caseFactory, gameState);

            //Act & Assert
            gameboard.FillInBoardCases();
            foreach (var i in gameboard.Boardsize)
            {
                Assert.That(i.ID, Is.Not.EqualTo(null));
            }
        }
    }
}