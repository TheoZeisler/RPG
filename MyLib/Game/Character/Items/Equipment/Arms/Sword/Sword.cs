using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Game.Character.Items.Equipment.Arms.Sword
{
    public class Sword : Arms
    {
        public Sword(int strength, string name, int price)
        {
            this.strength = strength;
            this.name = name;
            this.price = price;
        }
    }
}
