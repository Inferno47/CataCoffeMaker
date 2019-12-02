using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineLibrary
{
    public class CoffeeMaker
    {
        List<Product> m_Products = new List<Product>();

        public CoffeeMaker()
        {
            m_Products.Add(new Product("tea", 'T', 0.4));
            m_Products.Add(new Product("coffee", 'C', 0.6));
            m_Products.Add(new Product("chocolate", 'H', 0.5));
        }

        public CoffeeMaker(List<Product> i_Product)
        {
            m_Products = i_Product;
        }

        public string Maker(Order i_Order)
        {
            if (i_Order == null || i_Order.Product == null)
                return "M:You should send product";

            Product l_Product = m_Products.FirstOrDefault(p => p.m_Name == i_Order.Product);

            if (l_Product == null)
                return "M:this product does not exist";

            return l_Product.GetCommand(i_Order);
        }
    }
}
