using System;
using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private const int AxeAttack = 1;
    private const int AxeDurability = 1;
    private const int DummyHealth = 10;
    private const int DummyXp = 10;

    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void TestInIt()
    {
        axe = new Axe(AxeAttack, AxeDurability);
        dummy = new Dummy(DummyHealth, DummyXp);
    }
    [Test]
    public void AxeLosesDurabilyAfterAttack()
    {
        axe.Attack(dummy);       
        Assert.AreEqual(0,this.axe.DurabilityPoints, "Durability doesn't change after attack");
    }

    [Test]
    public void BrokenAxeCantAttack()
    {
        // Act
        axe.Attack(dummy);

        // Assert
        var ex = Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        Assert.That(ex.Message, Is.EqualTo("Axe is broken."));  
    }
}