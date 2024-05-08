using Microsoft.Extensions.DependencyInjection;
using SOLID_Goose_Game.Business.GameState;

namespace SOLID_Goose_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            StartupConfiguration startupConfiguration = new StartupConfiguration();
            services = startupConfiguration.RegisterServices();
            ServiceProvider serviceProvider = services.BuildServiceProvider();


            IGameState gameState = serviceProvider.GetService<IGameState>();

            gameState.SetupGame();
        }
    }
}
