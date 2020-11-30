using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Game.Character.Items.Equipment.Armor.Helmet
{
    public class Helmet : Armor
    {
        public Helmet(int armor, string name, int price)
        {
            this.armor = armor;
            this.name = name;
            this.price = price;
        }

        public int Armor
        {
            get => armor;
            private set => armor = value;
        }
    }
}
