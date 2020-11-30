using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Game.Character.Items.Equipment.Arms.Two_handed_sword
{
    public class Two_handed_sword : Arms
    {
        public Two_handed_sword(int strength, string name, int price)
        {
            this.strength = strength;
            this.name = name;
            this.price = price;
        }

    }
}
