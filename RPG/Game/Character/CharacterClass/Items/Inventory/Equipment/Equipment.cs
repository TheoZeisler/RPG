using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG .Game.Character.CharacterClass.Items.Inventory.Equipment
{
    class Equipment : Items
    {
        protected int lvlRequire;

        public string Name
        {
            get => name;
            protected set => name = value;
        }

    }

}
