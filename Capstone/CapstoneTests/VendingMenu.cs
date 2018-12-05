using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VendONaterV1000.ClassesAndInterfaces;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMenu
    {
        private Sales Sales = new Sales();

        [TestMethod]
        public void VerifyUserEntryTrue()
        {
            string userSlotEntry = "A1";

            bool result = Sales.VerifyUserEntry(userSlotEntry);

            Assert.AreEqual(true, result, "should return true if slot entry exists in the menu");
        }
        [TestMethod]
        public void VerifyUserEntryFalse()
        {
            string userSlotEntry = "A7";

            bool result = Sales.VerifyUserEntry(userSlotEntry);

            Assert.AreEqual(false, result, "Slot entries outside of the bounds of the menu should return false");
        }
        [TestMethod]
        public void FeedCashTest()
        {
            double feedAmount = 5;

            double result = Sales.FeedCash(feedAmount);

            Assert.AreEqual((Sales.CashInMachine), result, "should add the feed amount to the current balance");
        }
        [TestMethod]
        public void VerifyCostTestTrue()
        {
            Sales.CashInMachine = 5;
            string userSlotEntry = "A1";

            bool result = Sales.VerifyCost(userSlotEntry);

            Assert.AreEqual(true, result, "should return true if cash in machine is greater or equal to the cost of the product");
        }
        [TestMethod]
        public void VerifyCostTestFalse()
        {
            Sales.CashInMachine = 0.25;
            string userSlotEntry = "A1";

            bool result = Sales.VerifyCost(userSlotEntry);

            Assert.AreEqual(false, result, "should return false if cash in machine is less than cost of the requested item");
        }
    }
}
