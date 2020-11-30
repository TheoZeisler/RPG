
namespace MyLib.Game.Character.Items
{
    public class Items
    {
        protected string name;
        protected int price;
        protected bool isEquip;
        protected int health;
        protected int strength;
        protected int armor;
        public int ArmorPoint
        {
            get => armor;
            private set => armor = value;
        }

        public int Strength
        {
            get => strength;
            private set => strength = value;
        }

        public int Price
        {
            get => price;
            private set => price = value;
        }
        public string Name
        {
            get => name;
            private set => name = value;
        }
        public bool IsEquip
        {
            get => isEquip;
            set => isEquip = value;
        }
        public int Health
        {
            get => health;
            private set => health = value;
        }

    }
}
