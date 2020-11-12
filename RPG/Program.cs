using Newtonsoft.Json;
using RPG.Game;
using RPG.Game.Character;
using RPG.Game.Character.CharacterClass;
using RPG.Game.Character.CharacterClass.Items;
using RPG.Game.Character.CharacterClass.Items.Inventory;
using RPG.Game.Character.CharacterClass.PlayerClass;
using RPG.Game.CityHall;
using RPG.Game.Hostel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Program
    {

        static void Main(string[] args)
        {
            GamePlay gamePlay = new GamePlay();
            launch(gamePlay);  
        }
        static public void launch(GamePlay gamePlay)
        {
            Console.WriteLine("1- Nouvelle partie\n2- Charger partie\n3- Quitter");
            switch (gamePlay.verif(3))
            {
                case 1:
                    gamePlay.start();
                    Player p = new Player();
                    p = gamePlay.createPlayer(gamePlay.verif(4));
                    p.customization(p);
                    Inventory i = new Inventory(p);
                    List<Items> inventory = i.getInventory();
                    Monster m = new Monster();
                    Shop shop = new Shop();
                    Hostel hostel = new Hostel(p);
                    CityHall cityHall = new CityHall();
                    gamePlay.game(p, m, shop, hostel, inventory, gamePlay, cityHall, i);
                    break;
                case 2:
                    gamePlay.load(gamePlay);
                    break;
                case 3:
                    break;
            }
        }
    }
}
