﻿using SOLID_Goose_Game.Business.Cases.Interfaces;
using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Cases.Classes
{
    public class MazeCase : IMazeCase
    {
        IGameState gameState;
        public int ID { get; set; }
        public CaseType Type { get; set; }

        public MazeCase(int id, CaseType type, IGameState gameState)
        {
            ID = id;
            Type = type;
            this.gameState = gameState;
        }

        public void ResolveCase(Player player)
        {
            ApplyMazeCase(player);
            gameState.PrintGameState(Type.ToString());
        }
        public void ApplyMazeCase(Player player)
        {
            player.CurrentPosition -= 3;
            player.StartingPosition = player.CurrentPosition;
        }
    }
}