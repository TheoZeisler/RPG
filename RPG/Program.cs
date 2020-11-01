using RPG.Game;
using RPG.Game.Character;
using RPG.Game.Character.CharacterClass;
using RPG.Game.Character.CharacterClass.Items;
using RPG.Game.Character.CharacterClass.Items.Inventory;
using RPG.Game.Character.CharacterClass.PlayerClass;
using RPG.Game.Hostel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Program
    {

        static void Main(string[] args)
        {
            GamePlay gamePlay = new GamePlay();
            gamePlay.launch(gamePlay);
        }
    }
}
