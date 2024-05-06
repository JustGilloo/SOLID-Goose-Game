using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Cases
{
    public class EndCase : IEndCase
    {
        public int ID { get; set; }
        public CaseType Type { get; set; }

        public EndCase(int id, CaseType type)
        {
            this.ID = id;
            this.Type = type;
        }
    }
}
