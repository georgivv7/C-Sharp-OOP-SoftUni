namespace KingsGambit.Contracts
{
    using System;
    using System.Collections.Generic;
    public interface IKing : IAttackable
    {
        IReadOnlyCollection<ISubordinate> Subordinates { get; }
        void AddSubordinate(ISubordinate subordinate);

        void OnSubordinateDeath(object sender);
    }
}
