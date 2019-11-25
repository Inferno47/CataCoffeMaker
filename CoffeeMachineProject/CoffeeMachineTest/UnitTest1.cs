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

    #region Iteration 1

    [Test]
    public void TestEmpty()
    {
        Assert.AreEqual("M:You should send product", m_Coffeemaker.Maker(null));
    }

    [Test]
    public void TestSimpleTea()
    {
        Order l_Order = new Order { Product = "tea", Money = 0.4 };
        Assert.AreEqual("T::", m_Coffeemaker.Maker(l_Order));
    }

    [Test]
    public void TestSimpleCoffee()
    {
        Order l_Order = new Order { Product = "coffee", Money = 0.6 };
        Assert.AreEqual("C::", m_Coffeemaker.Maker(l_Order));
    }

    [Test]
    public void TestSimpleChocolate()
    {
        Order l_Order = new Order { Product = "chocolate", Money = 0.5 };
        Assert.AreEqual("H::", m_Coffeemaker.Maker(l_Order));
    }

    [Test]
    public void TestSimpleCappuchino()
    {
        Order l_Order = new Order { Product = "Capuchino", Money = 0.4 };
        Assert.AreEqual("M:this product does not exist", m_Coffeemaker.Maker(l_Order));
    }

    [Test]
    public void TestTeaWithSugar()
    {
        Order l_Order = new Order { Product = "tea", Sugar = 1, Money = 0.4 };
        Assert.AreEqual("T:1:0", m_Coffeemaker.Maker(l_Order));
    }

    [Test]
    public void TestCoffeeWithSugar()
    {
        Order l_Order = new Order { Product = "coffee", Sugar = 4, Money = 0.6 };
        Assert.AreEqual("C:4:0", m_Coffeemaker.Maker(l_Order));
    }

    [Test]
    public void TestChocolateWithSugar()
    {
        Order l_Order = new Order { Product = "chocolate", Sugar = 2, Money = 0.5 };
        Assert.AreEqual("H:2:0", m_Coffeemaker.Maker(l_Order));
    }

    #endregion

    #region Iteration 2

    [Test]
    public void TestChocolateNoEnougthMoney()
    {
        Order l_Order = new Order { Product = "chocolate", Sugar = 2, Money = 0.0 };
        Assert.AreEqual("M:it is missing 0,5", m_Coffeemaker.Maker(l_Order));
    }

    [Test]
    public void TestTeaNoEnougthMoney()
    {
        Order l_Order = new Order { Product = "tea", Sugar = 2, Money = 0.0 };
        Assert.AreEqual("M:it is missing 0,4", m_Coffeemaker.Maker(l_Order));
    }

    [Test]
    public void TestCoffeeNoEnougthMoney()
    {
        Order l_Order = new Order { Product = "coffee", Sugar = 2, Money = 0.0 };
        Assert.AreEqual("M:it is missing 0,6", m_Coffeemaker.Maker(l_Order));
    }

    [Test]
    public void TestChocolateMoreMoney()
    {
        Order l_Order = new Order { Product = "chocolate", Sugar = 2, Money = 1.0 };
        Assert.AreEqual("H:2:0", m_Coffeemaker.Maker(l_Order));
    }

    [Test]
    public void TestTeaMoreMoney()
    {
        Order l_Order = new Order { Product = "tea", Sugar = 2, Money = 10.0 };
        Assert.AreEqual("T:2:0", m_Coffeemaker.Maker(l_Order));
    }

    [Test]
    public void TestCoffeeMoreMoney()
    {
        Order l_Order = new Order { Product = "coffee", Sugar = 2, Money = 20.0 };
        Assert.AreEqual("C:2:0", m_Coffeemaker.Maker(l_Order));
    }

    #endregion

    #region Iteration 3

    [Test]
    public void TestSimpleOrangeJuice()
    {
        Order l_Order = new Order { Product = "orange juice", Money = 0.6 };
        Assert.AreEqual("O::", m_Coffeemaker.Maker(l_Order));
    }

    [Test]
    public void TestSimpleOrangeJuiceHot()
    {
        Order l_Order = new Order { Product = "orange juice", Hot = true, Money = 0.6 };
        Assert.AreEqual("O::", m_Coffeemaker.Maker(l_Order));
    }

    [Test]
    public void TestSimpleCoffeeHot()
    {
        Order l_Order = new Order { Product = "coffee", Hot = true, Money = 0.6 };
        Assert.AreEqual("Ch::", m_Coffeemaker.Maker(l_Order));
    }

    [Test]
    public void TestChocolateHot()
    {
        Order l_Order = new Order { Product = "chocolate", Hot = true, Money = 0.5 };
        Assert.AreEqual("Hh::", m_Coffeemaker.Maker(l_Order));
    }

    [Test]
    public void TestTeaHot()
    {
        Order l_Order = new Order { Product = "tea", Hot = true, Money = 0.5 };
        Assert.AreEqual("Th::", m_Coffeemaker.Maker(l_Order));
    }

    #endregion

    #region Iteration 4

    [Test]
    public void TestReportSimple()
    {
        Assert.AreEqual("Sales:\ntea: 0\ncoffee: 0\norange juice: 0\nchocolate: 0\n\nProfit: 0", m_Coffeemaker.Report());
    }

    [Test]
    public void TestReport()
    {
        Order l_Order = new Order { Product = "chocolate", Sugar = 2, Money = 0.5 };
        m_Coffeemaker.Maker(l_Order);
        m_Coffeemaker.Maker(l_Order);
        l_Order = new Order { Product = "coffee", Hot = true, Money = 0.6 };
        m_Coffeemaker.Maker(l_Order);
        l_Order = new Order { Product = "orange juice", Money = 0.6 };
        m_Coffeemaker.Maker(l_Order);
        Assert.AreEqual("Sales:\ntea: 0\ncoffee: 1\norange juice: 1\nchocolate: 2\n\nProfit: 2,2", m_Coffeemaker.Report());
    }

    #endregion
}