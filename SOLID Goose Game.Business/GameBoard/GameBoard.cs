using SOLID_Goose_Game.Business.Cases;
using SOLID_Goose_Game.Business.Cases.Interfaces;
using SOLID_Goose_Game.Business.Factories;
using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;
using SOLID_Goose_Game.Logging;

namespace SOLID_Goose_Game.Business.GameBoard
{
    public class GameBoard : IGameBoard
    {
        private ICaseFactory caseFactory;
        private ILogger logger;
        public ICase[] Boardsize { get; private set; } = new ICase[64];
        public bool IsFinishReached { get; set; }

        public GameBoard(ICaseFactory caseFactory, ILogger logger)
        {
            this.IsFinishReached = false;
            this.caseFactory = caseFactory;
            this.logger = logger;
        }

        public void FillInBoardCases()
        {
            for (int i = 0; i < Boardsize.Length; i++)
            {
                if ((i % 9 != 0 && i % 9 != 5) || i == 0 || i == Boardsize.Length - 1)
                {
                    this.Boardsize[i] = this.caseFactory.Create((CaseType)i, i, this.logger, this);
                }
                else
                {
                    this.Boardsize[i] = this.caseFactory.Create(CaseType.Goose, i, this.logger, this);
                }
            }
        }

        public void HandleCaseType(Player player)
        {
            if (player.CurrentPosition < 63)
            {
                Boardsize[player.CurrentPosition].ResolveCase(player);
            } else
            {
                Boardsize[63].ResolveCase(player);
            }
        }
    }
}
