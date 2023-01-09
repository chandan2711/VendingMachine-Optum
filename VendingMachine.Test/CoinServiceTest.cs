using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System;
using System.Linq;
using VendingMachine.BL;
using VendingMachine.BL.Interfaces;
using VendingMachine.Common.Enum;

namespace VendingMachine.Test
{
    [TestClass]
    public class CoinServiceTest
    {
        readonly Helper helper = new Helper();

        [TestMethod]
        public void CoinServiceBLTest_ValidatingQuarters()
        {
            var coinServiceBL = new CoinService(helper);
            var testResult = coinServiceBL.ValidCoinChecking(CoinName.Quarters.ToString());
            Assert.AreEqual(true, testResult);
        }
        [TestMethod]
        public void CoinServiceBLTest_ValidatingDimes()
        {
            var coinServiceBL = new CoinService(helper);
            var testResult = coinServiceBL.ValidCoinChecking(CoinName.Dimes.ToString());
            Assert.AreEqual(true, testResult);
        }
        [TestMethod]
        public void CoinServiceBLTest_ValidatingNickels()
        {
            var coinServiceBL = new CoinService(helper);
            var testResult = coinServiceBL.ValidCoinChecking(CoinName.Nickels.ToString());
            Assert.AreEqual(true, testResult);
        }
        [TestMethod]
        public void CoinServiceBLTest_ValidatingInvalidCoins()
        {
            var coinServiceBL = new CoinService(helper);
            var testResult = coinServiceBL.ValidCoinChecking("Invalid Option");
            Assert.AreEqual(false, testResult);
        }
        [TestMethod]
        public void CoinServiceBLTest_SumOfCoins()
        {
            var listOfCoins = new List<CoinName>();
            listOfCoins.Add(CoinName.Quarters);
            listOfCoins.Add(CoinName.Dimes);
            listOfCoins.Add(CoinName.Nickels);
            var coinServiceBL = new CoinService(helper);
            var testResult = coinServiceBL.GetSumOfCoins(listOfCoins);
            Assert.AreEqual((decimal)0.4, Convert.ToDecimal(testResult));
        }
    }
}