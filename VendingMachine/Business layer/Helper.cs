using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.BL.Interfaces;
using VendingMachine.Common;
using VendingMachine.Common.Constant;
using VendingMachine.Common.Enum;

namespace VendingMachine.BL
{
    public class Helper
    {

        public readonly Dictionary<string, double> dictionaryOfCoins = new Dictionary<string, double>();

        public readonly Dictionary<string, double> dictionaryOfProduct = new Dictionary<string, double>();

        public Helper()
        {
            // Adding Coins to DictionaryofCoins
            dictionaryOfCoins.Add(CoinName.Quarters.ToString(), CoinValue.Quarters);
            dictionaryOfCoins.Add(CoinName.Dimes.ToString(), CoinValue.Dimes);
            dictionaryOfCoins.Add(CoinName.Nickels.ToString(), CoinValue.Nickels);


            // Adding Product to DictionaryofCoins
            dictionaryOfProduct.Add(ProductName.Cola.ToString(), ProductPriceChart.Cola);
            dictionaryOfProduct.Add(ProductName.Chips.ToString(), ProductPriceChart.Chips);
            dictionaryOfProduct.Add(ProductName.Candy.ToString(), ProductPriceChart.Candy);
        }

    }
}
