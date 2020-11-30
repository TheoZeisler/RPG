using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Game.Character.Items.Consumable.Potion
{
    public class Potions : Items
    {
        public Potions(int health, string name, int price)
        {
            this.health = health;
            this.name = name;
            this.price = price;
        }
    }
}
