using System;
namespace Sensory
{
    class Program
    {
        
        static void Main()
        {
            Console.Clear();
            Game game =  Game.instance;
            game.Level = 1;
            new UserSystem(game);

            new Menu().Start(game);
        }
        
    }
    
}