using System;
using System.Collections.Generic;
using System.IO;
using MyLib.Game.Character.Items;
using MyLib.Game.Character.CharacterClass;
using Newtonsoft.Json;

namespace RPG.Game.CityHall
{
    class CityHall
    {
        //Fonction d'intro de la mairie 
        public void enter(Player p, GamePlay gamePlay, List<Items> inventory, Shop shop)
        {
            Console.WriteLine("Bienvenue " + p.Name + " dans la mairie. Ici tu peux sauvegarder ta partie.\n1- Sauvegarder\n2- Retour");
            switch (gamePlay.verif(2))
            {
                case 1:
                    save(p, gamePlay, inventory, shop);
                    break;
                case 2:
                    break;
            }
        }
        //Fonction qui sauvegarde la partie dans un fichier json
        public void save(Player p, GamePlay gamePlay, List<Items> inventory, Shop shop)
        {
            //Sauvegarde Player
            string jsonPlayer = JsonConvert.SerializeObject(p, Formatting.Indented);
            string settingsPathSave = @"C:\Users\Théo\Desktop\c#\RPG\RPG\Saves\Save.txt";
            if (File.Exists(settingsPathSave))
            {
                File.Delete(settingsPathSave);
            }   
            File.Create(settingsPathSave).Dispose();
            using (TextWriter tw = new StreamWriter(settingsPathSave))
            {
                tw.WriteLine(jsonPlayer);
            }
            //Sauvegarde Inventaire
            string jsonInventory = JsonConvert.SerializeObject(inventory, Formatting.Indented);
            string settingsPathInventory = @"C:\Users\Théo\Desktop\c#\RPG\RPG\Saves\Inventory.txt";
            if (File.Exists(settingsPathInventory))
            {
                File.Delete(settingsPathInventory);
            }
            File.Create(settingsPathInventory).Dispose();
            using (TextWriter tw = new StreamWriter(settingsPathInventory))
            {
                tw.WriteLine(jsonInventory);
            }
            //Sauvegarde Shop
            string jsonShop = JsonConvert.SerializeObject(shop, Formatting.Indented);
            string settingsPathShop = @"C:\Users\Théo\Desktop\c#\RPG\RPG\Saves\Shop.txt";
            if (File.Exists(settingsPathShop))
            {
                File.Delete(settingsPathShop);
            }
            File.Create(settingsPathShop).Dispose();
            using (TextWriter tw = new StreamWriter(settingsPathShop))
            {
                tw.WriteLine(jsonShop);
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Votre partie à été sauvegarder");
            Console.ResetColor();
            enter(p, gamePlay, inventory, shop);
        }
    }
}
