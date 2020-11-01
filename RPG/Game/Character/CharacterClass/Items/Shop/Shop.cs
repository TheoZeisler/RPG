using RPG.Game.Character.CharacterClass;
using RPG.Game.Character.CharacterClass.Items;
using RPG.Game.Character.CharacterClass.Items.Inventory.Consumable.Potion;
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
        private List<Potions> shopConsumable;

        public Shop()
        {
            shopArms = new List<Arms>();
            shopArmor = new List<Armor>();
            shopConsumable = new List<Potions>();
            Sword glaive = new Sword(3, "Glaive", 25);
            Sword katana = new Sword(5, "Katana", 40);
            Axe axe = new Axe(6, "Hache de viking", 50);
            Bow bow = new Bow(4, "Arc Lavoine", 35);
            Two_handed_sword sabre = new Two_handed_sword(8, "Le sabre", 75);
            Two_handed_sword tS = new Two_handed_sword(11, "L'épée longue", 100);
            shopArms.Add(glaive);
            shopArms.Add(katana);
            shopArms.Add(axe);
            shopArms.Add(bow);
            shopArms.Add(sabre);
            shopArms.Add(tS);
            Helmet lowHelmet = new Helmet(2, "Casque en maille", 10);
            Helmet mediumHelmet = new Helmet(4, "Casque en fer", 20);
            Helmet highHelmet = new Helmet(8, "Casque en diamant", 50);
            Boots lowBoots = new Boots(2, "Botte en maille", 10);
            Boots mediumBoots = new Boots(2, "Botte en fer", 20);
            Boots highBoots = new Boots(2, "Botte en diamant", 50);
            Chestplate lowChestplate = new Chestplate(4, "Plastron en maille", 25);
            Chestplate mediumChestplate = new Chestplate(8, "Plastron en fer", 50);
            Chestplate highChestplate = new Chestplate(20, "Plastron en diamant", 125);
            LegWarmer lowLegwarmer = new LegWarmer(3, "Jambière en maille", 25);
            LegWarmer mediumLegwarmer = new LegWarmer(6, "Jambière en fer", 50);
            LegWarmer highLegwarmer = new LegWarmer(16, "Jambière en diamant", 125);
            Shield lowShield = new Shield(1, "Bouclier en bois", 15);
            Shield mediumShield = new Shield(4, "Bouclier en fer", 25);
            Shield highShield = new Shield(10, "Bouclier humain", 80);
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
            Potions lowPotion = new Potions(15, "Potion de premier soin", 3);
            shopConsumable.Add(lowPotion);
            Potions potion = new Potions(40, "Potion de soin", 12);
            shopConsumable.Add(potion);
            Potions greatPotion = new Potions(100, "Giga potion", 25);
            shopConsumable.Add(greatPotion);

        }
        //Recupération du shop d'armes
        public List<Arms> getShopArms()
        {
            return shopArms;
        }
        //Recupération du shop d'armoure
        public List<Armor> getShopArmor()
        {
            return shopArmor;
        }
        //Recupération du shop de consommable
        public List<Potions> getShopConsumable()
        {
            return shopConsumable;
        }
        //Introduction du shop / menu du shop
        public void enter(Player p, GamePlay gamePlay, List<Items> inventory)
        {
            int number = 2;
            Console.Clear();
            Console.WriteLine("Bonjour " + p.Name + " que voulez vous ?\n1- Acheter\n2-Quitter vers le menu" );
            switch (gamePlay.verif(number))
            {
                case 1:
                    chooseShop(p, gamePlay, inventory);
                    break;
                case 2:
                    break;
            }

        }
        //Choix dans le shop
        public void chooseShop(Player p,GamePlay gamePlay, List<Items> inventory)
        {
            int number = 4;
            Console.WriteLine("Que voulez vous acheter ?\n1- Armes\n2- Armures\n3- Consommable\n4- Retour");
            switch(gamePlay.verif(number)){
                case 1:
                    armsShop(p, gamePlay, inventory);
                    break;
                case 2:
                    armorShop(p, gamePlay, inventory);
                    break;
                case 3:
                    consumableShop(p, gamePlay, inventory);
                    break;
                case 4:
                    enter(p, gamePlay, inventory);
                    break;
            }
        }
        //Affichage et achat du shop d'armes
        public void armsShop(Player p, GamePlay gamePlay, List<Items> inventory)
        {
            moneyPlayer(p);
            int number = shopArmor.Count() + 1;
            int choice = 0;
            Console.WriteLine("Voici la liste des armes que vous pouvez acheter :");
            for(int i = 1; i <= shopArms.Count(); i++)
            {
                Console.WriteLine(i + "- " + shopArms[i-1].Name + " (" + shopArms[i-1].Price + ") deniers");
            }
            Console.WriteLine(shopArms.Count() + 1 +  " Retour");
            choice = gamePlay.verif(number) -1;
            if(choice == shopArms.Count())
            {
                chooseShop(p, gamePlay, inventory);
            }
            else
            {
                if(hasMoney(p, shopArms[choice]))
                {
                    p.Money -= shopArms[choice].Price;
                    inventory.Add(shopArms[choice]);
                    Console.WriteLine("Voulez vous l'equipé ?\n1- Oui\n2- Non  ");
                    number = 2;
                    int b = gamePlay.verif(number);
                    if (b == 1)
                    {
                        for(int i = 0; i < inventory.Count(); i ++)
                        {
                            if (inventory[i].IsEquip && inventory[i].GetType() == typeof(Arms))
                            {
                                inventory[i].IsEquip = false;
                                p.Strength -= shopArms[choice].Strength;
                            }  
                        }
                        shopArms[choice].IsEquip = true;
                        p.Strength += shopArms[choice].Strength;
                    }
                    shopArms.Remove(shopArms[choice]);
                }
                else
                {
                    notEnough();
                    
                }
                armsShop(p, gamePlay, inventory);
            }
            
        }
        //Affichage et achat du shop d'armures
        public void armorShop(Player p, GamePlay gamePlay, List<Items> inventory)
        {
            moneyPlayer(p);
            int number = shopArmor.Count() + 1;
            int choice = 0;
            Console.WriteLine("Voici la liste des armures que vous pouvez acheter :");
            for (int i = 1; i <= shopArmor.Count(); i++)
            {
                Console.WriteLine(i + "- " + shopArmor[i-1].Name + " (" + shopArmor[i-1].Price + ") deniers");
            }
            Console.WriteLine(shopArmor.Count() + 1 + " Retour");
            choice  = gamePlay.verif(number) -1 ;
            if (choice == shopArmor.Count())
            {
                chooseShop(p, gamePlay, inventory);
            }
            else
            {
                if(hasMoney(p, shopArmor[choice]))
                {
                    p.Money -= shopArmor[choice].Price;
                    inventory.Add(shopArmor[choice]);
                    Console.WriteLine("Voulez vous l'equipé ?\n1- Oui\n2- Non  ");
                    number = 2;
                    int b = gamePlay.verif(number);
                    if (b == 1)
                    {
                        for (int i = 0; i < shopArmor.Count(); i++)
                        {
                            if (shopArmor[i].GetType() == typeof(Helmet) && shopArmor[i].GetType() == shopArmor[choice].GetType())
                            {
                                if (shopArmor[i].IsEquip)
                                {
                                    shopArmor[i].IsEquip = false;
                                    p.Armor -= shopArmor[i].ArmorPoint;
                                }  
                            }
                            if (shopArmor[i].GetType() == typeof(Chestplate) && shopArmor[i].GetType() == shopArmor[choice].GetType())
                            {
                                if (shopArmor[i].IsEquip)
                                {
                                    shopArmor[i].IsEquip = false;
                                    p.Armor -= shopArmor[i].ArmorPoint;
                                }
                            }
                            if (shopArmor[i].GetType() == typeof(LegWarmer) && shopArmor[i].GetType() == shopArmor[choice].GetType())
                            {
                                if (shopArmor[i].IsEquip)
                                {
                                    shopArmor[i].IsEquip = false;
                                    p.Armor -= shopArmor[i].ArmorPoint;
                                }
                            }
                            if (shopArmor[i].GetType() == typeof(Boots) && shopArmor[i].GetType() == shopArmor[choice].GetType())
                            {
                                if (shopArmor[i].IsEquip)
                                {
                                    shopArmor[i].IsEquip = false;
                                    p.Armor -= shopArmor[i].ArmorPoint;
                                }
                            }
                            if (shopArmor[i].GetType() == typeof(Shield) && shopArmor[i].GetType() == shopArmor[choice].GetType())
                            {
                                if (shopArmor[i].IsEquip)
                                {
                                    shopArmor[i].IsEquip = false;
                                    p.Armor -= shopArmor[i].ArmorPoint;
                                }
                            }
                        }
                        shopArmor[choice].IsEquip = true;
                        p.Armor += shopArmor[choice].ArmorPoint;
                    }
                    shopArms.Remove(shopArms[choice]);
                }
                else
                {
                    notEnough();
                }
                armorShop(p, gamePlay, inventory);
            }
            

        }
        //Affichage et achat du shop de consommable
        public void consumableShop(Player p, GamePlay gamePlay, List<Items> inventory)
        {
            moneyPlayer(p);
            int number = shopArmor.Count() + 1;
            int choice = 0;
            Console.WriteLine("Voici la liste des potions que vous pouvez acheter :");
            for (int i = 1; i <= shopConsumable.Count(); i++)
            {
                Console.WriteLine(i + "- " + shopConsumable[i-1].Name + " (" + shopConsumable[i-1].Price + ") deniers");
            }
            Console.WriteLine(shopConsumable.Count() + 1 + " Retour");
            choice = gamePlay.verif(number) -1;
            if (choice == shopConsumable.Count())
            {
                chooseShop(p, gamePlay, inventory);
            }
            else
            {
                if(hasMoney(p, shopConsumable[choice]))
                {
                    p.Money -= shopConsumable[choice].Price;
                    inventory.Add(shopConsumable[choice]);
                }
                else
                {
                    notEnough();
                    
                }
                consumableShop(p, gamePlay, inventory);
            }
        }
        //Fonction permettant de savoir si le joueur à asser d'argent
        public bool hasMoney(Player p, Items i)
        {
            if(p.Money < i.Price)
            {
                return false;
            }
            return true;
        }
        //Fonction quand le joueur n'a pas assez d'argent
        public void notEnough()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Tu n'as pas assez de deniers");
            Console.ResetColor();
        }
        //Fonction qui montre l'argent du joueur
        public void moneyPlayer(Player p)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Tu as : " + p.Money + " deniers");
            Console.ResetColor();
        }
    }
}
