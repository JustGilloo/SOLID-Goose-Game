using SOLID_Goose_Game.Business.Cases;
using SOLID_Goose_Game.Business.Cases.Classes;
using SOLID_Goose_Game.Business.Cases.Interfaces;
using SOLID_Goose_Game.Business.GameBoard;
using SOLID_Goose_Game.Business.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Factories
{
    public class CaseFactory : ICaseFactory
    {
        public ICase Create(CaseType caseType, int ID, IGameState gameState, IGameBoard gameBoard)
        {
            switch (caseType)
            {
                case CaseType.Bridge:
                    return new BridgeCase(ID, caseType, gameState);
                case CaseType.Inn:
                    return new InnCase(ID, caseType, gameState);
                case CaseType.Goose:
                    return new GooseCase(ID, caseType, gameState, gameBoard);
                case CaseType.Well:
                    return new WellCase(ID, caseType, gameState);
                case CaseType.Maze:
                    return new MazeCase(ID, caseType, gameState);
                case CaseType.Prison:
                    return new PrisonCase(ID, caseType, gameState);
                case CaseType.Death:
                    return new DeathCase(ID, caseType, gameState);
                case CaseType.End:
                    return new EndCase(ID, caseType, gameState, gameBoard);
                default:
                    return new RegularCase(ID, caseType, gameState);
            }
        }
    }
}
