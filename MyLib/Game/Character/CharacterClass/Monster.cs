using MyLib.Game.Character.CharracterInterfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Game.Character.CharacterClass
{
    public class Monster : Character, IAttack, IDefense
    {
        private string serveur;
        private string database;
        private string uid;
        private string password;
        private MySqlConnection run;
        private MySqlCommand cmd;
        private MySqlDataReader dataReader;
        private int hp;
        private int hpMax;
        private Monster m;
        private List<Monster> monstersList = new List<Monster>();

        public Monster(int strength, int dexterity, int armor, int hp, string name)
        {
            this.dexterity = dexterity;
            this.armor = armor;
            this.strength = strength;
            this.hp = hp;
            this.name = name;
            this.hpMax = hp;
        }
        public Monster()
        {
            int dexterity, armor, strength, lvl, constitution, hp = 0;
            string name = " ";
            string query = "SELECT * FROM monster";
            connection();
            run.Open();
            cmd = new MySqlCommand(query, run);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                name = (dataReader["name"] + "");
                dexterity = int.Parse(dataReader["dexterity"] + "");
                armor = int.Parse(dataReader["armor"] + "");
                strength = int.Parse(dataReader["strength"] + "");
                constitution = int.Parse(dataReader["constitution"] + "");
                lvl = int.Parse(dataReader["lvl"] + "");
                hp = constitution * lvl * 5;
                m = new Monster(strength, dexterity, armor, hp, name);
                monstersList.Add(m);
            }
            dataReader.Close();
            run.Close();
        }
        public Monster(bool t)
        {

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
        public int HpMax
        {
            get => hpMax;
            set => hpMax = value;
        }

        public int Strength
        {
            get => strength;
            protected set => strength = value;
        }

        public int Lvl
        {
            get => lvl;
            set => lvl = value;
        }

        protected int Constitution
        {
            get => constitution;
            set => constitution = value;
        }
        public int Hp
        {
            get => hp;
            set => hp = value;
        }
        public string Name
        {
            get => name;
            protected set => name = value;
        }
        public int Armor
        {
            get => armor;
            protected set => armor = value;
        }
        public int Dexterity
        {
            get => dexterity;
            protected set => dexterity = value;
        }
        public int Attack(int strength)
        {
            int attack = 0;
            Random rand = new Random();
            attack = strength + rand.Next((30 / 100) * strength, (70 / 100) * strength);
            return attack;
        }

        public int Defense(int dexterity, int armor)
        {
            dexterity = this.dexterity;
            armor = this.armor;
            int CA = dexterity * armor;
            return CA;
        }
        public void removeMonsterIfDead()
        {
            for (int i = 0; i < monstersList.Count(); i++)
            {
                if (monstersList[i].Hp <= 0)
                {
                    monstersList.RemoveAt(i);
                }
            }
        }
        public Monster getMonster(Player p)
        {
            
            int number = 0;
            bool noMonster = false;
            Random rand = new Random();
            while(noMonster == false)
            {
                number = 1;
                if (monstersList[number].Lvl <= p.Lvl )
                {
                    noMonster = true;
                    m = monstersList[number];
                }
            }
            return m;
        }
    }
}
