using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item item;
        private BankVault bankVault;

        [SetUp]
        public void Setup()
        {
            this.item = new Item("Owner", "1");
        }

        [Test]
        public void ConstructorSHouldWorkProperly()
        {
            this.bankVault = new BankVault();

            Assert.That(this.bankVault.VaultCells.Count, Is.EqualTo(12));
        }
        [Test]
        public void AddItemShouldThrowExceptionWhenCellDoesNotExist()
        {
            this.bankVault = new BankVault();

            Assert.Throws<ArgumentException>(() =>
            {
                this.bankVault.AddItem("F2", this.item);
            });
        }
        [Test]
        public void AddItemShouldThrowExceptionWhenCellNameIsTaken()
        {
            this.bankVault = new BankVault();
            this.bankVault.AddItem("C1", this.item);

            Assert.Throws<ArgumentException>(() =>
            {
                this.bankVault.AddItem("C1", new Item("Some", "2"));
            });
        }
        [Test]
        public void AddItemShouldTWorkProperly()
        {   
            this.bankVault = new BankVault();
            this.bankVault.AddItem("A1", this.item);

            var cell = this.bankVault.VaultCells.FirstOrDefault(c => c.Key == "A1");

            Assert.That(cell.Value.ItemId, Is.EqualTo(this.item.ItemId));
            Assert.That(cell.Key, Is.EqualTo("A1"));
            Assert.That(cell.Value.Owner, Is.EqualTo(this.item.Owner));
        }

        [Test]
        public void AddShouldThrowExceptionWhenExistingItemId()
        {
            this.bankVault = new BankVault();
            this.bankVault.AddItem("A1", this.item);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.bankVault.AddItem("A2", new Item("Some", "1"));
            });
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenNonExistingCell()
        {
            this.bankVault = new BankVault();
            this.bankVault.AddItem("A1", this.item);
            Assert.Throws<ArgumentException>(() =>
            {
                var result = this.bankVault.RemoveItem("F2", this.item);
            });
        }
        [Test]
        public void RemoveShouldThrowExceptionWhenITemIsNotInTheCell()
        {
            this.bankVault = new BankVault();
            this.bankVault.AddItem("A1", this.item);
            this.bankVault.AddItem("A2", new Item("Some", "2"));

            Assert.Throws<ArgumentException>(() =>
            {
                var result = this.bankVault.RemoveItem("A2", this.item);
            });
        }
        [Test]
        public void RemoveShouldWorkCorrectly()
        {
            this.bankVault = new BankVault();
            this.bankVault.AddItem("A1", this.item);
            this.bankVault.AddItem("A2", new Item("Some", "2"));

            var result = this.bankVault.RemoveItem("A1", this.item);


            Assert.IsNull(this.bankVault.VaultCells["A1"]);

        }
    }
}