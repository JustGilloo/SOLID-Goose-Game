using SOLID_Goose_Game.Business.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Cases
{
    public class RegularCase : ICase
    {
        public int ID { get; set; }
        public CaseType Type { get; set; }

        public RegularCase(int id, CaseType type)
        {
            this.ID = id;
            this.Type = type;
        }

        public void ResolveCase(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
