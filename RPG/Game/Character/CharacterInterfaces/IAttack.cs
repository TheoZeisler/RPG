using RPG.Game.Character.CharacterClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Game.Character.CharacterInterfaces
{
    interface IAttack
    {
        int Attack(int strength);
    }
}
