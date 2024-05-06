using SOLID_Goose_Game.Business.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Cases
{
    public interface ICase
    {
        int ID { get; set; }
        CaseType Type { get; set; }
        void ResolveCase(Player player);
    }
}
