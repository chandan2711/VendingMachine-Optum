using VendingMachine.BL;
using Microsoft.Extensions.DependencyInjection;
using VendingMachine.BL.Interfaces;
using VendingMachine.Common;
using VendingMachine.Common.Enum;

var Exit = true;
var listOfCoins = new List<CoinName>();
var collection = new ServiceCollection();
collection.AddSingleton<ICoinService, CoinService>();
collection.AddSingleton<Helper>();
collection.AddSingleton<IProductService, ProductService>();
var provider = collection.BuildServiceProvider();

try
{
    var coinServiceBL = provider.GetService<ICoinService>();
    var productServiceBL = provider.GetService<IProductService>();
    if (coinServiceBL != null && productServiceBL != null)
    {
        Console.WriteLine("Welcome To Vending Machine");
        do
        {
            Console.WriteLine("Enter Your Option : ");
            Console.WriteLine("Press '1' For Insert Coins...Press '2' For Product Selection...Press '3' For Exit...");
            var enteredResponse = Console.ReadLine();

            switch (enteredResponse)
            {
                case "1":
                    Console.WriteLine("Press 1 For Quarters(0.25).....Press 2 for Dimes(0.1).....Press 3 for Nickels(0.05)");
                    var optionChoosedForCoins = Console.ReadLine();
                    var coinName = (CoinName)Convert.ToInt32(optionChoosedForCoins);
                    var isCoinValid = coinServiceBL.ValidCoinChecking(coinName.ToString());
                    if (isCoinValid)
                    {
                        listOfCoins.Add(coinName);
                    }
                    var totalAmount = coinServiceBL.GetSumOfCoins(listOfCoins);
                    Console.WriteLine("Total Amount : {0}", totalAmount);
                    break;
                case "2":
                    Console.WriteLine("Available Products : ");
                    Console.WriteLine("'Cola - 1.00' 'Chips - 0.50' 'Candy : 0.65'");
                    Console.WriteLine("For Cola Press '1'...For Chips press '2'...For Candy Press'3'");
                    var OptionChoosedForProduct = Console.ReadLine();
                    var productName = (ProductName)Convert.ToInt32(OptionChoosedForProduct);
                    var returnAmount = productServiceBL.ProductPurchase(listOfCoins, productName.ToString());
                    Console.WriteLine("COLLECT YOUR AMOUNT : {0}", Convert.ToDecimal(returnAmount));
                    listOfCoins.Clear();
                    break;
                case "3":
                    Console.WriteLine("Thank You for using Vending Machine");
                    Exit = false;
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }

        } while (Exit);
    }
}
catch (Exception ex)
{
    Console.WriteLine("Facing Some Problem due to Invalid Input" + ex.ToString());
}