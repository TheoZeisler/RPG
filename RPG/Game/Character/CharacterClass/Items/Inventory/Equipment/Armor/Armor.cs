using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Armor
{
    class Armor : Equipment
    {
        protected int armor;
        public int ArmorPoint
        {
            get => armor;
            private set => armor = value;
        }

    }
}
