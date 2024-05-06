﻿using SOLID_Goose_Game.Business.Cases;
using SOLID_Goose_Game.Business.Factories;
using SOLID_Goose_Game.Business.Players;

namespace SOLID_Goose_Game.Business.GameBoard
{
    public class GameBoard : IGameBoard
    {
        ICaseFactory caseFactory;
        public ICase[] Boardsize { get; private set; } = new ICase[64];

        public GameBoard(ICaseFactory caseFactory)
        {

            this.caseFactory = caseFactory;
        }

        public void FillInBoardCases()
        {
            for (int i = 0; i < Boardsize.Length; i++)
            {
                if ((i % 9 != 0 && i % 9 != 5) || i == 0 || i == Boardsize.Length - 1)
                {
                    this.Boardsize[i] = this.caseFactory.Create((CaseType)i, i);
                }
                else
                {
                    this.Boardsize[i] = this.caseFactory.Create(CaseType.Goose, i);
                }
            }
        }

        public void CheckPlayerPositionCaseType(Player player)
        {
            if (player.CurrentPosition < 63)
            {
                Boardsize[player.CurrentPosition].ResolveCase(player);
            }
        }
    }
}
