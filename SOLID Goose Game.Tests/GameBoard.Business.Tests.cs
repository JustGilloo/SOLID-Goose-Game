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
using SOLID_Goose_Game.Input;
using SOLID_Goose_Game.UserInput;
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
            ILogger logger = new ConsoleLogger();
            IGameBoard gameBoard = new GameBoard(caseFactory, logger);
            Player player = new Player("Speler");

            //Act
            gameBoard.FillInBoardCases();

            //Assert
            Assert.That(gameBoard.Boardsize != null, Is.True);
        }

        [Test]
        public void AssertThatIDsAreSetInArrayOfCases()
        {
            //Arrange
            ICaseFactory caseFactory = new CaseFactory();
            ILogger logger = new ConsoleLogger();
            IGameBoard gameBoard = new GameBoard(caseFactory, logger);

            //Act & Assert
            gameBoard.FillInBoardCases();
            foreach (var i in gameBoard.Boardsize)
            {
                Assert.That(i.ID, Is.Not.EqualTo(null));
            }
        }
    }
}