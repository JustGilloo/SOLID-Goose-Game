using SOLID_Goose_Game.Business.Dice;
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
        private IDiceRollerService diceRoller;

        public GameState(ILogger logger, IUserInput userInput, IGameBoard gameBoard, IPlayerFactory playerFactory, IDiceRollerService diceRoller)
        {
            this.logger = logger;
            this.userInput = userInput;
            this.gameBoard = gameBoard;
            this.playerFactory = playerFactory;
            this.diceRoller = diceRoller;
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
            int numberOfPlayers = -1;
            PrintGameState("Welkom bij Ganzenbord!");
            PrintGameState("Met hoeveel spelers wil je spelen? (2-4 spelers, geef een getal in.)");
            do
            {
                numberOfPlayers = userInput.ValidateIfInputIsInt(userInput.GetUserInput());
                if (numberOfPlayers > 4 || numberOfPlayers < 2)
                {
                    logger.ClearLogger();
                    logger.LogMessage("U gaf geen (geldige) numerieke waarde in. Gelieve een getal van tot en met 4 in te geven.");
                }
            } while (numberOfPlayers > 4 || numberOfPlayers < 2);
            for (int i = 0; i < numberOfPlayers; i++)
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
        public bool ResolvePlayerTurn(int indexToFetch)
        {
            //Speler wiens beurt het is uit de lijst halen en laten dobbelen => fetchplayerfunctie
            IPlayer player = FetchActiveTurnPlayer(indexToFetch);
            //Speler oproepen om te bewegen
            player.SetStartingPosition();
            player.DetermineNewPosition(this.diceRoller.RollDiceArray(2, 6));
            //Gameboard check waarop speler landt
            this.gameBoard.HandleCaseType((Player)player);
            logger.LogMessage("");
            return (player.CurrentPosition == 63);
        }
        public IPlayer FetchActiveTurnPlayer(int indexToFetch)
        {
            return this.ParticipatingPlayers[indexToFetch];
        }
        public void GameLoop()
        {
            while (gameBoard.IsFinishReached == false)
            {
                for (int i = 0; i < this.ParticipatingPlayers.Count; i++)
                {
                    if (ResolvePlayerTurn(i))
                    {
                        gameBoard.IsFinishReached = true;
                        break;
                    }
                }
            }
        }
    }
}
