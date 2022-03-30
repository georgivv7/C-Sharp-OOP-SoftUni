using MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Mission : IMission
    {
        public Mission(string codeName, string missionState)
        {
            CodeName = codeName;
            ParseMissionState(missionState);
        }

        private void ParseMissionState(string missionState)
        {
            bool validState = Enum.TryParse(typeof(MissionState), missionState, out object outState);
            if (validState == false)
            {
                throw new ArgumentException("Invalid state!");
            }
            State = (MissionState)outState;
        }

        public MissionState State { get; private set; }
        public string CodeName { get; private set; }

        public void Complete()
        {
            if (State == MissionState.Finished)
            {
                throw new InvalidOperationException("Mission already finished!");
            }
            State = MissionState.Finished;
        }

        public override string ToString()
        {
            return string.Format($"Code Name: {CodeName} State: {State.ToString()}");
        }
    }
}
