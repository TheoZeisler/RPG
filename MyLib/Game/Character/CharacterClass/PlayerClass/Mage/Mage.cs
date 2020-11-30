using RPG.Game.Character.CharacterClass.Items.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Game.Character.CharacterClass.PlayerClass.Mage
{
    public class Mage : Player
    {
        public Mage()
        {
            intel = 5;
            Constitution = 8;
            strength = 2;
            hp = constitution * lvl * 5;
            hpMax = hp;
            mana = intel * lvl * 2;
            money = 50;
            xpMax = 100;
        }
       
    }
}
