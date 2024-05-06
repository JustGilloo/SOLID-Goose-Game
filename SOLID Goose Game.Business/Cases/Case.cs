using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Cases
{
    public class Case : ICase
    {
        public int ID { get; set; }
        public CaseType Type { get; set; }
    }
}
