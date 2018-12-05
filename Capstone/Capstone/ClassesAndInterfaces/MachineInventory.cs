using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VendONaterV1000.ClassesAndInterfaces;

namespace VendONaterV1000.ClassesAndInterfaces
{
    public class MachineInventory
    {
        public string FilePath { get; private set; }
        public string UserSlotEntry { get; set; }
        public Dictionary<string, InventoryItem> menuItems = new Dictionary<string, InventoryItem>();
        protected int QuantityRemaining { get { return 5; } set { } }



        public MachineInventory()
        {
            FilePath = @"C:\Users\Nico Cersosimo\workspace\c-module-1-capstone-team-3\Capstone\Capstone\VendingInfoFiles\MenuItems.txt";
            using (StreamReader sr = new StreamReader(FilePath))
            {//read the file in, store it in a class.
                //
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] menu = line.Split("|");

                    menuItems.Add(menu[0], new InventoryItem(menu[1], double.Parse(menu[2]), menu[3], QuantityRemaining));
                }
            }
        }
        public int SubtractQuantity(int quantityRemaining, int quantityBought)
        {
            quantityRemaining = quantityRemaining - quantityBought;
            QuantityRemaining = quantityRemaining;
            return QuantityRemaining;
        }
        //todo adds to task list in view**************
        public string MakeSound(string boughtItem, MachineInventory mi)
        {
           
            string sound = "";
            foreach (KeyValuePair<string, InventoryItem> item in mi.menuItems)
            {
                Console.Clear();
                if (boughtItem.Contains("Chip"))
                {
                    sound =  "Crunch Crunch, Yum!";
                   // return sound;
                }
                else if (boughtItem.Contains("Candy"))
                {
                    sound = "Munch Much, Yum!";
                   // return sound;
                }
                else if (boughtItem.Contains("Drink"))
                {
                    sound = "Glug Glug, Yum!";
                   // return sound;
                }
                else
                {
                    sound= "Chew Chew, Yum!";
                   // return sound;
                }
            }
            return sound;
            
        }
        public void VendingMenus()
        {
            bool topMenu = true;
            MachineInventory mi = new MachineInventory();
            Sales transaction = new Sales();


            Console.WriteLine("Welcome to the vendor thing");
            while (topMenu)
            {

                //foreach through the dictionary and write each to the console)

                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                string input = Console.ReadLine();
                Console.Clear();
                if (input == "1")
                {
                    Console.WriteLine("Please insert cash in whole dollar amounts");
                    string feedAmount = Console.ReadLine();
                    double userFeed = double.Parse(feedAmount);
                    transaction.FeedCash(userFeed);
                    Console.WriteLine($"You inserted ${userFeed} \nMaking a total of ${transaction.CashInMachine}\nPress Enter to continue");
                    Console.ReadLine();

                    Console.Clear();
                }
                else if (input == "2")
                {
                    Console.WriteLine($"Slot|Item Name|Cost|Stock");
                    foreach (KeyValuePair<string, InventoryItem> item in mi.menuItems)
                    {

                        Console.WriteLine($"{item.Key}|{item.Value.Name}|{item.Value.Price}|{item.Value.QuantityRemaining}");
                    }
                    Console.WriteLine($"Current Money Provided: ${transaction.CashInMachine}\n");
                    Console.WriteLine("Please select the corresponding slot for the item you want(case Sensitive)");
                    transaction.UserSlotEntry = Console.ReadLine();
                    if (transaction.VerifyUserEntry(transaction.UserSlotEntry))
                    {
                        if (mi.menuItems[transaction.UserSlotEntry].QuantityRemaining >= 1)
                        {
                            if (transaction.CashInMachine >= mi.menuItems[transaction.UserSlotEntry].Price)
                            {
                                transaction.CreateSalesReport();
                                transaction.SellPruduct(transaction.UserSlotEntry, 1, mi);

                            }
                        }
                        else { Console.WriteLine("SOLD OUT, please make another selection"); }
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry, please try again");
                    }
                }
                else if(input == "3")
                {
                    Console.WriteLine( transaction.coinConverter(mi));
                    Console.WriteLine($"Have a Great {DateTime.UtcNow.ToString("G")}");
                    Console.ReadLine();
                    topMenu = false;
                }
                // Console.ReadLine();
            }



        }
    }
}
//C:\Users\Nico Cersosimo\workspace\c-module-1-capstone-team-3\Capstone\Capstone\VendingInfoFiles\SalesReport.txt

