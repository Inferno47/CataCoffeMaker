using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineLibrary
{
    public interface EmailNotifier
    {
        void notifyMissingDrink(String drink);
    }
}
