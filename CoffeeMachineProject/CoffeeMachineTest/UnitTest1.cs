using NUnit.Framework;
using CoffeeMachineLibrary;

public class Tests
{
    CoffeeMaker m_Coffeemaker;

    [SetUp]
    public void Setup()
    {
        m_Coffeemaker = new CoffeeMaker();
    }

    [Test]
    public void TestEmpty()
    {
        Assert.AreEqual("M:You should send product", m_Coffeemaker.Maker(null));
    }

    [Test]
    public void TestSimpleTea()
    {
        Order l_Order = new Order { Product = "tea" };
        Assert.AreEqual("T::", m_Coffeemaker.Maker(l_Order));
    }

    [Test]
    public void TestSimpleCoffee()
    {
        Order l_Order = new Order { Product = "coffee" };
        Assert.AreEqual("C::", m_Coffeemaker.Maker(l_Order));
    }

    [Test]
    public void TestSimpleChocolate()
    {
        Order l_Order = new Order { Product = "chocolate" };
        Assert.AreEqual("H::", m_Coffeemaker.Maker(l_Order));
    }

    [Test]
    public void TestSimpleCappuchino()
    {
        Order l_Order = new Order { Product = "Capuchino" };
        Assert.AreEqual("M:this product does not exist", m_Coffeemaker.Maker(l_Order));
    }

    [Test]
    public void TestTeaWithSugar()
    {
        Order l_Order = new Order { Product = "tea", Sugar = 1 };
        Assert.AreEqual("T:1:0", m_Coffeemaker.Maker(l_Order));
    }

    [Test]
    public void TestCoffeeWithSugar()
    {
        Order l_Order = new Order { Product = "coffee", Sugar = 4 };
        Assert.AreEqual("C:4:0", m_Coffeemaker.Maker(l_Order));
    }

    [Test]
    public void TestChocolateWithSugar()
    {
        Order l_Order = new Order { Product = "chocolate", Sugar = 2 };
        Assert.AreEqual("H:2:0", m_Coffeemaker.Maker(l_Order));
    }
}