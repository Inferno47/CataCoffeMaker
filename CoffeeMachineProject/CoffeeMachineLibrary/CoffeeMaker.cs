using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineLibrary
{
    public class CoffeeMaker
    {
        Dictionary<string, KeyValuePair<string, double>> m_Product = new Dictionary<string, KeyValuePair<string, double>>() {
            { "tea", new KeyValuePair<string, double>("T", 0.4) },
            { "coffee", new KeyValuePair<string, double>("C", 0.6) },
            { "chocolate", new KeyValuePair<string, double>("H", 0.5) } };

        public string Maker(Order i_Order)
        {
            if (i_Order == null || i_Order.Product == null)
                return "M:You should send product";

            string l_Sugar = i_Order.Sugar != 0 ? i_Order.Sugar + ":0" : ":";

            if (!m_Product.ContainsKey(i_Order.Product))
                return "M:this product does not exist";

            KeyValuePair<string, double> l_Item = m_Product.FirstOrDefault(p => p.Key == i_Order.Product).Value;

            if (i_Order.Money < l_Item.Value)
                return "M:it is missing " + (l_Item.Value - i_Order.Money);

            return l_Item.Key + ":" + l_Sugar;
        }
    }
}
