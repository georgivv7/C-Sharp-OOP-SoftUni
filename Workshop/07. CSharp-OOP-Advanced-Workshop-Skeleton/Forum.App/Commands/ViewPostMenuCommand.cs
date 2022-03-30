namespace Forum.App.Commands
{
    using Contracts;
    public class ViewPostMenuCommand : ICommand
    {
        private IMenuFactory menuFactory;
        public ViewPostMenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }
        public IMenu Execute(params string[] args)
        {
            int categoryId = int.Parse(args[0]);

            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - "Command".Length);

            IMenu menu = this.menuFactory.CreateMenu(menuName);
            if (menu is IIdHoldingMenu idHoldingMenu)
            {
                int postId = int.Parse(args[0]);
                idHoldingMenu.SetId(postId);
            }
           
            return menu;
        }
    }
}
