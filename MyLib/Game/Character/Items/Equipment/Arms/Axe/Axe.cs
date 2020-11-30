using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Game.Character.Items.Equipment.Arms.Axe
{
    public class Axe : Arms
    {
        public Axe(int strength, string name, int price)
        {
            this.strength = strength;
            this.name = name;
            this.price = price;
        }
    }
}
