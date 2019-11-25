using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineLibrary
{
    public class CoffeeMaker
    {
        Dictionary<string, string> m_Product = new Dictionary<string, string>() { { "tea", "T" }, { "coffee", "C" }, { "chocolate", "H" } };

        public string Maker(Order i_Order)
        {
            if (i_Order == null || i_Order.Product == null)
                return "M:You should send product";

            string l_Sugar = i_Order.Sugar != 0 ? i_Order.Sugar + ":0" : ":";

            if (!m_Product.ContainsKey(i_Order.Product))
                return "M:this product does not exist";

            return m_Product.FirstOrDefault(p => p.Key == i_Order.Product).Value + ":" + l_Sugar;
        }
    }
}
