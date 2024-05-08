using SOLID_Goose_Game.UserInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Input
{
    public class UserInput : IUserInput
    {
        public string GetUserInput()
        {
            return Console.ReadLine();
        }

        public int ValidateIfInputIsInt(string input)
        {
            if (int.TryParse(input, out int value) == true)
            {
                return value;
            }
            return -1;
        }
    }
}
