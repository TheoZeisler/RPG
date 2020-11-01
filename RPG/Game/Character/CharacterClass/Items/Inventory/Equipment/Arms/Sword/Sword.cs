using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Arms.Sword
{
    class Sword : Arms
    {
        public Sword(int strength, string name, int price)
        {
            this.strength = strength;
            this.name = name;
            this.price = price;
        }
    }
}
