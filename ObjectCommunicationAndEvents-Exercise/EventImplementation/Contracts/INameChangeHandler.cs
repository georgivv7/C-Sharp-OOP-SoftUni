﻿namespace EventImplementation.Contracts
{
    public interface INameChangeHandler
    {
        void OnDispatcherNameChange(object sender, NameChangeEventArgs args);
    }
}
