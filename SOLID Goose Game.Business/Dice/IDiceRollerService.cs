﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Dice
{
    public interface IDiceRollerService
    {
        int[] RollDiceArray(int amountOfDice, int amountOfSides);
    }
}
