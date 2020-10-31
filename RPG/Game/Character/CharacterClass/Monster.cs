using RPG.Game.Character.CharacterClass.CharacterInterfaces;
using RPG.Game.Character.CharacterInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Game.Character.CharacterClass
{
    class Monster : Character, IAttack, IDefense
    {
        private int hp;
        private List<Monster> monstersList = new List<Monster>();

        public Monster(int constitution, int strength, int dexterity, int armor)
        {
            this.dexterity = dexterity;
            this.armor = armor;
            this.constitution = constitution;
            this.strength = strength;
            hp = constitution * lvl * 5;
        }
        public Monster()
        {

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
            attack = strength + rand.Next((30/100)*strength, (70/100)*strength);
            return attack;
        }

        public Monster createMonster()
        {
            Random rand = new Random();
            Monster m = new Monster(rand.Next(3, 17), rand.Next(1,4), rand.Next(1,3) , rand.Next(1,3));
            return m;
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
            for(int i = 0; i < monstersList.Count(); i++)
            {
                if(monstersList[i].Hp <= 0)
                {
                    monstersList.RemoveAt(i);
                }
            }
        }
    }
}
