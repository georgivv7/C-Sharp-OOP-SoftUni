using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace UnitTests
{
    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        [TestCase((new int[] { 1, 2, 3, 4 }))]
        [TestCase((new int[] { 4, 3, 2, 1 }))]
        [TestCase((new int[] { -14 }))]
        [TestCase((new int[] { }))]
        public void TestValidConstructor(int[] values)
        {
            DataBase db = new DataBase(values);

            FieldInfo fieldInfo = typeof(DataBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(fi => fi.FieldType == typeof(int[]));
            IEnumerable<int> fieldValues = ((int[])fieldInfo.GetValue(db)).Take(values.Length);

            Assert.That(fieldValues, Is.EquivalentTo(values));
        }

        [Test]
        public void TestInvalidConstructor()
        {
            int[] values = new int[17];

            Assert.That(() => new DataBase(values), Throws.InvalidOperationException);
        }
        [Test]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        [TestCase(-20)]
        [TestCase(0)]
        [TestCase(500)]
        public void AddMethodValid(int value)
        {
            DataBase db = new DataBase();

            db.Add(value);
        }
        [Test]
        public void AddMethodInvalid()
        {
            int[] values = new int[16];
            DataBase db = new DataBase(values);

            Assert.That(() => db.Add(1), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase((new int[] { 1, 2, 3, 4 }))]
        [TestCase((new int[] { 4, 3, 2, 1 }))]
        [TestCase((new int[] { -14 }))]
        public void RemoveMethodValid(int[] values)
        {
            DataBase db = new DataBase(values);

            FieldInfo fieldInfo = typeof(DataBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(fi => fi.FieldType == typeof(int[]));
            fieldInfo.SetValue(db, values);

            db.Remove();
        }
        [Test]
        public void RemoveMethodInvalid()
        {
            DataBase dataBase = new DataBase();

            FieldInfo currentIndexInfo = typeof(DataBase)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(fi => fi.FieldType == typeof(int));

            currentIndexInfo.SetValue(dataBase, 0);

            Assert.That(() => dataBase.Remove(), Throws.InvalidOperationException);
        }
    }
}
