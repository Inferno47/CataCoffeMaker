using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineLibrary
{
    public class CoffeeMaker
    {
        private Dictionary<string, int> m_Sale = new Dictionary<string, int>() { { "tea", 0 }, { "coffee", 0 }, { "orange juice", 0 }, { "chocolate", 0 } };
        private double m_Profit = 0;

        private Dictionary<string, KeyValuePair<string, double>> m_Product = new Dictionary<string, KeyValuePair<string, double>>() {
            { "tea", new KeyValuePair<string, double>("T", 0.4) },
            { "coffee", new KeyValuePair<string, double>("C", 0.6) },
            { "orange juice", new KeyValuePair<string, double>("O", 0.6) },
            { "chocolate", new KeyValuePair<string, double>("H", 0.5) } };

        public string Maker(Order i_Order)
        {
            if (i_Order == null || i_Order.Product == null)
                return "M:You should send product";

            string l_Sugar = (i_Order.Sugar != 0 && i_Order.Product != "orange juice") ? i_Order.Sugar + ":0" : ":";

            if (!m_Product.ContainsKey(i_Order.Product))
                return "M:this product does not exist";

            KeyValuePair<string, double> l_Item = m_Product.FirstOrDefault(p => p.Key == i_Order.Product).Value;

            if (i_Order.Money < l_Item.Value)
                return "M:it is missing " + (l_Item.Value - i_Order.Money);

            m_Sale[i_Order.Product]++;
            m_Profit += l_Item.Value;

            return l_Item.Key + (i_Order.Hot && i_Order.Product != "orange juice" ? "h" : "") + ":" + l_Sugar;
        }

        public string Report()
        {
            string l_Report = "Sales:\n";

            foreach (KeyValuePair<string, int> l_Product in m_Sale)
                l_Report += l_Product.Key + ": " + l_Product.Value + "\n";

            l_Report += "\nProfit: " + m_Profit;

            return l_Report;
        }
    }
}
