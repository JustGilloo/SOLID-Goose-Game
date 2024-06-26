﻿using SOLID_Goose_Game.Business.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Cases.Interfaces
{
    public interface IPrisonCase : ICase
    {
        void ApplyPrisonCaseEffect(Player player);
        void DisplayPrisonEffectTurnMessage(Player player);
    }
}
