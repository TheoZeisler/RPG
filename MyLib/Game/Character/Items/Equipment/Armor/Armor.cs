using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Game.Character.Items.Equipment.Armor
{
    public class Armor : Equipment
    {
        protected int armor;
        public int ArmorPoint
        {
            get => armor;
            private set => armor = value;
        }

    }
}
