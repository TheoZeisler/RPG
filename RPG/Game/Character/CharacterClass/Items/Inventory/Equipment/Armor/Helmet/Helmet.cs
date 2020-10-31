using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Armor.Helmet
{
    class Helmet : Armor
    {
        public Helmet(int armor, string name)
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
