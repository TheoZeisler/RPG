using RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Arms.Axe;
using RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Arms.Bow;
using RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Arms.Sword;
using RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Arms.Two_handed_sword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Game.Character.CharacterClass.Items
{
    class Items 
    {
        protected string name;
        protected int price;
        protected bool isEquip;
        protected int health;

        public int Price
        {
            get => price;
            private set => price = value;
        }
        public string Name
        {
            get => name;
            private set => name = value;
        }
        public bool IsEquip
        {
            get => isEquip;
            set => isEquip = value;
        }
        public int Health
        {
            get => health;
            private set => health = value;
        }

    }
}
