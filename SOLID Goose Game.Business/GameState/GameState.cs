using SOLID_Goose_Game.Business.GameBoard;
using SOLID_Goose_Game.Business.Players;
using SOLID_Goose_Game.Logging;
using SOLID_Goose_Game.UserInput;

namespace SOLID_Goose_Game.Business.GameState
{
    public class GameState : IGameState
    {
        private ILogger logger;
        private IUserInput userInput;
        private IGameBoard gameBoard;

        public GameState(ILogger logger, IUserInput userInput, IGameBoard gameBoard)
        {
            this.logger = logger;
            this.userInput = userInput;
            this.gameBoard = gameBoard;
            this.IsGameOver = false;
        }
        public bool IsGameOver { get; set; }

        public void PrintGameState(string message)
        {
            logger.LogMessage(message);
        }
        public void SetupGame()
        {
            int userinput = -1;
            PrintGameState("Welkom bij Ganzenbord!");
            PrintGameState("Met hoeveel spelers wil je spelen? (2-4 spelers, geef een getal in.)");
            do
            {
                userinput = userInput.ValidateIfInputIsInt(userInput.GetUserInput());
                if (userinput == -1)
                {
                    logger.ClearLogger();
                    logger.LogMessage("U gaf geen geldig getal in. Gelieve een getal van tot en met 4 in te geven.");
                }
            } while (userinput > 4 || userinput < 0);
            for (int i = 0; i < userinput; i++)
            {
                PrintGameState($"Geef een naam in voor speler {i}:");
                this.CreatePlayer(userInput.GetUserInput());
                logger.ClearLogger();
            }
            PrintGameState("Zet je klaar, ganzen maar! 🦆");
            this.gameBoard.FillInBoardCases();
            PrintGameState("Druk op enter om te beginnen!");
            this.userInput.GetUserInput();
        }
        public void CreatePlayer(string playerName)
        {

        }
        public bool ResolvePlayerTurn(Player player)
        {
            return false;
        }
        public void GameLoop()
        {

        }
    }
}
