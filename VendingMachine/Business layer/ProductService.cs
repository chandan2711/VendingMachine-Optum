using VendingMachine.BL.Interfaces;
using VendingMachine.Common;

namespace VendingMachine.BL
{

    public class ProductService : IProductService
    {
        private readonly Helper _helper;

        public ProductService(Helper helperBL)
        {
            this._helper = helperBL;
            
        }

        public double ProductPurchase(double sumOfCoins, string enteredOption)
        {

            if (_helper.dictionaryOfProduct.ContainsKey(enteredOption))
            {
                var productName = GetProductName(enteredOption);
                var productPrice = _helper.dictionaryOfProduct[enteredOption];
                if (sumOfCoins >= productPrice)
                {

                    sumOfCoins = sumOfCoins - productPrice;
                    PurchaseSuccess(productName.ToString());
                    return sumOfCoins;
                }
                else
                {
                    PurchaseFailure(sumOfCoins,productName.ToString(), productPrice);
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
        private void PurchaseFailure(double sumOfCoins,string productName,double productPrice)                         
        {
            Console.WriteLine("Not Sufficient Balance in your Account ");
            Console.WriteLine("Availabl Amount : " + sumOfCoins + "$");
            Console.WriteLine("Price of {0} is {1}$", productName, productPrice               );
        }

    }
}
