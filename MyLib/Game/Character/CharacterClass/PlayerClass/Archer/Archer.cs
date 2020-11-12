using RPG.Game.Character.CharacterClass.Items.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Game.Character.CharacterClass.PlayerClass.Archer
{
    class Archer : Player
    {
        public Archer()
        {
            Constitution = 5;
            strength = 7;
            dexterity = 3;
            hp = constitution * lvl * 5;
            hpMax = hp;
            mana = intel * lvl * 2;
            money = 50;
            xpMax = 100;
        }
        
    }
}
