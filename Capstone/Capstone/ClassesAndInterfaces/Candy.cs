using System;
using System.Collections.Generic;
using System.Text;

namespace VendONaterV1000.ClassesAndInterfaces
{
    class Candy : InventoryItem, IFoodInfo
    {
        public string FoodType { get; set; }

        public string ConsumedSound()
        {
            throw new NotImplementedException();
        }
    }
}
