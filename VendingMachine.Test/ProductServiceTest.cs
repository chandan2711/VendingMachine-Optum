using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.BL;

namespace VendingMachine.Test
{
    [TestClass]

    public class ProductServiceTest
    {
        readonly Helper helper = new Helper();

        [TestMethod]
        public void ProductServiceBLTest_SuccessColaPurchase()
        {
            var coinServiceBL = new ProductService(helper);
            var testResult = coinServiceBL.ProductPurchase(1.5, "1");
            Assert.AreEqual(0.50, testResult);
        }
        [TestMethod]
        public void ProductServiceBLTest_SuccessChipsPurchase()
        {
            var coinServiceBL = new ProductService(helper);
          
            var testResult = coinServiceBL.ProductPurchase(1.5, "2");
            Assert.AreEqual(1.0, testResult);
        }
        [TestMethod]
        public void ProductServiceBLTest_SuccessCandyPurchase()
        {
            var coinServiceBL = new ProductService(helper);
            var testResult = coinServiceBL.ProductPurchase(1.00, "3");
            Assert.AreEqual(0.35, testResult);
        }

        [TestMethod]
        public void ProductServiceBLTest_FailurePurchase()
        {
            var coinServiceBL = new ProductService(helper);
            var testResult = coinServiceBL.ProductPurchase(0.50, "1");
            Assert.AreEqual(0.5, testResult);
        }
        [TestMethod]
        public void ProductServiceBLTest_InvalidOption()
        {
            var coinServiceBL = new ProductService(helper);
            var testResult = coinServiceBL.ProductPurchase(0.1, "5");
            Assert.AreEqual(0.1, testResult);
        }
    }
}
