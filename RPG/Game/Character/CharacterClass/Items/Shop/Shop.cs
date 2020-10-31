using RPG.Game.Character.CharacterClass;
using RPG.Game.Character.CharacterClass.Items;
using RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Armor;
using RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Armor.Boots;
using RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Armor.Chestplate;
using RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Armor.Helmet;
using RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Armor.LegWarmer;
using RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Armor.Shield;
using RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Arms;
using RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Arms.Axe;
using RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Arms.Bow;
using RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Arms.Sword;
using RPG.Game.Character.CharacterClass.Items.Inventory.Equipment.Arms.Two_handed_sword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Game
{
    class Shop : Items
    {
        private List<Arms> shopArms;
        private List<Armor> shopArmor;
        private List<Items> shopConsumable;

        public Shop()
        {
            shopArms = new List<Arms>();
            shopArmor = new List<Armor>();
            shopConsumable = new List<Items>();
            Sword glaive = new Sword(3, "Glaive");
            Sword katana = new Sword(5, "Katana");
            Axe axe = new Axe(6, "Hache de viking");
            Bow bow = new Bow(4, "Arc Lavoine");
            Two_handed_sword sabre = new Two_handed_sword(8, "Le sabre");
            Two_handed_sword tS = new Two_handed_sword(11, "L'épée longue");
            shopArms.Add(glaive);
            shopArms.Add(katana);
            shopArms.Add(axe);
            shopArms.Add(bow);
            shopArms.Add(sabre);
            shopArms.Add(tS);
            Helmet lowHelmet = new Helmet(2, "Casque en maille");
            Helmet mediumHelmet = new Helmet(4, "Casque en fer");
            Helmet highHelmet = new Helmet(8, "Casque en diamant");
            Boots lowBoots = new Boots(2, "Botte en maille");
            Boots mediumBoots = new Boots(2, "Botte en fer");
            Boots highBoots = new Boots(2, "Botte en diamant");
            Chestplate lowChestplate = new Chestplate(4, "Plastron en maille");
            Chestplate mediumChestplate = new Chestplate(8, "Plastron en fer");
            Chestplate highChestplate = new Chestplate(20, "Plastron en diamant");
            LegWarmer lowLegwarmer = new LegWarmer(3, "Jambière en maille");
            LegWarmer mediumLegwarmer = new LegWarmer(6, "Jambière en fer");
            LegWarmer highLegwarmer = new LegWarmer(16, "Jambière en diamant");
            Shield lowShield = new Shield(1, "Bouclier en bois");
            Shield mediumShield = new Shield(4, "Bouclier en fer");
            Shield highShield = new Shield(10, "Bouclier humain");
            shopArmor.Add(lowHelmet);
            shopArmor.Add(mediumHelmet);
            shopArmor.Add(highHelmet);
            shopArmor.Add(lowBoots);
            shopArmor.Add(mediumBoots);
            shopArmor.Add(highBoots);
            shopArmor.Add(lowChestplate);
            shopArmor.Add(mediumChestplate);
            shopArmor.Add(highChestplate);
            shopArmor.Add(lowLegwarmer);
            shopArmor.Add(mediumLegwarmer);
            shopArmor.Add(highLegwarmer);
            shopArmor.Add(lowShield);
            shopArmor.Add(mediumShield);
            shopArmor.Add(highShield);

        }


        public List<Arms> getShopArms()
        {
            return shopArms;
        }
        public List<Armor> getShopArmor()
        {
            return shopArmor;
        }
        public List<Items> getShopConsumable()
        {
            return shopConsumable;
        }

        public void enter(Player p, GamePlay gamePlay)
        {
            int number = 2;
            Console.Clear();
            Console.WriteLine("Bonjour " + p.Name + " que voulez vous ?\n1- Acheter\n2-Quitter vers le menu" );
            switch (gamePlay.verif(number))
            {
                case 1:
                    chooseShop(p, gamePlay);
                    break;
                case 2:
                    gamePlay.menu();
                    break;
            }

        }
        public void chooseShop(Player p,GamePlay gamePlay)
        {
            int number = 4;
            Console.Clear();
            Console.WriteLine("Que voulez vous acheter ?\n1- Armes\n2- Armures\n3- Consommable\n4- Retour");
            switch(gamePlay.verif(number)){
                case 1:
                    armsShop(p, gamePlay);
                    break;
                case 2:
                    armorShop(p, gamePlay);
                    break;
                case 3:
                    consumableShop(p, gamePlay);
                    break;
                case 4:
                    enter(p, gamePlay);
                    break;
            }
        }
        public void armsShop(Player p, GamePlay gamePlay)
        {
            Console.Clear();
            Console.WriteLine("Voici la liste des armes que vous pouvez acheter :");
            for(int i = 0; i < shopArms.Count(); i++)
            {
                Console.WriteLine(shopArms[i].Name);
            }
        }
        public void armorShop(Player p, GamePlay gamePlay)
        {
            Console.Clear();
            Console.WriteLine("Voici la liste des armes que vous pouvez acheter :");
            for (int i = 0; i < shopArmor.Count(); i++)
            {
                Console.WriteLine(shopArmor[i].Name);
            }
        }
        public void consumableShop(Player p, GamePlay gamePlay)
        {

        }
    }
}
