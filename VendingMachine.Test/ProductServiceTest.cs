using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.BL;
using VendingMachine.BL.Interfaces;
using VendingMachine.Common.Enum;
using VendingMachine.Common;

namespace VendingMachine.Test
{
    [TestClass]

    public class ProductServiceTest
    {

        readonly Helper helper = new Helper();

        [TestMethod]
        public void ProductServiceBLTest_SuccessColaPurchase()
        {
            ICoinService _coinService = new CoinService(helper);
            var listOfCoins = new List<CoinName>();
            listOfCoins.Add(CoinName.Quarters);
            listOfCoins.Add(CoinName.Quarters);
            listOfCoins.Add(CoinName.Quarters);
            listOfCoins.Add(CoinName.Quarters);
            listOfCoins.Add(CoinName.Dimes);
            var coinServiceBL = new ProductService(helper, _coinService);
            var testResult = coinServiceBL.ProductPurchase(listOfCoins, ProductName.Cola.ToString());
            Assert.AreEqual((decimal)0.1, Convert.ToDecimal(testResult));
        }
        [TestMethod]
        public void ProductServiceBLTest_SuccessChipsPurchase()
        {
            ICoinService _coinService = new CoinService(helper);
            var listOfCoins = new List<CoinName>();
            listOfCoins.Add(CoinName.Quarters);
            listOfCoins.Add(CoinName.Quarters);
            listOfCoins.Add(CoinName.Nickels);
            var coinServiceBL = new ProductService(helper, _coinService);
            var testResult = coinServiceBL.ProductPurchase(listOfCoins, ProductName.Chips.ToString());
            Assert.AreEqual((decimal)0.05, Convert.ToDecimal(testResult));
        }
        [TestMethod]
        public void ProductServiceBLTest_SuccessCandyPurchase()
        {
            ICoinService _coinService = new CoinService(helper);
            var listOfCoins = new List<CoinName>();
            listOfCoins.Add(CoinName.Quarters);
            listOfCoins.Add(CoinName.Quarters);
            listOfCoins.Add(CoinName.Quarters);
            listOfCoins.Add(CoinName.Quarters);
            var coinServiceBL = new ProductService(helper, _coinService);
            var testResult = coinServiceBL.ProductPurchase(listOfCoins, ProductName.Candy.ToString());
            Assert.AreEqual((decimal)0.35, Convert.ToDecimal(testResult));
        }

        [TestMethod]
        public void ProductServiceBLTest_FailurePurchase()
        {
            ICoinService _coinService = new CoinService(helper);
            var emptyListOfCoins = new List<CoinName>();
            var coinServiceBL = new ProductService(helper, _coinService);
            var testResult = coinServiceBL.ProductPurchase(emptyListOfCoins, ProductName.Cola.ToString());
            Assert.AreEqual(0.0, testResult);
        }
        [TestMethod]
        public void ProductServiceBLTest_InvalidOption()
        {
            ICoinService _coinService = new CoinService(helper);
            var listOfCoins = new List<CoinName>();
            var coinServiceBL = new ProductService(helper, _coinService);
            var testResult = coinServiceBL.ProductPurchase(listOfCoins, "Invalid Option");
            Assert.AreEqual(0.0, testResult);
        }
    }
}
