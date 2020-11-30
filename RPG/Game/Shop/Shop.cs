using MyLib.Game.Character.CharacterClass;
using MyLib.Game.Character.Items;
using MyLib.Game.Character.Items.Consumable.Potion;
using MyLib.Game.Character.Items.Equipment.Armor;
using MyLib.Game.Character.Items.Equipment.Armor.Boots;
using MyLib.Game.Character.Items.Equipment.Armor.Chestplate;
using MyLib.Game.Character.Items.Equipment.Armor.Helmet;
using MyLib.Game.Character.Items.Equipment.Armor.LegWarmer;
using MyLib.Game.Character.Items.Equipment.Armor.Shield;
using MyLib.Game.Character.Items.Equipment.Arms;
using MyLib.Game.Character.Items.Equipment.Arms.Axe;
using MyLib.Game.Character.Items.Equipment.Arms.Bow;
using MyLib.Game.Character.Items.Equipment.Arms.Sword;
using MyLib.Game.Character.Items.Equipment.Arms.Two_handed_sword;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG.Game
{
    class Shop : Items
    {
        private List<Arms> shopArms;
        private List<Armor> shopArmor;
        private List<Potions> shopConsumable;
        private string serveur;
        private string database;
        private string uid;
        private string password;
        private MySqlConnection run;
        private MySqlCommand cmd;
        private MySqlDataReader dataReader;

        public Shop()
        {
            int strength, price, armor, health = 0;
            string name, type =  " ";
            shopArms = new List<Arms>();
            shopArmor = new List<Armor>();
            shopConsumable = new List<Potions>();
            string query = "SELECT * FROM armsshop";
            connection();
            run.Open();
            cmd = new MySqlCommand(query, run);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                name = (dataReader["name"] + "");
                price = int.Parse(dataReader["price"] + "");
                strength = int.Parse(dataReader["strength"] + "");
                type = (dataReader["type"] + "");
                if(type == "Sword")
                {
                    Sword sw = new Sword(strength, name, price);
                    shopArms.Add(sw);
                } 
                else if(type == "Axe")
                {
                    Axe ax = new Axe(strength, name, price);
                    shopArms.Add(ax);
                }
                else if (type == "Bow")
                {
                    Bow bo = new Bow(strength, name, price);
                    shopArms.Add(bo);
                }
                else if (type == "Two Handed Sword")
                {
                    Two_handed_sword tw = new Two_handed_sword(strength, name, price);
                    shopArms.Add(tw);
                }
            }
            dataReader.Close();
            run.Close();

            string queryArmor = "SELECT * FROM armorshop";
            connection();
            run.Open();
            cmd = new MySqlCommand(queryArmor, run);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                name = (dataReader["name"] + "");
                price = int.Parse(dataReader["price"] + "");
                armor = int.Parse(dataReader["armor"] + "");
                type = (dataReader["type"] + "");
                if (type == "Helmet")
                {
                    Helmet he = new Helmet(armor, name, price);
                    shopArmor.Add(he);
                }
                else if (type == "Chestplate")
                {
                    Chestplate ch = new Chestplate(armor, name, price);
                    shopArmor.Add(ch);
                }
                else if (type == "LegWarmer")
                {
                    LegWarmer le = new LegWarmer(armor, name, price);
                    shopArmor.Add(le);
                }
                else if (type == "Boots")
                {
                    Boots bo = new Boots(armor, name, price);
                    shopArmor.Add(bo);
                }
                else if (type == "Shield")
                {
                    Shield sh = new Shield(armor, name, price);
                    shopArmor.Add(sh);
                }
            }
            dataReader.Close();
            run.Close();

            string queryConsumable = "SELECT * FROM consumableshop";
            connection();
            run.Open();
            cmd = new MySqlCommand(queryConsumable, run);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                name = (dataReader["name"] + "");
                price = int.Parse(dataReader["price"] + "");
                health = int.Parse(dataReader["health"] + "");
                Potions po = new Potions(health, name, price);
                shopConsumable.Add(po);
            }
            dataReader.Close();
            run.Close();
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
                            if (inventory[i].IsEquip && inventory[i].GetType() == typeof(Bow) || inventory[i].GetType() == typeof(Axe) || inventory[i].GetType() == typeof(Sword) || inventory[i].GetType() == typeof(Two_handed_sword))
                            {
                                inventory[i].IsEquip = false;
                                p.Strength -= inventory[i].Strength;
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
                        for (int i = 0; i < inventory.Count(); i++)
                        {
                            if (inventory[i].GetType() == typeof(Helmet) && inventory[i].GetType() == shopArmor[choice].GetType())
                            {
                                if (inventory[i].IsEquip)
                                {
                                    inventory[i].IsEquip = false;
                                    p.Armor -= inventory[i].ArmorPoint;
                                }  
                            }
                            if (inventory[i].GetType() == typeof(Chestplate) && inventory[i].GetType() == shopArmor[choice].GetType())
                            {
                                if (inventory[i].IsEquip)
                                {
                                    inventory[i].IsEquip = false;
                                    p.Armor -= inventory[i].ArmorPoint;
                                }
                            }
                            if (inventory[i].GetType() == typeof(LegWarmer) && inventory[i].GetType() == shopArmor[choice].GetType())
                            {
                                if (inventory[i].IsEquip)
                                {
                                    inventory[i].IsEquip = false;
                                    p.Armor -= inventory[i].ArmorPoint;
                                }
                            }
                            if (inventory[i].GetType() == typeof(Boots) && inventory[i].GetType() == shopArmor[choice].GetType())
                            {
                                if (inventory[i].IsEquip)
                                {
                                    inventory[i].IsEquip = false;
                                    p.Armor -= inventory[i].ArmorPoint;
                                }
                            }
                            if (inventory[i].GetType() == typeof(Shield) && inventory[i].GetType() == shopArmor[choice].GetType())
                            {
                                if (inventory[i].IsEquip)
                                {
                                    inventory[i].IsEquip = false;
                                    p.Armor -= inventory[i].ArmorPoint;
                                }
                            }
                        }
                        shopArmor[choice].IsEquip = true;
                        p.Armor += shopArmor[choice].ArmorPoint;
                    }
                    shopArmor.Remove(shopArmor[choice]);
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
                    shopConsumable.Remove(shopConsumable[choice]);
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
