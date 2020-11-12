
namespace MyLib.Game.Character.Items
{
    class Items 
    {
        protected string name;
        protected int price;
        protected bool isEquip;
        protected int health;

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
