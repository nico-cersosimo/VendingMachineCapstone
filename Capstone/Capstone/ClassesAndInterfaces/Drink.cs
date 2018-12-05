using System;
using System.Collections.Generic;
using System.Text;

namespace VendONaterV1000.ClassesAndInterfaces
{
    class Drink : InventoryItem, IFoodInfo
    {
        public string FoodType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string ConsumedSound()
        {
            throw new NotImplementedException();
        }
    }
}
