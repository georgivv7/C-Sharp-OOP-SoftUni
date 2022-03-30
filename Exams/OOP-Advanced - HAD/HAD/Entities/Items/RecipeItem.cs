namespace HAD.Entities.Items
{
    using HAD.Contracts;
    using System.Collections.Generic;
    using System.Text;

    public class RecipeItem : BaseItem, IRecipe
    {
        private IList<string> requiredItems;
        public RecipeItem(string name, 
            long strengthBonus, long agilityBonus, long intelligenceBonus,long hitPointsBonus, 
            long damageBonus,
            IList<string> requiredItems) 
            : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
        {
            this.requiredItems = requiredItems;
        }

        public IReadOnlyList<string> RequiredItems => (IReadOnlyList<string>)this.requiredItems;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"###Item: {this.Name}");
            sb.AppendLine(base.ToString());

            return sb.ToString();
        }
    }
}
