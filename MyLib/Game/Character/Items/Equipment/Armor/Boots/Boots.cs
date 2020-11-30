using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Game.Character.Items.Equipment.Armor.Boots
{
    public class Boots : Armor
    {
        public Boots(int armor, string name, int price)
        {
            this.armor = armor;
            this.price = price;
            this.name = name;
        }

        public int Armor
        {
            get => armor;
            private set => armor = value;
        } 
    }
}
