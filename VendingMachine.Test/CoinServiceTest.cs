using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using VendingMachine.BL;
using VendingMachine.BL.Interfaces;

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
            var testResult = coinServiceBL.GetCoinValue("3");
            Assert.AreEqual(0.25, testResult);
        }
        [TestMethod]
        public void CoinServiceBLTest_ValidatingDimes()
        {
            var coinServiceBL = new CoinService(helper);
            var testResult = coinServiceBL.GetCoinValue("2");
            Assert.AreEqual(0.1, testResult);
        }
        [TestMethod]
        public void CoinServiceBLTest_ValidatingNickels()
        {
            var coinServiceBL = new CoinService(helper);
            var testResult = coinServiceBL.GetCoinValue("1");
            Assert.AreEqual(0.05, testResult);
        }
        [TestMethod]
        public void CoinServiceBLTest_ValidatingInvalidCoins()
        {
            var coinServiceBL = new CoinService(helper);
            var testResult = coinServiceBL.GetCoinValue("4");
            Assert.AreEqual(0.00, testResult);
        }
    }
}