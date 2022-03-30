using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class DummyTests
{
    private const int DummyHealth = 10;
    private const int DummyXp = 10;
    private const int AttackPoints = 5;
    Dummy dummy;
    [SetUp]
    public void TestInIt()
    {
        dummy = new Dummy(DummyHealth, DummyXp);
    }
    [Test]
    public void DummyLosesHealthAfterAttack()
    {
        int expected = DummyHealth - AttackPoints;
        this.dummy.TakeAttack(AttackPoints);
        Assert.That(this.dummy.Health, Is.EqualTo(expected));
    }

    [Test]
    public void DummyIfDeadThrowsException()
    {
        this.dummy.TakeAttack(6);
        this.dummy.TakeAttack(6);

        var ex = Assert.Throws<InvalidOperationException>(() => this.dummy.TakeAttack(6));
        Assert.That(ex.Message, Is.EqualTo("Dummy is dead."));
    }
    [Test]
    public void DeadDummyCanGiveExperience()
    {
        while (!dummy.IsDead())
        {
            this.dummy.TakeAttack(AttackPoints);
        }

        var gotExperience = this.dummy.GiveExperience();
        Assert.AreEqual(DummyXp, gotExperience, "Dead dummy doesn't give experience");
    }

    [Test]
    public void AliveDummyCannotGiveExperience()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => this.dummy.GiveExperience());
        Assert.That(ex.Message, Is.EqualTo("Target is not dead."));
    }
}
