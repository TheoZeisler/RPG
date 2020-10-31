using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Arms.Bow
{
    class Bow : Arms
    {
        public Bow(int strength, string name)
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
