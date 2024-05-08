using SOLID_Goose_Game.Business.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Cases
{
    public interface IEndCase : ICase
    {
        void CheckPlayerRollExceedsID(Player player);
        void MovePlayerBack(Player player);
    }
}
