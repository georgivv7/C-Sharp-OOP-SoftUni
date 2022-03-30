using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite
{
    public class Commando : SpecializedSoldier, ICommando
    {
        private ICollection<IMission> missions;

        public Commando(int id, string firstName, string lastName, double salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => (IReadOnlyCollection<IMission>)missions;

        public void AddMission(IMission mission)
        {
            missions.Add(mission);
        }

        public void CompleteMission(string missionCodeName)
        {
            IMission mission = Missions.FirstOrDefault(m => m.CodeName == missionCodeName);
            if (mission == null)
            {
                throw new ArgumentException("Mission not found!");
            }
            mission.Complete();
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.ToString())
                   .AppendLine($"{nameof(Corps)}: {Corps.ToString()}")
                   .AppendLine($"{nameof(Missions)}:");

            foreach (var mission in Missions)
            {
                builder.AppendLine($"  {mission.ToString()}");
            }
            string result = builder.ToString().TrimEnd();
            return result;
        }
    }
}
