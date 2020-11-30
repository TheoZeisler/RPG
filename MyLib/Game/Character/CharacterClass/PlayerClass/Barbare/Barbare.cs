using RPG.Game.Character.CharacterClass.Items.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Game.Character.CharacterClass.PlayerClass.Barbare
{
    public class Barbare : Player
    {
        public Barbare()
        {
            strength = 6;
            Constitution = 15;
            hp = constitution * lvl * 5;
            hpMax = hp;
            mana = intel * lvl * 2;
            money = 50;
            xpMax = 100;
        }
        
    }
}
