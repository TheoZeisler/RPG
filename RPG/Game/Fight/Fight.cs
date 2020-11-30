using MyLib.Game.Character.CharacterClass;
using MyLib.Game.Character.Items;
using MyLib.Game.Character.Items.Consumable.Potion;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG
{
    class Fight
    {
        private Player player;
        private Monster monster;
        private int nbFight = 1;
        private List<Items> inventory;

        public Fight(Player p, Monster m, int nbFight, List<Items> inventory)
        {
            player = p;
            monster = m;
            this.nbFight = nbFight;
            this.inventory = inventory;
        }
        //Menu principal du combat
        public void versus(GamePlay gamePlay)
        {
            int number = 4;
            int choice = 0;
            bool turn = true;
            bool fight = true;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vous avez été agressé par un "+ monster.Name +" !\nVous entrez en combat !\n");
            while (fight)
            {   
                if (turn)
                {
                    menuFight();
                    choice = gamePlay.verif(number);
                    switch (choice)
                    {
                        case 1:
                            attack();
                            break;
                        case 2:
                            if(player.Hp != player.HpMax)
                            {
                                consumable(gamePlay);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Tu es full hp");
                                Console.ResetColor();
                                turn = !turn;
                            }
                            break;
                        case 3:
                            escape(ref fight);
                            break;
                    }
                }
                else
                {
                    monsterTurn();
                    
                }
                turn = !turn;
                endVersus(ref fight, gamePlay);
            }
        }
        //Fonction d'attaque
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
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\nVous avez attaqué le  " + monster.Name + " !\nIl subit " + attack + " points de dégats. Il lui reste " + monster.Hp + " pv");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\nVous n'avez pas réussi à attaquer ! Il lui reste " + monster.Hp + " pv");
            }
               
        }
            //Fonction pour utiliser un consommable
        public void consumable(GamePlay gamePlay)
        {
            int choice = 0;
            Console.WriteLine("Quelle potions voulez vous utiliser ? ");
            for(int i = 0; i < inventory.Count(); i++)
            {
                if(inventory[i].GetType() == typeof(Potions))
                {
                    Console.WriteLine(i+ "- " + inventory[i].Name);
                }
            }
            Console.WriteLine(inventory.Count() + "- Retour");
            choice = gamePlay.verif(inventory.Count());
            if(choice == inventory.Count())
            {
                menuFight();
            }
            else
            {
                player.Hp += inventory[choice - 1].Health;
                if(player.Hp > player.HpMax)
                {
                    player.Hp = player.HpMax;
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nVous avez maintenant " + player.Hp + " hp\n");
                Console.ResetColor();
            }
            
        }
        //Fonction pour fuir
        public void escape(ref bool fight)
        {
            Random rand = new Random();
            if((player.Strength/2) + player.Dexterity + (player.Constitution/6) + rand.Next(20) > monster.Strength + (2 * monster.Dexterity))
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("------\n\nVous prenez la fuite !");
                Console.ResetColor();
                fight = !fight;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("------\n\nImpossible de fuir !");
                Console.ResetColor();
            }
        }
        //Fonction qui met fin au combat
        public void endVersus(ref bool fight, GamePlay gamePlay)
        {
            if (player.Hp == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("------\n\nVous êtes mort. Vous réapparaissez à l'auberge. Vous avez perdu 25 deniers\n" +
                    "Votre vie a été régénéré au maximum");
                Console.ResetColor();
                player.Money -= 25;
                player.Hp = player.HpMax;
                fight = !fight;
                
            }
            else if (monster.Hp == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("------\n\nVictoire ! Vous avez tué le  " + monster.Name + " ! Vous avez gagné " + (10 * nbFight) + " deniers et " + (50 * nbFight) + "xp\n");
                Console.ResetColor();
                monster.Hp = monster.HpMax;
                Console.WriteLine(monster.Hp + " aaaa  " + monster.HpMax);
                //monster.removeMonsterIfDead();
                player.CurrentXp += 50 * nbFight;
                if(player.CurrentXp >= player.XpMax)
                {
                    lvlUp();
                }
                player.Money += 10 * nbFight;
                continueToFight(gamePlay, ref fight);
            }
        }
        //Tour du monstre
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("------\n\nLe  " + monster.Name + " vous a attaqué !\nVous avez subit " + attack + " points de dégats. Il vous reste " + player.Hp + " pv");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("------\n\nLe  " + monster.Name + " vous a loupé ! Il vous reste " + player.Hp + " pv");
            }
        }

        //Fonction qui permet d'enchaîner les combats
        public void continueToFight(GamePlay gamePlay, ref bool fight)
        {
            Console.WriteLine("\nVoulez vous continuer à combattre ?\n1- Oui\n2- Non ");
            switch (gamePlay.verif(2))
            {
                case 1:
                    nbFight++;
                    Fight f = new Fight(player, monster.getMonster(player), nbFight, inventory);
                    fight = !fight;
                    f.versus(gamePlay);
                    break;
                case 2:
                    nbFight = 1;
                    fight = !fight;
                    break;
            }
        }
        //Fonction qui permet au jouer de passer un niveau
        public void lvlUp()
        {
            if(player.CurrentXp > player.XpMax)
            {
                player.CurrentXp -= player.XpMax;
            }
            else
            {
                player.CurrentXp = 0;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Vous venez de paser un niveau ! Vos statistiques augmentent");
            Console.ResetColor();
            player.Lvl++;
            player.XpMax = player.XpMax * 2;
            player.Dexterity++;
            player.Strength++;
            player.Intel++;
            player.HpMax += 5;
            player.Hp += 5;
        }
        //Menu du combat
        public void menuFight()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n1-Attaquer      2-Consommable\n          3-Fuir\n");
        }
    }

}
