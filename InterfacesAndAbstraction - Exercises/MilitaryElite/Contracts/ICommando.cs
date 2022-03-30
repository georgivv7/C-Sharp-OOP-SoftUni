using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
    public interface ICommando : ISpecializedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }
        void AddMission(IMission mission);
        void CompleteMission(string missionCodeName);
    }
}
