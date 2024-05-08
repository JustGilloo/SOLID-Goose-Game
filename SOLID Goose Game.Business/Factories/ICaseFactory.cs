using SOLID_Goose_Game.Business.Cases;
using SOLID_Goose_Game.Business.Cases.Interfaces;
using SOLID_Goose_Game.Business.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Factories
{
    public interface ICaseFactory
    {
        ICase Create(CaseType caseType, int ID, IGameState gameState);
    }
}
