using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Dice
{
    public class DiceRollerService : IDiceRollerService
    {
        public int[] RollDiceArray(int amountOfDice, int amountOfSides)
        {
            Random random = new Random();
            int[] rolls = new int[amountOfDice];
            for (int i = 0; i < amountOfDice; i++)
            {
                rolls[i] += random.Next(1, amountOfSides + 1);
            }
            return rolls;
        }
    }
}
