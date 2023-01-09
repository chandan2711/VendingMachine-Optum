using VendingMachine.BL.Interfaces;
using VendingMachine.Common;
using VendingMachine.Common.Enum;

namespace VendingMachine.BL
{

    public class ProductService : IProductService
    {
        private readonly ICoinService _coinService;
        private readonly Helper _helper;

        public ProductService(Helper helperBL, ICoinService coinService)
        {
            this._helper = helperBL;
            this._coinService = coinService;

        }

        public double ProductPurchase(List<CoinName> listOfCoins, string productName)
        {
            var sumOfCoins = _coinService.GetSumOfCoins(listOfCoins);
            if (_helper.dictionaryOfProduct.ContainsKey(productName))
            {
                var productPrice = _helper.dictionaryOfProduct[productName];
                if (sumOfCoins >= productPrice)
                {

                    sumOfCoins = sumOfCoins - productPrice;
                    PurchaseSuccess(productName.ToString());
                    return sumOfCoins;
                }
                else
                {
                    PurchaseFailure(sumOfCoins, productName.ToString(), productPrice);
                }

            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
            return sumOfCoins;
        }

        private ProductName GetProductName(string enterOption)
        {
            var productName = (ProductName)Convert.ToInt32(enterOption);
            return productName;
        }

        private void PurchaseSuccess(string productName)
        {
            Console.WriteLine("Product {0} Dispensed", productName);
            Console.WriteLine("THANK YOU");
        }
        private void PurchaseFailure(double sumOfCoins, string productName, double productPrice)
        {
            Console.WriteLine("Not Sufficient Balance in your Account ");
            Console.WriteLine("Availabl Amount : " + sumOfCoins + "$");
            Console.WriteLine("Price of {0} is {1}$", productName, productPrice);
        }

    }
}
