using SOLID_Goose_Game.Business.Cases;
using SOLID_Goose_Game.Business.Dice;
using SOLID_Goose_Game.Business.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.GameBoard
{
    public class GameBoard : IGameBoard
    {
        ICaseFactory caseFactory;
        public ICase[] Boardsize { get; private set; } = new ICase[64];

        public GameBoard(ICaseFactory caseFactory) {

            this.caseFactory = caseFactory;
        }

        public void FillInBoardCases()
        {
            for (int i = 0; i < Boardsize.Length; i++)
            {
                //Hier moet de factory opgeroepen worden
               this.Boardsize[i] = this.caseFactory.Create((CaseType)i, i);
            }
        }
    }
}
