using SOLID_Goose_Game.Business.Cases;
using SOLID_Goose_Game.Business.Cases.Classes;
using SOLID_Goose_Game.Business.Cases.Interfaces;
using SOLID_Goose_Game.Business.GameBoard;
using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Factories
{
    public class CaseFactory : ICaseFactory
    {
        public ICase Create(CaseType caseType, int ID, ILogger logger, IGameBoard gameBoard)
        {
            switch (caseType)
            {
                case CaseType.Bridge:
                    return new BridgeCase(ID, caseType, logger);
                case CaseType.Inn:
                    return new InnCase(ID, caseType, logger);
                case CaseType.Goose:
                    return new GooseCase(ID, caseType, gameBoard, logger);
                case CaseType.Well:
                    return new WellCase(ID, caseType, logger);
                case CaseType.Maze:
                    return new MazeCase(ID, caseType, logger);
                case CaseType.Prison:
                    return new PrisonCase(ID, caseType, logger);
                case CaseType.Death:
                    return new DeathCase(ID, caseType, logger);
                case CaseType.End:
                    return new EndCase(ID, caseType, gameBoard, logger);
                default:
                    return new RegularCase(ID, caseType, logger);
            }
        }
    }
}
