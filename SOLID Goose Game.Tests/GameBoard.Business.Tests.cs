using SOLID_Goose_Game.Business.GameBoard;
using SOLID_Goose_Game.Business.Dice;
using SOLID_Goose_Game.Business.Factories;
using SOLID_Goose_Game.Business.Cases;
using System.Diagnostics;
using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;
using System.Threading.Tasks;
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
            IGameState gameState = new GameState();
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
            IGameState gameState = new GameState();
            IGameBoard gameboard = new GameBoard(caseFactory, gameState);

            //Act & Assert
            gameboard.FillInBoardCases();
            foreach (var i in gameboard.Boardsize)
            {
                Assert.That(i.ID, Is.Not.EqualTo(null));
            }
        }

        [Test]
        public void AssertsTheCaseTypeOfTheCurrentPlayerPosition()
        {
            //Arrange
            ICaseFactory caseFactory = new CaseFactory();
            IGameState gameState = new GameState();
            IDiceRollerService diceroller = new DiceRollerService();
            int[] dieRolls = new int[2];
            Player player = new Player();
            GameBoard gameboard = new GameBoard(caseFactory, gameState);
            player.StartingPosition = 0;
            player.CurrentPosition = 0;
            gameboard.FillInBoardCases();
            ICase expectedCase = gameboard.Boardsize[12];
            dieRolls = [3, 3];

            int expectedStartingPosition = player.CurrentPosition;

            //Act
            player.DetermineNewPosition(dieRolls);
            gameboard.HandleCaseType(player);

            //Assert
            Assert.AreEqual(expectedCase, gameboard.Boardsize[player.CurrentPosition]);
        }
    }
}