using System;
using System.IO;
using System.Linq;
using System.Text;

using static store_net_cli.Goods;
 
namespace store_net_cli
{
  class Goods {
    public static void ReadAllGoods(string products_file) {
      try {
        // Read all lines from the file Product.txt into array
        string[] all_products = File.ReadAllLines(products_file);
        // Iterate over all elements of array
        foreach (var product in all_products)
        // Print a line to the console
        Console.WriteLine(product);
      }                  
      catch {
        Console.Clear();
        Console.WriteLine("There is not any kind of goods. Press 0 to exit to the main menu\n ");
      }
    }
    public static void BuyGoods(string products_file, string checkout_file) {
      try {
        // Read all lines from the file products_file into array
        string[] all_products = File.ReadAllLines(products_file);
        // Iterate over all elements of array
        foreach (var products in all_products)
        // Print a line to the console
        Console.WriteLine(products);
        // Ask a user for inputting name
        Console.WriteLine("Please type the name of the item that you would like to purchase - \n");

        // Search the name of the item input by a user for matching with products
        string search = Console.ReadLine();
        string[] product_names = File.ReadAllLines("Product.txt", Encoding.Default);
        string product = product_names.Where(x => x.Contains(search)).Select(x => x).ToArray()[0];
        File.AppendAllText(checkout_file, search + "\n");
        Console.Clear();
        Console.WriteLine("Your item has been added. Press 0 to exit to the main menu\n ");
      }
      catch {
        Console.Clear();
        Console.WriteLine("There is not this kind of goods. Press 0 to exit to the main menu\n ");
      }
    }
    public static void AddGoods(string products_file){
      Console.WriteLine("Name: ");
      string product_name = Console.ReadLine();
      Console.WriteLine("Pricing: ");
      string pricing = Console.ReadLine();
      File.AppendAllText("Product.txt", product_name + " - ");
      File.AppendAllText("Product.txt", pricing + "\n");
      Console.Clear();
      Console.WriteLine("Press 0 to exit to the main menu\n ");
    }
    public static void CheckOut(string checkout_file) {
      try {
        Console.Clear();
        Console.WriteLine("Checking out. Press 0 to exit to the main menu\n ");

        // Read all lines from the checkout_file into array
        string[] all_products = File.ReadAllLines(checkout_file);
        // Iterate over all elements of array
        foreach (var products in all_products)
        // Print a line to the console
        Console.WriteLine(products);

        Console.WriteLine("\n" + "Would you like to proceed checking out ?\nYes - 1  \nNo - 0 \n\n");
        string purchase = Console.ReadLine();
        switch(purchase) {
          case "1":
            // Delete file with bucket after checking out
            File.Delete(@checkout_file);
            Console.Clear();
            Console.WriteLine("You successfully have paid for goods\nThank you for the purchase\nPress 0 to exit to the main menu\n");
            break;
          case "0":
            Console.Clear();
            Console.WriteLine("Press 0 to exit to the main menu");
            break;
        }
      }
      catch {
        Console.WriteLine("Sorry. It looks like you have not chosen any items\n");
      }
    }
  }
  class Program
  {        
  static void Main(string[] args)
    {
      // Introduction with a user
      string user_name;
      Console.WriteLine("Welcome to the store!\n What is your name?\n");
      user_name = Console.ReadLine();
      Console.Clear();
      Console.WriteLine("Nice to meet you " + user_name + "\n");

      string caseSwitch="0";
      /*
        * 0 - Main menu
        * 1 - List goods
        * 2 - Add goods
        * 3 - Buy goods
        * 4 - Checking out
        * 5 - Quit
        */
      Console.WriteLine("Choose the one: \n\n1. List goods \n2. Add goods \n3. Buy goods \n4. Checking out \n5. Quit");
      // Run infinite loop
      while(true)
      {
        caseSwitch = Console.ReadLine();
        switch(caseSwitch) {
          case "1":
            Console.Clear();
            Console.WriteLine("The list of goods. Press 0 to exit to the main menu\n ");
            ReadAllGoods("Product.txt");
            break;
          case "2":
            Console.Clear();
            Console.WriteLine("Add goods. Press 0 to exit to the main menu\n ");
            AddGoods("Product.txt");
            break;
          case "3":
            Console.Clear();
            Console.WriteLine("Buy goods. Press 0 to exit to the main menu\n ");
            BuyGoods("Product.txt", "Checkout.txt");
            break;
          case "4":
            CheckOut("Checkout.txt");
            break;
          case "5":
            Console.Clear();
            Console.WriteLine("Good buy "+ user_name + " and have a wonderful day!");
            Environment.Exit(0);
            break;
          default:
            Console.Clear();
            Console.WriteLine("Choose the one: \n\n1. List goods \n2. Add goods \n3. Buy goods \n4. Checking out \n5. Quit\n");
            break;
        }
      }
    }
  }
}
