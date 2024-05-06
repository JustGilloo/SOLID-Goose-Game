using SOLID_Goose_Game.Business.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Factories
{
    public interface ICaseFactory
    {
        ICase Create(CaseType caseType, int ID);
    }
}
