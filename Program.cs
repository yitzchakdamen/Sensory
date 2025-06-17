using System;
namespace Sensory
{
    class Program
    {
        
        static void Main()
        {
            Console.Clear();
            Game game = new Game();
            game.AddGameAgent();
            game.AddGameAgent();
            game.AddGameAgent();

            new Menu().Start(game);
        }
        
    }
    
}