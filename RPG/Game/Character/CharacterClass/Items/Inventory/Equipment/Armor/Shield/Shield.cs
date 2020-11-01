using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Armor.Shield
{
    class Shield : Armor
    {
        public Shield(int armor, string name, int price)
        {
            this.armor = armor;
            this.name = name;
            this.price = price;
        }

        public int Armor
        {
            get => armor;
            private set => armor = value;
        }
    }
}
