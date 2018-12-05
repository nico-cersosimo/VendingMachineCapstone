using System;
using System.Collections.Generic;
using System.Text;

namespace VendONaterV1000.ClassesAndInterfaces
{
    interface IFoodInfo
    {
        string FoodType { get; set; }
        string ConsumedSound();
    }
}
