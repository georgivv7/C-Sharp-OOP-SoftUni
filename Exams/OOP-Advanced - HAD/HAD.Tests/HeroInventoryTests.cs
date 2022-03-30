namespace HAD.Tests
{
    using HAD.Contracts;
    using HAD.Entities.Items;
    using HAD.Entities.Miscellaneous;
    using NUnit.Framework;
    using System.Collections.Generic;

    public class HeroInventoryTests
    {
        [SetUp]
        public void Setup()
        {
            HeroInventory heroInventory = new HeroInventory();
            IDictionary<string, IItem> commonItems = new Dictionary<string, IItem>();
            IDictionary<string, IRecipe> recipeItems = new Dictionary<string, IRecipe>();
        }

        [Test]
        public void AddCommonItems()
        {
            HeroInventory heroInventory = new HeroInventory();
            IDictionary<string, IItem> commonItems = new Dictionary<string, IItem>();

            IItem item = new CommonItem("Knife", 20, 10, 20, 15, 30);
            heroInventory.AddCommonItem(item);

            Assert.AreEqual(heroInventory.TotalStrengthBonus, 20);
            Assert.AreEqual(heroInventory.TotalAgilityBonus, 10);
            Assert.AreEqual(heroInventory.TotalIntelligenceBonus, 20);
            Assert.AreEqual(heroInventory.TotalHitPointsBonus, 15);
            Assert.AreEqual(heroInventory.TotalDamageBonus, 30);
        }
        [Test]
        public void AddRecipeItems()
        {
            HeroInventory heroInventory = new HeroInventory();
            IDictionary<string, IRecipe> recipeItems = new Dictionary<string, IRecipe>();
            IList<string> requireditems = new List<string>() { "Knife", "Stick" };

            IItem item = new RecipeItem("Spear", 25, 10, 10, 100, 50, requireditems);
            heroInventory.AddCommonItem(item);

            Assert.AreEqual(heroInventory.TotalStrengthBonus, 25);
            Assert.AreEqual(heroInventory.TotalAgilityBonus, 10);
            Assert.AreEqual(heroInventory.TotalIntelligenceBonus, 10);
            Assert.AreEqual(heroInventory.TotalHitPointsBonus, 100);
            Assert.AreEqual(heroInventory.TotalDamageBonus, 50);
        }

    }
}
