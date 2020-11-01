using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Arms
{
    class Arms : Equipment
    {
        protected int strength;

        public int Strength
        {
            get => strength;
            private set => strength = value;
        }

    }
    
}
