using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameGenerator
{
    class CrudShop
    {
        private string serveur;
        private string database;
        private string uid;
        private string password;
        private MySqlConnection run;
        private MySqlCommand cmd;
        private MySqlDataReader dataReader;

        public void shopManager()
        {
            Console.WriteLine("Vous êtes dans le manager des objets.\n" +
                "1- Crée un objet\n" +
                "2- Supprimer un objet\n" +
                "3- Modifier un objet\n" +
                "4- Récupérer un objet\n" +
                "5- Récupérer tous les objets\n" +
                "6- Retour");
            switch (verif(6))
            {
                case 1:
                    createObject();
                    break;
                case 2:
                    deleteObject();
                    break;
                case 3:
                    updateObject();
                    break;
                case 4:
                    
                    readObject(objectType());
                    shopManager();
                    break;
                case 5:
                    readAllObject();
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
        public void createObject()
        {
            Console.WriteLine("Création d'un objet :\n" +
                "1- Crée une arme\n" +
                "2- Crée une armure\n" +
                "3- Crée une potion\n");
            switch (verif(3))
            {
                case 1:
                    createArmsObject();
                    break;
                case 2:
                    createArmorObject();
                    break;
                case 3:
                    createConsumableObject();
                    break;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Objet crée");
            Console.ResetColor();
            shopManager();
        }
        public void createArmsObject()
        {
            string type = " ", name;
            int price, strength;
            Console.WriteLine("Création d'une armes :\n" +
                "1- Epée\n" +
                "2- Hache\n" +
                "3- Arc\n" +
                "4- Epée a deux mains\n");
            switch (verif(4))
            {
                case 1:
                    type = "Sword";
                    break;
                case 2:
                    type = "Axe"; 
                    break;
                case 3:
                    type = "Bow";
                    break;
                case 4:
                    type = "Two Handed Sword";
                    break;
            }
            Console.WriteLine("Nom : ");
            name = Console.ReadLine();
            Console.WriteLine("Prix : ");
            price = verifIsDigit();
            Console.WriteLine("Force : ");
            strength = verifIsDigit();

            string query = "INSERT INTO armsshop (name, price, strength, type) VALUES ('" + name + "', " + price + ", " + strength + ", '" + type + "')";
            connection();
            run.Open();
            cmd = new MySqlCommand(query, run);
            cmd.ExecuteNonQuery();
            run.Close();
        }
        public void createArmorObject()
        {
            string type = " ", name;
            int price, armor;
            Console.WriteLine("Création d'une armes :\n" +
                "1- Casque\n" +
                "2- Plastron\n" +
                "3- Jambière\n" +
                "4- Bottes\n" +
                "5- Bouclier\n");
            switch (verif(5))
            {
                case 1:
                    type = "Helmet";
                    break;
                case 2:
                    type = "Chestplate";
                    break;
                case 3:
                    type = "LegWarmer";
                    break;
                case 4:
                    type = "Boots";
                    break;
                case 5:
                    type = "Shield";
                    break;
            }
            Console.WriteLine("Nom : ");
            name = Console.ReadLine();
            Console.WriteLine("Prix : ");
            price = verifIsDigit();
            Console.WriteLine("Armure : ");
            armor = verifIsDigit();

            string query = "INSERT INTO armorshop (name, price, armor, type) VALUES ('" + name + "', " + price + ", " + armor + ", '" + type + "')";
            connection();
            run.Open();
            cmd = new MySqlCommand(query, run);
            cmd.ExecuteNonQuery();
            run.Close();
        }
        public void createConsumableObject()
        {
            string query = " ";
            Console.WriteLine("Création d'une potion :\n" +
                "1- Petite potion\n" +
                "2- Moyenne potion \n" +
                "3- Grosse potion\n");
            switch (verif(3))
            {
                case 1:
                    query = "INSERT INTO consumableshop (name, price, health) VALUES ('Potion de premier soin', " + 3 + ", " + 15 + ")";
                    break;
                case 2:
                    query = "INSERT INTO consumableshop (name, price, health) VALUES ('Potion de soin', " + 12 + ", " + 40 + ")";
                    break;
                case 3:
                    query = "INSERT INTO consumableshop (name, price, health) VALUES ('Giga potion', " + 25 + ", " + 100 + ")";
                    break;
            }
            connection();
            run.Open();
            cmd = new MySqlCommand(query, run);
            cmd.ExecuteNonQuery();
            run.Close();
        }
        public void deleteObject()
        {
            string type = " ";
            int id;
            Console.WriteLine("Suppression d'un objet.\n" +
                "1- Armes\n" +
                "2- Armure\n" +
                "3- Consommable\n");
            switch (verif(3))
            {
                case 1:
                    type = "arms";
                    break;
                case 2:
                    type = "armor";
                    break;
                case 3:
                    type = "consumable";
                    break;
            }
            id = readObject(type);

            Console.WriteLine("Etes vous sur de vouloir supprimer cette objet ? (1- Oui/2- Non)\n");
            switch (verif(2))
            {
                case 1:
                    string query = "DELETE FROM " + type + "shop WHERE id = " + id;
                    connection();
                    run.Open();
                    cmd = new MySqlCommand(query, run);
                    cmd.ExecuteNonQuery();
                    run.Close();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Objet supprimé");
                    Console.ResetColor();
                    break;
                case 2:
                    break;
            }

            shopManager();
        }
        public int readObject(string type)
        {
            int id;
            List<string> objet = new List<string>();
            id = getIdObject();
            string query = "SELECT * FROM " + type +"shop WHERE id=" + id;
            connection();
            run.Open();
            cmd = new MySqlCommand(query, run);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                objet.Add(dataReader["name"] + "");
                objet.Add(dataReader["price"] + "");
                if(type == "arms")
                {
                    objet.Add(dataReader["strength"] + "");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Voici votre objet : \n");
                    Console.ResetColor();
                    Console.WriteLine("Nom : " + objet[0].ToString() + "/ Prix : " + objet[1].ToString() + "/ Force : " + objet[2].ToString() + "\n");
                }
                else if(type == "armor")
                {
                    objet.Add(dataReader["armor"] + "");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Voici votre objet : \n");
                    Console.ResetColor();
                    Console.WriteLine("Nom : " + objet[0].ToString() + "/ Prix : " + objet[1].ToString() + "/ Armure : " + objet[2].ToString() + "\n");
                }
                else
                {
                    objet.Add(dataReader["health"] + "");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Voici votre objet : \n");
                    Console.ResetColor();
                    Console.WriteLine("Nom : " + objet[0].ToString() + "/ Prix : " + objet[1].ToString() + "/ Points de vie : " + objet[2].ToString() + "\n");
                }
   
            }
            dataReader.Close();
            run.Close();
            return id;
        }
        public int getIdObject()
        {
            int id;
            Console.WriteLine("Id de l'objet : ");
            id = verifIsDigit();
            return id;
        }
        public string objectType()
        {
            string type = " ";
            Console.WriteLine("Quel type d'objet.\n" +
                "1- Arme\n" +
                "2- Armure\n" +
                "3- Consommable\n");
            switch (verif(3))
            {
                case 1:
                    type = "arms";
                    break;
                case 2:
                    type = "armor";
                    break;
                case 3:
                    type = "consumable";
                    break;
            }
            return type;
        }
        public void updateObject()
        {
            int id;
            string query = "";
            Console.WriteLine("Modification d'un objet :");
            string typeObject = objectType();
            id = readObject(typeObject);
            Console.WriteLine("Etes vous sur de vouloir modifier cet objet ? (1- Oui/2- Non)\n");
            switch (verif(2))
            {
                case 1:
                    int price, armor, strength, health;
                    string name;
                    Console.WriteLine("modification de l'objet :\n" +
                        "Nom : ");
                    name = Console.ReadLine();
                    Console.WriteLine("Prix : ");
                    price = verifIsDigit();
                    if(typeObject == "arms")
                    {
                        Console.WriteLine("Force : ");
                        strength = verifIsDigit();
                        query = "UPDATE " + typeObject + "shop SET name = '" + name + ", price " + price + ", strength = " + strength + " WHERE id = " + id;
                    }
                    else if(typeObject == "armor") 
                    {
                        Console.WriteLine("Armure : ");
                        armor = verifIsDigit();
                        query = "UPDATE " + typeObject + "shop SET name = '" + name + ", price " + price + ", armor = " + armor + " WHERE id = " + id;
                    }
                    else
                    {
                        Console.WriteLine("Points de vie ");
                        health = verifIsDigit();
                        query = "UPDATE " + typeObject + "shop SET name = '" + name + ", price " + price + ", health = " + health + " WHERE id = " + id;
                    }
                    connection();
                    run.Open();
                    cmd = new MySqlCommand(query, run);
                    cmd.ExecuteNonQuery();
                    run.Close();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Objet modifié");
                    Console.ResetColor();
                    break;
                case 2:
                    break;
            }
            shopManager();
        }
        public void readAllObject()
        {
            int space = 20;
            int tempSpace = 0;
            List<string> armsId = new List<string>();
            List<string> armsName = new List<string>();
            List<string> armsPrice = new List<string>();
            List<string> armsStrength = new List<string>();
            List<string> armsType = new List<string>();
            List<string> armorId = new List<string>();
            List<string> armorName = new List<string>();
            List<string> armorPrice = new List<string>();
            List<string> armorArmor = new List<string>();
            List<string> armorType = new List<string>();
            string query = "SELECT * FROM armsshop";
            connection();
            run.Open();
            cmd = new MySqlCommand(query, run);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                armsId.Add(dataReader["id"] + "");
                armsName.Add(dataReader["name"] + "");
                armsPrice.Add(dataReader["price"] + "");
                armsStrength.Add(dataReader["strength"] + "");
                armsType.Add(dataReader["type"] + "");
            }
            dataReader.Close();
            run.Close();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Voici la liste des armes : \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Id           ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Nom                ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Prix               ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Force                ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Type\n");
            Console.ResetColor();
            for (int i = 0; i < armsId.Count(); i++)
            {
                Console.Write(armsId[i].ToString());
                tempSpace = space - armsName[i].Length - 5;
                for (int j = 0; j < tempSpace; j++)
                {
                    Console.Write(" ");
                }
                Console.Write(armsName[i].ToString());
                tempSpace = space - armsPrice[i].Length;
                for (int j = 0; j < tempSpace; j++)
                {
                    Console.Write(" ");
                }
                Console.Write(armsPrice[i].ToString());
                tempSpace = space - armsStrength[i].Length;
                for (int j = 0; j < tempSpace; j++)
                {
                    Console.Write(" ");
                }
                Console.Write(armsStrength[i].ToString());
                tempSpace = space - armsType[i].Length;
                for (int j = 0; j < tempSpace; j++)
                {
                    Console.Write(" ");
                }
                Console.Write(armsType[i].ToString() + "\n\n");
            }

                string queryArmor = "SELECT * FROM armorshop";
                connection();
                run.Open();
                cmd = new MySqlCommand(queryArmor, run);
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    armorId.Add(dataReader["id"] + "");
                    armorName.Add(dataReader["name"] + "");
                    armorPrice.Add(dataReader["price"] + "");
                    armorArmor.Add(dataReader["armor"] + "");
                    armorType.Add(dataReader["type"] + "");
                }
                dataReader.Close();
                run.Close();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Voici la liste des armures : \n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Id           ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Nom                ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Prix               ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Armure               ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Type\n");
                Console.ResetColor();
                for (int i = 0; i < armorId.Count(); i++)
                {
                    Console.Write(armorId[i].ToString());
                    tempSpace = space - armorName[i].Length - 5;
                    for (int j = 0; j < tempSpace; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(armorName[i].ToString());
                    tempSpace = space - armorPrice[i].Length;
                    for (int j = 0; j < tempSpace; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(armorPrice[i].ToString());
                    tempSpace = space - armorArmor[i].Length;
                    for (int j = 0; j < tempSpace; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(armorArmor[i].ToString());
                    tempSpace = space - armorType[i].Length;
                    for (int j = 0; j < tempSpace; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(armorType[i].ToString() + "\n\n");
                }
            shopManager();
        }
    }     
}
