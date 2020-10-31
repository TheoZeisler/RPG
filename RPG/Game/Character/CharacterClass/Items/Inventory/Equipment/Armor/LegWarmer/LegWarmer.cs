using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Armor.LegWarmer
{
    class LegWarmer : Armor
    {
        public LegWarmer(int armor, string name)
        {
            this.armor = armor;
            this.name = name;
        }

        protected int Armor
        {
            get => armor;
            set => armor = value;
        }
    }
}
