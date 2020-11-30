using MyLib.Game.Character.CharacterClass;
using MyLib.Game.Character.CharacterClass.PlayerClass.Archer;
using MyLib.Game.Character.CharacterClass.PlayerClass.Barbare;
using MyLib.Game.Character.CharacterClass.PlayerClass.Mage;
using MyLib.Game.Character.CharacterClass.PlayerClass.Voleur;
using RPG.Game.CityHall;
using RPG.Game.Hostel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using MyLib.Game.Character.Items;
using RPG.Game;
using Newtonsoft.Json;

namespace RPG
{
    class GamePlay
    {
        private Player p;

        //Fontion qui introduit le jeu et les diffèrente classe
        public void start()
        {
            Console.WriteLine("Bienvenue jeune aventurier dans ce RPG !\nPour comencer il faut que tu choissises un personnage.\n4 choix s'offre à toi :\n\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("-Le Barbare");
            Console.ResetColor();
            Console.Write(" : Il permet de frapper fort tout en encaissant beaucoup de coups\n~~~~\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("-Le Mage");
            Console.ResetColor();
            Console.Write(" : Il frappe avec des sorts puissants tout en ayant beaucoup de mana\n~~~~\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("-L'Archer");
            Console.ResetColor();
            Console.Write(" : Il peux attaquer à l'aide d'un arc mais il est très peu résistant\n~~~~\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("-Le Voleur");
            Console.ResetColor();
            Console.Write(" : Il a beaucoup de dextérité et il gagne plus d'argent par combat\n~~~~\n" +
                "Taper 1 pour le Barbare / 2 pour le Mage / 3 pour l'Archer / 4 pour le Voleur\n"); 
        }
        //Fonction permettant de vérifier l'entré du joueur
        public int verif(int number)
        {
            bool isInt = false;
            int goodChoice = 0;
            while (!isInt || goodChoice > number || goodChoice < 1)
            {
                string choice = Console.ReadLine();
                isInt = int.TryParse(choice, out goodChoice);
                if (!isInt)
                {
                    Console.WriteLine("Réessayer");
                }
            }
            return goodChoice;
        }
        //Fonction qui crée le Player
        public Player createPlayer(int playerChoice)
        {
            Console.Clear();
            switch (playerChoice)
            {
                case 1:
                    Barbare barbare = new Barbare();
                    Inventory inventoryB = new Inventory(barbare);
                    Console.WriteLine("Création d'un Barbare");
                    return barbare;
                case 2:
                    Mage mage = new Mage();
                    Inventory inventoryM = new Inventory(mage);
                    Console.WriteLine("Création d'un Mage");
                    return mage;
                case 3:
                    Archer archer = new Archer();
                    Inventory inventoryA = new Inventory(archer);
                    Console.WriteLine("Création d'un Archer");
                    return archer;
                case 4:
                    Voleur voleur = new Voleur();
                    Inventory inventoryV = new Inventory(voleur);
                    Console.WriteLine("Création d'un Voleur");
                    return voleur;
            }
            Player p = new Player();
            return p ;
        }
        //Fonction du menu principal du jeu
        public void menu()
        {
            Console.WriteLine("--- Menu du jeu ---\n" +
                "Tape 1 pour te battre contre un monstre\n" +
                "Tape 2 pour aller à l'auberge pour régénérer tes points de vie\n" +
                "Tape 3 pour aller au shop acheter des équipements\n" +
                "Tape 4 pour aller à la Mairie pour sauvegarder ta partie\n" +
                "Tape 5 pour voir ton inventaire\n" +
                "Tape 6 pour voir tes statistiques\n" +
                "Tape 7 pour quitter\n\n");
        }
        //Fonction qui lance le jeu en créant les diffèrentes entitées nécessaire au jeu
        public void launch(GamePlay gamePlay)
        {
            Console.WriteLine("1- Nouvelle partie\n2- Charger partie\n3- Quitter");
            switch (gamePlay.verif(3))
            {
                case 1:
                    gamePlay.start();
                    p = new Player();
                    p = gamePlay.createPlayer(gamePlay.verif(4));
                    p.customization(p);
                    Inventory i = new Inventory(p);
                    Shop shop = new Shop();
                    List<Items> inventory = i.getInventory();
                    game(p,shop, gamePlay, inventory, i);
                    break;
                case 2:
                    load(gamePlay);
                    break;
                case 3:
                    break;
            }

        }
        //Fonction qui renvoie le player
        public Player getPlayer()
        {
            return p;
        }
        //Fonction du menu principal avec les diffèrents choix
        public void game(Player p,Shop shop, GamePlay gamePlay, List<Items> inventory, Inventory i)
        {
            Monster m = new Monster();
            Hostel hostel = new Hostel(p);
            CityHall cityHall = new CityHall();
            
            bool play = true;
            while (play)
            {
                gamePlay.menu();
                switch (gamePlay.verif(7))
                {
                    case 1:
                        Fight fight = new Fight(p, m.getMonster(p), 1, inventory);
                        fight.versus(gamePlay);
                        break;
                    case 2:
                        hostel.enter(gamePlay);
                        break;
                    case 3:
                        shop.enter(p, gamePlay, inventory);
                        break;
                    case 4:
                        cityHall.enter(p, gamePlay, inventory, shop);
                        break;
                    case 5:
                        i.showInventory();
                        break;
                    case 6:
                        p.showStat(p);
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        //Fonction qui permet de charger une partie
        public void load(GamePlay gamePlay)
        {
            //Sauvegarde joueur
            string pathSave = @"C:\Users\Théo\Desktop\c#\RPG\RPG\Saves\Save.txt";
            string jsonSave = File.ReadAllText(pathSave);
            Player p = JsonConvert.DeserializeObject<Player>(jsonSave);
            //Sauvegarde inventaire
            string pathinventory = @"C:\Users\Théo\Desktop\c#\RPG\RPG\Saves\Inventory.txt";
            string jsonInventory = File.ReadAllText(pathinventory);
            List<Items> inventory = JsonConvert.DeserializeObject<List<Items>>(jsonInventory);
            //Sauvegarde joueur
            string pathShop = @"C:\Users\Théo\Desktop\c#\RPG\RPG\Saves\Shop.txt";
            string jsonShop = File.ReadAllText(pathShop);
            Shop s = JsonConvert.DeserializeObject<Shop>(jsonShop);
            Inventory i = new Inventory(p);
            gamePlay.game(p, s, gamePlay, inventory, i);

        }
    }
}
