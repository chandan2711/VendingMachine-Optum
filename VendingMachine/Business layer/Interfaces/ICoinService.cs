using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Common.Enum;

namespace VendingMachine.BL.Interfaces
{
    public interface ICoinService
    {
        bool ValidCoinChecking(string enterdOptionForCoins);

        double GetSumOfCoins(List<CoinName> listOfCoinNames);
    }
}
