using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Armor.Boots
{
    class Boots : Armor
    {
        public Boots(int armor, string v)
        {
            this.armor = armor;
        }

        protected int Armor
        {
            get => armor;
            set => armor = value;
        } 
    }
}
