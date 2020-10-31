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

        public Inventory()
        {
            inventory = new List<Items>();
            Sword sword = new Sword(2, "Épée courte");
            inventory.Add(sword);
        }

        public List<Items> getInventory()
        {
            return inventory;
        }
    }
}
