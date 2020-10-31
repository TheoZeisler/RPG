using RPG.Game.Character;
using RPG.Game.Character.CharacterClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Fight
    {
        private Player player;
        private Monster monster;

        public Fight(Player p, Monster m)
        {
            player = p;
            monster = m;
        }
        public void versus(GamePlay gamePlay)
        {
            int number = 4;
            int choice = 0;
            bool turn = true;
            bool fight = true;

            Console.WriteLine("Vous avez été agressé par un monstre !\nVous entrez en combat !\n");
            while (fight)
            {   
                if (turn)
                {
                    Console.WriteLine("\n\n1-Attaquer       2-Sort\n3-Consommable    4-Fuir\n");
                    choice = gamePlay.verif(number);
                    switch (choice)
                    {
                        case 1:
                            attack();
                            break;
                        case 2:
                            spell();
                            break;
                        case 3:
                            consumable();
                            break;
                        case 4:
                            escape(ref fight);
                            break;
                    }
                }
                else
                {
                    monsterTurn();
                    
                }
                turn = !turn;
                endVersus(ref fight);
            }
        }
        public void attack()
        {
            int attack = player.Attack(player.Strength);
            int defense = monster.Defense(monster.Dexterity, monster.Armor);
            if (attack > defense)
            {
                monster.Hp -= attack;
                if(monster.Hp < 0)
                {
                    monster.Hp = 0;
                }
                Console.WriteLine("\n\nVous avez attaqué le monstre !\nIl subit " + attack + " points de dégats. Il lui reste " + monster.Hp + " pv");
                Console.Read();
            }
            else
            {
                Console.WriteLine("\n\nVous n'avez pas réussi à attaquer ! Il lui reste " + monster.Hp + " pv");
                Console.Read();
            }
               
        }
            
        public void spell()
        {

        }
        public void consumable()
        {
            
        }
        public void escape(ref bool fight)
        {
            Random rand = new Random();
            if((player.Strength/2) + player.Dexterity + (player.Constitution/6) + rand.Next(20) > monster.Strength + (2 * monster.Dexterity))
            {
                Console.WriteLine("------\n\nVous prenez la fuite !");
                fight = !fight;
            }
            else
            {
                Console.WriteLine("------\n\nImpossible de fuir !");
            }
        }
        public void endVersus(ref bool fight)
        {
            if (player.Hp == 0)
            {
                Console.WriteLine("------\n\nVous êtes mort. Vous réapparaissez à l'auberge. Vous avez perdu 1000 deniers\n" +
                    "Votre vie a été régénéré au maximum");
                player.Hp = player.HpMax;
                fight = !fight;
            }
            else if (monster.Hp == 0)
            {
                Console.WriteLine("------\n\nVictoire ! Vous avez tué le monstre !");
                fight = !fight;
            }
        }
        public void monsterTurn()
        {
            int attack = monster.Attack(monster.Strength);
            int defense = monster.Defense(monster.Dexterity, monster.Armor);
            if (attack > defense)
            {
                player.Hp -= attack;
                if (player.Hp < 0)
                {
                    player.Hp = 0;
                }
                Console.WriteLine("------\n\nLe monstre vous a attaqué !\nVous avez subit " + attack + " points de dégats. Il vous reste " + player.Hp + " pv");
                Console.Read();
            }
            else
            {
                Console.WriteLine("------\n\nLe monstre vous a loupé ! Il vous reste " + player.Hp + " pv");
                Console.Read();
            }
        }
    }

}
