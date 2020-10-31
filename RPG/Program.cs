using RPG.Game;
using RPG.Game.Character;
using RPG.Game.Character.CharacterClass;
using RPG.Game.Character.CharacterClass.PlayerClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Program
    {

        static void Main(string[] args)
        {
            GamePlay gamePlay = new GamePlay();
            gamePlay.start();
            Player p = new Player();
            int number = 4;
            p = gamePlay.createPlayer(gamePlay.verif(number));
            p.customization(p);
            Monster m = new Monster();
            Shop shop = new Shop();
            gamePlay.menu();
            switch (gamePlay.verif(number))
            {
                case 1:
                    Fight fight = new Fight(p, m.createMonster());
                    fight.versus(gamePlay);
                    break;
                case 2:
                    
                    break;
                case 3:
                    shop.enter(p, gamePlay);
                    break;
                case 4:
                    break;
            }
            Console.Read();
            
        }
    }
}
