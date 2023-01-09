using VendingMachine.BL;
using Microsoft.Extensions.DependencyInjection;
using VendingMachine.BL.Interfaces;


var sumOfCoins = 0.0;
var Exit = true;
var collection = new ServiceCollection();
collection.AddSingleton<IProductService, ProductService>();
collection.AddSingleton<ICoinService, CoinService>();
collection.AddSingleton<Helper>();
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
                    Console.WriteLine("Press 1 For Nickels(0.05).....Press 2 for Dimes(0.1).....Press 3 for Quarters(0.25)");
                    var optionChoosedForCoins = Console.ReadLine();
                    var coinValue = coinServiceBL.GetCoinValue(optionChoosedForCoins ?? "1");
                    
                    sumOfCoins = sumOfCoins + coinValue;
                    Console.WriteLine("Total Amount : {0}", sumOfCoins);
                    break;
                case "2":
                    Console.WriteLine("Available Products : ");
                    Console.WriteLine("'Cola - 1.00' 'Chips - 0.50' 'Candy : 0.65'");
                    Console.WriteLine("For Cola Press '1'...For Chips press '2'...For Candy Press'3'");
                    var OptionChoosedForProduct = Console.ReadLine();
                    sumOfCoins = productServiceBL.ProductPurchase(sumOfCoins, OptionChoosedForProduct ?? "1");
                    break;
                case "3":
                    Console.WriteLine("Collect Your Amount : {0}", Convert.ToDecimal(sumOfCoins));
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