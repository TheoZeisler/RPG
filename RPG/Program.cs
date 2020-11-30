using MyLib.Game.Character.CharacterClass;
using MyLib.Game.Character.Items;
using Newtonsoft.Json;
using RPG.Game;
using RPG.Game.CityHall;
using RPG.Game.Hostel;
using System;
using System.Collections.Generic;

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
                    Shop shop = new Shop();
                    gamePlay.game(p,shop,gamePlay, inventory, i);
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
