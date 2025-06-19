using System;
namespace Sensory
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            Game game = Game.instance;

            UserSystem userSystem = new UserSystem(game).Start();

            new Menu().Start(game);
            
            userSystem.PlayerStatusUpdate(game.Level, game.score);
        }  
    }
}