using System;
namespace Sensory
{
    class Program
    {
        
        static void Main()
        {
            Console.Clear();
            Game game =  Game.instance;
            
            new UserSystem(game).Start();

            new Menu().Start(game);
        }
        
    }
    
}