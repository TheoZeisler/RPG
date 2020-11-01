using RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Armor.Helmet;
using RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Arms.Sword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Game.Character.CharacterClass.Items.Inventory
{
    class Inventory : Items
    {
        private List<Items> inventory;

        public Inventory(Player p)
        {
            inventory = new List<Items>();
            Sword sword = new Sword(2, "Épée courte",0);
            sword.IsEquip = true;
            p.Strength += sword.Strength;
            inventory.Add(sword);
        }
        //retourne l'inventaire
        public List<Items> getInventory()
        {
            return inventory;
        }

        //Affichage de l'inventaire
        public void showInventory()
        {
            Console.WriteLine("Voici votre inventaire : \n");
            for(int i = 0; i < inventory.Count(); i++)
            {
                Console.WriteLine(inventory[i].Name);
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Appuyer sur entré pour revenir au menu ...\n\n");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
