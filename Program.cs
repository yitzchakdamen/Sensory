using System;
namespace Sensory
{
    class Program
    {
        
        static void Main()
        {

            Game game = new();
            game.AddGameAgent();

            new Menu().Start(game);
        }
        
    }
    
}