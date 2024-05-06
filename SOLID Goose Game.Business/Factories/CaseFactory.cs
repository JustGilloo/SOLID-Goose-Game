using SOLID_Goose_Game.Business.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Factories
{
    public class CaseFactory : ICaseFactory
    {
        public ICase Create(CaseType caseType, int ID)
        {
            switch (caseType)
            {
                case CaseType.Bridge:
                    return new BridgeCase();
                case CaseType.Inn:
                    return new InnCase();
                case CaseType.Goose:
                    return new GooseCase();
                case CaseType.Well:
                    return new WellCase();
                case CaseType.Maze:
                    return new MazeCase();
                case CaseType.Prison:
                    return new PrisonCase();
                case CaseType.Death:
                    return new DeathCase();
                case CaseType.End:
                    return new EndCase();
                default:
                    return new Case();
            }
        }
    }
}
