using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Armor.Boots
{
    class Boots : Armor
    {
        public Boots(int armor, string name, int price)
        {
            this.armor = armor;
            this.price = price;
            this.name = name;
        }

        public int Armor
        {
            get => armor;
            private set => armor = value;
        } 
    }
}
