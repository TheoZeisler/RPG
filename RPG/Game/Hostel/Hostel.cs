using MyLib.Game.Character.CharacterClass;
using System;

namespace RPG.Game.Hostel
{
    class Hostel
    {
        private Player p;
        public Hostel(Player p)
        {
            this.p = p;
        }

        public void enter(GamePlay gamePlay)
        {
            int number = 4;
            Console.WriteLine("Bienvenue dans l'auberge. Que voulez vous faire ?\n" +
                "1- Régénération de 25% des pv max (15 deniers)\n" +
                "2- Régénération de 50% des pv max (40 deniers)\n" +
                "3- Régénération de 100% des pv max (100 deniers)\n" +
                "4- Retour\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Vous avez " + p.Money + " deniers");
            Console.ResetColor();
            switch (gamePlay.verif(number))
            {
                case 1:
                    if (p.Hp != p.HpMax)
                    {
                        regen25(gamePlay);
                    }
                    else
                    {
                        hpMax();
                    }
                    break;
                case 2:
                    if (p.Hp != p.HpMax)
                    {
                        regen50(gamePlay);
                    }
                    else
                    {
                        hpMax();
                    }
                    break;
                case 3:
                    if (p.Hp != p.HpMax)
                    {
                        regen100(gamePlay);
                    }
                    else
                    {
                        hpMax();
                    }
                    break;
                case 4:
                    break;
            }
        }
        public void regen25(GamePlay gamePlay)
        {
            if (hasMoney(15))
            {
                p.Hp += (p.HpMax * 25) / 100;
                if (p.Hp > p.HpMax)
                {
                    p.Hp = p.HpMax;
                }
                p.Money -= 15;
                regenDone();
            }
            else
            {
                notEnough();
            }
            enter(gamePlay);
        }
        public void regen50(GamePlay gamePlay)
        {
            if(hasMoney(40))
            {
                p.Hp += (p.HpMax * 50) / 100;
                if (p.Hp > p.HpMax)
                {
                    p.Hp = p.HpMax;
                }
                p.Money -= 40;
                regenDone();
            }
            else
            {
                notEnough();
            }
            enter(gamePlay);
        }
        public void regen100(GamePlay gamePlay)
        {
            if(hasMoney(100))
            {
                p.Hp = p.HpMax;
                p.Money -= 100;
                regenDone();
            }
            else
            {
                notEnough();
            }
            enter(gamePlay);
        }
        public void regenDone()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Regénération faite. Vous avez maintenant " + p.Hp + " hp");
            Console.ResetColor();
        }
        public bool hasMoney(int price)
        {
            if (p.Money < price)
            {
                return false;
            }
            return true;
        }
        public void notEnough()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Tu n'as pas assez de deniers");
            Console.ResetColor();
        }
        public void hpMax()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Tes hp sont au maximun, reviens ici quand tu auras perdu de la vie\n");
            Console.ResetColor();
        }
    }
}
