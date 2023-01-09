using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.BL.Interfaces;
using VendingMachine.Common;

namespace VendingMachine.BL
{
    public class Helper
    {

        public readonly Dictionary<string, double> dictionaryOfCoins = new Dictionary<string, double>();

        public readonly Dictionary<string, double> dictionaryOfProduct = new Dictionary<string, double>();

        public Helper()
        {
            // Adding Coins to DictionaryofCoins
            dictionaryOfCoins.Add("1", 0.05);
            dictionaryOfCoins.Add("2", 0.10);
            dictionaryOfCoins.Add("3", 0.25);


            // Adding Product to DictionaryofCoins
            dictionaryOfProduct.Add("1", ProductPriceChart.Cola);
            dictionaryOfProduct.Add("2", ProductPriceChart.Chips);
            dictionaryOfProduct.Add("3", ProductPriceChart.Candy);
        }

    }
}
