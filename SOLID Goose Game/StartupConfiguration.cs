using Microsoft.Extensions.DependencyInjection;
using SOLID_Goose_Game.Business.Dice;
using SOLID_Goose_Game.Business.Factories;
using SOLID_Goose_Game.Business.GameBoard;
using SOLID_Goose_Game.Business.GameState;
using SOLID_Goose_Game.Input;
using SOLID_Goose_Game.Logging;
using SOLID_Goose_Game.UserInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Goose_Game
{
    internal class StartupConfiguration
    {
        public ServiceCollection RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddScoped<IDiceRollerService, DiceRollerService>();
            services.AddScoped<ILogger, ConsoleLogger>();
            services.AddScoped<IUserInput, ConsoleInputter>();
            services.AddScoped<ICaseFactory, CaseFactory>();
            services.AddSingleton<IGameState, GameState>();
            services.AddSingleton<IGameBoard, GameBoard>();
            return services;
        }
    }
}
