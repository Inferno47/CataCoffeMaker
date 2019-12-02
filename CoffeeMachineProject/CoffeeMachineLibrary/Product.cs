using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineLibrary
{
    public class Product
    {
        public string m_Name { get; }
        public char m_Code { get; }
        public double m_Price { get; }

        public Product(string i_Name, char i_Code, double i_Price)
        {
            m_Name = i_Name;
            m_Code = i_Code;
            m_Price = i_Price;
        }

        public string GetCommand(Order i_Order)
        {
            if (i_Order.Money < m_Price)
                return "M:it is missing " + (m_Price - i_Order.Money);

            string l_Sugar = i_Order.Sugar != 0 ? i_Order.Sugar + ":0" : ":";

            return m_Code + ":" + l_Sugar;
        }
    }
}
