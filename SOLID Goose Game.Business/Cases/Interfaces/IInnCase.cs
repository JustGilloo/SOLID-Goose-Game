using SOLID_Goose_Game.Business.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Cases.Interfaces
{
    public interface IInnCase : ICase
    {
        void ApplyInnCaseEffect(Player player);
        void DisplayInnCaseEffectMessage(Player player);
    }
}
