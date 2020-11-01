using RPG.Game.Character.CharacterClass;
using RPG.Game.Character.CharacterClass.Items;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RPG.Game.CityHall
{
    class CityHall
    {
        //Fonction d'intro de la mairie 
        public void enter(Player p, GamePlay gamePlay, List<Items> inventory)
        {
            Console.WriteLine("Bienvenue " + p.Name + " dans la mairie. Ici tu peux sauvegarder ta partie.\n1- Sauvegarder\n2- Retour");
            switch (gamePlay.verif(2))
            {
                case 1:
                    save(p, gamePlay, inventory);
                    break;
                case 2:
                    break;
            }
        }
        //Fonction qui sauvegarde la partie dans un fichier json
        public void save(Player p, GamePlay gamePlay, List<Items> inventory)
        {
            byte[] player;
            string inv;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            player = JsonSerializer.SerializeToUtf8Bytes(p, options); 
            inv = JsonSerializer.Serialize(inventory, options);
            string settingsPath = @"C:\Users\Théo\Desktop\RPG\RPG\RPG\Saves\Save1.txt";
            File.WriteAllBytes(settingsPath, player);
            File.AppendAllText(settingsPath, inv);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Votre partie à été sauvegarder");
            Console.ResetColor();
            enter(p, gamePlay, inventory);
        }
    }
}
