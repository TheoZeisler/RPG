using RPG.Game.Character.CharacterClass.Items.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Game.Character.CharacterClass.PlayerClass.Voleur
{
    class Voleur : Player
    {
        public Voleur()
        {
            Constitution = 7;
            dexterity = 5;
            strength = 3;
            hp = constitution * lvl * 5;
            hpMax = hp;
            mana = intel * lvl * 2;
            money = 50;
            xpMax = 100;
        }
        
    }
}
