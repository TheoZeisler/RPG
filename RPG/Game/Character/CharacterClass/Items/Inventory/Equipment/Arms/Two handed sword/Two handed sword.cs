using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Arms.Two_handed_sword
{
    class Two_handed_sword : Arms
    {
        public Two_handed_sword(int strength, string name)
        {
            this.strength = strength;
            this.name = name;
        }

        protected int Strength
        {
            get => strength;
            set => strength = value;
        }
    }
}
