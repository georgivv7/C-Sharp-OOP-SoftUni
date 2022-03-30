namespace Forum.App.Commands
{
    using Contracts;
    using System;

    public class LogInCommand : ICommand
    {
        private IMenuFactory menuFactory;
        private IUserService userService;

        public LogInCommand(IMenuFactory menuFactory, IUserService userService) 
        {
            this.menuFactory = menuFactory;
            this.userService = userService;
        }
        public IMenu Execute(params string[] args)
        {
            string username = args[0];
            string password = args[1];

            bool success = this.userService.TrySignUpUser(username, password);

            if (success == false)
            {
                throw new InvalidOperationException("Invalid login!");
            }

            return this.menuFactory.CreateMenu("MainMenu");
        }
    }
}

