using System;
using System.Collections.Generic;
using System.Text;

namespace VendONaterV1000.ClassesAndInterfaces
{
    class Chip : InventoryItem, IFoodInfo
    {
        public string FoodType { get ; set; }

        public string ConsumedSound()
        {
            throw new NotImplementedException();
        }
    }
}
