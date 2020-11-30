using MyLib.Game.Character.CharacterClass;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGenerator
{
    class CrudMonster
    {
        private string serveur;
        private string database;
        private string uid;
        private string password;
        private MySqlConnection run;
        private MySqlCommand cmd;
        private MySqlDataReader dataReader;


        public void createMonster()
        {
            int dexterity, armor, strength, constitution, lvl;
            string name;
            Console.WriteLine("Création d'un monstre :\n" +
                "Nom : ");
            name = Console.ReadLine();
            Console.WriteLine("Dexterité : ");
            dexterity = verifIsDigit();
            Console.WriteLine("Armure : ");
            armor = verifIsDigit();
            Console.WriteLine("Force : ");
            strength = verifIsDigit();
            Console.WriteLine("Constitution : ");
            constitution = verifIsDigit();
            Console.WriteLine("Niveau du monstre : ");
            lvl = verifIsDigit();

            string query = "INSERT INTO monster (name, dexterity, armor, strength, constitution, lvl) VALUES ('"+ name  + "', "+ dexterity + ", " + armor + ", " + strength + ", " + constitution + ", " + lvl + ")";
            connection();
            run.Open();
            cmd = new MySqlCommand(query, run);
            cmd.ExecuteNonQuery();
            run.Close();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Monstre crée");
            Console.ResetColor();
            monsterManager();
        }

        public int readMonster()
        {
            int id;
            int hp = 0; ;
            int constitution;
            int lvl;
            List<string> monster = new List<string>();
            id = getIdMonster();
            string query = "SELECT * FROM monster WHERE id=" + id;
            connection();
            run.Open();
            cmd = new MySqlCommand(query, run);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                monster.Add(dataReader["name"] + "");
                monster.Add(dataReader["dexterity"] + "");
                monster.Add(dataReader["armor"] + "");
                monster.Add(dataReader["strength"] + "");
                constitution = int.Parse(dataReader["constitution"] + "");
                monster.Add(dataReader["constitution"] + "");
                lvl = int.Parse(dataReader["lvl"] + "");
                monster.Add(dataReader["lvl"] + "");
                hp = constitution * lvl * 5;
            }
            dataReader.Close();
            run.Close();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Voici votre monstre : \n");
            Console.ResetColor();
            Console.WriteLine("Nom : " + monster[0].ToString() + "/ Dexterité : " + monster[1].ToString() + "/ Armure : " + monster[2].ToString() + "/ Force : " + monster[3].ToString() + "/ Hp : " + hp + "/ Lvl : " + monster[5].ToString() + "\n");
            return id;
        }
        public void readAllMonster()
        {
            int space = 20;
            int tempSpace = 0;
            int constitution;
            int hp;
            int lvl;
            string hpString;
            List<string> monsterId = new List<string>();
            List<string> monsterName = new List<string>();
            List<string> monsterDexterity = new List<string>();
            List<string> monsterArmor = new List<string>();
            List<string> monsterStrength = new List<string>();
            List<string> monsterHp = new List<string>();
            List<string> monsterLvl = new List<string>();
            string query = "SELECT * FROM monster";
            connection();
            run.Open();
            cmd = new MySqlCommand(query, run);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                monsterId.Add(dataReader["id"] + "");
                monsterName.Add(dataReader["name"] + "");
                monsterDexterity.Add(dataReader["dexterity"] + "");
                monsterArmor.Add(dataReader["armor"] + "");
                monsterStrength.Add(dataReader["strength"] + "");
                constitution = int.Parse(dataReader["constitution"] + "");
                lvl = int.Parse(dataReader["lvl"] + "");
                monsterLvl.Add(dataReader["lvl"] + "");
                hp = constitution * lvl * 5;
                hpString = hp.ToString();
                monsterHp.Add(hpString);
            }
            dataReader.Close();
            run.Close();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Voici la liste des monstres : \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Id           ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Nom           ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Dexterité              ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Armure               ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Force                  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Hp                 ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Lvl\n");
            Console.ResetColor();
            for(int i = 0; i < monsterId.Count(); i++)
            {
                Console.Write(monsterId[i].ToString());
                tempSpace = space - monsterName[i].Length - 5;
                for (int j = 0; j < tempSpace; j++)
                {
                    Console.Write(" ");
                }
                Console.Write(monsterName[i].ToString());
                tempSpace = space - monsterDexterity[i].Length;
                for (int j = 0; j < tempSpace; j++)
                {
                    Console.Write(" ");
                }
                Console.Write(monsterDexterity[i].ToString());
                tempSpace = space - monsterArmor[i].Length;
                for (int j = 0; j < tempSpace; j++)
                {
                    Console.Write(" ");
                }
                Console.Write(monsterArmor[i].ToString());
                tempSpace = space - monsterStrength[i].Length;
                for (int j = 0; j < tempSpace; j++)
                {
                    Console.Write(" ");
                }
                Console.Write(monsterStrength[i].ToString());
                tempSpace = space - monsterHp[i].Length;
                for (int j = 0; j < tempSpace; j++)
                {
                    Console.Write(" ");
                }
                Console.Write(monsterHp[i].ToString());
                tempSpace = space - monsterLvl[i].Length;
                for (int j = 0; j < tempSpace; j++)
                {
                    Console.Write(" ");
                }
                Console.Write(monsterLvl[i].ToString()+ "\n\n");  
            }
            monsterManager();
        }

        public void updateMonster()
        {
            int id;
            Console.WriteLine("Modification d'un monstre :");
            id = readMonster();
            Console.WriteLine("Etes vous sur de vouloir modifier ce monstre ? (1- Oui/2- Non)\n");
            switch (verif(2))
            {
                case 1:
                    int dexterity, armor, strength, constitution, lvl;
                    string name;
                    Console.WriteLine("modification du monstre :\n" +
                        "Nom : ");
                    name = Console.ReadLine();
                    Console.WriteLine("Dexterité : ");
                    dexterity = verifIsDigit();
                    Console.WriteLine("Armure : ");
                    armor = verifIsDigit();
                    Console.WriteLine("Force : ");
                    strength = verifIsDigit();
                    Console.WriteLine("Constitution : ");
                    constitution = verifIsDigit();
                    Console.WriteLine("Niveau du monstre : ");
                    lvl = verifIsDigit();
                    string query = "UPDATE monster SET name = '" + name + "', dexterity = " + dexterity + ", armor = " + armor + ", strength = " + strength + ", constitution = " + constitution + ", lvl = " + lvl + " WHERE id = " + id;
                    connection();
                    run.Open();
                    cmd = new MySqlCommand(query, run);
                    cmd.ExecuteNonQuery();
                    run.Close();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Monstre modifié");
                    Console.ResetColor();
                    break;
                case 2:
                    break;
            }
            monsterManager();
        }

        public void deleteMonster()
        {
            int id;
            Console.WriteLine("Suppression d'un monstre.");
            id = readMonster();
            
            Console.WriteLine("Etes vous sur de vouloir supprimer ce monstre ? (1- Oui/2- Non)\n");
            switch (verif(2))
            {
                case 1:
                    string query = "DELETE FROM monster WHERE id = " + id;
                    connection();
                    run.Open();
                    cmd = new MySqlCommand(query, run);
                    cmd.ExecuteNonQuery();
                    run.Close();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Monstre supprimé");
                    Console.ResetColor();
                    break;
                case 2:
                    break;
            }

            monsterManager();
        }
        public int verifIsDigit()
        {
            bool isInt = false;
            int goodChoice = 0;
            while (!isInt && goodChoice <= 0)
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
        public void monsterManager()
        {
            Console.WriteLine("Vous êtes dans le manager de monstre.\n" +
                "1- Crée un monstre\n" +
                "2- Supprimer un monstre\n" +
                "3- Modifier un monstre\n" +
                "4- Récupérer un monstre\n" +
                "5- Récupérer tous les monstres\n" +
                "6- Retour");
            switch (verif(6))
            {
                case 1:
                    createMonster();
                    break;
                case 2:
                    deleteMonster();
                    break;
                case 3:
                    updateMonster();
                    break;
                case 4:
                    readMonster();
                    monsterManager();
                    break;
                case 5:
                    readAllMonster();
                    break;
                case 6:
                    break;
            }
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
        public void connection()
        {
            serveur = "localhost";
            database = "rpg";
            uid = "root";
            password = "1234";
            string connectionString;
            connectionString = "SERVER=" + serveur + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            run = new MySqlConnection(connectionString);
        }
        public int getIdMonster()
        {
            int id;
            Console.WriteLine("Id du monstre : ");
            id = verifIsDigit();
            return id;
        }
    }
}
