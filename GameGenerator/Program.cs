using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            CrudMonster cM = new CrudMonster();
            CrudShop cS = new CrudShop();
            bool crudEdit = true;
            while (crudEdit)
            {
                Console.WriteLine("Bienvenue dans la génération de toutes les entitées du jeu\n" +
                                "1- Crud monster (Create / Read / Update / Delete)\n" +
                                "2- Crud shop\n" +
                                "3- Quitter");
                switch (verif(3))
                {
                    case 1:
                        cM.monsterManager();
                        break;
                    case 2:
                        cS.shopManager();
                        break;
                    case 3:
                        crudEdit = false;
                        break;
                }
            }
        }
            
        static public int verif(int number)
        {
            bool isInt = false;
            int goodChoice = 0;
            while (!isInt || goodChoice > number || goodChoice < 1)
            {
                string choice = Console.ReadLine();
                isInt = int.TryParse(choice, out goodChoice);
                if (!isInt)
                {
                    Console.WriteLine("Réessayer");
                }
            }
            return goodChoice;
        }
    }
}
