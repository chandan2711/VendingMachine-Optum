using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.BL.Interfaces
{
    public interface IProductService
    {
        double ProductPurchase(double sumOfCoins,string enteredOption);
    }
}
