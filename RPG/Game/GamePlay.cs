using RPG.Game.Character.CharacterClass;
using RPG.Game.Character.CharacterClass.PlayerClass;
using RPG.Game.Character.CharacterClass.PlayerClass.Archer;
using RPG.Game.Character.CharacterClass.PlayerClass.Barbare;
using RPG.Game.Character.CharacterClass.PlayerClass.Mage;
using RPG.Game.Character.CharacterClass.PlayerClass.Voleur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class GamePlay
    {
        public void start()
        {
            Console.WriteLine("Bienvenue jeune aventurier dans ce RPG !\nPour comencer il faut que tu choissises un personnage.\n4 choix s'offre à toi :\n" +
                "-Le Barbare : Il permet de frapper fort tout en encaissant beaucoup de coups\n~~~~\n" +
                "-Le Mage : Il frappe avec des sorts puissants tout en ayant beaucoup de mana\n~~~~\n" +
                "-L'Archer : Il peux attaquer à l'aide d'un arc mais il est très peu résistant\n~~~~\n" +
                "-Le Voleur : Il a beaucoup de dextérité et il gagne plus d'argent par combat\n~~~~\n" +
                "Taper 1 pour le Barbare / 2 pour le Mage / 3 pour l'Archer / 4 pour le Voleur\n");
        }
        public int verif(int number)
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
        public Player createPlayer(int playerChoice)
        {
            switch (playerChoice)
            {
                case 1:
                    Barbare barbare = new Barbare();
                    Console.WriteLine("Création d'un Barbare");
                    return barbare;
                case 2:
                    Mage mage = new Mage();
                    Console.WriteLine("Création d'un Mage");
                    return mage;
                case 3:
                    Archer archer = new Archer();
                        Console.WriteLine("Création d'un Archer");
                    return archer;
                case 4:
                    Voleur voleur = new Voleur();
                        Console.WriteLine("Création d'un Voleur");
                    return voleur;
            }
            Player p = new Player();
            return p ;
        }
        public void menu()
        {
            Console.WriteLine("--- Menu du jeu ---\n" +
                "Tape 1 si tu veux te battre contre un monstre\n" +
                "Tape 2 si tu veux aller à l'auberge pour régénérer tes points de vie\n" +
                "Tape 3 si tu veux aller au shop acheter des équipements\n" +
                "Tape 4 Si tu veux aller à la Mairie pour sauvegarder ta partie\n\n");
        }
    }
}
