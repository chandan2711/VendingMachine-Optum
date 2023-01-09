using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Common.Enum;

namespace VendingMachine.BL.Interfaces
{
    public interface IProductService
    {
        double ProductPurchase(List<CoinName> listOfCoins, string enteredOption);
    }
}
