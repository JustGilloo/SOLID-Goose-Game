using SOLID_Goose_Game.Business.Cases.Interfaces;
using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Business.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game.Business.Cases.Classes
{
    public class GooseCase : IGooseCase
    {
        IGameState gameState;
        public int ID { get; set; }
        public CaseType Type { get; set; }

        public GooseCase(int id, CaseType type, IGameState gameState)
        {
            ID = id;
            Type = type;
            this.gameState = gameState;
        }

        public void ResolveCase(Player player)
        {
            DeterminePlayerMovementDirection(player);
            gameState.PrintGameState(Type.ToString());
        }
        public void DeterminePlayerMovementDirection(Player player)
        {
            if (ID > player.StartingPosition)
            {
                MovePlayerForwards(player);
            }
            else
            {
                MovePlayerBackwards(player);
            }
        }
        public void MovePlayerForwards(Player player)
        {
            player.DetermineNewPosition(player.DiceResultArray);
        }
        public void MovePlayerBackwards(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
