using RPG.Game.Character.CharacterClass.CharacterInterfaces;
using RPG.Game.Character.CharacterInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Game.Character.CharacterClass
{
    class Player : Character, IAttack, IDefense
    {
        protected int hp;
        protected int hpMax;
        protected int mana;
        protected int armorClass;

        public int Attack(int strength)
        {
            int attack = 0;
            Random rand = new Random();
            attack = strength + rand.Next((30 * strength) / 100, (70 * strength) / 100);
            return attack;
        }
        public int Lvl
        {
            get => lvl;
            set => lvl = value;
        }
        public int HpMax
        {
            get => hpMax;
            protected set => hpMax = value;
        }
        public int Hp
        {
            get => hp;
            set => hp = value;
        }
        public int Strength
        {
            get => strength;
            set => strength = value;
        }
        public int Dexterity
        {
            get => dexterity;
            set => dexterity = value;
        }
        public int Intel
        {
            get => intel;
            set => intel = value;
        }
        public int Constitution
        {
            get => constitution;
            set => constitution = value;
        }
        public int Armor
        {
            get => armor;
            set => armor = value;
        }
        public string Name
        {
            get => name;
            protected set => name = value;
        }
        public void customization(Player p)
        {
            Console.WriteLine("Entrer votre nom de personnage :");
            p.name = Console.ReadLine();
        }

        public int Defense(int dexterity, int armor)
        {
            dexterity = this.dexterity;
            armor = this.armor;
            int CA = dexterity * armor;
            return CA;
        }
    }
}
