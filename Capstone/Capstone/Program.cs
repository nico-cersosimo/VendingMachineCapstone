using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VendONaterV1000.ClassesAndInterfaces;

namespace VendONaterV1000
{
    class Program : MachineInventory
    {
        static void Main(string[] args)
        {
            bool topMenu = true;
            MachineInventory mi = new MachineInventory();
            Sales transaction = new Sales();
            
            mi.VendingMenus();

            
           // Console.WriteLine("Welcome to the vendor thing");



           
            Console.ReadLine();
        }
    }
}
