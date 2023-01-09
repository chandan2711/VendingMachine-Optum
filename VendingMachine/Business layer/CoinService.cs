using VendingMachine.BL.Interfaces;
using VendingMachine.Common.Enum;

namespace VendingMachine.BL
{
    public class CoinService : ICoinService
    {
        private readonly Helper _helper;
        public CoinService(Helper helperBL)
        {
            _helper = helperBL;
        }


        public bool ValidCoinChecking(string coinName)
        {
            if (_helper.dictionaryOfCoins.ContainsKey(coinName))
            {
                return true; ;

            }
            else
            {
                // Any Other Option Except(1,2,3) will consider as Pennies(0.01)
                Console.WriteLine("Invalid Coin");
                return false;
            }
        }

        public double GetSumOfCoins(List<CoinName> listOfCoinNames)
        {
            var sumOfCoins = 0.0;
            foreach (var coinName in listOfCoinNames)
            {
                sumOfCoins = sumOfCoins + _helper.dictionaryOfCoins[coinName.ToString()];
            }
            return sumOfCoins;
        }

    }
}
