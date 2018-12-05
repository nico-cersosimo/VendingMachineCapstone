using System;
using System.Collections.Generic;
using System.Text;

namespace VendONaterV1000.ClassesAndInterfaces
{
    public class InventoryItem
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int QuantityRemaining { get; set; }

        public InventoryItem(string name, double price, string type, int quantityRemaining)
        {

            this.Name = name;
            this.Price = price;
            this.Type = type;
            this.QuantityRemaining = quantityRemaining;
        }
        public InventoryItem()
        {
            
        }
    }
}
