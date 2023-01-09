using VendingMachine.BL.Interfaces;

namespace VendingMachine.BL
{
    public class CoinService : ICoinService
    {
        private readonly Helper _helper;
        public CoinService(Helper helperBL)
        {
            _helper = helperBL;
        }


        public double GetCoinValue(string enterdOptionForCoins)
        {
            if (_helper.dictionaryOfCoins.ContainsKey(enterdOptionForCoins))
            {
                return _helper.dictionaryOfCoins[enterdOptionForCoins];

            }
            else
            {
                // Any Other Option Except(1,2,3) will consider as Pennies(0.01)
                Console.WriteLine("Invalid Coin");
                return 0.0;
            }
        }

    }
}
