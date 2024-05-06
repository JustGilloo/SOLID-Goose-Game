using SOLID_Goose_Game.Business.Cases;
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
        public ICase Create(CaseType caseType, int ID, IGameState gameState)
        {
            switch (caseType)
            {
                case CaseType.Bridge:
                    return new BridgeCase(ID, caseType, gameState);
                case CaseType.Inn:
                    return new InnCase(ID, caseType);
                case CaseType.Goose:
                    return new GooseCase(ID, caseType);
                case CaseType.Well:
                    return new WellCase(ID, caseType);
                case CaseType.Maze:
                    return new MazeCase(ID, caseType);
                case CaseType.Prison:
                    return new PrisonCase(ID, caseType);
                case CaseType.Death:
                    return new DeathCase(ID, caseType);
                case CaseType.End:
                    return new EndCase(ID, caseType);
                default:
                    return new RegularCase(ID, caseType);
            }
        }
    }
}
