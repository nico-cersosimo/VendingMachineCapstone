using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VendONaterV1000.ClassesAndInterfaces;

namespace VendONaterV1000.ClassesAndInterfaces
{
    public class Sales : MachineInventory
    {
        Dictionary<string, int> salesReport = new Dictionary<string, int>();
        public double CashInMachine = 0.00;
        private string UserSlotEntry = "";
        public string coinMoneyStartingAmount = "";
        public double startingCash = 0.00;
        public string ItemSlot = "";
        public double TotalSales = 0.00;

        public void CreateSalesReport()
        {
            if (salesReport.Count == 0)
            {
                if (File.Exists(@"C:\Users\Nico Cersosimo\workspace\c-module-1-capstone-team-3\Capstone\Capstone\VendingInfoFiles\SalesReport.txt"))
                    using (StreamReader sr = new StreamReader(@"C:\Users\Nico Cersosimo\workspace\c-module-1-capstone-team-3\Capstone\Capstone\VendingInfoFiles\SalesReport.txt"))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            if (line.Contains("|"))
                            {
                                string[] splitLine = line.Split("|");
                                salesReport.Add(splitLine[0].Trim(), int.Parse(splitLine[1]));
                            }
                            else
                            {
                                string[] totalSplit = line.Split("$");
                                TotalSales += double.Parse(totalSplit[1]);
                            }
                        }

                    }
                else
                {
                    foreach (KeyValuePair<string, InventoryItem> item in menuItems)
                    {
                        salesReport.Add(item.Value.Name, 0);
                    }
                }
            }
        }

        public bool VerifyUserEntry(string userSlotEntry)
        {
            UserSlotEntry = userSlotEntry;
            return menuItems.Keys.Contains(userSlotEntry);

        }

        public double FeedCash(double feedAmount)

        {
            startingCash = CashInMachine;
            CashInMachine += feedAmount;
            AuditLogJammer($"FEED MONEY", startingCash.ToString());
            return CashInMachine;

        }
        public bool VerifyCost(string userSlotEntry)
        {

            if (CashInMachine >= menuItems[userSlotEntry].Price)
            {
                return true;
            }
            else return false;

        }
        public string coinConverter(MachineInventory mi)
        {
            int quarter = 0;
            int dime = 0;
            int nickels = 0;
            int pennies = 0;

            coinMoneyStartingAmount = CashInMachine.ToString();

            quarter = (int)(CashInMachine / 0.25);
            CashInMachine = CashInMachine % 0.25;
            dime = (int)(CashInMachine / 0.10);
            CashInMachine = CashInMachine % 0.10;
            nickels = (int)(CashInMachine / 0.05);
            CashInMachine = CashInMachine % 0.05;
            pennies = (int)(CashInMachine / 0.01);
            CashInMachine = 0;
            AuditLogJammer($"GIVE CHANGE", coinMoneyStartingAmount);
            return $"Change is {coinMoneyStartingAmount}, in {quarter} quarters {dime} dimes {nickels} nickels and {pennies} pennies";
        }

        public void SellPruduct(string itemSlot, int amountSold, MachineInventory mi)
        {

            ItemSlot = itemSlot;
            salesReport[mi.menuItems[itemSlot].Name]++;
            TotalSales += mi.menuItems[itemSlot].Price;

            using (StreamWriter sw = new StreamWriter(@"C:\Users\Nico Cersosimo\workspace\c-module-1-capstone-team-3\Capstone\Capstone\VendingInfoFiles\SalesReport.txt"))
            {
                foreach (KeyValuePair<string, int> entry in salesReport)
                {
                    sw.WriteLine($"{entry.Key} | {entry.Value}");
                }
                
                sw.WriteLine($"Total Sales: ${TotalSales}");
            }
            mi.menuItems[itemSlot].QuantityRemaining = mi.menuItems[itemSlot].QuantityRemaining - amountSold;
            double sellPruductStartingAmount = CashInMachine;
            CashInMachine -= mi.menuItems[itemSlot].Price;
            string itemName = mi.menuItems[itemSlot].Name;
            //  string itemSlotString = itemSlot;

            AuditLogJammer($"{mi.menuItems[itemSlot].Name} {itemSlot} ", sellPruductStartingAmount.ToString());
            Console.WriteLine(mi.MakeSound(mi.menuItems[UserSlotEntry].Type, mi));
        }

        //change this to just write the information
        //tell me what to write and i will write it.
        public void AuditLogJammer(string phraseToWrite, string startingAmount)
        {
            string auditPath = @"C:\Users\Nico Cersosimo\workspace\c-module-1-capstone-team-3\Capstone\Capstone\VendingInfoFiles\AuditLog.txt";
            using (StreamWriter sw = new StreamWriter(auditPath, true))
            {

                sw.WriteLine($"{DateTime.UtcNow.ToString("G")} {phraseToWrite}: {startingAmount}\t{CashInMachine.ToString()} \n");

            }
        }

    }
}
