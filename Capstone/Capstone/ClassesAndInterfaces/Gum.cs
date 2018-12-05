using System;
using System.Collections.Generic;
using System.Text;

namespace VendONaterV1000.ClassesAndInterfaces
{
    class Gum : InventoryItem, IFoodInfo
    {
        public string FoodType
        {
            get
            {
                return "gum";
            }
            set
            {
            }
        }

        public string ConsumedSound()
        {

            return "Chew Chew Yum Yum";
        }

    }
}
