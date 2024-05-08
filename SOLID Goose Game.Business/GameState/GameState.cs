using SOLID_Goose_Game.Business.Factories;
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
        private IPlayerFactory playerFactory;

        public GameState(ILogger logger, IUserInput userInput, IGameBoard gameBoard, IPlayerFactory playerFactory)
        {
            this.logger = logger;
            this.userInput = userInput;
            this.gameBoard = gameBoard;
            this.playerFactory = playerFactory;
            this.IsGameOver = false;
            this.ParticipatingPlayers = new List<IPlayer>();
        }
        public bool IsGameOver { get; set; }
        public List<IPlayer> ParticipatingPlayers { get; set; }

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
                if (userinput > 4 || userinput < 2)
                {
                    logger.ClearLogger();
                    logger.LogMessage("U gaf geen (geldige) numerieke waarde in. Gelieve een getal van tot en met 4 in te geven.");
                }
            } while (userinput > 4 || userinput < 2);
            for (int i = 0; i < userinput; i++)
            {
                logger.ClearLogger();
                PrintGameState($"Geef een naam in voor speler {i + 1}:");
                this.ParticipatingPlayers.Add(this.playerFactory.Create(PlayerType.Regular, this.userInput.GetUserInput()));
                logger.ClearLogger();
            }
            this.gameBoard.FillInBoardCases();
            PrintGameState("Zet je klaar, ganzen maar!");
            PrintGameState("Druk op ENTER om te beginnen!");
            this.userInput.GetUserInput();
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
